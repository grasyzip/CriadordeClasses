using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GeradorClasses
{
    public partial class FormClassesSalvas : Form
    {
        private DataTable dtClasses;
        private bool mousePressed = false;
        private Point mousePos;

        public FormClassesSalvas()
        {
            InitializeComponent();

            if (dataGridViewClasses == null)
            {
                MessageBox.Show("Erro: DataGridView não encontrado! O formulário pode estar corrompido.",
                    "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ConfigurarEventosMoverForm();

            this.Load += FormClassesSalvas_Load;
        }

        private void FormClassesSalvas_Load(object sender, EventArgs e)
        {
            CarregarClasses();
        }

        private void ConfigurarEventosMoverForm()
        {
            if (panelSuperior == null) return;

            panelSuperior.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    mousePressed = true;
                    mousePos = new Point(e.X, e.Y);
                }
            };

            panelSuperior.MouseMove += (s, e) =>
            {
                if (mousePressed)
                {
                    Location = new Point(
                        Location.X + e.X - mousePos.X,
                        Location.Y + e.Y - mousePos.Y
                    );
                }
            };

            panelSuperior.MouseUp += (s, e) => mousePressed = false;
        }

        private void CarregarClasses(string filtro = "")
        {
            try
            {
                if (dataGridViewClasses == null)
                {
                    MessageBox.Show("Controle DataGridView não está disponível!", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Cursor = Cursors.WaitCursor;
                dtClasses = Database.ListarClasses();

                if (dtClasses == null)
                {
                    dtClasses = new DataTable();
                    dtClasses.Columns.Add("ID", typeof(int));
                    dtClasses.Columns.Add("NomeClasse", typeof(string));
                    dtClasses.Columns.Add("Data", typeof(DateTime));
                }

                if (!string.IsNullOrWhiteSpace(filtro) && dtClasses.Rows.Count > 0)
                {
                    DataView dv = new DataView(dtClasses);
                    dv.RowFilter = $"NomeClasse LIKE '%{filtro.Replace("'", "''")}%'";
                    dataGridViewClasses.DataSource = dv.ToTable();
                }
                else
                {
                    dataGridViewClasses.DataSource = dtClasses;
                }

                ConfigurarDataGridView();
                AtualizarContador();

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Erro ao carregar classes: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarContador()
        {
            if (lblTotalClasses != null && dataGridViewClasses != null)
            {
                int total = dataGridViewClasses.Rows?.Count ?? 0;
                lblTotalClasses.Text = $"{total} classe(s) encontrada(s)";
            }
        }

        private void ConfigurarDataGridView()
        {
            try
            {
                if (dataGridViewClasses == null) return;

                dataGridViewClasses.BackgroundColor = Color.FromArgb(44, 62, 80);
                dataGridViewClasses.ForeColor = Color.White;
                dataGridViewClasses.RowHeadersVisible = false;
                dataGridViewClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewClasses.AllowUserToAddRows = false;
                dataGridViewClasses.ReadOnly = true;
                dataGridViewClasses.EnableHeadersVisualStyles = false;

                if (dataGridViewClasses.ColumnHeadersDefaultCellStyle != null)
                {
                    dataGridViewClasses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
                    dataGridViewClasses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridViewClasses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
                dataGridViewClasses.ColumnHeadersHeight = 40;

                if (dataGridViewClasses.DefaultCellStyle != null)
                {
                    dataGridViewClasses.DefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
                    dataGridViewClasses.DefaultCellStyle.ForeColor = Color.White;
                    dataGridViewClasses.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
                    dataGridViewClasses.DefaultCellStyle.SelectionForeColor = Color.White;
                }
                dataGridViewClasses.RowTemplate.Height = 30;

                if (dataGridViewClasses.Columns != null && dataGridViewClasses.Columns.Count > 0)
                {
                    foreach (DataGridViewColumn coluna in dataGridViewClasses.Columns)
                    {
                        switch (coluna.Name.ToUpper())
                        {
                            case "ID":
                                coluna.HeaderText = "Código";
                                coluna.Width = 50;
                                break;
                            case "NOMECLASSE":
                                coluna.HeaderText = "Nome da Classe";
                                break;
                            case "DATA":
                                coluna.HeaderText = "Data de Criação";
                                if (coluna is DataGridViewTextBoxColumn textColumn)
                                {
                                    textColumn.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao configurar DataGridView: {ex.Message}");
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewClasses == null) return;

                if (dataGridViewClasses.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridViewClasses.SelectedRows[0];

                    if (selectedRow.Cells["ID"].Value != null &&
                        selectedRow.Cells["NomeClasse"].Value != null)
                    {
                        int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                        string nomeClasse = selectedRow.Cells["NomeClasse"].Value.ToString();

                        string codigo = Database.CarregarClasse(id);

                        if (!string.IsNullOrEmpty(codigo))
                        {
                            FormVisualClasse formVisual = new FormVisualClasse();
                            formVisual.SetConteudo(nomeClasse, codigo);
                            formVisual.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível carregar o código da classe!", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dados inválidos na linha selecionada!", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione uma classe para visualizar!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao visualizar classe: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewClasses == null) return;

                if (dataGridViewClasses.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridViewClasses.SelectedRows[0];

                    if (selectedRow.Cells["NomeClasse"].Value != null)
                    {
                        string nomeClasse = selectedRow.Cells["NomeClasse"].Value.ToString();

                        DialogResult result = MessageBox.Show($"Deseja realmente excluir a classe '{nomeClasse}'?",
                            "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                            if (Database.ExcluirClasse(id))
                            {
                                MessageBox.Show("Classe excluída com sucesso!", "Sucesso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CarregarClasses(txtBusca?.Text.Trim() ?? "");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione uma classe para excluir!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir classe: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusca != null)
            {
                CarregarClasses(txtBusca.Text.Trim());
            }
        }

        private void btnLimparBusca_Click(object sender, EventArgs e)
        {
            if (txtBusca != null)
            {
                txtBusca.Clear();
                CarregarClasses();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarClasses(txtBusca?.Text.Trim() ?? "");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}