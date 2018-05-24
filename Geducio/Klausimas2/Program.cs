using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klausimas2
{
	class Program
	{
		class Matrica
		{
			public const int Cn = 50;     // maksimalus eilučių, stulpelių skaičius           

			private int[,] DMas;          // dvimatis sveikų skaičių masyvas
			public int N { get; set; }    // savybė N: eilučių, stulpelių skaičius            

			public Matrica()
			{
				DMas = new int[Cn, Cn];
				N = 0;
			}

			public void Deti(int i, int j, int sk)
			{
				DMas[i, j] = sk;
			}

			public int Imti(int i, int j)
			{
				return DMas[i, j];
			}

			// Užrašykite metodą, kuris suskaičiuoja kvadratinės matricos I srities
			// maksimalų neigiamą elementą.

			public int Skaiciavimas()
			{
				int max = 0;
				for (int i = 0; i < N; i++)
				{
					int iki = Math.Max(N - 1 - i, i);
					for (int j = N - 1; j >= iki; j--)
					{
						if (DMas[i, j] < 0 && (max == 0 || DMas[i, j] > max))
							max = DMas[i, j];
					}
				}
				return max;
			}
		}

		const string CFd = "..\\..\\Matrica1.txt";
		const string CFd1 = "..\\..\\Matrica2.txt";
		const string CFr = "..\\..\\Rez.txt";



		static void Main(string[] args)
		{
			if (File.Exists(CFr))
				File.Delete(CFr);

			Matrica Mtr = new Matrica();  // Ikonteineris su dvimačiu masyvu
			Skaityti(CFd, Mtr);
			Spausdinti(CFr, Mtr, " Pirma matrica");

			Matrica Mtr1 = new Matrica();  // II konteineris su dvimačiu masyvu
			Skaityti(CFd1, Mtr1);
			Spausdinti(CFr, Mtr1, " Antra matrica");

			int[] B = new int[Mtr.N];
			int[] B1 = new int[Mtr1.N];

			// Atlikite visus nurodytus skaičiavimus.
			int mtrMax = Mtr.Skaiciavimas();
			int mtr1Max = Mtr1.Skaiciavimas();
			Console.Write("Pirmos matricos pirmos srities maksimalus neigiamas: ");
			if (mtrMax == 0)
				Console.WriteLine("nėra neigiamų.");
			else
				Console.WriteLine(mtrMax);

			Console.Write("Antros matricos pirmos srities maksimalus neigiamas: ");
			if (mtr1Max == 0)
				Console.WriteLine("nėra neigiamų.");
			else
				Console.WriteLine(mtr1Max);

			AntrasDidziausias(Mtr, B);
			AntrasDidziausias(Mtr1, B1);

			Spausdinti1(CFr, B, Mtr.N, "Iš Pirmos matricos suformuotas masyvas");
			Spausdinti1(CFr, B1, Mtr1.N, "Iš Antros matricos suformuotas masyvas");
		}

		static void Skaityti(string fv, Matrica A)
		{
			using (StreamReader reader = new StreamReader(fv))
			{
				int skaicius;
				string line = reader.ReadLine();
				char[] skyr = { ' ' };
				string[] skaiciai = line.Split(skyr,
									  StringSplitOptions.RemoveEmptyEntries);
				A.N = int.Parse(skaiciai[0]);
				for (int i = 0; i < A.N; i++)
				{
					line = reader.ReadLine();
					skaiciai = line.Split(skyr,
									  StringSplitOptions.RemoveEmptyEntries);
					for (int j = 0; j < A.N; j++)
					{
						skaicius = int.Parse(skaiciai[j]);
						A.Deti(i, j, skaicius);
					}
				}
			}
		}


		// Matricos konteinerio duomenų spausdinimas faile fv
		static void Spausdinti(string fv, Matrica A, string tekstas)
		{
			using (var fr = File.AppendText(fv))
			{
				fr.WriteLine();
				fr.WriteLine("      " + tekstas);

				for (int i = 0; i < A.N; i++)
				{
					for (int j = 0; j < A.N; j++)
					{
						fr.Write("{0, 4:d}", A.Imti(i, j));
					}
					fr.WriteLine();
				}
			}
		}

		// Masyvo duomenų spausdinimas faile fv
		static void Spausdinti1(string fv, int[] B, int n, string tekstas)
		{
			using (var fr = File.AppendText(fv))
			{
				fr.WriteLine();
				fr.WriteLine("      " + tekstas);

				for (int i = 0; i < n; i++)
				{
					fr.Write("{0, 4:d}", B[i]);
				}
				fr.WriteLine();
			}
		}


		// Užrašykite metodą, kuris randa kiekvieno stulpelio antrą didžiausią elementą
		// ir jį įrašo į naują rinkinį.
		static void AntrasDidziausias(Matrica m, int[] ats)
		{
			for (int i = 0; i < m.N; i++)
			{
				int? max = null;
				int? max2 = null;
				for (int j = 0; j < m.N; j++)
				{
					int e = m.Imti(j, i);
					if (max == null)
						max = e;
					else if (max2 == null)
						max2 = e;
					else if (e > max)
					{
						max2 = max;
						max = e;
					}
					else if (e > max2)
						max2 = e;
				}
				ats[i] = max2.Value;
			}
		}

	}
}
