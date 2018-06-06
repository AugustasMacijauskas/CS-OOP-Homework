using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliųParkas
{
    abstract class Transportas
    {
        public string ValstybinisNumeris { get; set; }
        public string Gamintojas { get; set; }
        public string Modelis { get; set; }
        public DateTime PagaminimoData { get; set; }
        public DateTime TechninėApžiūra { get; set; }
        public string Kuras { get; set; }
        public double VidutinėsSąnaudos { get; set; }

        public Transportas(string valstNr, string gam, string mod, DateTime pag, DateTime tech, string kur, double vid)
        {
            this.ValstybinisNumeris = valstNr;
            this.Gamintojas = gam;
            this.Modelis = mod;
            this.PagaminimoData = pag;
            this.TechninėApžiūra = tech;
            this.Kuras = kur;
            this.VidutinėsSąnaudos = vid;
        }

        public override string ToString()
        {
            return string.Format(" {0, -10}     {1, -7}         {2:yyyy MM}            {3, -15} ", Gamintojas, Modelis, PagaminimoData, Kuras);
        }
    }
}
