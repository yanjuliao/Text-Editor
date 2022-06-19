using System;

namespace Text_Editor
{
	public class Dicionario
	{
		const int INT_MAX = 2147483647;
		private string[] palavras = { };

		public Dicionario()
        {
			Array.Resize(ref palavras, 0);
		}

		private int gerarHashByInt(int chave)
        {
			return chave % INT_MAX;
        }

		private int gerarHashByStr(string palavra)
        {
			int chave = Utils.getCodigoASCII(palavra);
			chave = this.gerarHashByInt(chave);
			return chave;
        }

		public void add(string palavra)
        {
			if(Utils.isEmpty(palavra))
            {
				return;
            }

			palavra = palavra.ToLower();
			bool existe = false;
			int chave = this.gerarHashByStr(palavra);

			while (chave >= 0 && chave < palavras.Length && !Utils.isEmpty(this.palavras[chave]))
			{
				if (this.palavras[chave] == palavra)
				{
					existe = true;
					break;
				}

				chave = this.gerarHashByInt(chave + 1);
			}

			if (!existe)
            {
				if (chave >= palavras.Length)
				{
					Array.Resize(ref palavras, chave + 1);
				}

				this.palavras[chave] = palavra;
			}			
        }

		public bool contains(string palavra)
        {
			if (Utils.isEmpty(palavra))
			{
				return false;
			}

			palavra = palavra.ToLower();
			int chave = this.gerarHashByStr(palavra);

			while (chave >= 0 && chave < palavras.Length && !Utils.isEmpty(this.palavras[chave]))
			{
				if (this.palavras[chave] == palavra)
				{
					return true;
				}

				chave = this.gerarHashByInt(chave + 1);
			}

			return false;
		}

		public string[] getPalavras()
        {
			return this.palavras;

		}

		public void setPalavras(string[] palavras)
        {
			this.palavras = palavras;
        }
	}
}