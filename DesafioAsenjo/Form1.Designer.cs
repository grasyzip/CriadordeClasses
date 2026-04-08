namespace DesafioAsenjo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSuperior = new Panel();
            lblTitulo = new Label();
            btnFechar = new Button();
            panelConteudo = new Panel();
            panelVisibilidade = new Panel();
            rbPrivate = new RadioButton();
            rbPublic = new RadioButton();
            lblVisibilidade = new Label();
            labelTipo = new Label();
            cmbTipoPropriedade = new ComboBox();
            btnClassesSalvas = new Button();
            lblNomeClasse = new Label();
            txtNomeClasse = new TextBox();
            lblPropriedade = new Label();
            txtPropriedade = new TextBox();
            btnAddList = new Button();
            lblPropriedades = new Label();
            lbListaPropriedades = new ListBox();
            btnLimpar = new Button();
            btnGerarClasse = new Button();
            panelInferior = new Panel();
            panelSuperior.SuspendLayout();
            panelConteudo.SuspendLayout();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.FromArgb(52, 73, 94);
            panelSuperior.Controls.Add(lblTitulo);
            panelSuperior.Controls.Add(btnFechar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Margin = new Padding(6);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Padding = new Padding(19, 21, 19, 21);
            panelSuperior.Size = new Size(743, 128);
            panelSuperior.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(33, 32);
            lblTitulo.Margin = new Padding(6, 0, 6, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(386, 59);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gerador de Classe";
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.FromArgb(231, 76, 60);
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFechar.ForeColor = Color.White;
            btnFechar.Location = new Point(576, 32);
            btnFechar.Margin = new Padding(6);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(139, 64);
            btnFechar.TabIndex = 1;
            btnFechar.Text = "✖ SAIR";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click_1;
            // 
            // panelConteudo
            // 
            panelConteudo.BackColor = Color.FromArgb(44, 62, 80);
            panelConteudo.Controls.Add(panelVisibilidade);
            panelConteudo.Controls.Add(rbPrivate);
            panelConteudo.Controls.Add(rbPublic);
            panelConteudo.Controls.Add(lblVisibilidade);
            panelConteudo.Controls.Add(labelTipo);
            panelConteudo.Controls.Add(cmbTipoPropriedade);
            panelConteudo.Controls.Add(btnClassesSalvas);
            panelConteudo.Controls.Add(lblNomeClasse);
            panelConteudo.Controls.Add(txtNomeClasse);
            panelConteudo.Controls.Add(lblPropriedade);
            panelConteudo.Controls.Add(txtPropriedade);
            panelConteudo.Controls.Add(btnAddList);
            panelConteudo.Controls.Add(lblPropriedades);
            panelConteudo.Controls.Add(lbListaPropriedades);
            panelConteudo.Controls.Add(btnLimpar);
            panelConteudo.Controls.Add(btnGerarClasse);
            panelConteudo.Dock = DockStyle.Fill;
            panelConteudo.Location = new Point(0, 128);
            panelConteudo.Margin = new Padding(6);
            panelConteudo.Name = "panelConteudo";
            panelConteudo.Padding = new Padding(37, 43, 37, 43);
            panelConteudo.Size = new Size(743, 1010);
            panelConteudo.TabIndex = 1;
            // 
            // panelVisibilidade
            // 
            panelVisibilidade.Location = new Point(441, 483);
            panelVisibilidade.Name = "panelVisibilidade";
            panelVisibilidade.Size = new Size(257, 37);
            panelVisibilidade.TabIndex = 14;
            // 
            // rbPrivate
            // 
            rbPrivate.AutoSize = true;
            rbPrivate.BackColor = Color.FromArgb(52, 73, 94);
            rbPrivate.Font = new Font("Segoe UI", 10F);
            rbPrivate.ForeColor = Color.White;
            rbPrivate.Location = new Point(341, 340);
            rbPrivate.Name = "rbPrivate";
            rbPrivate.Size = new Size(129, 41);
            rbPrivate.TabIndex = 13;
            rbPrivate.TabStop = true;
            rbPrivate.Text = "Private";
            rbPrivate.UseVisualStyleBackColor = true;
            // 
            // rbPublic
            // 
            rbPublic.AutoSize = true;
            rbPublic.BackColor = Color.FromArgb(52, 73, 94);
            rbPublic.Checked = true;
            rbPublic.Font = new Font("Segoe UI", 10F);
            rbPublic.ForeColor = Color.White;
            rbPublic.Location = new Point(79, 345);
            rbPublic.Name = "rbPublic";
            rbPublic.Size = new Size(120, 41);
            rbPublic.TabIndex = 12;
            rbPublic.TabStop = true;
            rbPublic.Text = "Public";
            rbPublic.UseVisualStyleBackColor = true;
            // 
            // lblVisibilidade
            // 
            lblVisibilidade.AutoSize = true;
            lblVisibilidade.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblVisibilidade.ForeColor = Color.White;
            lblVisibilidade.Location = new Point(53, 292);
            lblVisibilidade.Name = "lblVisibilidade";
            lblVisibilidade.Size = new Size(175, 37);
            lblVisibilidade.TabIndex = 11;
            lblVisibilidade.Text = "Visibilidade:";
            // 
            // labelTipo
            // 
            labelTipo.AutoSize = true;
            labelTipo.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTipo.ForeColor = Color.White;
            labelTipo.Location = new Point(456, 182);
            labelTipo.Name = "labelTipo";
            labelTipo.Size = new Size(82, 37);
            labelTipo.TabIndex = 10;
            labelTipo.Text = "Tipo:";
            // 
            // cmbTipoPropriedade
            // 
            cmbTipoPropriedade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoPropriedade.Font = new Font("Segoe UI", 10F);
            cmbTipoPropriedade.FormattingEnabled = true;
            cmbTipoPropriedade.Items.AddRange(new object[] { "string", "int", "decimal", "double", "float", "bool", "DateTime", "Guid", "long", "short", "byte", "char" });
            cmbTipoPropriedade.Location = new Point(456, 225);
            cmbTipoPropriedade.Name = "cmbTipoPropriedade";
            cmbTipoPropriedade.Size = new Size(242, 45);
            cmbTipoPropriedade.TabIndex = 9;
            // 
            // btnClassesSalvas
            // 
            btnClassesSalvas.BackColor = Color.FromArgb(155, 89, 182);
            btnClassesSalvas.FlatStyle = FlatStyle.Flat;
            btnClassesSalvas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClassesSalvas.ForeColor = Color.White;
            btnClassesSalvas.Location = new Point(44, 888);
            btnClassesSalvas.Name = "btnClassesSalvas";
            btnClassesSalvas.Size = new Size(656, 81);
            btnClassesSalvas.TabIndex = 0;
            btnClassesSalvas.Text = "📂 CLASSES SALVAS";
            btnClassesSalvas.UseVisualStyleBackColor = false;
            btnClassesSalvas.Click += btnClassesSalvas_Click;
            // 
            // lblNomeClasse
            // 
            lblNomeClasse.AutoSize = true;
            lblNomeClasse.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNomeClasse.ForeColor = Color.White;
            lblNomeClasse.Location = new Point(43, 49);
            lblNomeClasse.Margin = new Padding(6, 0, 6, 0);
            lblNomeClasse.Name = "lblNomeClasse";
            lblNomeClasse.Size = new Size(227, 37);
            lblNomeClasse.TabIndex = 0;
            lblNomeClasse.Text = "Nome da Classe:";
            // 
            // txtNomeClasse
            // 
            txtNomeClasse.BackColor = Color.FromArgb(52, 73, 94);
            txtNomeClasse.BorderStyle = BorderStyle.FixedSingle;
            txtNomeClasse.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNomeClasse.ForeColor = Color.White;
            txtNomeClasse.Location = new Point(43, 96);
            txtNomeClasse.Margin = new Padding(6);
            txtNomeClasse.Name = "txtNomeClasse";
            txtNomeClasse.Size = new Size(656, 45);
            txtNomeClasse.TabIndex = 1;
            // 
            // lblPropriedade
            // 
            lblPropriedade.AutoSize = true;
            lblPropriedade.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPropriedade.ForeColor = Color.White;
            lblPropriedade.Location = new Point(43, 177);
            lblPropriedade.Margin = new Padding(6, 0, 6, 0);
            lblPropriedade.Name = "lblPropriedade";
            lblPropriedade.Size = new Size(184, 37);
            lblPropriedade.TabIndex = 2;
            lblPropriedade.Text = "Propriedade:";
            // 
            // txtPropriedade
            // 
            txtPropriedade.BackColor = Color.FromArgb(52, 73, 94);
            txtPropriedade.BorderStyle = BorderStyle.FixedSingle;
            txtPropriedade.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPropriedade.ForeColor = Color.White;
            txtPropriedade.Location = new Point(42, 225);
            txtPropriedade.Margin = new Padding(6);
            txtPropriedade.Name = "txtPropriedade";
            txtPropriedade.Size = new Size(250, 45);
            txtPropriedade.TabIndex = 3;
            txtPropriedade.TextChanged += txtPropriedade_TextChanged;
            // 
            // btnAddList
            // 
            btnAddList.BackColor = Color.FromArgb(52, 152, 219);
            btnAddList.FlatStyle = FlatStyle.Flat;
            btnAddList.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddList.ForeColor = Color.White;
            btnAddList.Location = new Point(225, 401);
            btnAddList.Margin = new Padding(6);
            btnAddList.Name = "btnAddList";
            btnAddList.Size = new Size(267, 64);
            btnAddList.TabIndex = 4;
            btnAddList.Text = "ADICIONAR";
            btnAddList.UseVisualStyleBackColor = false;
            btnAddList.Click += btnAddList_Click;
            // 
            // lblPropriedades
            // 
            lblPropriedades.AutoSize = true;
            lblPropriedades.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPropriedades.ForeColor = Color.White;
            lblPropriedades.Location = new Point(42, 483);
            lblPropriedades.Margin = new Padding(6, 0, 6, 0);
            lblPropriedades.Name = "lblPropriedades";
            lblPropriedades.Size = new Size(196, 37);
            lblPropriedades.TabIndex = 5;
            lblPropriedades.Text = "Propriedades:";
            // 
            // lbListaPropriedades
            // 
            lbListaPropriedades.BackColor = Color.FromArgb(52, 73, 94);
            lbListaPropriedades.BorderStyle = BorderStyle.FixedSingle;
            lbListaPropriedades.Font = new Font("Consolas", 11F);
            lbListaPropriedades.ForeColor = Color.White;
            lbListaPropriedades.FormattingEnabled = true;
            lbListaPropriedades.ItemHeight = 34;
            lbListaPropriedades.Location = new Point(42, 530);
            lbListaPropriedades.Margin = new Padding(6);
            lbListaPropriedades.Name = "lbListaPropriedades";
            lbListaPropriedades.Size = new Size(656, 206);
            lbListaPropriedades.TabIndex = 6;
            lbListaPropriedades.SelectedIndexChanged += lbListaPropriedades_SelectedIndexChanged;
            // 
            // btnLimpar
            // 
            btnLimpar.BackColor = Color.FromArgb(230, 126, 34);
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLimpar.ForeColor = Color.White;
            btnLimpar.Location = new Point(42, 766);
            btnLimpar.Margin = new Padding(6);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(300, 82);
            btnLimpar.TabIndex = 7;
            btnLimpar.Text = "🗑️ LIMPAR SELEÇÃO";
            btnLimpar.UseVisualStyleBackColor = false;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnGerarClasse
            // 
            btnGerarClasse.BackColor = Color.FromArgb(46, 204, 113);
            btnGerarClasse.FlatStyle = FlatStyle.Flat;
            btnGerarClasse.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGerarClasse.ForeColor = Color.White;
            btnGerarClasse.Location = new Point(377, 766);
            btnGerarClasse.Margin = new Padding(6);
            btnGerarClasse.Name = "btnGerarClasse";
            btnGerarClasse.Size = new Size(322, 82);
            btnGerarClasse.TabIndex = 8;
            btnGerarClasse.Text = "⚙️ GERAR CLASSE";
            btnGerarClasse.UseVisualStyleBackColor = false;
            btnGerarClasse.Click += btnGerarClasse_Click;
            // 
            // panelInferior
            // 
            panelInferior.BackColor = Color.FromArgb(52, 73, 94);
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Location = new Point(0, 1138);
            panelInferior.Margin = new Padding(6);
            panelInferior.Name = "panelInferior";
            panelInferior.Size = new Size(743, 30);
            panelInferior.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(743, 1168);
            Controls.Add(panelConteudo);
            Controls.Add(panelSuperior);
            Controls.Add(panelInferior);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(6);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerador de Classes";
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelConteudo.ResumeLayout(false);
            panelConteudo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblNomeClasse;
        private Label lblPropriedade;
        private Label lblPropriedades;
        private Button btnAddList;
        private Button btnLimpar;
        private Button btnGerarClasse;
        private TextBox txtNomeClasse;
        private TextBox txtPropriedade;
        private ListBox lbListaPropriedades;
        private Panel panelInferior;
        private Panel panelSuperior;
        private Panel panelConteudo;
        private Label lblTitulo;
        private Button btnFechar;
        private Button btnClassesSalvas;
        private ComboBox cmbTipoPropriedade;
        private Label labelTipo;
        private Panel panelVisibilidade;
        private RadioButton rbPrivate;
        private RadioButton rbPublic;
        private Label lblVisibilidade;
    }
}
