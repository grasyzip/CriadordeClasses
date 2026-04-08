using System;
using System.Drawing;
using System.Windows.Forms;

namespace GeradorClasses
{
    public partial class FormVisualClasse : Form
    {
        private bool mousePressed = false;
        private Point mousePos;

        public FormVisualClasse()
        {
            try
            {
                InitializeComponent();
                ConfigurarEventosMoverForm();
                
                this.StartPosition = FormStartPosition.CenterScreen;
                this.WindowState = FormWindowState.Normal;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar FormVisualClasse: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetConteudo(string nomeClasse, string codigo)
        {
            try
            {
                if (lblNomeClasse == null || txtCodigo == null)
                    return;

                lblNomeClasse.Text = nomeClasse ?? "Sem nome";
                txtCodigo.Text = codigo ?? string.Empty;

                AplicarDestaqueSintaxe();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao definir conteúdo: {ex.Message}");
            }
        }

        private void AplicarDestaqueSintaxe()
        {
            try
            {
                if (txtCodigo == null || string.IsNullOrEmpty(txtCodigo.Text))
                    return;

                int posicaoOriginal = txtCodigo.SelectionStart;
                txtCodigo.SelectAll();
                txtCodigo.SelectionColor = Color.White;
                txtCodigo.SelectionFont = new Font(txtCodigo.Font, FontStyle.Regular);

                string[] palavrasChave = {
                    "class", "public", "private", "protected", "internal",
                    "string", "int", "float", "double", "bool", "void",
                    "return", "new", "using", "namespace", "static",
                    "get", "set", "value", "override", "virtual",
                    "if", "else", "for", "foreach", "while", "do",
                    "try", "catch", "finally", "throw", "this", "base"
                };

                foreach (string palavra in palavrasChave)
                {
                    int index = 0;
                    while (index < txtCodigo.Text.Length)
                    {
                        index = txtCodigo.Text.IndexOf(palavra, index, StringComparison.Ordinal);
                        if (index == -1) break;

                        bool bordaEsquerda = (index == 0) ||
                                            !char.IsLetterOrDigit(txtCodigo.Text[index - 1]);
                        bool bordaDireita = (index + palavra.Length >= txtCodigo.Text.Length) ||
                                           !char.IsLetterOrDigit(txtCodigo.Text[index + palavra.Length]);

                        if (bordaEsquerda && bordaDireita)
                        {
                            txtCodigo.Select(index, palavra.Length);
                            txtCodigo.SelectionColor = Color.FromArgb(86, 156, 214);
                        }

                        index += palavra.Length;
                    }
                }

                txtCodigo.Select(posicaoOriginal, 0);
                txtCodigo.SelectionColor = Color.White;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro no destaque: {ex.Message}");
            }
        }

        private void ConfigurarEventosMoverForm()
        {
            try
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
                        this.Location = new Point(
                            this.Location.X + e.X - mousePos.X,
                            this.Location.Y + e.Y - mousePos.Y
                        );
                    }
                };

                panelSuperior.MouseUp += (s, e) => mousePressed = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro nos eventos: {ex.Message}");
            }
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtCodigo.Text);

                // Feedback visual imediato
                btnCopiar.Text = "✓ Copiado!";
                btnCopiar.BackColor = Color.FromArgb(39, 174, 96);

                // Timer para voltar ao texto original - sem MessageBox
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1500;
                timer.Tick += (s, ev) =>
                {
                    btnCopiar.Text = "📋 COPIAR";
                    btnCopiar.BackColor = Color.FromArgb(46, 204, 113);
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();

                // REMOVI O MessageBox daqui - isso travava a interface
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao copiar: {ex.Message}");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    MessageBox.Show("Não há código para salvar!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nomeArquivo = string.IsNullOrWhiteSpace(lblNomeClasse.Text) ?
                    "ClasseGerada" : lblNomeClasse.Text;

                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                {
                    nomeArquivo = nomeArquivo.Replace(c, '_');
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Arquivo C# (*.cs)|*.cs|Todos os arquivos (*.*)|*.*";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.FileName = $"{nomeArquivo}.cs";
                    saveFileDialog.Title = "Salvar classe como arquivo C#";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(saveFileDialog.FileName, txtCodigo.Text);

                        btnDownload.Text = "✓ SALVO!";
                        btnDownload.BackColor = Color.FromArgb(39, 174, 96);

                        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                        timer.Interval = 1500;
                        timer.Tick += (s, ev) =>
                        {
                            btnDownload.Text = "💾 DOWNLOAD .cs";
                            btnDownload.BackColor = Color.FromArgb(52, 152, 219);
                            timer.Stop();
                            timer.Dispose();
                        };
                        timer.Start();

                        MessageBox.Show($"Arquivo salvo com sucesso em:\n{saveFileDialog.FileName}",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar arquivo: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}