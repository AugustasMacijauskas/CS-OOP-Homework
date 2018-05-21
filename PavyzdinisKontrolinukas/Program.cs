using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PavyzdinisKontrolinukas
{

    class Mokinys
    {
        string vardas;
        string pavarde;
        string lytis;
        int amzius;
        string klase;
        double pazVidurkis;

        public Mokinys()
        {

        }

        public Mokinys(string pv, string v, string lytis, int amzius, string kl, double pazV)
        {
            pavarde = pv;
            vardas = v;
            this.lytis = lytis;
            this.amzius = amzius;
            klase = kl;
            pazVidurkis = pazV;
        }

        public override string ToString()
        {
            string naujas;
            naujas = string.Format("{0, -15}     {1, -15}     {2, -8}            {3, -4:d}             {4, -8}      {5, 5:f}    ", pavarde, vardas, lytis, amzius, klase, pazVidurkis);
            return naujas;
        }

        public static bool operator <=(Mokinys m1, Mokinys m2)
        {
            int poz1 = String.Compare(m1.pavarde, m2.pavarde, StringComparison.CurrentCulture);
            int poz2 = String.Compare(m1.vardas, m2.vardas, StringComparison.CurrentCulture);

            return ((m1.pazVidurkis > m2.pazVidurkis) || ((m1.pazVidurkis == m2.pazVidurkis) && poz1 < 0) || ((m1.pazVidurkis == m2.pazVidurkis) && (poz1 == 0) && (poz2 < 0)));
        }

        public static bool operator >=(Mokinys m1, Mokinys m2)
        {
            int poz1 = String.Compare(m1.pavarde, m2.pavarde, StringComparison.CurrentCulture);
            int poz2 = String.Compare(m1.vardas, m2.vardas, StringComparison.CurrentCulture);

            return ((m1.pazVidurkis < m2.pazVidurkis) || ((m1.pazVidurkis == m2.pazVidurkis) && poz1 > 0) || ((m1.pazVidurkis == m2.pazVidurkis) && (poz1 == 0) && (poz2 > 0)));
        }

        public string KokiaKlase() { return klase; }

        public string KokiaLytis() { return lytis; }

        public double KoksVidurkis() { return pazVidurkis; }
    }

    class MokiniuKonteineris
    {
        const int max = 100;
        int n = 0;
        Mokinys[] mok;

        public MokiniuKonteineris()
        {
            mok = new Mokinys[max];
        }

        public int KoksMax() { return max; }

        public int Imti() { return n; }

        public void Deti(Mokinys ob) { mok[n++] = ob; }

        public Mokinys Imti(int k) { return mok[k]; }

        public void Rikiuoti()
        {
            Mokinys temp;
            int minInd;

            for (int i = 0; i < n - 1; i++)
            {
                minInd = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (mok[j] <= mok[minInd])
                    {
                        minInd = j;
                    }
                }

                temp = mok[i];
                mok[i] = mok[minInd];
                mok[minInd] = temp;
            }
        }

        public void Įterpti(string pav, string var, string lyt, int gimM, string kl, double vidur)
        {
            Mokinys naujas = new Mokinys(pav, var, lyt, gimM, kl, vidur);

            int i;
            for (i = 0; (i < n) && (mok[i] <= naujas); i++)
            {

            }

            //int i = 0;
            //while (i < n && mok[i] < naujas)
            //    i++;

            for (int j = n; j > i; j--)
            {
                mok[j] = mok[j - 1];
            }
            mok[i] = naujas;
            n = n + 1;
        }

        public double Vidurkis(string lyt)
        {
            double vid = 0;
            int countas = 0;

            for (int i = 0; i < n; i++)
            {
                if (mok[i].KokiaLytis() == lyt)
                {
                    vid += mok[i].KoksVidurkis();
                    countas++;
                }
            }

            if (countas > 0)
                return vid / countas;
            else
                return -1;
        }
    }

    class Program
    {

        const string duom = "..\\..\\Mokinys.txt";
        const string rez = "..\\..\\MokinysRez.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1257);
            MokiniuKonteineris mok = new MokiniuKonteineris();
            string pavadinimas;
            Skaityti(mok, out pavadinimas);
            if (File.Exists(rez))
                File.Delete(rez);
            Spausdinti(mok, string.Format("Pradiniai duomenys:\n{0}", pavadinimas));
            if (mok.Vidurkis("moteris") > -1)
                Console.WriteLine(mok.Vidurkis("moteris"));
            else
                Console.WriteLine("Šiame masyve vidurkio pagal sąlygą nėra");

            mok.Rikiuoti();
            Spausdinti(mok, "Surikiuotas masyvas:");

            //string vardas;
            //string pavarde;
            //string lytis;
            //int amzius;
            //string klase;
            //double pazVidurkis;
            //Console.WriteLine("Iveskite mokinio pavardę: ");
            //pavarde = Console.ReadLine();
            //Console.WriteLine("Iveskite mokinio vardą: ");
            //vardas = Console.ReadLine();
            //Console.WriteLine("Iveskite mokinio lytį: ");
            //lytis = Console.ReadLine();
            //Console.WriteLine("Iveskite mokinio gimimo metus: ");
            //amzius = int.Parse(Console.ReadLine());
            //Console.WriteLine("Iveskite mokinio klasę: ");
            //klase = Console.ReadLine();
            //Console.WriteLine("Iveskite mokinio pažymių vidurkį: ");
            //pazVidurkis = double.Parse(Console.ReadLine());

            mok.Įterpti("Jonaitis", "Benas", "vyras", 2000, "IIIm", 9.5);
            Spausdinti(mok, "Įterptas elementas:");
            if (mok.Vidurkis("moteris") > -1)
                Console.WriteLine(mok.Vidurkis("moteris"));
            else
                Console.WriteLine("Šiame masyve vidurkio pagal sąlygą nėra");

            MokiniuKonteineris naujas = new MokiniuKonteineris();
            //string kokiaKlase;
            //Console.WriteLine("Iveskite kokios klasės mokiniai turi būti naujame masyve: ");
            //kokiaKlase = double.Parse(Console.ReadLine());
            NaujoMasyvoFormavimas(mok, naujas, "123");
            Spausdinti(naujas, "Naujo masyvo formavimas");
            if (naujas.Vidurkis("moteris") > -1)
                Console.WriteLine(naujas.Vidurkis("moteris"));
            else
                Console.WriteLine("Šiame masyve vidurkio pagal sąlygą nėra");

            Console.WriteLine("Programa baigė darbą!");
        }

        static void NaujoMasyvoFormavimas(MokiniuKonteineris mok, MokiniuKonteineris naujas, string klase)
        {
            for (int i = 0; i < mok.Imti(); i++)
            {
                if (mok.Imti(i).KokiaKlase() == klase)
                {
                    naujas.Deti(mok.Imti(i));
                }
            }
        }

        static void Skaityti(MokiniuKonteineris mok, out string pavadinimas)
        {
            using(StreamReader reader = new StreamReader(duom))
            {
                string pavarde;
                string vardas;
                string lytis;
                int amzius;
                string klase;
                double pazVidurkis;

                string line;
                string[] splitas;

                pavadinimas = reader.ReadLine();

                while ((line = reader.ReadLine()) != null && mok.Imti() < mok.KoksMax())
                {
                    splitas = line.Split(';');
                    pavarde = splitas[0].Trim();
                    vardas = splitas[1].Trim();
                    lytis = splitas[2].Trim();
                    amzius = int.Parse(splitas[3].Trim());
                    klase = splitas[4].Trim();
                    pazVidurkis = double.Parse(splitas[5].Trim());
                    Mokinys naujas = new Mokinys(pavarde, vardas, lytis, amzius, klase, pazVidurkis);
                    mok.Deti(naujas);
                }
            }
        }

        static void Spausdinti(MokiniuKonteineris mok, string antraste)
        {
            const string virsus = "----------------------------------------------------------------------------------------------------------------\r\n" +
                                  "   Nr.       Pavardė            Vardas              Lytis            Gim. metai          Klasė        Vidurkis  \r\n" +
                                  "----------------------------------------------------------------------------------------------------------------";

            using(var fr = File.AppendText(rez))
            {
                if (mok.Imti() > 0)
                {
                    fr.WriteLine(antraste);
                    fr.WriteLine(virsus);

                    for (int i = 0; i < mok.Imti(); i++)
                    {
                        fr.WriteLine(" {0, 4:d}       {1}", i + 1, mok.Imti(i).ToString());
                    }
                    fr.WriteLine("----------------------------------------------------------------------------------------------------------------\n\n");
                }
                else
                {
                    fr.WriteLine("Sąrašas tuščias");
                }
            }
        }
    }
}