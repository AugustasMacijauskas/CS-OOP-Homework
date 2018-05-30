using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sportas
{
    abstract class Sportininkas : IComparable<Sportininkas>
    {
        public string Sportas { get; set; }
        public string Komanda { get; set; }
        public string Pavardė { get; set; }
        public string Vardas { get; set; }
        public int Rungtynės { get; set; }

        public Sportininkas(string sport, string kom, string pvrd, string vrd, int rung)
        {
            Sportas = sport;
            Komanda = kom;
            Pavardė = pvrd;
            Vardas = vrd;
            Rungtynės = rung;
        }

        public override string ToString()
        {
            return string.Format(" {0, -15} {1, -15} {2}         {3, -15}  {4, 4:d} ", Pavardė, Vardas, Sportas, Komanda, Rungtynės);
        }

        public abstract int SkaičiuotiVidurkį();

        public abstract int SkaičiuotiPapildomąVidurkį();

        public abstract int Rikiuoti();

        public int CompareTo(Sportininkas other)
        {
            if (this is Krepšininkas && other is Futbolininkas)
                return -1;
            if (this is Futbolininkas && other is Krepšininkas)
                return 1;
            if (this is Krepšininkas && other is Krepšininkas)
                return ((Krepšininkas)this).CompareTo((Krepšininkas)other);
            if (this is Futbolininkas && other is Futbolininkas)
                return ((Futbolininkas)this).CompareTo((Futbolininkas)other);

            return 0;
        }
    }

    class Krepšininkas : Sportininkas, IComparable<Krepšininkas>
    {
        public int Taškai { get; set; }
        public int AtkovotiKamuoliai { get; set; }
        public int RezultatyvūsPerdavimai { get; set; }

        public Krepšininkas(string sport, string kom, string pvrd, string vrd, int rung, int tsk, int atk, int rezp) : base(sport, kom, pvrd, vrd, rung)
        {
            Taškai = tsk;
            AtkovotiKamuoliai = atk;
            RezultatyvūsPerdavimai = rezp;
        }

        public override string ToString()
        {
            return string.Format(" {0}          {1, 4:d}                         {2, 4:d}                           {3, 4:d} ", base.ToString(), Taškai, RezultatyvūsPerdavimai, AtkovotiKamuoliai);
        }

        public override int SkaičiuotiVidurkį()
        {
            return this.Taškai;
        }

        public override int SkaičiuotiPapildomąVidurkį()
        {
            return this.RezultatyvūsPerdavimai;
        }

        public override int Rikiuoti()
        {
            return this.RezultatyvūsPerdavimai;
        }

        public int CompareTo(Krepšininkas other)
        {
            return RezultatyvūsPerdavimai.CompareTo(other.RezultatyvūsPerdavimai);
        }

        public static bool operator <(Krepšininkas k1, Krepšininkas k2)
        {
            return k1.RezultatyvūsPerdavimai < k2.RezultatyvūsPerdavimai;
        }

        public static bool operator >(Krepšininkas k1, Krepšininkas k2)
        {
            return k1.RezultatyvūsPerdavimai > k2.RezultatyvūsPerdavimai;
        }
    }

    class Futbolininkas : Sportininkas, IComparable<Futbolininkas>
    {
        public int Ivarciai { get; set; }
        public int GeltonųKortelių { get; set; }

        public Futbolininkas(string sport, string kom, string pvrd, string vrd, int rung, int iv, int kort) : base(sport, kom, pvrd, vrd, rung)
        {
            Ivarciai = iv;
            GeltonųKortelių = kort;
        }

        public override string ToString()
        {
            return string.Format(" {0}          {1, 4:d}                         {2, 4:d} ", base.ToString(), Ivarciai, GeltonųKortelių);
        }

        public override int SkaičiuotiVidurkį()
        {
            return this.Ivarciai;
        }

        public override int SkaičiuotiPapildomąVidurkį()
        {
            return this.GeltonųKortelių;
        }

        public static bool operator <(Futbolininkas f1, Futbolininkas f2)
        {
            return f1.GeltonųKortelių < f2.GeltonųKortelių;
        }

        public static bool operator >(Futbolininkas f1, Futbolininkas f2)
        {
            return f1.GeltonųKortelių > f2.GeltonųKortelių;
        }

        public override int Rikiuoti()
        {
            return this.GeltonųKortelių;
        }

        public int CompareTo(Futbolininkas other)
        {
            return -GeltonųKortelių.CompareTo(other.GeltonųKortelių);
        }
    }

    class Komanda
    {
        public string Sportas { get; set; }
        public string Pavadinimas { get; set; }
        public string Miestas { get; set; }
        public string Treneris { get; set; }
        public int Rungtynės { get; set; }

        public Komanda(string sport, string pav, string mst, string tr, int rungt)
        {
            Sportas = sport;
            Pavadinimas = pav;
            Miestas = mst;
            Treneris = tr;
            Rungtynės = rungt;
        }

        public override string ToString()
        {
            return string.Format("  {0, -15} {1}     {2, -15} {3, -30} {4, 4:d}", Pavadinimas, Sportas, Miestas, Treneris, Rungtynės);
        }
    }

    class Program
    {
        const string komandosDuom = "..\\..\\Komandos2.txt";
        const string sportininkaiDuom = "..\\..\\Sportininkai2.txt";
        const string rez = "..\\..\\Rezultatai.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            List<Sportininkas> sportininkai = new List<Sportininkas>();
            List<Komanda> komandos = new List<Komanda>();
            SkaitytiSportininkus(sportininkaiDuom, sportininkai);
            SkaitytiKomandas(komandosDuom, komandos);

            if (File.Exists(rez))
                File.Delete(rez);
            SpausdintiSportininkus(rez, sportininkai, "Pradiniai sportininkų duomenys:");
            SpausdintiKomandas(rez, komandos, sportininkai, "Pradiniai komandų duomenys:");

            List<Sportininkas> naujas = new List<Sportininkas>();
            Formuoti(sportininkai, naujas, komandos);
            if (naujas.Count > 0)
            {
                SpausdintiSportininkus(rez, naujas, "Krepšininkai/futbolininkai, kurie žaidė visose varžybose ir atitiko vidurkio kriterijus:");

                Rikiuoti(naujas, typeof(Futbolininkas));
                Rikiuoti(naujas, typeof(Krepšininkas));
                SpausdintiSportininkus(rez, naujas, "Surikiuotas masyvas:");
            }
            else
            {
                PrintText(rez, "Suformuotas sąrašas tuščias!");
            }

            Console.WriteLine("Programa baigė darbą!");
        }

        static void Rikiuoti(List<Sportininkas> A, Type tipas)
        {
            int minIndex;
            for (int i = 0; i < A.Count - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < A.Count; j++)
                {
                    if (A[j].CompareTo(A[minIndex]) == 1)
                    {
                        minIndex = j;
                    }
                }
                var temp = A[i];
                A[i] = A[minIndex];
                A[minIndex] = temp;
            }
        }

        static void PrintText(string fn, string text)
        {
            using (var writer = File.AppendText(fn))
            {
                writer.WriteLine(text);
            }
        }

        static void Formuoti(List<Sportininkas> A, List<Sportininkas> naujas, List<Komanda> komandos)
        {
            for (int i = 0; i < A.Count; i++)
            {
                Komanda tempKomanda = komandos.Find(x => (x.Pavadinimas == A[i].Komanda && x.Sportas == A[i].Sportas));
                double vidurkis = SkaiciuotiVidurki(A, tempKomanda);
                double papildomasVidurkis = SkaiciuotiPapildomaVidurki(A, tempKomanda);
                var tempSportininkas = A[i];
                Console.WriteLine($"Vidurkis: {vidurkis}");
                Console.WriteLine($"Papildomas vidurkis: {papildomasVidurkis}");

                if (tempSportininkas.Rungtynės == tempKomanda.Rungtynės)
                {
                    naujas.Add(A[i]);
                    //Console.WriteLine(A[i].Pavardė + " " + tempSportininkas.Rungtynės + " " + tempKomanda.Pavadinimas + " " + tempKomanda.Rungtynės);
                    //if (tempSportininkas.SkaičiuotiVidurkį() >= vidurkis)
                    //{
                    //    if (tempSportininkas is Krepšininkas && tempSportininkas.SkaičiuotiPapildomąVidurkį() > papildomasVidurkis)
                    //    {
                    //        naujas.Add(A[i]);
                    //    }
                    //    else if (tempSportininkas is Futbolininkas && tempSportininkas.SkaičiuotiPapildomąVidurkį() < papildomasVidurkis)
                    //    {
                    //        naujas.Add(A[i]);
                    //    }
                    //}
                }
            }
        }

        static double SkaiciuotiPapildomaVidurki(List<Sportininkas> A, Komanda komanda)
        {
            double suma = 0;
            int kiekis = 0;
            for (int i = 0; i < A.Count; i++)
            {
                var temp = A[i];
                if (temp.Sportas == komanda.Sportas && temp.Komanda == komanda.Pavadinimas)
                {
                    suma += temp.SkaičiuotiPapildomąVidurkį();
                    kiekis++;
                }
            }

            return suma / kiekis;
        }

        static double SkaiciuotiVidurki(List<Sportininkas> A, Komanda komanda)
        {
            double suma = 0;
            int kiekis = 0;
            for (int i = 0; i < A.Count; i++)
            {
                var temp = A[i];
                if (temp.Sportas == komanda.Sportas && temp.Komanda == komanda.Pavadinimas)
                {
                    suma += temp.SkaičiuotiVidurkį();
                    kiekis++;
                }
            }

            return suma / kiekis;
        }

        static void SkaitytiSportininkus(string duom, List<Sportininkas> A)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string line;
                string[] parts;
                string sportas;
                string komanda;
                string pavardė;
                string vardas;
                int rungtynės;

                while ((line = reader.ReadLine()) != null)
                {
                    parts = line.Split(';');
                    sportas = parts[0].Trim();
                    komanda = parts[1].Trim();
                    pavardė = parts[2].Trim();
                    vardas = parts[3].Trim();
                    rungtynės = int.Parse(parts[4].Trim());

                    if (sportas == "k")
                    {
                        int taškai = int.Parse(parts[5].Trim());
                        int atkovotiKamuoliai = int.Parse(parts[6].Trim());
                        int rezultatyvūsPerdavimai = int.Parse(parts[7].Trim());
                        Krepšininkas naujas = new Krepšininkas(sportas, komanda, pavardė, vardas, rungtynės, taškai, atkovotiKamuoliai, rezultatyvūsPerdavimai);
                        A.Add(naujas);
                    }
                    else if (sportas == "f")
                    {
                        int ivarciai = int.Parse(parts[5].Trim());
                        int geltonųKortelių = int.Parse(parts[6].Trim());
                        Futbolininkas naujas = new Futbolininkas(sportas, komanda, pavardė, vardas, rungtynės, ivarciai, geltonųKortelių);
                        A.Add(naujas);
                    }
                }
            }
        }

        static void SkaitytiKomandas(string duom, List<Komanda> A)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string line;
                string[] parts;
                string sportas;
                string pavadinimas;
                string miestas;
                string treneris;
                int rungtynės;

                while ((line = reader.ReadLine()) != null)
                {
                    parts = line.Split(';');
                    sportas = parts[0].Trim();
                    pavadinimas = parts[1].Trim();
                    miestas = parts[2].Trim();
                    treneris = parts[3].Trim();
                    rungtynės = int.Parse(parts[4].Trim());
                    Komanda nauja = new Komanda(sportas, pavadinimas, miestas, treneris, rungtynės);
                    A.Add(nauja);
                }
            }
        }

        static void SpausdintiSportininkus(string rez, List<Sportininkas> A, string antraste)
        {
            const string virsus = "--------------------------------------------------------------------------------------------------------------------------------------------------------\r\n" +
                                  " Nr.  Pavardė         Vardas       Sportas      Komanda        Rungtynės  Taškai/Įvarčiai  Rezultatyvūs perdavimai/Geltonų kortelių  Atkovoti kamuoliai \r\n" +
                                  "--------------------------------------------------------------------------------------------------------------------------------------------------------";

            using (var fr = File.AppendText(rez))
            {
                fr.WriteLine(antraste);
                if (A.Count > 0)
                {
                    fr.WriteLine(virsus);
                    for (int i = 0; i < A.Count; i++)
                    {
                        Sportininkas sp = A[i];
                        fr.WriteLine(" {0, 2:d} {1}", i + 1, sp.ToString());
                    }
                    fr.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------\r\n");
                }
                else
                {
                    fr.WriteLine("Sąrašas tuščias!\n");
                }
            }
        }

        static void SpausdintiKomandas(string rez, List<Komanda> A, List<Sportininkas> B, string antraste)
        {
            const string virsus = "------------------------------------------------------------------------------------------------------------------------\r\n" +
                                  " Nr.  Pavadinimas  Sportas  Miestas         Treneris                     Rungtynės     Vidurkis     Papildomas vidurkis \r\n" +
                                  "------------------------------------------------------------------------------------------------------------------------";

            using (var fr = File.AppendText(rez))
            {
                fr.WriteLine(antraste);
                if (A.Count > 0)
                {
                    fr.WriteLine(virsus);
                    for (int i = 0; i < A.Count; i++)
                    {
                        Komanda kom = A[i];
                        fr.WriteLine(" {0, 2:d} {1}         {2, 6:f1}             {3, 6:f1}", i + 1, kom.ToString(), SkaiciuotiVidurki(B, kom), SkaiciuotiPapildomaVidurki(B, kom));
                    }
                    fr.WriteLine("------------------------------------------------------------------------------------------------------------------------\r\n");
                }
                else
                {
                    fr.WriteLine("Sąrašas tuščias!\n");
                }
            }
        }
    }
}
