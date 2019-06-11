using System;

namespace BendrinesKlases
{
    enum Statusas
    {
        VF, //valstybės finansuojama vieta
        VNF //valstybės nefinansuojama vieta
    }

    abstract class Studentas : IComparable<Studentas>
    {
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public string PazymejimoNr { get; set; }
        public double Vidurkis { get; set; }
        public Statusas Statusas { get; set; }

        public Studentas() { }

        public Studentas(string vardas, string pavarde, string pazymejimoNr, double vidurkis, Statusas statusas)
        {
            Vardas = vardas;
            Pavarde = pavarde;
            PazymejimoNr = pazymejimoNr;
            Statusas = statusas;
        }

        public int CompareTo(Studentas other)
        {
            int poz1 = String.Compare(Pavarde, other.Pavarde, StringComparison.CurrentCulture);
            int poz2 = String.Compare(Vardas, other.Vardas, StringComparison.CurrentCulture);

            if (poz1 < 0)
            {
                return -1;
            }
            else if (poz1 == 0)
            {
                if (poz2 < 0)
                {
                    return -1;
                }
                else if (poz2 == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }
    }
}
