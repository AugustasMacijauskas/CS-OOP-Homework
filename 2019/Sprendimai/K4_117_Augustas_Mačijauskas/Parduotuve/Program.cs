using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Parduotuve
{
    class Pardavejas
    {
        private string VP;
        private int amzius;
        private int stazas;
        private int kategorija;

        public Pardavejas(string pavvrd, int amz, int staz, int kateg)
        {
            VP = pavvrd;
            amzius = amz;
            stazas = staz;
            kategorija = kateg;
        }

        public Pardavejas()
        {
            VP = "NA";
            amzius = 0;
            stazas = 0;
            kategorija = 0;
        }

        public string ImtiVardaPavarde() { return VP; }
        public int ImtiAmziu() { return amzius; }
        public int ImtiStaza() { return stazas; }
        public int ImtiKategorija() { return kategorija; }

        public override string ToString()
        {
            string eil;
            eil = String.Format(" {0, -20} {1, 3:d}       {2, 3:d}         {3, 3:d}", VP, amzius, stazas, kategorija);
            return eil;
        }
    }

    class Parduotuve
    {
        const int Max = 20;
        private Pardavejas[] pard;
        private int n;

        const int MaxEil = 20;
        const int MaxStulp = 10;
        private int[,] pajamos;
        private int nn;
        private int mm;

        public Parduotuve()
        {
            pard = new Pardavejas[Max];
            n = 0;

            pajamos = new int[MaxEil, MaxStulp];
            nn = 0;
            mm = 0;
        }

        public int Imti() { return n; }

        public Pardavejas ImtiPardaveja(int i) { return pard[i]; }

        public void DetiPardaveja(Pardavejas ob) { pard[n++] = ob; }

        public void DetiN(int x) { nn = x; }

        public void DetiM(int x) { mm = x; }

        public int ImtiN() { return nn; }

        public int ImtiM() { return mm; }

        public void DetiPajamas(int i, int j, int k) { pajamos[i, j] = k; }

        public int ImtiPajamas(int i, int j) { return pajamos[i, j]; }

        public int RastiIndeksa()
        {
            int ind = 0;
            int pinigai = pajamos[0, 0];

            for (int i = 0; i < nn; i++)
            {
                for (int j = 0; j < mm; j++)
                {
                    if (pajamos[i, j] > pinigai)
                    {
                        ind = i;
                        pinigai = pajamos[i, j];
                    }
                }
            }

            return ind;
        }

        public int RastiIndeksaPagalKategorija(int kat)
        {
            int ind = -1;
            int uzdarbis = 0;

            int l;
            for (l = 0; l < n; l++)
            {
                if (pard[l].ImtiKategorija() == kat)
                {
                    ind = l;
                    for (int k = 0; k < mm; k++)
                    {
                        uzdarbis += pajamos[ind, k];
                    }
                    //Console.WriteLine(uzdarbis);
                    break;
                }
            }

            for (int i = l + 1; i < nn; i++)
            {
                if (pard[i].ImtiKategorija() == kat)
                {
                    int pagalb = 0;
                    for (int j = 0; j < mm; j++)
                    {
                        pagalb += pajamos[i, j];
                    }
                    //Console.WriteLine(pagalb + " " + uzdarbis);
                    if (pagalb < uzdarbis)
                    {
                        ind = i;
                        uzdarbis = pagalb;
                    }
                }
            }

            return ind;
        }

        public int DienuKiekis(int p)
        {
            int kiekis = 0;
            int pDienosUzdarbis = 0;

            for (int k = 0; k < nn; k++)
            {
                pDienosUzdarbis += pajamos[k, p];
            }
            //Console.WriteLine(pDienosUzdarbis);

            for (int j = 0; j < mm; j++)
            {
                if (j != p)
                {
                    int pagalb = 0;
                    for (int i = 0; i < nn; i++)
                    {
                        pagalb += pajamos[i, j];
                    }
                    //Console.WriteLine(pagalb);
                    if (pagalb > pDienosUzdarbis)
                    {
                        kiekis++;
                    }
                }
            }
            return kiekis;
        }
    }

    class Program
    {
        const string duom = "..\\..\\Parduotuve.txt";

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.GetEncoding(1257);

            Parduotuve parduotuve = new Parduotuve();
            string pavadinimas;
            Skaityti(duom, parduotuve, out pavadinimas);
            SpausdintiPardavejus(parduotuve, pavadinimas, "Pradiniai pardavėjų duomenys:");
            SpausdintiMatrica(parduotuve, "Pradinė matrica:");

            int ind = parduotuve.RastiIndeksa();
            Pardavejas laikinas = parduotuve.ImtiPardaveja(ind);
            Console.WriteLine("Pirmojo pardavėjo, bet kurią vieną dieną surinkusio daugiausiai įplaukų, asmeninė informacija:");
            Console.WriteLine("Nr.: {0}; Vardas Pavardė: {1}; Amžius: {2}; Stažas {3}; Kategorija {4}.\n", ind + 1, laikinas.ImtiVardaPavarde(), laikinas.ImtiAmziu(), laikinas.ImtiStaza(), laikinas.ImtiKategorija());

            Console.WriteLine("1 - pirma kategorija");
            Console.WriteLine("2 - antra kategorija");
            Console.WriteLine("3 - trečia kategorija");
            Console.Write("Įveskite norimą kategoriją: ");
            int kat = int.Parse(Console.ReadLine());
            ind = parduotuve.RastiIndeksaPagalKategorija(kat);
            if (ind > -1)
            {
                laikinas = parduotuve.ImtiPardaveja(ind);
                Console.WriteLine("Pirmojo nurodytos kategorijos pardavėjo, per visas dienas surinkusio mažiausiai pinigų, asmeninė informacija:");
                Console.WriteLine("Nr.: {0}; Vardas Pavardė: {1}; Amžius: {2}; Stažas {3}; Kategorija {4}.\n", ind + 1, laikinas.ImtiVardaPavarde(), laikinas.ImtiAmziu(), laikinas.ImtiStaza(), laikinas.ImtiKategorija());
            }
            else
            {
                Console.WriteLine("Pasirinktos kategorijos pardavėjo nėra.\n");
            }

            Console.WriteLine("Kiekis dienų, per kurias buvo surinkta daugiau įplaukų nei pirmą dieną: {0}.\n", parduotuve.DienuKiekis(0));


            Console.WriteLine("Programa baigė darbą!");
        }

        static void Skaityti(string duom, Parduotuve A, out string pav)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string line;
                string[] parts;
                int nn, mm;

                string vrdpav;
                int amz;
                int staz;
                int kat;

                line = reader.ReadLine();
                parts = line.Split(';');
                pav = parts[0].Trim();
                nn = int.Parse(parts[1].Trim());
                mm = int.Parse(parts[2].Trim());
                A.DetiN(nn);
                A.DetiM(mm);

                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    vrdpav = parts[0].Trim();
                    amz = int.Parse(parts[1].Trim());
                    staz = int.Parse(parts[2].Trim());
                    kat = int.Parse(parts[3].Trim());
                    Pardavejas naujas = new Pardavejas(vrdpav, amz, staz, kat);
                    A.DetiPardaveja(naujas);
                }

                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    for (int j = 0; j < mm; j++)
                    {
                        int skaic = int.Parse(parts[j].Trim());
                        A.DetiPajamas(i, j, skaic);
                    }
                }

            }
        }

        static void SpausdintiPardavejus(Parduotuve A, string pav, string antraste)
        {
            const string virsus = "--------------------------------------------------------\r\n" +
                                  " Nr. Vardas Pavardė      Amžius    Stažas    Kategorija \r\n" +
                                  "--------------------------------------------------------";

            Console.WriteLine(antraste);
            Console.WriteLine(pav);
            Console.WriteLine(virsus);
            for (int i = 0; i < A.Imti(); i++)
            {
                Pardavejas laikinas = A.ImtiPardaveja(i);
                Console.WriteLine("{0, 3:d} {1}", i + 1, laikinas.ToString());
            }
            Console.WriteLine("--------------------------------------------------------\n");
        }

        static void SpausdintiMatrica(Parduotuve A, string antraste)
        {
            Console.WriteLine(antraste);

            for (int i = 0; i < A.ImtiN(); i++)
            {
                for (int j = 0; j < A.ImtiM(); j++)
                {
                    Console.Write("{0, 3:d};", A.ImtiPajamas(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
