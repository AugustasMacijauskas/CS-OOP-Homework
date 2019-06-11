using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace temp
{
	class Autoriai
	{
		private Mazgas pr;
		private Mazgas pb;
		private Mazgas ss;

		public Mazgas Pbt() => pbt;
		private Mazgas pbt;

		public Autoriai()
		{
			pb = new Mazgas();
			pr = new Mazgas(pb);
			pbt = pr;
			ss = null;
		}

		public void Pradzia() => ss = pr.Kitas;

		public void Kitas() => ss = ss.Kitas;

		public static Autoriai operator ++(Autoriai a)
		{
			a.ss = a.ss.Kitas;
			return a;
		}

		public bool Yra() => ss.Kitas != null;

		public void Deti(Autorius value)
		{
			pbt = pbt.Kitas = new Mazgas(value, pb);
		}

		public Autorius Imti() => ss.Duomenys;

		public void Iterpti(Autorius naujas)
		{
			Mazgas d;
			Mazgas ankstesnis = pr;
			for (d = pr.Kitas; d != pb && d.Duomenys >= naujas; d = d.Kitas)
			{
				ankstesnis = d;
			}

			ankstesnis.Kitas = new Mazgas(naujas, ankstesnis.Kitas);
		}

		public void Naikinti()
		{
			while (pr != null)
			{
				ss = pr;
				pr = pr.Kitas;
				ss.Kitas = null;
			}

			pb = pbt = ss = null;
		}

		public void RikiuotiMinMax()
		{
			for (Mazgas d1 = pr.Kitas; d1 != pb; d1 = d1.Kitas)
			{
				Mazgas max = d1;

				for (Mazgas d2 = d1.Kitas; d2 != pb; d2 = d2.Kitas)
				{
					if (d2.Duomenys >= max.Duomenys)
					{
						max = d2;
					}
				}

				(d1.Duomenys, max.Duomenys) = (max.Duomenys, d1.Duomenys);
			}
		}

		public void RikiuotiBurbuliukas()
		{
			if (pr.Kitas.Kitas == null) return;
			bool buvoKeitimu = true;
			while (buvoKeitimu)
			{
				buvoKeitimu = false;
				Mazgas d = pr.Kitas;
				while (d.Kitas.Kitas != null)
				{
					if (d.Kitas.Duomenys >= d.Duomenys)
					{
						(d.Duomenys, d.Kitas.Duomenys) = (d.Kitas.Duomenys, d.Duomenys);
						buvoKeitimu = true;
					}
					d = d.Kitas;
				}
			}
		}
	}

	class Program
	{

		const string duom = "duom.txt";

		static void Main(string[] args)
		{
			// Console.InputEncoding = Encoding.GetEncoding(1257);
			Console.OutputEncoding = Encoding.Unicode;

			Autoriai autoriai = new Autoriai();
			Skaityti(autoriai, duom);
			Spausdinti(autoriai, "Pradiniai duomenys:");

			// autoriai.RikiuotiBurbuliukas();
			autoriai.RikiuotiMinMax();
			Spausdinti(autoriai, "Surikiuoti duomenys:");

			autoriai.Iterpti(new Autorius("", "", "", 0));
			Spausdinti(autoriai, "Įterpta:");

			Autoriai nauji = new Autoriai();
			Formuoti(autoriai, nauji);
			Spausdinti(nauji, "Atrinkti duomenys:");

			Autorius brangiKnyga = BrangiausiaKnygaIgno(nauji);
			Console.WriteLine(brangiKnyga);

			BrangiausiosKnygosDovydas(nauji);

			nauji.Naikinti();

			Console.ReadKey();
		}

		static void Formuoti(Autoriai senas, Autoriai naujas)
		{
			var leidykla = senas.Pbt().Duomenys.Leidykla();
			for (senas.Pradzia(); senas.Yra(); senas++)
			{
				if (senas.Imti().Leidykla() == leidykla)
				{
					naujas.Deti(senas.Imti());
				}
			}
		}

		static void Skaityti(Autoriai A, string source)
		{
			using (var reader = new StreamReader(source))
			{
				// A = new Autoriai();
				string eil;
				while (!string.IsNullOrEmpty(eil = reader.ReadLine()))
				{
					var duom = eil.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
					A.Deti(new Autorius(duom[0], duom[1], duom[2], double.Parse(duom[3])));
				}
			}
		}

		static void Spausdinti(Autoriai A, string txt)
		{
			Console.WriteLine(txt);
			Console.WriteLine("|--------------------|---------------|---------------|------|");
			for (A.Pradzia(); A.Yra(); A++)
			{
				Console.WriteLine(A.Imti());
			}
			Console.WriteLine("|--------------------|---------------|---------------|------|\n");
		}

		static Autorius BrangiausiaKnygaIgno(Autoriai A)
		{
			Console.Write("Įveskite autoriaus vardą ir pavardę: ");
			var value = Console.ReadLine();
			Autorius max = new Autorius("", "", "", 0);
			for (A.Pradzia(); A.Yra(); A++)
			{
				var d = A.Imti();
				if (string.Compare(d.VardasPavarde(), value, StringComparison.CurrentCulture) == 0 && d.CompareTo(max) > 0)
				{
					max = d;
				}
			}
			if (max.Kaina() == 0) return null;
			else return max;
		}

		static void BrangiausiosKnygosDovydas(Autoriai A)
		{
			var results = new List<Autorius>();
			Console.Write("Įveskite autoriaus vardą ir pavardę: ");
			var value = Console.ReadLine();

			for (A.Pradzia(); A.Yra(); A++)
			{
				var autorius = A.Imti();
				if (string.Compare(autorius.VardasPavarde(), value, StringComparison.CurrentCulture) == 0)
				{
					if (results.Count == 0)
					{
						results.Add(autorius);
					}
					else
					{
						if (results[0].CompareTo(autorius) < 0)
						{
							results.Clear();
							results.Add(autorius);
						}
						else if (results[0].CompareTo(autorius) == 0)
						{
							results.Add(autorius);
						}
					}
				}
			}

			if (results.Count == 0)
			{
				Console.WriteLine("Nėra knygų\n");
			}
			else if (results.Count == 1)
			{
				Console.WriteLine($"Knyga:\n${results[0]}");
			}
			else
			{
				Console.WriteLine($"Knygos:\n{string.Join("\n", results)}");
			}

		}
	}
}
