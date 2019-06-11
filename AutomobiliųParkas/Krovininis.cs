using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliųParkas
{
<<<<<<< HEAD
    class Krovininis : Transportas, IComparable<Krovininis>
    {
        public double PriekabosTalpa { get; set; }

        public Krovininis(string valstNr, string gam, string mod, DateTime pag, DateTime tech, string kur, double vid, double talp) : base(valstNr, gam, mod, pag, tech, kur, vid)
        {
            this.PriekabosTalpa = talp;
        }

        public override double PapildomasRodiklis()
        {
            return this.PriekabosTalpa;
        }

        public override string ToString()
        {
            return base.ToString() + $"{PriekabosTalpa}";
        }

        public int CompareTo(Krovininis other)
        {
            return PriekabosTalpa.CompareTo(other.PriekabosTalpa);
        }

        public static bool operator <(Krovininis k1, Krovininis k2)
        {
            int poz1 = String.Compare(k1.Gamintojas, k2.Gamintojas, StringComparison.CurrentCulture);
            int poz2 = String.Compare(k1.Modelis, k2.Modelis, StringComparison.CurrentCulture);
            return ((poz1 < 0) || ((poz1 == 0) && (poz2 < 0)));
        }

        public static bool operator >(Krovininis k1, Krovininis k2)
        {
            int poz1 = String.Compare(k1.Gamintojas, k2.Gamintojas, StringComparison.CurrentCulture);
            int poz2 = String.Compare(k1.Modelis, k2.Modelis, StringComparison.CurrentCulture);
            return ((poz1 > 0) || ((poz1 == 0) && (poz2 > 0)));
        }
    }
}
=======
    class Krovininis : Transportas
    {
        public double PriekabosTalpa { get; set; }

        public Krovininis(string valstNr, string gam, string mod, DateTime pag, DateTime tech, string kur, double vid, double talp) : base (valstNr, gam, mod, pag, tech, kur, vid)
        {
            this.PriekabosTalpa = talp;
        }
    }
}
>>>>>>> cfc5373580dd3e017a31e595e5e73ffbdcc6884d
