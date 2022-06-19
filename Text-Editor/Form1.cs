using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Editor
{
    public partial class frmPrincipal : Form
    {
        const string ARQUIVO_DICIONARIO = "Dicionario.txt";
        Dicionario dicionario = new Dicionario();
        
        public frmPrincipal()
        {
            InitializeComponent();
            this.inicialiazarDicionario();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            foreach (var linha in txtBox.Lines)
            {
                string novaLinha = linha + ".";
                string texto = Utils.sanitizar(novaLinha);
                string[] palavras = texto.Split(" ");
                AdicionarPalavrasDicionario(palavras);
                salvarDicionario();
            }
        }

        private void AdicionarPalavrasDicionario(string[] palavras)
        {
            foreach(var palavra in palavras)
            {

                if (!Utils.isEmpty(palavra))
                {
                    if (!this.dicionario.contains(palavra))
                    {
                        if (MessageBox.Show("A palavra " + "'" + palavra + "'" + " não existe no dicionário. Deseja adicioná-la?", "Dicionario", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            this.dicionario.add(palavra);
                        }
                    }
                }
            }
        }

        private void inicialiazarDicionario()
        {
            string[] palavras = File.ReadAllLines(ARQUIVO_DICIONARIO);
            this.dicionario.setPalavras(palavras);
        }

        private void salvarDicionario()
        {
            File.WriteAllLines(ARQUIVO_DICIONARIO, this.dicionario.getPalavras());
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            var importArquivo = new OpenFileDialog();
            importArquivo.Filter = "txt file|*txt";

            var resultado = importArquivo.ShowDialog();

           if (resultado == DialogResult.OK)
            {
                string textolido = File.ReadAllText(importArquivo.FileName);
                txtBox.Text = textolido;
            }
        }
    }
}
