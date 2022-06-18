using System;
using System.Text.RegularExpressions;

namespace Text_Editor
{
	public class Utils
	{
		public static int getCodigoASCII(string texto)
		{
			int codigo = 0;

			foreach (var caracter in texto)
			{
				codigo = codigo + (int)caracter;
			}

			return codigo;

		}

		public static bool isEmpty(string valor)
		{
			if (valor != null)
			{
				valor = valor.Replace(" ", "");
			}

			return valor == null || valor == "";

		}

		public static string sanitizar(string texto)
        {
			string pattern = @"[^\w\s]|[ºª]";
			Regex rgx = new Regex(pattern);
			return rgx.Replace(texto, " ");
		}
	}
}

