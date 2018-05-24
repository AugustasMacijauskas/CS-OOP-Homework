using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Klausimas5
{
	class Program
	{
		const string duom = "...\\...\\Tekstas.txt";
		const string rez = "...\\...\\RedTekstas.txt";

		static void Main(string[] args)
		{
			string skyrikliai = " .,;:?!";
			if (File.Exists(rez))
				File.Delete(rez);
			RastiZTekste(duom, rez, skyrikliai);
		}



		static void RastiZTekste(string fr, string fv, string skyrikliai)
		{
			using (var ats = File.CreateText(fv)) {
				using (StreamReader reader = new StreamReader(fr)) {
					string line = "pradzia";
					while ((line = reader.ReadLine()) != null) {



						// Panaudokite metodus, kurie randa paskutinį kiekvienos eilutės žodį, 
						// pasibaigiantį lyginiu skaitmeniu, ir metodą, kuris randa paskutinį
						// trumpiausią eilutės žodį, pasibaigiantį skaitmeniu.
						// Rastus žodžius sukeiskite vietomis. Skyrikliai nekeičiami.

						Group a = paskutinisLyginiu(line, skyrikliai);
						Group b = trumpiausiasSkaitmeniu(line, skyrikliai);

						if (a != null) {
							if (a.Index > b.Index) {
								Group x = b;
								b = a;
								a = x;
							}
							line = line.Remove(b.Index, b.Length).Insert(b.Index, a.Value);
							line = line.Remove(a.Index, a.Length).Insert(a.Index, b.Value);
						}
						
						Console.WriteLine(line);
						ats.WriteLine(line);
					}
				}
			}
		}


		// Naujas metodas1
		// Užrašykite metodą, kuris randa paskutinį kiekvienos eilutės žodį, pasibaigiantį lyginiu skaitmeniu.
		static Group paskutinisLyginiu(string line, string skyrikliai)
		{
			Match m = Regex.Match(line, $@"(\G|^|[{skyrikliai}])([^{skyrikliai}]*[02468])([{skyrikliai}]|$)", RegexOptions.RightToLeft);
			if (!m.Success)
				return null;
			return m.Groups[2];
		}



		// Naujas metodas2
		// Užrašykite metodą, kuris randa paskutinį trumpiausią eilutės žodį, pasibaigiantį skaitmeniu.
		static Group trumpiausiasSkaitmeniu(string line, string skyrikliai) {
			Group ret = null;
			foreach (Match m in Regex.Matches(line, $@"(\G|^|[{skyrikliai}])([^{skyrikliai}]*[0-9])([{skyrikliai}]|$)")) {
				if (ret == null || ret.Length >= m.Groups[2].Length)
					ret = m.Groups[2];
			}
			return ret;
		}


	}
}
