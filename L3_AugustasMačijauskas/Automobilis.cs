using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L3_AugustasMačijauskas
{
    class Automobilis : AutomobilioBlueprint
    {
        public string ValstybinisNumeris { get; set; }
        public DateTime TechninėApžiūra { get; set; }
        public double VidutinėsSąnaudos { get; set; }

        public Automobilis(string valstNr, string gam, string mod, DateTime pag, DateTime tech, string kur, double vidSan) : base (gam, mod, pag, kur)
        {
            this.ValstybinisNumeris = valstNr;
            this.TechninėApžiūra = tech;
            this.VidutinėsSąnaudos = vidSan;
        }

        public static bool operator <(Automobilis a1, Automobilis a2)
        {
            int poz = string.Compare(a1.ValstybinisNumeris, a2.ValstybinisNumeris, StringComparison.CurrentCulture);

            return ((a1.TechninėApžiūra < a2.TechninėApžiūra) || ((a1.TechninėApžiūra == a2.TechninėApžiūra) && (poz < 0)));
        }

        public static bool operator >(Automobilis a1, Automobilis a2)
        {
            int poz = string.Compare(a1.ValstybinisNumeris, a2.ValstybinisNumeris, StringComparison.CurrentCulture);

            return ((a1.TechninėApžiūra > a2.TechninėApžiūra) || ((a1.TechninėApžiūra == a2.TechninėApžiūra) && (poz > 0)));
        }

        public static bool operator <=(Automobilis a1, Automobilis a2)
        {
            return a1.PagaminimoData < a2.PagaminimoData;
        }

        public static bool operator >=(Automobilis a1, Automobilis a2)
        {
            return a1.PagaminimoData > a2.PagaminimoData;
        }

        public override string ToString()
        {
            return string.Format("        {0, 6}           {1, -10}     {2, -20} {3:yyyy MM}            {4:yyyy MM dd}         {5, -15}    {6, 5:f1}", ValstybinisNumeris, Gamintojas, Modelis, PagaminimoData, TechninėApžiūra, Kuras, VidutinėsSąnaudos);
        }
    }
}
