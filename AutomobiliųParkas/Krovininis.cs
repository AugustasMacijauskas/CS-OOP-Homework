using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliųParkas
{
    class Krovininis : Transportas
    {
        public double PriekabosTalpa { get; set; }

        public Krovininis(string valstNr, string gam, string mod, DateTime pag, DateTime tech, string kur, double vid, double talp) : base (valstNr, gam, mod, pag, tech, kur, vid)
        {
            this.PriekabosTalpa = talp;
        }
    }
}
