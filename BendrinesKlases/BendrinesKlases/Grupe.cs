using System.Collections.Generic;
using System.Linq;

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

        public Studentas GeriausiasStudentas()
        {
            Studentas geriausias = StudentuSarasas[0];

            for (int i = 1; i < StudentuSarasas.Count; i++)
            {
                if (StudentuSarasas[i].Vidurkis > geriausias.Vidurkis)
                {
                    geriausias = StudentuSarasas[i];
                }
            }

            return geriausias;
        }
    }
}
