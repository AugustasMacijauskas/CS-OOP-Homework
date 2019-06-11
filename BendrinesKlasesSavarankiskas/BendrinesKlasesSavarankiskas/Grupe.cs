using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BendrinesKlasesSavarankiskas
{
    class Grupe<T> where T : Studentas
    {
        public string Pavadinimas { get; private set; }
        public int Kursas { get; private set; }
        public string Specializacija { get; set; }
        public string Kuratorius { get; set; }
        public List<Studentas> Studentai { get; private set; }

        public Grupe(string pav, int kursas, string spec, string kur)
        {
            this.Pavadinimas = pav;
            this.Kursas = kursas;
            this.Specializacija = spec;
            this.Kuratorius = kur;
            this.Studentai = new List<Studentas>();
        }
    }
}
