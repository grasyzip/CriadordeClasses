using GeradorClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DesafioAsenjo
{
    public partial class Form1 : Form
    {
        // MODIFICADO: Agora é List<PropriedadeInfo>
        private List<PropriedadeInfo> propriedades = new List<PropriedadeInfo>();

        public Form1()
        {
            InitializeComponent();

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.MinimumSize = new Size(400, 550);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (propriedades.Count > 0)
            {
                DialogResult result = MessageBox.Show("Deseja realmente limpar todas as propriedades?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    propriedades.Clear();
                    lbListaPropriedades.Items.Clear();
                }
            }
            else
            {
                MessageBox.Show("Não há propriedades para limpar!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGerarClasse_Click(object sender, EventArgs e)
        {
            string nomeClasse = txtNomeClasse.Text.Trim();

            bool isPublic = rbPublic.Checked; // true se Pública, false se Privada

            GeradorBLL.ValidarDados(nomeClasse, propriedades);

            if (Erro.GetErro())
            {
                MessageBox.Show(Erro.GetMensagem(), "Erro de Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string classeGerada = GeradorBLL.GerarClasse(nomeClasse, propriedades, isPublic);

            FormVisualClasse formVisual = new FormVisualClasse();
            formVisual.SetConteudo(nomeClasse, classeGerada);
            formVisual.Show();

            Database.SalvarClasse(nomeClasse, classeGerada, propriedades);
        }

        // MODIFICADO: Agora adiciona com tipo
        private void btnAddList_Click(object sender, EventArgs e)
        {
            string propriedade = txtPropriedade.Text.Trim();
            string tipo = cmbTipoPropriedade.SelectedItem?.ToString() ?? "string";

            if (string.IsNullOrWhiteSpace(propriedade))
            {
                MessageBox.Show("Digite o nome da propriedade!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPropriedade.Focus();
                return;
            }

            if (!char.IsLetter(propriedade[0]))
            {
                MessageBox.Show("O nome da propriedade deve começar com letra!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPropriedade.SelectAll();
                return;
            }

            if (propriedade.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("A propriedade deve conter apenas letras e números!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPropriedade.SelectAll();
                return;
            }

            // Verificar se já existe uma propriedade com o mesmo nome
            if (propriedades.Any(p => p.Nome.Equals(propriedade, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"A propriedade '{propriedade}' já foi adicionada!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPropriedade.SelectAll();
                return;
            }

            // Adicionar a propriedade com o tipo selecionado
            PropriedadeInfo novaProp = new PropriedadeInfo(propriedade, tipo);
            propriedades.Add(novaProp);

            // Exibir na lista com o formato "tipo nome"
            lbListaPropriedades.Items.Add(novaProp.ToString());

            txtPropriedade.Clear();
            txtPropriedade.Focus();
            cmbTipoPropriedade.SelectedIndex = 0; // Volta para string
        }

        // NOVO: Remover propriedade com duplo clique
        private void lbListaPropriedades_DoubleClick(object sender, EventArgs e)
        {
            if (lbListaPropriedades.SelectedItem != null)
            {
                int index = lbListaPropriedades.SelectedIndex;
                propriedades.RemoveAt(index);
                lbListaPropriedades.Items.RemoveAt(index);
            }
        }

        private void btnFechar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClassesSalvas_Click(object sender, EventArgs e)
        {
            FormClassesSalvas form = new FormClassesSalvas();
            form.ShowDialog();
        }

        private void lbListaPropriedades_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtPropriedade_TextChanged(object sender, EventArgs e) { }

        private void cmbTipoPropriedade_SelectIndexChanged(object sender, EventArgs e) { }
    }
}