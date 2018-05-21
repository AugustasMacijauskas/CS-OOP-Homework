using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace K1_502_pavyzdinis
{
    class Miestas
    {
        public string Pavadinimas { get; set; }
        public string Valstybė { get; set; }
        public double Gyventojų { get; set; }
        public double Plotas { get; set; }

        public Miestas(string pav, string valst, double gyv, double pl)
        {
            this.Pavadinimas = pav;
            this.Valstybė = valst;
            this.Gyventojų = gyv;
            this.Plotas = pl;
        }

        public static bool operator <(Miestas m1, Miestas m2)
        {
            int poz = string.Compare(m1.Pavadinimas, m2.Pavadinimas, StringComparison.CurrentCulture);

            return ((m1.Gyventojų > m2.Gyventojų) || ((m1.Gyventojų == m2.Gyventojų) && (poz < 0)));
        }

        public static bool operator >(Miestas m1, Miestas m2)
        {
            int poz = string.Compare(m1.Pavadinimas, m2.Pavadinimas, StringComparison.CurrentCulture);

            return ((m1.Gyventojų < m2.Gyventojų) || ((m1.Gyventojų == m2.Gyventojų) && (poz > 0)));
        }

        public override string ToString()
        {
            return string.Format(" {0, -20}  {1, -20}           {2, 6:f0}                     {3, 4:f0}", Pavadinimas, Valstybė, Gyventojų, Plotas);
        }
    }

    class DaugMiestų
    {
        const int MAX = 100;
        int n; // Masyvo elementu kiekis
        Miestas[] miestai;

        public DaugMiestų()
        {
            n = 0;
            miestai = new Miestas[MAX];
        }

        public int ImtiMAX() { return MAX; }

        public int Imti() { return n; }

        public Miestas Imti(int k) { return miestai[k]; }

        public void Dėti(Miestas ob) { miestai[n++] = ob; }

        public int RastiDidžiausioPlotoMiestoIndeksą()
        {
            int indeksas = 0;
            double DidžPlotas = miestai[indeksas].Plotas;

            for (int i = 1; i < n; i++)
            {
                if (miestai[i].Plotas > DidžPlotas)
                {
                    DidžPlotas = miestai[i].Plotas;
                    indeksas = i;
                }
            }

            return indeksas;
        }

        public void Šalinti(int k)
        {
            for (int i = k; i < n - 1; i++)
            {
                miestai[i] = miestai[i + 1];
            }
            n--;
        }

        public void BurburliukasSort()
        {
            int i = 0;
            bool bk = true;

            while (bk)
            {
                bk = false;

                for (int j = n - 1; j > i; j--)
                {
                    if (miestai[j] < miestai[j - 1])
                    {
                        bk = true;
                        Miestas temp = miestai[j];
                        miestai[j] = miestai[j - 1];
                        miestai[j - 1] = temp;
                    }
                }
                i++;
            }
        }
    }

    class Program
    {
        const string duom = "..\\..\\Duomenys.txt";

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.GetEncoding(1257);
            Console.OutputEncoding = Encoding.Unicode;
            DaugMiestų M = new DaugMiestų();
            Skaityti(duom, M);
            Spausdinti(M, "Pradinis miestų sąrašas:");

            DaugMiestų V = new DaugMiestų();
            Console.Write("Įveskite valstybę, kurios miestus norite sudėti į naują sąrašą: ");
            string šalis = Console.ReadLine();
            Console.WriteLine();
            Formuoti(M, V, šalis);
            if (V.Imti() > 0)
            {
                Spausdinti(V, "Suformuotas tam tikros valstybės (" + šalis + ") miestų sąrašas:");
                int ind = V.RastiDidžiausioPlotoMiestoIndeksą();
                Console.WriteLine("Nurodytos valstybės ({0}) didžiausio ploto miestas: {1}; jo plotas: {2} km^2.\n", šalis, V.Imti(ind).Pavadinimas, V.Imti(ind).Plotas);
                V.Šalinti(ind);
                if (V.Imti() > 0)
                {
                    V.BurburliukasSort();
                    Spausdinti(V, "Surikiuotas nurodytos valstybės (" + šalis + ") sąrašas, iš kurio pašalintas didžiausio ploto miestas:");
                }
                else
                {
                    Console.WriteLine("Surikiuotas nurodytos valstybės (" + šalis + ") sąrašas, iš kurio pašalintas didžiausio ploto miestas:");
                    Console.WriteLine("Naujas sąrašas tuščias!\n");
                }
            }
            else
            {
                Console.WriteLine("Suformuotas tam tikros valstybės (" + šalis + ") miestų sąrašas:");
                Console.WriteLine("Naujas sąrašas tuščias!\n");
            }

            //M.BurburliukasSort();
            //Spausdinti(M, "Surikiuotas:");

            Console.WriteLine("Programa baigė darbą!\n");
        }

        static void Formuoti(DaugMiestų senas, DaugMiestų naujas, string valst)
        {
            for (int i = 0; i < senas.Imti(); i++)
            {
                if (senas.Imti(i).Valstybė == valst.Trim())
                {
                    naujas.Dėti(senas.Imti(i));
                }
            }
        }

        static void Skaityti(string duom, DaugMiestų M)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string line;
                string[] parts;
                string pav;
                string valst;
                double gyv;
                double plot;

                while ((line = reader.ReadLine()) != null)
                {
                    parts = line.Split(';');
                    pav = parts[0].Trim();
                    valst = parts[1].Trim();
                    gyv = double.Parse(parts[2].Trim());
                    plot = double.Parse(parts[3].Trim());
                    Miestas naujas = new Miestas(pav, valst, gyv, plot);
                    M.Dėti(naujas);
                }
            }
        }

        static void Spausdinti(DaugMiestų miestai, string antraštė)
        {
            const string virsus = "----------------------------------------------------------------------------------------------\r\n" +
                                  " Nr. Miestas               Valstybė            Gyventojų skaičius (tūkst.)      Plotas (km^2) \r\n" +
                                  "----------------------------------------------------------------------------------------------";
            Console.WriteLine(antraštė);
            if (miestai.Imti() > 0)
            {
                Console.WriteLine(virsus);
                for (int i = 0; i < miestai.Imti(); i++)
                {
                    Console.WriteLine("{0, 3:d} {1}", i + 1, miestai.Imti(i).ToString());
                }
                Console.WriteLine("----------------------------------------------------------------------------------------------\r\n");
            }
            else
            {
                Console.WriteLine("Sąrašas tuščias!\n");
            }
        }
    }
}
