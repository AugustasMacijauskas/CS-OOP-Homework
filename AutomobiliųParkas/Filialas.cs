using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliųParkas
{
    class Filialas
    {
        private FilialoDuomenys filialas;
        private List<Transportas> automobiliai;

        public Filialas(FilialoDuomenys filialas, List<Transportas> automobiliai)
        {
            this.filialas = filialas;
            this.automobiliai = automobiliai;
        }

        private string PrintCars()
        {
            string ret = "";
            for (int i = 0; i < automobiliai.Count; i++)
            {
                ret += "   " + (i + 1).ToString() + automobiliai[i].ToString() + "\n";
            }

            return ret;
        }

        public FilialoDuomenys FilialoDuomenys()
        {
            return this.filialas;
        }

        public override string ToString()
        {
            const string header = "Automobiliai:\r\n" +
                                  "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\r\n" +
                                  " Nr.   Tipas            Valstybinis numeris   Gamintojas      Modelis        Pagaminimo data     Techninės apžiūros data       Kuras        Vidutinės sąnaudos/100km     Papildomas rodiklis \r\n" +
                                  "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\r\n";
            return filialas.ToString() + header + this.PrintCars() + "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\r\n";
        }

        public List<Transportas> FilialoAutomobiliai()
        {
            return automobiliai;
        }
    }
}
