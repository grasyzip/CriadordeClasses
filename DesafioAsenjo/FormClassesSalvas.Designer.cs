

namespace GeradorClasses
{
    partial class FormClassesSalvas
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelSuperior;
        private Label lblTitulo;
        private Label lblTotalClasses;
        private Button btnFechar;
        private Panel panelInferior;
        private Button btnVisualizar;
        private Button btnExcluir;
        private Button btnAtualizar;
        private Panel panelBusca;
        private TextBox txtBusca;
        private Button btnBuscar;
        private Button btnLimparBusca;
        private DataGridView dataGridViewClasses;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelSuperior = new Panel();
            lblTitulo = new Label();
            lblTotalClasses = new Label();
            btnFechar = new Button();
            panelInferior = new Panel();
            btnVisualizar = new Button();
            btnExcluir = new Button();
            btnAtualizar = new Button();
            panelBusca = new Panel();
            txtBusca = new TextBox();
            btnBuscar = new Button();
            btnLimparBusca = new Button();
            dataGridViewClasses = new DataGridView();
            panelSuperior.SuspendLayout();
            panelInferior.SuspendLayout();
            panelBusca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClasses).BeginInit();
            SuspendLayout();

            this.dataGridViewClasses = new System.Windows.Forms.DataGridView();

            // panelSuperior
            panelSuperior.BackColor = Color.FromArgb(52, 73, 94);
            panelSuperior.Controls.Add(lblTitulo);
            panelSuperior.Controls.Add(lblTotalClasses);
            panelSuperior.Controls.Add(btnFechar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(900, 70);
            panelSuperior.TabIndex = 0;

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(219, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "📂 Classes Salvas";

            // lblTotalClasses
            lblTotalClasses.AutoSize = true;
            lblTotalClasses.Font = new Font("Segoe UI", 10F);
            lblTotalClasses.ForeColor = Color.FromArgb(52, 152, 219);
            lblTotalClasses.Location = new Point(250, 25);
            lblTotalClasses.Name = "lblTotalClasses";
            lblTotalClasses.Size = new Size(138, 19);
            lblTotalClasses.TabIndex = 1;
            lblTotalClasses.Text = "0 classe(s) encontrada(s)";

            // btnFechar - CORRIGIDO: tamanho aumentado
            btnFechar.BackColor = Color.FromArgb(231, 76, 60);
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFechar.ForeColor = Color.White;
            btnFechar.Location = new Point(780, 15);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(100, 40);
            btnFechar.TabIndex = 2;
            btnFechar.Text = "✖ FECHAR";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;

            // panelInferior
            panelInferior.BackColor = Color.FromArgb(52, 73, 94);
            panelInferior.Controls.Add(btnVisualizar);
            panelInferior.Controls.Add(btnExcluir);
            panelInferior.Controls.Add(btnAtualizar);
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Location = new Point(0, 530);
            panelInferior.Name = "panelInferior";
            panelInferior.Size = new Size(900, 70);
            panelInferior.TabIndex = 1;

            // btnVisualizar - CORRIGIDO: tamanho aumentado
            btnVisualizar.BackColor = Color.FromArgb(46, 204, 113);
            btnVisualizar.FlatStyle = FlatStyle.Flat;
            btnVisualizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVisualizar.ForeColor = Color.White;
            btnVisualizar.Location = new Point(20, 15);
            btnVisualizar.Name = "btnVisualizar";
            btnVisualizar.Size = new Size(150, 40);
            btnVisualizar.TabIndex = 0;
            btnVisualizar.Text = "👁️ VISUALIZAR";
            btnVisualizar.UseVisualStyleBackColor = false;
            btnVisualizar.Click += btnVisualizar_Click;

            // btnExcluir - CORRIGIDO: tamanho aumentado
            btnExcluir.BackColor = Color.FromArgb(231, 76, 60);
            btnExcluir.FlatStyle = FlatStyle.Flat;
            btnExcluir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExcluir.ForeColor = Color.White;
            btnExcluir.Location = new Point(180, 15);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(150, 40);
            btnExcluir.TabIndex = 1;
            btnExcluir.Text = "🗑️ EXCLUIR";
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += btnExcluir_Click;

            // btnAtualizar - CORRIGIDO: tamanho aumentado
            btnAtualizar.BackColor = Color.FromArgb(52, 152, 219);
            btnAtualizar.FlatStyle = FlatStyle.Flat;
            btnAtualizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.Location = new Point(340, 15);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(150, 40);
            btnAtualizar.TabIndex = 2;
            btnAtualizar.Text = "🔄 ATUALIZAR";
            btnAtualizar.UseVisualStyleBackColor = false;
            btnAtualizar.Click += btnAtualizar_Click;

            // panelBusca
            panelBusca.BackColor = Color.FromArgb(52, 73, 94);
            panelBusca.Controls.Add(txtBusca);
            panelBusca.Controls.Add(btnBuscar);
            panelBusca.Controls.Add(btnLimparBusca);
            panelBusca.Dock = DockStyle.Top;
            panelBusca.Location = new Point(0, 70);
            panelBusca.Name = "panelBusca";
            panelBusca.Padding = new Padding(10);
            panelBusca.Size = new Size(900, 70);
            panelBusca.TabIndex = 2;

            // txtBusca - CORRIGIDO: tamanho aumentado
            txtBusca.Font = new Font("Segoe UI", 11F);
            txtBusca.Location = new Point(20, 18);
            txtBusca.Name = "txtBusca";
            txtBusca.PlaceholderText = "🔍 Buscar por nome da classe...";
            txtBusca.Size = new Size(400, 32);
            txtBusca.TabIndex = 0;
            //txtBusca.KeyPress += txtBusca_KeyPress;

            // btnBuscar - CORRIGIDO: tamanho aumentado
            btnBuscar.BackColor = Color.FromArgb(52, 152, 219);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(430, 15);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(120, 40);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "🔍 BUSCAR";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;

            // btnLimparBusca - CORRIGIDO: tamanho aumentado
            btnLimparBusca.BackColor = Color.FromArgb(149, 165, 166);
            btnLimparBusca.FlatStyle = FlatStyle.Flat;
            btnLimparBusca.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLimparBusca.ForeColor = Color.White;
            btnLimparBusca.Location = new Point(560, 15);
            btnLimparBusca.Name = "btnLimparBusca";
            btnLimparBusca.Size = new Size(120, 40);
            btnLimparBusca.TabIndex = 2;
            btnLimparBusca.Text = "✖ LIMPAR";
            btnLimparBusca.UseVisualStyleBackColor = false;
            btnLimparBusca.Click += btnLimparBusca_Click;

            // dataGridViewClasses
            dataGridViewClasses.ColumnHeadersHeight = 40;
            dataGridViewClasses.Dock = DockStyle.Fill;
            dataGridViewClasses.Location = new Point(0, 140);
            dataGridViewClasses.Name = "dataGridViewClasses";
            dataGridViewClasses.RowHeadersWidth = 50;
            dataGridViewClasses.Size = new Size(900, 390);
            dataGridViewClasses.TabIndex = 3;
            //dataGridViewClasses.DoubleClick += dataGridViewClasses_DoubleClick;

            // FormClassesSalvas
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 62, 80);
            ClientSize = new Size(900, 600);
            Controls.Add(dataGridViewClasses);
            Controls.Add(panelBusca);
            Controls.Add(panelSuperior);
            Controls.Add(panelInferior);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormClassesSalvas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Classes Salvas";
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelInferior.ResumeLayout(false);
            panelBusca.ResumeLayout(false);
            panelBusca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClasses).EndInit();
            ResumeLayout(false);
        }
    }
}