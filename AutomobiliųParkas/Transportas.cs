using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliųParkas
{
<<<<<<< HEAD
    abstract class Transportas : IComparable<Transportas>
=======
    abstract class Transportas
>>>>>>> cfc5373580dd3e017a31e595e5e73ffbdcc6884d
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

<<<<<<< HEAD
        public abstract double PapildomasRodiklis();

        public string TechninėApžiūraToString(DateTime techApžiūrosGaliojimoPabaiga)
        {
            return string.Format("{0}; {1}; {2} {3:yyyy MM dd}",
                this.Gamintojas,
                this.Modelis,
                this.ValstybinisNumeris,
                techApžiūrosGaliojimoPabaiga
            );
        }

        public override string ToString()
        {
            string type = this is Lengvasis ? "Lengvasis" : this is Krovininis ? "Krovininis" : "Mikroautobusas";
            return string.Format(
                "   {0, -15}         " + 
                "{1, -10}     " +
                "{2, -15} " +
                "{3, -15}    " +
                "{4:yyyy MM}                " +
                "{5:yyyy MM dd}             " +
                "{6, -10}             " +
                "{7, 4:f2}                      ",
                type, ValstybinisNumeris,
                Gamintojas,
                Modelis,
                PagaminimoData,
                TechninėApžiūra,
                Kuras,
                VidutinėsSąnaudos
            );
        }

        public int CompareTo(Transportas other)
        {
            if (this is Lengvasis && (other is Krovininis || other is Mikroautobusas))
                return 1;
            if (this is Krovininis && other is Lengvasis)
                return -1;
            if (this is Krovininis && other is Mikroautobusas)
                return 1;
            if (this is Mikroautobusas && (other is Lengvasis || other is Krovininis))
                return -1;
            if (this is Lengvasis && other is Lengvasis)
                return ((Lengvasis)this).CompareTo((Lengvasis)other);
            if (this is Krovininis && other is Krovininis)
                return ((Krovininis)this).CompareTo((Krovininis)other);
            if (this is Mikroautobusas && other is Mikroautobusas)
                return ((Mikroautobusas)this).CompareTo((Mikroautobusas)other);


            return 0;
=======
        public override string ToString()
        {
            return string.Format(" {0, -10}     {1, -7}         {2:yyyy MM}            {3, -15} ", Gamintojas, Modelis, PagaminimoData, Kuras);
>>>>>>> cfc5373580dd3e017a31e595e5e73ffbdcc6884d
        }
    }
}
