using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L3_AugustasMačijauskas
{
    class Automobilis
    {
        public string ValstybinisNumeris { get; set; }
        public string Gamintojas { get; set; }
        public string Modelis { get; set; }
        public DateTime PagaminimoData { get; set; }
        public DateTime TechninėApžiūra { get; set; }
        public double Kuras { get; set; }
        public double VidutinėsSąnaudos { get; set; }

        public Automobilis(string valstNr, string gam, string mod, DateTime pag, DateTime tech, double kur, double vidSan)
        {
            this.ValstybinisNumeris = valstNr;
            this.Gamintojas = gam;
            this.Modelis = mod;
            this.PagaminimoData = pag;
            this.TechninėApžiūra = tech;
            this.Kuras = kur;
            this.VidutinėsSąnaudos = vidSan;
        }

        public static bool operator <=(Automobilis a1, Automobilis a2)
        {
            int poz = string.Compare(a1.ValstybinisNumeris, a2.ValstybinisNumeris, StringComparison.CurrentCulture);

            return ((a1.TechninėApžiūra < a2.TechninėApžiūra) || ((a1.TechninėApžiūra == a2.TechninėApžiūra) && (poz < 0)));
        }

        public static bool operator >=(Automobilis a1, Automobilis a2)
        {
            int poz = string.Compare(a1.ValstybinisNumeris, a2.ValstybinisNumeris, StringComparison.CurrentCulture);

            return ((a1.TechninėApžiūra > a2.TechninėApžiūra) || ((a1.TechninėApžiūra == a2.TechninėApžiūra) && (poz > 0)));
        }

        public override string ToString()
        {
            return string.Format(" {0, -20}    {1, -10}     {2, -7}         {3:yyyy MM}            {4:yyyy MM dd}            {5, 5:f1}             {6, 5:f1}", ValstybinisNumeris, Gamintojas, Modelis, PagaminimoData, TechninėApžiūra, Kuras, VidutinėsSąnaudos);
        }
    }
}
