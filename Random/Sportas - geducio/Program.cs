using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sportas
{
	internal class Program
	{
		public const string ZaidejuDuomenuFailas = "Sportininkai.txt";
		public const string KomanduDuomenuFailas = "Komandos.txt";

		private static readonly Dictionary<string, KrepsinioKomanda> KrepsinioKomandos =
			new Dictionary<string, KrepsinioKomanda>();

		private static readonly Dictionary<string, FutboloKomanda> FutboloKomandos = new Dictionary<string, FutboloKomanda>();

		public static readonly List<Zaidejas> VisiZaidejai = new List<Zaidejas>();

		private static void Main() {
			Console.OutputEncoding = Console.InputEncoding = Encoding.UTF8;
			Nuskaityti();
			Isvesti(VisiZaidejai);

			Isvesti(KrepsinioKomandos.Values.AsEnumerable().Cast<Komanda>().Union(FutboloKomandos.Values.AsEnumerable()));

			Console.WriteLine();

			foreach (KeyValuePair<string, KrepsinioKomanda> komanda in KrepsinioKomandos) {
				Isvesti(komanda.Value);
			}

			foreach (KeyValuePair<string, FutboloKomanda> komanda in FutboloKomandos) {
				Isvesti(komanda.Value);
			}
		}

		private static void Isvesti(List<Zaidejas> zaidejai)
		{
			if (zaidejai.Count == 0) {
				Console.WriteLine("Elementų nėra");
				return;
			}
			Console.WriteLine("----------------------------------------------------------------------------------------------");
			Console.WriteLine($" {"Vardas",12} {"Pavardė",12} {"Komanda",20} {"Taškai",6} {"Žaista",6} {"Geltonų/Atkovota ir Rezultatyvių",32}");
			Console.WriteLine("-----------------------------------------------------------------------------------------------");
			foreach (var z in zaidejai)
			{
				Console.Write(
					$" {z.Vardas,12} {z.Pavarde,12} {z.Komanda.Pavadinimas,20} {z.Taskai,6:D} {z.ZaistaRungtyniu,6:D} ");
				if (z is Krepsininkas k)
					Console.WriteLine(
						$"{k.AtkovotaKamuoliu,16:D} {k.RezultatyviuPerdavimu,15:D}");
				else if(z is Futbolininkas f)
					Console.WriteLine(
						$"{f.GeltonuKorteliu,8:D}");
			}

			Console.WriteLine("-----------------------------------------------------------------------------------------------");
		}

		private static void Isvesti(IEnumerable<Komanda> komandos)
		{
			Console.WriteLine("--------------------------------------------------------------------");
			Console.WriteLine($" {"Pavadinimas",20} {"Miestas",12} {"Treneris",25} {"Žaista",6}");
			Console.WriteLine("--------------------------------------------------------------------");
			foreach (var k in komandos)
			{
				Console.WriteLine(
					$" {k.Pavadinimas,20} {k.Miestas,12} {k.Treneris,25} {k.ZaistaRungtyniu,6:D} ");
			}

			Console.WriteLine("--------------------------------------------------------------------");
		}

		private static void Isvesti(Komanda komanda)
		{
			Console.WriteLine(komanda);
			komanda.Rikiuok();
			Isvesti(komanda.Zaidejai);
			Console.WriteLine("Geriausi žaidėjai:");
			Isvesti(komanda.GeriausiZaidejai());
		}

		private static void Nuskaityti() {
			using (var input = new StreamReader(KomanduDuomenuFailas)) {
				string[] temp;
				while ((temp = input.ReadLine()?.Split(';')) != null) {
					switch (temp[0]) {
						case "k":
							KrepsinioKomandos[temp[1]] = new KrepsinioKomanda(
								temp[1], temp[2], temp[3],
								Convert.ToInt32(temp[4]));
							break;
						case "f":
							FutboloKomandos[temp[1]] = new FutboloKomanda(
								temp[1], temp[2], temp[3],
								Convert.ToInt32(temp[4]));
							break;
						default:
							throw new InvalidDataException("Duomenu failas netinkamas");
					}
				}
			}

			using (var input = new StreamReader(ZaidejuDuomenuFailas)) {
				string[] temp;
				while ((temp = input.ReadLine()?.Split(';')) != null) {
					Zaidejas zaidejas = null;
					switch (temp[0]) {
						case "k":
							var k = new Krepsininkas(temp[3], temp[2],
								Convert.ToInt32(temp[4]), Convert.ToInt32(temp[5]),
								Convert.ToInt32(temp[6]), Convert.ToInt32(temp[7]), KrepsinioKomandos[temp[1]]);
							KrepsinioKomandos[temp[1]].Zaidejai.Add(k);
							zaidejas = k;
							break;
						case "f":
							var f = new Futbolininkas(temp[3], temp[2],
								Convert.ToInt32(temp[4]), Convert.ToInt32(temp[5]),
								Convert.ToInt32(temp[6]), FutboloKomandos[temp[1]]);
							FutboloKomandos[temp[1]].Zaidejai.Add(f);
							zaidejas = f;
							break;
						default:
							throw new InvalidDataException("Duomenu failas netinkamas");
					}
					VisiZaidejai.Add(zaidejas);
				}
			}
		}
	}
}