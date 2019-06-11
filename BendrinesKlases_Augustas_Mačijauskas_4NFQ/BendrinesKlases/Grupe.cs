using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BendrinesKlases
{
    class Grupe<T> where T : Studentas
    {
        public string Pavadinimas { get; private set; } //uždraudžiame pavadinimo keitimą
        public int Kursas { get; private set; }
        public string Specializacija { get; set; }
        public string Kuratorius { get; set; }
        public List<T> StudentuSarasas { get; private set; }

        public Grupe(string pavadinimas, int kursas, string specializacija, string kuratorius)
        {
            Pavadinimas = pavadinimas;
            Kursas = kursas;
            Specializacija = specializacija;
            Kuratorius = kuratorius;
            StudentuSarasas = new List<T>();
        }

        private double DidziausiasVidurkis()
        {
            double didVidurkis = StudentuSarasas[0].Vidurkis;

            for (int i = 0; i < StudentuSarasas.Count; i++)
            {
                if (StudentuSarasas[i].Vidurkis > didVidurkis)
                {
                    didVidurkis = StudentuSarasas[i].Vidurkis;
                }
            }

            return didVidurkis;
        }

        public List<Studentas> GeriausiStudentai()
        {
            double didVidurkis = DidziausiasVidurkis();

            List<Studentas> geriausi = new List<Studentas>();

            for (int i = 0; i < StudentuSarasas.Count; i++)
            {
                if (Math.Abs(StudentuSarasas[i].Vidurkis - didVidurkis) <= 0.001)
                {
                    if (StudentuSarasas[i] is Bakalauras)
                    {
                        var temp = StudentuSarasas[i] as Bakalauras;
                        geriausi.Add(new Bakalauras(temp.Vardas, temp.Pavarde, temp.PazymejimoNr, temp.Vidurkis, temp.Statusas));
                    }
                    else if (StudentuSarasas[i] is Magistrantas)
                    {
                        var temp = StudentuSarasas[i] as Magistrantas;
                        geriausi.Add(new Magistrantas(temp.Vardas, temp.Pavarde, temp.PazymejimoNr, temp.Vidurkis, temp.Statusas, temp.Tema));
                    }
                }
            }

            return geriausi;
        }
    }
}
