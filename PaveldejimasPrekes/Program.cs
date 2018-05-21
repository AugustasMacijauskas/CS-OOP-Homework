using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PaveldejimasPrekes
{
    abstract public class Preke : IComparable<Preke>
    {
        public string Pavadinimas { get; set; }
        public string Tipas { get; set; }
        public double Kaina { get; set; }

        /// <summary>
        /// Konstruktorius be parametrų
        /// </summary>
        public Preke()
        {

        }

        /// <summary>
        /// Konstruktorius su parametrais
        /// </summary>
        /// <param name="pav"></param>
        /// <param name="tipas"></param>
        /// <param name="kaina"></param>
        public Preke(string pav = "", string tipas = "", double kaina = 0.0)
        {
            Pavadinimas = pav;
            Tipas = tipas;
            Kaina = kaina;
        }

        abstract public double Suma();

        abstract public void DidintiKaina();

        public override string ToString()
        {
            string eil = "";
            eil = string.Format(" {0, -16}    {1, -20} {2, 5:f}", Pavadinimas, Tipas, Kaina);
            return eil;
        }

        public int CompareTo(Preke kita)
        {
            int poz = String.Compare(this.Pavadinimas, kita.Pavadinimas,
                                     StringComparison.CurrentCulture);

            if ((this.Kaina < kita.Kaina) || ((this.Kaina == kita.Kaina) && (poz > 0)))
                return 1;
            else
                return -1;
        }
    }

    class Prekes : Preke
    {
        public int Kiekis { get; set; }

        public Prekes()
        {

        }

        public Prekes(string pav = "", string tipas = "", double kaina = 0.0,
            int kiek = 0) : base (pav, tipas, kaina)
        {
            Kiekis = kiek;
        }

        public override string ToString()
        {
            string eil = "";
            eil = string.Format(" {0} {1, 6:d}", base.ToString(), Kiekis);
            return eil;
        }

        public override double Suma()
        {
            return Kiekis * Kaina;
        }

        public override void DidintiKaina()
        {
            Kaina = Kaina * 1.1;
        }
    }

    class Program
    {
        const string duom = "..\\..\\Prekes - Copy.txt";
        const string duom1 = "..\\..\\Prekes1 - Copy.txt";
        const string rez = "..\\..\\Rezultatai.txt";

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.GetEncoding(1257);

            if (File.Exists(rez))
                File.Delete(rez);
           
            List<Prekes> prekes = new List<Prekes>();
            Skaityti(duom, prekes);
            Spausdinti(rez, prekes, "Pradinis sąrašas:");

            List<Prekes> naujas = new List<Prekes>();
            Perrašyti(prekes, naujas);
            Console.WriteLine("Įveskite prekės tipą: ");
            string tipasPasalinti = Console.ReadLine();
            naujas.RemoveAll(item => item.Tipas == tipasPasalinti);
            Spausdinti(rez, naujas, "Suformuotas sąrašas:");
            if (naujas.Count > 0)
            {
                naujas.Sort();
                Spausdinti(rez, naujas, "Surikiuotas suformuotas sąrašas:");
                using (var fr = File.AppendText(rez))
                {
                    double vid = naujas.Average(item => item.Kiekis);
                    fr.WriteLine("Kiekio vidurkis: {0, 5:f}", vid);
                    
                    //double prekiuSuma = naujas.Sum(x => x.Suma());
                    double prekiuSuma = Sum(naujas);
                    fr.WriteLine("Naujo sąrašo prekių bendra suma: {0, 5:f}\n", prekiuSuma);
                }
            }
            else
            {
                using (var fr = File.AppendText(rez)) 
                {
                    fr.WriteLine("Veiksmai neatlikti - sąrašas tuščias!\n");
                }
            }

            List<Prekes> naujas1 = new List<Prekes>();
            Skaityti(duom1, naujas1);
            Spausdinti(rez, naujas1, "Nauji pradiniai duomenys:");
            Įterpti(naujas, naujas1, tipasPasalinti);
            Spausdinti(rez, naujas, "Nauji pradiniai duomenys įterpti į seną sąrašą:");

            foreach(Prekes pr in prekes)
                pr.DidintiKaina();

            foreach (Prekes pr in naujas)
                pr.DidintiKaina();

            foreach (Prekes pr in naujas1)
                pr.DidintiKaina();

            Spausdinti(rez, prekes, "Pradinis sąrašas su padidintomis kainomis:");
            Spausdinti(rez, naujas, "Antras sąrašas su padidintomis kainomis:");
            Spausdinti(rez, naujas1, "Naujas (trečias) sąrašas su padidintomis kainomis:");

            Console.WriteLine("Programa baigė darbą!");
        }

        static void Įterpti(List<Prekes> senas, List<Prekes> naujas, string tipas)
        {
            for (int i = 0; i < naujas.Count; i++)
            {
                if (naujas[i].Tipas != tipas)
                {
                    Prekes pr = new Prekes(naujas[i].Pavadinimas, naujas[i].Tipas,
                                       naujas[i].Kaina, naujas[i].Kiekis);
                    int ind = RastiVieta(senas, pr);
                    if (ind == senas.Count)
                    {
                        senas.Add(pr);
                    }
                    else
                    {
                        senas.Insert(ind, pr);
                    }
                }
            }
        }

        static int RastiVieta(List<Prekes> A, Prekes pr)
        {
            int index = A.Count;
            for (int i = 0; i < A.Count; i++)
            {
                if (pr.CompareTo(A[i]) == -1)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        static double Sum(List<Prekes> A)
        {
            double suma = 0;
            for (int i = 0; i < A.Count; i++)
                suma = suma + A[i].Suma();
            return suma;
        }

        static void Perrašyti(List<Prekes> senas, List<Prekes> naujas)
        {
            for (int i = 0; i < senas.Count; i++)
            {
                Prekes p = new Prekes(senas[i].Pavadinimas, senas[i].Tipas,
                                      senas[i].Kaina, senas[i].Kiekis);
                naujas.Add(p);
            }
        }

        static void Skaityti(string duom, List<Prekes> A)
        {
            using (StreamReader reader = new StreamReader(duom, Encoding.GetEncoding(1257)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string pav = parts[0].Trim();
                    string tema = parts[1].Trim();
                    double kaina = double.Parse(parts[2]);
                    int kiek = int.Parse(parts[3]);
                    Prekes pr = new Prekes(pav, tema, kaina, kiek);
                    A.Add(pr);
                }
            }
        }

        static void Spausdinti(string rez, List<Prekes> A ,string info)
        {
            const string virsus = "----------------------------------------------------------\r\n" +
                                  " Pavadinimas          Tipas                Kaina   Kiekis \r\n" +
                                  "----------------------------------------------------------";

            using (var fr = File.AppendText(rez))
            {
                fr.WriteLine(info);
                if (A.Count > 0)
                {
                    fr.WriteLine(virsus);
                    for (int i = 0; i < A.Count; i++)
                    {
                        Prekes pr = A[i];
                        fr.WriteLine("{0}", pr.ToString());
                    }
                    fr.WriteLine("--------------------------------------------------" +
                                 "--------\r\n");
                }
                else
                {
                    fr.WriteLine("Sąrašas tuščias!\n");
                }
            }
        }
    }
}