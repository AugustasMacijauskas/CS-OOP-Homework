using System;

namespace Sportas
{
	internal class Krepsininkas : Zaidejas
	{
		public int AtkovotaKamuoliu;
		public int RezultatyviuPerdavimu;

		public Krepsininkas(string vardas = "", string pavarde = "", int zaistaRungtyniu = 0, int taskai = 0,
							int atkovotaKamuoliu = 0, int rezultatyviuPerdavimu = 0, Komanda komanda = null) : base(vardas, pavarde, zaistaRungtyniu, taskai, komanda) {
			AtkovotaKamuoliu = atkovotaKamuoliu;
			RezultatyviuPerdavimu = rezultatyviuPerdavimu;
		}
	}

	internal class Futbolininkas : Zaidejas
	{
		public int GeltonuKorteliu;

		public Futbolininkas(string vardas = "", string pavarde = "", int zaistaRungtyniu = 0, int taskai = 0,
							 int geltonuKorteliu = 0, Komanda komanda = null) : base(vardas, pavarde, zaistaRungtyniu, taskai, komanda) {
			GeltonuKorteliu = geltonuKorteliu;
		}
	}

	internal class Zaidejas : IComparable<Zaidejas>
	{
		public string Vardas, Pavarde;
		public int ZaistaRungtyniu;
		public int Taskai;
		public Komanda Komanda;

		public Zaidejas(string vardas = "", string pavarde = "", int zaistaRungtyniu = 0, int taskai = 0, Komanda komanda = null) {
			Vardas = vardas;
			Pavarde = pavarde;
			ZaistaRungtyniu = zaistaRungtyniu;
			Taskai = taskai;
			Komanda = komanda;
		}

		public int CompareTo(Zaidejas other) {
			return other.Taskai.CompareTo(Taskai);
		}
	}
}