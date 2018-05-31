using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L3_AugustasMačijauskas
{
    abstract class AutomobilioBlueprint
    {
        public string Gamintojas { get; set; }
        public string Modelis { get; set; }
        public DateTime PagaminimoData { get; set; }
        public string Kuras { get; set; }

        public AutomobilioBlueprint(string gam, string mod, DateTime pag, string kur)
        {
            this.Gamintojas = gam;
            this.Modelis = mod;
            this.PagaminimoData = pag;
            this.Kuras = kur;
        }

        public override string ToString()
        {
            return string.Format(" {0, -10}     {1, -7}         {2:yyyy MM}            {3, -15} ", Gamintojas, Modelis, PagaminimoData, Kuras);
        }

        public abstract void Nusidėvėjimas();
    }
}
