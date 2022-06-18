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
        Dicionario dicionario = new Dicionario();
        
        public frmPrincipal()
        {
            InitializeComponent();
            this.inicialiazarDicionario();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            String texto = Utils.sanitizar(this.txtBox.Text);
            String[] palavras = texto.Split(" ");
            this.AdicionarPalavrasDicionario(palavras);
        }

        private void AdicionarPalavrasDicionario(String[] palavras)
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
                            File.WriteAllLines("Dicionario.txt", palavras);
                        }
                    }
                }
            }
        }

        private void inicialiazarDicionario()
        {
            var linhas = File.ReadAllLines("Dicionario.txt");

            foreach (var linha in linhas)
            {
                this.dicionario.add(linha);
            }
        }
    }
}
