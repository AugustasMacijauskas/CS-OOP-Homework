using System.Collections.Generic;
using System.Linq;

namespace Sportas
{
	internal class FutboloKomanda : Komanda
	{
		public FutboloKomanda(string pavadinimas = "?", string miestas = "?", string treneris = "?", int zaistaRungtyniu = 0,
							  List<Zaidejas> zaidejai = null) : base(pavadinimas, miestas, treneris, zaistaRungtyniu, zaidejai) { }

		public override List<Zaidejas> GeriausiZaidejai() {
			double taskuVidurkis = TaskuVidurkis();
			double geltonuKort = GeltonuKortVidurkis();
			return Zaidejai.Where(f => f.ZaistaRungtyniu == ZaistaRungtyniu
									   && f.Taskai >= taskuVidurkis
									   && ((Futbolininkas)f).GeltonuKorteliu <= geltonuKort).ToList();
		}

		public double GeltonuKortVidurkis() {
			return Zaidejai.Average(f => ((Futbolininkas)f).GeltonuKorteliu);
		}

		public override void Rikiuok() {
			Zaidejai.Sort(new Futbolininkas_RikiuokPagalKorteles());
		}

		public class Futbolininkas_RikiuokPagalKorteles : IComparer<Zaidejas>
		{
			public int Compare(Zaidejas x, Zaidejas y) {
				return ((Futbolininkas)x).GeltonuKorteliu.CompareTo(((Futbolininkas)y).GeltonuKorteliu);
			}
		}
	}

	internal class KrepsinioKomanda : Komanda
	{
		public KrepsinioKomanda(string pavadinimas = "?", string miestas = "?", string treneris = "?",
								int zaistaRungtyniu = 0, List<Zaidejas> zaidejai = null) : base(pavadinimas, miestas, treneris,
			zaistaRungtyniu, zaidejai) { }

		public override List<Zaidejas> GeriausiZaidejai() {
			double taskuVidurkis = TaskuVidurkis();
			double rezultatyvPerd = RezultatyviuPerdVidurkis();
			return Zaidejai.Where(k => k.ZaistaRungtyniu == ZaistaRungtyniu
									   && k.Taskai >= taskuVidurkis
									   && ((Krepsininkas)k).RezultatyviuPerdavimu >= rezultatyvPerd).ToList();
		}

		public double RezultatyviuPerdVidurkis() {
			return Zaidejai.Average(k => ((Krepsininkas)k).RezultatyviuPerdavimu);
		}

		public class Krepsininkas_RikiuokPagalPerdavimus : IComparer<Zaidejas>
		{
			public int Compare(Zaidejas x, Zaidejas y) {
				return ((Krepsininkas)y).RezultatyviuPerdavimu.CompareTo(((Krepsininkas)x).RezultatyviuPerdavimu);
			}
		}

		public override void Rikiuok() {
			Zaidejai.Sort(new Krepsininkas_RikiuokPagalPerdavimus());
		}
	}

	internal class Komanda
	{
		public string Pavadinimas;
		public string Miestas;
		public string Treneris;
		public int ZaistaRungtyniu;
		public List<Zaidejas> Zaidejai;

		public Komanda(string pavadinimas = "?", string miestas = "?", string treneris = "?", int zaistaRungtyniu = 0,
					   List<Zaidejas> zaidejai = null) {
			Pavadinimas = pavadinimas;
			Miestas = miestas;
			Treneris = treneris;
			ZaistaRungtyniu = zaistaRungtyniu;
			Zaidejai = zaidejai ?? new List<Zaidejas>();
		}

		public void Add(Zaidejas z) {
			Zaidejai.Add(z);
		}

		public virtual List<Zaidejas> GeriausiZaidejai() {
			return new List<Zaidejas>(Zaidejai);
		}

		public double TaskuVidurkis() {
			return Zaidejai.Average(z => z.Taskai);
		}

		public override string ToString() {
			return $"{Pavadinimas} {Miestas} {Treneris}, žaidė: {ZaistaRungtyniu}";
		}

		public virtual void Rikiuok() {
			Zaidejai.Sort();
		}
	}
}