using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Text_Editor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //Inst�ncia da minha lista
            MinhaLista Lista = new MinhaLista();

            //Leitura de cada linha do dicion�rio
            var linhas = File.ReadAllLines("Dicionario.txt");

            // Para cada linha do dicion�rio a matriz valorAscii vai receber o ascii de cada letra.
            foreach (var linha in linhas)
            {
                byte [] valorAscii = Encoding.ASCII.GetBytes(linha);

                /* Para cada valor ascii de cada letra ser� feita uma soma para achar o
                 valor ascii da palavra inteira e essa soma ser� o elemento inserido na minha lista.*/ 
                foreach (var valor in valorAscii)
                {
                    int contador = 0;
                    contador = contador + Convert.ToInt32(valor);
                    Lista.insereInicio(contador);
                }
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmPrincipal());
        }
    }
}
