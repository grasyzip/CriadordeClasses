using System;
using System.Drawing;
using System.Windows.Forms;

namespace GeradorClasses
{
    partial class FormVisualClasse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtCodigo = new RichTextBox();
            btnCopiar = new Button();
            btnFechar = new Button();
            lblTitulo = new Label();
            panelSuperior = new Panel();
            lblNomeClasse = new Label();
            panelInferior = new Panel();
            btnDownload = new Button();
            panelSuperior.SuspendLayout();
            panelInferior.SuspendLayout();
            SuspendLayout();
            // 
            // txtCodigo
            // 
            txtCodigo.BackColor = Color.FromArgb(44, 62, 80);
            txtCodigo.BorderStyle = BorderStyle.None;
            txtCodigo.Dock = DockStyle.Fill;
            txtCodigo.Font = new Font("Consolas", 11F);
            txtCodigo.ForeColor = Color.White;
            txtCodigo.Location = new Point(0, 128);
            txtCodigo.Margin = new Padding(6);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(1519, 1220);
            txtCodigo.TabIndex = 0;
            txtCodigo.Text = "";
            txtCodigo.WordWrap = false;
            // 
            // btnCopiar
            // 
            btnCopiar.BackColor = Color.FromArgb(46, 204, 113);
            btnCopiar.FlatStyle = FlatStyle.Flat;
            btnCopiar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCopiar.ForeColor = Color.White;
            btnCopiar.Location = new Point(22, 21);
            btnCopiar.Margin = new Padding(6);
            btnCopiar.Name = "btnCopiar";
            btnCopiar.Size = new Size(223, 64);
            btnCopiar.TabIndex = 1;
            btnCopiar.Text = "📋 COPIAR";
            btnCopiar.UseVisualStyleBackColor = false;
            btnCopiar.Click += btnCopiar_Click;
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.FromArgb(231, 76, 60);
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFechar.ForeColor = Color.White;
            btnFechar.Location = new Point(1241, 21);
            btnFechar.Margin = new Padding(6);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(223, 64);
            btnFechar.TabIndex = 2;
            btnFechar.Text = "✖ FECHAR";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(28, 32);
            lblTitulo.Margin = new Padding(6, 0, 6, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(316, 59);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Classe Gerada:";
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.FromArgb(52, 73, 94);
            panelSuperior.Controls.Add(lblTitulo);
            panelSuperior.Controls.Add(lblNomeClasse);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Margin = new Padding(6);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Padding = new Padding(19, 21, 19, 21);
            panelSuperior.Size = new Size(1519, 128);
            panelSuperior.TabIndex = 1;
            // 
            // lblNomeClasse
            // 
            lblNomeClasse.AutoSize = true;
            lblNomeClasse.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
            lblNomeClasse.ForeColor = Color.FromArgb(52, 152, 219);
            lblNomeClasse.Location = new Point(316, 38);
            lblNomeClasse.Margin = new Padding(6, 0, 6, 0);
            lblNomeClasse.Name = "lblNomeClasse";
            lblNomeClasse.Size = new Size(0, 51);
            lblNomeClasse.TabIndex = 1;
            // 
            // panelInferior
            // 
            panelInferior.BackColor = Color.FromArgb(52, 73, 94);
            panelInferior.Controls.Add(btnDownload);
            panelInferior.Controls.Add(btnCopiar);
            panelInferior.Controls.Add(btnFechar);
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Location = new Point(0, 1348);
            panelInferior.Margin = new Padding(6);
            panelInferior.Name = "panelInferior";
            panelInferior.Size = new Size(1519, 107);
            panelInferior.TabIndex = 2;
            // 
            // btnDownload
            // 
            btnDownload.BackColor = Color.FromArgb(192, 64, 0);
            btnDownload.FlatStyle = FlatStyle.Flat;
            btnDownload.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDownload.ForeColor = Color.White;
            btnDownload.Location = new Point(279, 21);
            btnDownload.Margin = new Padding(6);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(295, 64);
            btnDownload.TabIndex = 3;
            btnDownload.Text = "💾 DOWNLOAD .cs";
            btnDownload.UseVisualStyleBackColor = false;
            btnDownload.Click += btnDownload_Click;
            // 
            // FormVisualClasse
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 62, 80);
            ClientSize = new Size(1519, 1455);
            Controls.Add(txtCodigo);
            Controls.Add(panelSuperior);
            Controls.Add(panelInferior);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(6);
            MinimumSize = new Size(1114, 853);
            Name = "FormVisualClasse";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Visualizador de Classe";
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelInferior.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnCopiar;
        private Button btnFechar;
        private Label lblNomeClasse;
        private Label lblTitulo;
        private RichTextBox txtCodigo;
        private Panel panelSuperior;
        private Panel panelInferior;
        private Button btnDownload;
    }
}