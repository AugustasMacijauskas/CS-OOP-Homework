using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliųParkas
{
    class Mikroautobusas : Transportas
    {
        public int SėdimųVietų { get; set; }

        public Mikroautobusas(string valstNr, string gam, string mod, DateTime pag, DateTime tech, string kur, double vid, int vietu) : base (valstNr, gam, mod, pag, tech, kur, vid)
        {
            this.SėdimųVietų = vietu;
        }

    }
}
