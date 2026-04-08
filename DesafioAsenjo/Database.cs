using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GeradorClasses
{
    public static class Database
    {
        private static string connectionString = string.Empty;

        static Database()
        {
            ConfigurarConexao();
        }

        private static void ConfigurarConexao()
        {
            try
            {
                string caminhoBanco = Path.Combine(Application.StartupPath, "GeradorClasses.accdb");

                if (!File.Exists(caminhoBanco))
                {
                    MessageBox.Show($"ERRO CRÍTICO!\n\nArquivo GeradorClasses.accdb não encontrado!\n\nColoque o arquivo na pasta:\n{Application.StartupPath}",
                                  "Banco de Dados Ausente",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

                connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={caminhoBanco};";

                using (OleDbConnection testConn = new OleDbConnection(connectionString))
                {
                    testConn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERRO CRÍTICO DE CONEXÃO!\n\n{ex.Message}\n\nA aplicação será encerrada.",
                              "Erro de Conexão",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public static void InicializarBanco()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    DataTable schema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                        new object[] { null, null, "ClassesGeradas", null });

                    if (schema != null && schema.Rows.Count > 0)
                    {
                        // MODIFICADO: Verificar se a coluna Visibilidade existe
                        DataTable columnsSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns,
                            new object[] { null, null, "ClassesGeradas", null });

                        bool colunaVisibilidadeExiste = false;
                        foreach (DataRow row in columnsSchema.Rows)
                        {
                            if (row["COLUMN_NAME"].ToString() == "Visibilidade")
                            {
                                colunaVisibilidadeExiste = true;
                                break;
                            }
                        }

                        // Se não existir, adicionar a coluna
                        if (!colunaVisibilidadeExiste)
                        {
                            string alterTableSql = "ALTER TABLE ClassesGeradas ADD COLUMN Visibilidade YESNO";
                            using (OleDbCommand cmd = new OleDbCommand(alterTableSql, conn))
                            {
                                cmd.ExecuteNonQuery();
                                System.Diagnostics.Debug.WriteLine("Coluna Visibilidade adicionada com sucesso");
                            }
                        }

                        System.Diagnostics.Debug.WriteLine("Tabela já existe");
                        return;
                    }

                    // MODIFICADO: Criar tabela com a coluna Visibilidade
                    string createTableSql = @"
            CREATE TABLE ClassesGeradas (
                ID COUNTER CONSTRAINT PrimaryKey PRIMARY KEY,
                NomeClasse TEXT(100) NOT NULL,
                Codigo LONGTEXT NOT NULL,
                Data DATETIME NOT NULL,
                Propriedades LONGTEXT,
                Visibilidade YESNO
            )";

                    using (OleDbCommand cmd = new OleDbCommand(createTableSql, conn))
                    {
                        cmd.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine("Tabela criada com sucesso");
                    }
                }
            }
            catch (Exception ex)
            {
                string logPath = Path.Combine(Application.StartupPath, "erro_log.txt");
                File.AppendAllText(logPath, $"Erro ao inicializar banco: {ex.Message}\r\n");
            }
        }

        // MODIFICADO: Adicionado parâmetro visibilidade
        public static void SalvarClasse(string nomeClasse, string codigo, List<PropriedadeInfo> propriedades, bool isPublic = true)
        {
            try
            {
                string logPath = Path.Combine(Application.StartupPath, "debug_log.txt");
                File.AppendAllText(logPath, $"Tentando salvar classe: {nomeClasse} (Visibilidade: {(isPublic ? "Pública" : "Privada")})\r\n");

                if (string.IsNullOrEmpty(connectionString))
                {
                    MessageBox.Show("Conexão com banco de dados não configurada!", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // MODIFICADO: Incluir Visibilidade no INSERT
                    string sql = @"INSERT INTO ClassesGeradas 
                          (NomeClasse, Codigo, Data, Propriedades, Visibilidade) 
                          VALUES (?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = nomeClasse ?? string.Empty;
                        cmd.Parameters.Add("?", OleDbType.LongVarWChar).Value = codigo ?? string.Empty;
                        cmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;

                        string propsString = propriedades != null
                            ? string.Join(";", propriedades.Select(p => $"{p.Tipo}:{p.Nome}"))
                            : string.Empty;
                        cmd.Parameters.Add("?", OleDbType.LongVarWChar).Value = propsString;

                        // NOVO: Parâmetro para Visibilidade (YESNO no Access = boolean)
                        cmd.Parameters.Add("?", OleDbType.Boolean).Value = isPublic;

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            File.AppendAllText(logPath, "Classe salva com sucesso\r\n");
                            MessageBox.Show("Classe salva com sucesso no banco de dados!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar classe: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                string logPath = Path.Combine(Application.StartupPath, "erro_log.txt");
                File.AppendAllText(logPath, $"Erro ao salvar: {ex.Message}\r\n{ex.StackTrace}\r\n");
            }
        }

        // MODIFICADO: Incluir Visibilidade na listagem
        public static DataTable ListarClasses()
        {
            DataTable dt = new DataTable();

            try
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    return dt;
                }

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    // MODIFICADO: Incluir Visibilidade no SELECT
                    string sql = "SELECT ID, NomeClasse, Data, Visibilidade FROM ClassesGeradas ORDER BY Data DESC";

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar classes: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        // MODIFICADO: Carregar classe incluindo visibilidade
        public static string CarregarClasse(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    MessageBox.Show("Conexão com banco de dados não configurada!", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT Codigo FROM ClassesGeradas WHERE ID = ?";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = id;
                        object resultado = cmd.ExecuteScalar();
                        return resultado?.ToString() ?? string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar classe: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        // MODIFICADO: Carregar classe completa com visibilidade
        public static (string codigo, List<PropriedadeInfo> propriedades, bool isPublic) CarregarClasseCompleta(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    return (string.Empty, new List<PropriedadeInfo>(), true);
                }

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    // MODIFICADO: Incluir Visibilidade no SELECT
                    string sql = "SELECT Codigo, Propriedades, Visibilidade FROM ClassesGeradas WHERE ID = ?";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = id;
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string codigo = reader["Codigo"]?.ToString() ?? string.Empty;
                                string propsString = reader["Propriedades"]?.ToString() ?? string.Empty;

                                // NOVO: Ler visibilidade (tratar como bool)
                                bool isPublic = true; // valor padrão
                                if (reader["Visibilidade"] != DBNull.Value)
                                {
                                    isPublic = Convert.ToBoolean(reader["Visibilidade"]);
                                }

                                List<PropriedadeInfo> propriedades = new List<PropriedadeInfo>();
                                if (!string.IsNullOrEmpty(propsString))
                                {
                                    foreach (string prop in propsString.Split(';'))
                                    {
                                        if (!string.IsNullOrEmpty(prop))
                                        {
                                            string[] partes = prop.Split(':');
                                            if (partes.Length == 2)
                                            {
                                                propriedades.Add(new PropriedadeInfo(partes[1], partes[0]));
                                            }
                                        }
                                    }
                                }

                                return (codigo, propriedades, isPublic);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar classe: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return (string.Empty, new List<PropriedadeInfo>(), true);
        }

        public static bool ExcluirClasse(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    MessageBox.Show("Conexão com banco de dados não configurada!", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM ClassesGeradas WHERE ID = ?";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = id;
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir classe: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}