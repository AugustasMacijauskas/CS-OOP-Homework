using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sportas
{
    class Sportininkas
    {
        public string Sportas { get; private set; }
        public string Komanda { get; private set; }
        public string Pavardė { get; private set; }
        public string Vardas { get; private set; }
        public int Rungtynės { get; private set; }

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
            return string.Format(" {0, -15} {1, -15} {2}         {3, -15} {4, 4:d} ", Pavardė, Vardas, Sportas, Komanda, Rungtynės);
        }

        public virtual void PapildomasRodiklis()
        {

        }
    }

    class Krepšininkas : Sportininkas
    {
        public int Taškai { get; set; }
        public int AtkovotiKamuoliai { get; set; }
        public int RezultatyvūsPerdavimai { get; set; }

        public Krepšininkas (string sport, string kom, string pvrd, string vrd, int rung, int tsk, int atk, int rezp) : base(sport, kom, pvrd, vrd, rung)
        {
            Taškai = tsk;
            AtkovotiKamuoliai = atk;
            RezultatyvūsPerdavimai = rezp;
        }

        public override string ToString()
        {
            return string.Format(" {0}          {1, 4:d}                       {2, 4:d}                           {3, 4:d} ", base.ToString(), Taškai, AtkovotiKamuoliai, RezultatyvūsPerdavimai);
        }
    }

    class Futbolininkas : Sportininkas
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
            return string.Format(" {0}          {1, 4:d}                       {2, 4:d} ", base.ToString(), Ivarciai, GeltonųKortelių);
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
        const string komandosDuom = "..\\..\\Komandos.txt";
        const string sportininkaiDuom = "..\\..\\Sportininkai.txt";
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
            SpausdintiKomandas(rez, komandos, "Pradiniai komandų duomenys:");

            List<Sportininkas> naujas = new List<Sportininkas>();
            Formuoti(sportininkai, naujas, komandos);
            SpausdintiSportininkus(rez, naujas, "Krepšininkai/futbolininkai, kurie žaidė visose varžybose ir įmetė taškų/pelnė įvarčių ne mažiau nei komandos vidurkis:");

            Console.WriteLine("Programa baigė darbą!");
        }

        static void Formuoti(List<Sportininkas> A, List<Sportininkas> naujas, List<Komanda> komandos)
        {
            double vidurkisK = SkaiciuotiVidurki(A, typeof(Krepšininkas));
            double vidurkisF = SkaiciuotiVidurki(A, typeof(Futbolininkas));
            Console.WriteLine(vidurkisK + " " + vidurkisF);

            for (int i = 0; i < A.Count; i++)
            {
                Komanda test = komandos.Find(x => (x.Pavadinimas == A[i].Komanda && x.Sportas == A[i].Sportas));
                if (A[i].Rungtynės == test.Rungtynės)
                {
                    Console.WriteLine(A[i].Pavardė + " " + A[i].Rungtynės + " " + test.Pavadinimas + " " + test.Rungtynės);
                    if (A[i].GetType() == typeof(Krepšininkas))
                    {
                        Krepšininkas temp = A[i] as Krepšininkas;
                        if (temp.Taškai >= vidurkisK)
                        {
                            Console.WriteLine(temp.Taškai);
                            naujas.Add(temp);
                        }
                    }
                    else if (A[i].GetType() == typeof(Futbolininkas))
                    {
                        Futbolininkas temp = A[i] as Futbolininkas;
                        if (temp.Ivarciai >= vidurkisF)
                        {
                            Console.WriteLine(temp.Ivarciai);
                            naujas.Add(temp);
                        }
                    }
                }
            }

        }

        //static Komanda RastiKomanda(Sportininkas A, List<Komanda> komandos)
        //{
        //    Komanda laikina = komandos[0];
        //    for (int i = 1; i < komandos.Count; i++)
        //    {
        //        if (A.Komanda == komandos[i].Pavadinimas)
        //        {
        //            return komandos[i];
        //        }
        //    }
        //}

        static double SkaiciuotiVidurki(List<Sportininkas> A, Type tipas)
        {
            double suma = 0;
            int kiekis = 0;
            for (int i = 0; i < A.Count; i++)
            {
                if (tipas == typeof(Krepšininkas) && A[i].GetType() == tipas)
                {
                    Krepšininkas naujas = A[i] as Krepšininkas;
                    suma += naujas.Taškai;
                    kiekis++;
                }
                else if (tipas == typeof(Futbolininkas) && A[i].GetType() == tipas)
                {
                    Futbolininkas naujas = A[i] as Futbolininkas;
                    suma += naujas.Ivarciai;
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
                    sportas = parts[0];
                    komanda = parts[1];
                    pavardė = parts[2];
                    vardas = parts[3];
                    rungtynės = int.Parse(parts[4]);

                    if (sportas == "k")
                    {
                        int taškai = int.Parse(parts[5]);
                        int atkovotiKamuoliai = int.Parse(parts[6]);
                        int rezultatyvūsPerdavimai = int.Parse(parts[7]);
                        Krepšininkas naujas = new Krepšininkas(sportas, komanda, pavardė, vardas, rungtynės, taškai, atkovotiKamuoliai, rezultatyvūsPerdavimai);
                        A.Add(naujas);
                    }
                    else if (sportas == "f")
                    {
                        int ivarciai = int.Parse(parts[5]);
                        int geltonųKortelių = int.Parse(parts[6]);
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
                    sportas = parts[0];
                    pavadinimas = parts[1];
                    miestas = parts[2];
                    treneris = parts[3];
                    rungtynės = int.Parse(parts[4]);
                    Komanda nauja = new Komanda(sportas, pavadinimas, miestas, treneris, rungtynės);
                    A.Add(nauja);
                }
            }
        }

        static void SpausdintiSportininkus(string rez, List<Sportininkas> A, string antraste)
        {
            const string virsus = "--------------------------------------------------------------------------------------------------------------------------------------------------------\r\n" +
                                  " Nr.  Pavardė         Vardas       Sportas      Komanda        Rungtynės  Taškai/Įvarčiai  Atkovoti kamuoliai/Geltonų kortelių  Rezultatyvūs perdavimai \r\n" +
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

        static void SpausdintiKomandas(string rez, List<Komanda> A, string antraste)
        {
            const string virsus = "-----------------------------------------------------------------------------------\r\n" +
                                  " Nr.  Pavadinimas  Sportas  Miestas         Treneris                     Rungtynės \r\n" +
                                  "-----------------------------------------------------------------------------------";

            using (var fr = File.AppendText(rez))
            {
                fr.WriteLine(antraste);
                if (A.Count > 0)
                {
                    fr.WriteLine(virsus);
                    for (int i = 0; i < A.Count; i++)
                    {
                        Komanda kom = A[i];
                        fr.WriteLine(" {0, 2:d} {1}", i + 1, kom.ToString());
                    }
                    fr.WriteLine("-----------------------------------------------------------------------------------\r\n");
                }
                else
                {
                    fr.WriteLine("Sąrašas tuščias!\n");
                }
            }
        }
    }
}
