using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliųParkas
{
<<<<<<< HEAD
    class Mikroautobusas : Transportas, IComparable<Mikroautobusas>
    {
        public int SėdimųVietų { get; set; }

        public Mikroautobusas(string valstNr, string gam, string mod, DateTime pag, DateTime tech, string kur, double vid, int vietu) : base(valstNr, gam, mod, pag, tech, kur, vid)
=======
    class Mikroautobusas : Transportas
    {
        public int SėdimųVietų { get; set; }

        public Mikroautobusas(string valstNr, string gam, string mod, DateTime pag, DateTime tech, string kur, double vid, int vietu) : base (valstNr, gam, mod, pag, tech, kur, vid)
>>>>>>> cfc5373580dd3e017a31e595e5e73ffbdcc6884d
        {
            this.SėdimųVietų = vietu;
        }

<<<<<<< HEAD
        public override double PapildomasRodiklis()
        {
            return this.SėdimųVietų;
        }

        public override string ToString()
        {
            return base.ToString() + $"{SėdimųVietų}";
        }

        public int CompareTo(Mikroautobusas other)
        {
            return SėdimųVietų.CompareTo(other.SėdimųVietų);
        }
=======
>>>>>>> cfc5373580dd3e017a31e595e5e73ffbdcc6884d
    }
}
