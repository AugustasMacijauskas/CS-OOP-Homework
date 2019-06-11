namespace BendrinesKlases
{
    class Magistrantas : Studentas
    {
        public string Tema { get; set; }

        public Magistrantas() { }

        public Magistrantas(string vardas, string pavarde, string pazymejimoNr, double vidurkis, Statusas statusas, string tema)
            : base(vardas, pavarde, pazymejimoNr, vidurkis, statusas)
        {
            Tema = tema;
        }
    }
}
