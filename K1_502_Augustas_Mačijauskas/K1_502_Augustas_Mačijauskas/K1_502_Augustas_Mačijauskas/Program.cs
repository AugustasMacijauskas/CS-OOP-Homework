using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace K1_502_Augustas_Mačijauskas
{
    class Mokestis
    {
        private int butoNumeris;
        private string vardasPavardė;
        private string adresas;
        private DateTime paskutinisMokėjimas;
        private double skola;

        public Mokestis() { }

        public Mokestis(int butoNr, string vp, string adresas, DateTime paskMok, double skola)
        {
            this.butoNumeris = butoNr;
            this.vardasPavardė = vp;
            this.adresas = adresas;
            this.paskutinisMokėjimas = paskMok;
            this.skola = skola;
        }

        public int ButoNumeris() { return this.butoNumeris; }
        public string VardasPavardė() { return this.vardasPavardė; }
        public string Adresas() { return this.adresas; }
        public DateTime PaskutinisMokėjimas() { return this.paskutinisMokėjimas; }
        public double Skola() { return this.skola; }

        public static bool operator <(Mokestis m1, Mokestis m2)
        {
            int poz = String.Compare(m1.vardasPavardė, m2.vardasPavardė, StringComparison.CurrentCulture);

            return ((poz < 0) || (poz == 0 && m1.butoNumeris > m2.butoNumeris));
        }

        public static bool operator >(Mokestis m1, Mokestis m2)
        {
            int poz = String.Compare(m1.vardasPavardė, m2.vardasPavardė, StringComparison.CurrentCulture);

            return ((poz > 0) || (poz == 0 && m1.butoNumeris < m2.butoNumeris));
        }

        public override string ToString()
        {
            return string.Format("  {0, 4:d}    {1, -25} {2, -15} {3: yyyy MM dd}       {4, 8:f}",
                                 this.butoNumeris, this.vardasPavardė, this.adresas, this.paskutinisMokėjimas, this.skola);
        }
    }

    class Program
    {
        const string duomenys = "..\\..\\..\\Duomenys6.txt";
        const string naujiDuomenys = "..\\..\\..\\Duomenys6_1.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1257);
            List<Mokestis> N = new List<Mokestis>();
            Skaityti(duomenys, N);
            Spausdinti(N, "Pradiniai mokesčių duomenys:");
            Rikiuoti(N);
            Spausdinti(N, "Surikiuotas mokesčių masyvas:");

            Console.Write("Įveskite naują data (formatas yyyy MM dd): ");
            DateTime mazesneData = DateTime.Parse(Console.ReadLine());
            // Console.WriteLine("{0:yyyy MM dd}", mazesneData);
            Išmetimas(N, mazesneData);
            if (N.Count > 0)
            {
                Spausdinti(N, "Išmesti mokėtojai, kurių paskutinio mokėjimo data mažesnė už nurodytą klaviatūra:");
            }
            else
            {
                Console.WriteLine("Išmesti mokėtojai, kurių paskutinio mokėjimo data mažesnė už nurodytą klaviatūra:");
                Console.WriteLine("Sąrašas tuščias!\r\n");
            }

            List<Mokestis> M = new List<Mokestis>();
            Skaityti(naujiDuomenys, M);
            Spausdinti(M, "Nauji duomenys:");
            Iterpimas(N, M);
            Spausdinti(N, "Masyvas M įterptas į N:");

            List<Mokestis> P = new List<Mokestis>();
            double didSkola = DidžiausiaSkolaMasyve(N);
            // Console.WriteLine(didSkola);
            if (didSkola < 0)
            {
                DidžiausiosSkolos(N, P, didSkola);
                Spausdinti(P, "Didžiausias skolas N masyve turintys mokėtojai:");
            }
            else
            {
                Console.WriteLine("Didžiausias skolas N masyve turintys mokėtojai:");
                Console.WriteLine("Skolininkų nėra!\r\n");
            }

            Console.WriteLine("Programa baigė darbą!");
        }

        static void DidžiausiosSkolos(List<Mokestis> N, List<Mokestis> P, double didSkola)
        {
            for (int i = 0; i < N.Count; i++)
            {
                if (N[i].Skola() == didSkola)
                {
                    P.Add(N[i]);
                }
            }
        }

        static double DidžiausiaSkolaMasyve(List<Mokestis> N)
        {
            double didSkola = N[0].Skola();
            for (int i = 1; i < N.Count; i++)
            {
                if (N[i].Skola() < didSkola)
                {
                    didSkola = N[i].Skola();
                }
            }

            return didSkola;
        }

        // Burbuliuko metodas
        static void Rikiuoti(List<Mokestis> N)
        {
            int i = 0;
            bool buvoKeitimu = true;

            while (buvoKeitimu)
            {
                buvoKeitimu = false;
                for (int j = N.Count - 1; j > i; j--)
                {
                    if (N[j] < N[j - 1])
                    {
                        buvoKeitimu = true;
                        Mokestis temp = N[j];
                        N[j] = N[j - 1];
                        N[j - 1] = temp;
                    }
                }
                i++;
            }
        }

        static void Iterpimas(List<Mokestis> N, List<Mokestis> M)
        {
            for (int i = 0; i < M.Count; i++)
            {
                Mokestis naujasMokestis = M[i];
                int indeksas = IterpimoVieta(N, naujasMokestis);
                N.Insert(indeksas, naujasMokestis);
            }
        }

        static int IterpimoVieta(List<Mokestis> N, Mokestis naujas)
        {
            int i;
            for (i = 0; ((i < N.Count) && N[i] < naujas); i++)
            {

            }

            return i;
        }

        static void Išmetimas(List<Mokestis> N, DateTime data)
        {
            for (int i = 0; i < N.Count; i++)
            {
                if (N[i].PaskutinisMokėjimas() < data)
                {
                    N.RemoveAt(i);
                    i--;
                }
            }
        }

        static void Skaityti(string file, List<Mokestis> N)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                string line;
                int butoNumeris;
                string vardasPavardė;
                string adresas;
                DateTime paskutinisMokėjimas;
                double skola;

                while((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    butoNumeris = int.Parse(parts[0].Trim());
                    vardasPavardė = parts[1].Trim();
                    adresas = parts[2].Trim();
                    paskutinisMokėjimas = DateTime.Parse(parts[3].Trim());
                    skola = double.Parse(parts[4].Trim());

                    Mokestis naujasMokestis = new Mokestis(butoNumeris, vardasPavardė, adresas, paskutinisMokėjimas, skola);
                    N.Add(naujasMokestis);
                }
            }
        }

        static void Spausdinti(List<Mokestis> N, string antraste)
        {
            const string virsus = "-----------------------------------------------------------------------------------\r\n" +
                                  " Nr. Buto Nr. Vardas Pavardė         Adresas        Paskutinis mokėjimas     Skola \r\n" +
                                  "-----------------------------------------------------------------------------------";

            Console.WriteLine(antraste);
            if (N.Count > 0)
            {
                Console.WriteLine(virsus);
                for (int i = 0; i < N.Count; i++)
                {
                    Console.WriteLine("{0, 3:d} {1}", i + 1, N[i].ToString());
                }
                Console.WriteLine("-----------------------------------------------------------------------------------\r\n");
            }
            else
            {
                Console.WriteLine("Sąrašas tuščias!");
            }
        }
    }
}
