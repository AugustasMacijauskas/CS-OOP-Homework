using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TablePrinter;

namespace Augustas_Mačijauskas_Kontrolinis5
{
    class Klientas
    {
        public string PavardėVardas { get; set; }
        public string TelefonoNr { get; set; }
        public string SodrosNr { get; set; }
        public DateTime GimimoData { get; set; }

        public Klientas(string vrd, string tlf, string sNr, DateTime gim)
        {
            this.PavardėVardas = vrd;
            this.TelefonoNr = tlf;
            this.SodrosNr = sNr;
            this.GimimoData = gim;
        }

        public static bool operator <(Klientas k1, Klientas k2)
        {
            int poz = string.Compare(k1.PavardėVardas, k2.PavardėVardas, StringComparison.CurrentCulture);
            long sodra1 = long.Parse(k1.SodrosNr);
            long sodra2 = long.Parse(k2.SodrosNr);

            return ((poz < 0) || ((poz == 0) && (sodra1 < sodra2)));
        }

        public static bool operator >(Klientas k1, Klientas k2)
        {
            int poz = string.Compare(k1.PavardėVardas, k2.PavardėVardas, StringComparison.CurrentCulture);
            long sodra1 = long.Parse(k1.SodrosNr);
            long sodra2 = long.Parse(k2.SodrosNr);

            return ((poz > 0) || ((poz == 0) && (sodra1 > sodra2)));
        }

        public override string ToString()
        {
            return string.Format(" {0, -25} {1, -10}              {2, -10}          {3:d}" , PavardėVardas, TelefonoNr, SodrosNr, GimimoData);
        }
    }

    class Poliklinika
    {
        const int MAX = 100;
        public int n { get; set; }
        private Klientas[] klientai;

        public Poliklinika()
        {
            n = 0;
            klientai = new Klientas[MAX];
        }

        public int Max()
        {
            return MAX;
        }

        public void Dėti(Klientas ob)
        {
            klientai[n++] = ob;
        }

        public void Dėti(Klientas ob, int ind)
        {
            klientai[ind] = ob;
        }

        public Klientas Imti(int k)
        {
            return klientai[k];
        }

        public void Rikiuoti()
        {
            int minInd;
            for (int i = 0; i < n - 1; i++)
            {
                minInd = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (klientai[j] < klientai[minInd])
                    {
                        minInd = j;
                    }
                }

                Klientas temp = klientai[i];
                klientai[i] = klientai[minInd];
                klientai[minInd] = temp;
            }
        }
    }

    class Program
    {
        const string duom = "..\\..\\Duomenys1.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1257);
            Console.InputEncoding = Encoding.Unicode;

            Poliklinika klientai = new Poliklinika();
            Skaityti(duom, klientai);
            Spausdinti(klientai, "Pradiniai duomenys:");

            klientai.Rikiuoti();
            Spausdinti(klientai, "Surikiuoti duomenys:");

            Console.Write("Įveskite datą, už kurią jaunesnius klientus norite pašalinti: ");
            DateTime data = DateTime.Parse(Console.ReadLine());
            Išmesti(klientai, data);
            if (klientai.n > 0)
            {
                Spausdinti(klientai, string.Format("Pašalinti už {0:d} jaunesni klientai:", data));
            }
            else
            {
                Console.WriteLine("Pašalinti už {0:d} jaunesni klientai:", data);
                Console.WriteLine("Iš sąrašo išmesti visi elementai!\r\n");
            }

            Klientas naujasKlientas;
            Console.WriteLine("Įveskite naujo kliento duomenis: ");
            Console.Write("Pavardę ir vardą: ");
            string vp = Console.ReadLine();
            Console.Write("Telefono numerį: ");
            string tlf = Console.ReadLine();
            Console.Write("Sodros pažymėjimo numerį: ");
            string sNr = Console.ReadLine();
            Console.Write("Gimimo datą: ");
            DateTime gim = DateTime.Parse(Console.ReadLine());
            naujasKlientas = new Klientas(vp, tlf, sNr, gim);
            int ind = RastiIndeksą(klientai, naujasKlientas);
            Console.WriteLine();
            //Console.WriteLine(ind);
            Įterpti(klientai, naujasKlientas, ind);
            Spausdinti(klientai, "Įterptas naujas klientas:");

            Console.WriteLine("Programa baigė darbą!");
        }

        static int RastiIndeksą(Poliklinika mas, Klientas k)
        {
            int ind = 0;
            //Console.WriteLine(k.ToString());
            for (int i = 0; i < mas.n; i++)
            {
                Klientas temp = mas.Imti(i);
                if (k < temp)
                {
                    //Console.WriteLine("Rasta");
                    break;
                }
                else if (k > temp)
                {
                    //Console.WriteLine(temp.PavardėVardas + "  vs  " + k.PavardėVardas);
                    //Console.WriteLine("!!");
                    ind++;
                }
            }

            return ind;
        }

        static void Įterpti(Poliklinika mas, Klientas klientas, int k)
        {
            for (int i = mas.n; i > k; i--)
            {
                Klientas temp = mas.Imti(i - 1);
                mas.Dėti(temp, i);
            }
            mas.Dėti(klientas, k);
            mas.n = mas.n + 1;
        }

        static void Išmesti(Poliklinika mas, DateTime data)
        {
            int m = 0;
            for (int i = 0; i < mas.n; i++)
            {
                Klientas temp = mas.Imti(i);
                if (temp.GimimoData < data)
                {
                    mas.Dėti(temp, m++);
                }
            }
            mas.n = m;

            //Arba
            /*
            for (int i = 0; i < mas.n; i++)
            {
                Klientas temp = mas.Imti(i);
                if (temp.GimimoData > data)
                {
                    for (int j = i; j < mas.n - 1; j++)
                    {
                        mas.Dėti(mas.Imti(j + 1), j);
                    }
                    mas.n--;
                }
            }
            */
        }

        static void Skaityti(string duom, Poliklinika mas)
        {
            using(StreamReader reader = new StreamReader(duom))
            {
                string line;
                string[] parts;

                string vp, tlf, sNr;
                DateTime gim;

                while((line = reader.ReadLine()) != null && ((mas.n + 1) < mas.Max()))
                {
                    parts = line.Split(';');
                    vp = parts[0].Trim();
                    tlf = parts[1].Trim();
                    sNr = parts[2].Trim();
                    gim = DateTime.Parse(parts[3].Trim());
                    Klientas naujas = new Klientas(vp, tlf, sNr, gim);
                    mas.Dėti(naujas);
                }
            }
        }

        static void Spausdinti(Poliklinika mas, string antraste)
        {
            Table<Klientas> pavadinimas = new Table<Klientas>();
            pavadinimas.AddColumn(x => x.PavardėVardas, "Pavardė");
            pavadinimas.AddColumn(x => x.TelefonoNr, "Tlf");
            pavadinimas.AddColumn(x => x.SodrosNr, "Sodra");
            pavadinimas.AddColumn(x => x.GimimoData, "Data");

            pavadinimas.CellAlign = CellAlign.Left;
            pavadinimas.CellBorderMargin = 5;
            pavadinimas.PrintPigeonContainer(mas, mas.n);
            //const string virsus = "--------------------------------------------------------------------------------------\r\n" +
            //                      " Nr. Pavardė vardas            Telefono nr.     Sodros pažymėjimo nr.     Gimimo data \r\n" +
            //                      "--------------------------------------------------------------------------------------";

            //Console.WriteLine(antraste);
            //if (mas.n > 0)
            //{
            //    Console.WriteLine(virsus);
            //    for (int i = 0; i < mas.n; i++)
            //    {
            //        Console.WriteLine("{0, 3:d} {1} ", i + 1, mas.Imti(i).ToString());
            //    }
            //    Console.WriteLine("--------------------------------------------------------------------------------------\r\n");
            //}
            //else
            //{
            //    Console.WriteLine("Sąrašas tuščias!\r\n");
            //}
        }
    }
}
