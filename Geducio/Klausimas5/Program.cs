using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Klausimas5
{
	class Program
	{
		const string duom = "...\\...\\Tekstas.txt";
		const string rez = "...\\...\\RedTekstas.txt";

		static void Main(string[] args) {
			string skyrikliai = " .,;:?!";
			if (File.Exists(rez))
				File.Delete(rez);
			RastiZTekste(duom, rez, skyrikliai);
		}


		static void RastiZTekste(string fr, string fv, string skyrikliai) {
			using (var ats = File.CreateText(fv)) {
				using (StreamReader reader = new StreamReader(fr)) {
					string line;
					while ((line = reader.ReadLine()) != null) {
						// Panaudokite metodą, kuris randa priešpaskutinį kiekvienos eilutės žodį, pasibaigiantį lotyniška priebalse,
						// ir jį sukeičia vietomis su paskutiniu eilutės žodžiu. Skyrikliai nekeičiami.
						line = SukeistiZodzius(line, skyrikliai);
						ats.WriteLine(line);
						Console.WriteLine(line);
					}
				}
			}
		}


		const string lotPrieb = "qwrtpsdfghjklzxcvbnm";

		// Užrašykite metodą, kuris randa priešpaskutinį kiekvienos eilutės žodį, pasibaigiantį lotyniška priebalse,
		// ir jį sukeičia vietomis su paskutiniu eilutės žodžiu. Skyrikliai nekeičiami.
		static string SukeistiZodzius(string line, string skyrikliai) {
			string skyrBeg = $@"(\G|^|[{skyrikliai}])";
			string skyrEnd = $"([{skyrikliai}]|$)";
			Regex r = new Regex($"{skyrBeg}([^{skyrikliai}]*[{lotPrieb}]){skyrEnd}", RegexOptions.IgnoreCase);
			MatchCollection matches = r.Matches(line);
			if (matches.Count < 2)
				return line;

			Group priespaskutinis = matches[matches.Count - 2].Groups[2];

			Regex r2 = new Regex($"{skyrBeg}([^{skyrikliai}]+){skyrEnd}", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);
			Group paskutinis = r2.Match(line).Groups[2];

			line = line.Remove(paskutinis.Index, paskutinis.Length);
			line = line.Insert(paskutinis.Index, priespaskutinis.Value);
			line = line.Remove(priespaskutinis.Index, priespaskutinis.Length);
			line = line.Insert(priespaskutinis.Index, paskutinis.Value);
			return line;
		}
	}
}