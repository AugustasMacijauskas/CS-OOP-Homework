namespace BendrinesKlasesSavarankiskas
{
    enum Statusas {
        VF,
        VNF
    }

    abstract class Studentas
    {
        public string Vardas { get; set; }
        public string Pavardė { get; set; }
        public string PažymėjimoNumeris { get; set; }
        public double Vidurkis { get; set; }
        public Statusas Statusas { get; set; }

        public Studentas() { }

        public Studentas(string var, string pav, string paz, double vid, Statusas stat) {
            this.Vardas = var;
            this.Pavardė = pav;
            this.PažymėjimoNumeris = paz;
            this.Vidurkis = vid;
            this.Statusas = stat;
        }

        public override string ToString()
        {
            return string.Format(" {0} {1} {2} {3, 6:f1} {4} ", this.Vardas, this.Pavardė, this.PažymėjimoNumeris, this.Vidurkis, this.Statusas);
        }
    }
}
