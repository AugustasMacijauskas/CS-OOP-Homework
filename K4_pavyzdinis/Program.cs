using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace K4_pavyzdinis
{
    class Žaidėjas
    {
        private string VP;
        private int amžius;
        private double ūgis;
        private string pozicija;

        public Žaidėjas()
        {
            VP = "Nezinomas Nezinomaitis";
            amžius = 0;
            ūgis = 0.0;
            pozicija = "NA";
        }

        public Žaidėjas(string pv, int amz, double ug, string poz)
        {
            VP = pv;
            amžius = amz;
            ūgis = ug;
            pozicija = poz;
        }

        public string ImtiVardaPavarde() { return VP; }
        public int ImtiAmziu() { return amžius; }
        public double ImtiUgi() { return ūgis; }
        public string ImtiPozicija() { return pozicija; }
    }

    class Komanda
    {
        const int Max = 12;
        private Žaidėjas[] krep;
        private int n;

        const int MaxEil = 12;
        const int MaxStulp = 100;
        private int[,] taskai;
        private int nn;
        private int mm;

        public Komanda()
        {
            n = 0;
            krep = new Žaidėjas[Max];

            nn = 0;
            mm = 0;
            taskai = new int[MaxEil, MaxStulp];
        }

        public int ImtiMax() { return Max; }

        public int Imti() { return n; }

        public Žaidėjas ImtiZaideja(int i) { return krep[i]; }

        public void DetiZaideja(Žaidėjas ob) { krep[n++] = ob; }

        public void DetiTaskus(int i, int j, int t) { taskai[i, j] = t; }

        public int ImtiTaskus(int i, int j) { return taskai[i, j]; }

        public void DetiN(int x) { nn = x; }

        public int ImtiN() { return nn; }

        public void DetiM(int x) { mm = x; }

        public int ImtiM() { return mm; }

        public int DaugiausiaiTaskuPelnesZaidejas()
        {
            int index = 0;
            int maxTsk = taskai[0, 0];

            for (int i = 0; i < nn; i++)
            {
                for (int j = 0; j < mm; j++)
                {
                    if (taskai[i, j] > maxTsk)
                    {
                        index = i;
                        maxTsk = taskai[i, j];
                    }
                }
            }

            return index;
        }

        public int DaugiausiaiPagalPozicija(string poz)
        {
            int index = -1;
            int tsk = 0;

            int l;
            for (l = 0; l < n; l++)
            {
                if (krep[l].ImtiPozicija() == poz)
                {
                    index = l;
                    for (int k = 0; k < mm; k++)
                    {
                        tsk += taskai[l, k];
                    }
                    break;
                }
            }

            for (int i = l; i < nn; i++)
            {
                if (krep[i].ImtiPozicija() == poz)
                {
                    int pagalb = 0;
                    for (int j = 0; j < mm; j++)
                    {
                        pagalb += taskai[i, j];
                    }

                    if (pagalb > tsk)
                    {
                        index = i;
                        tsk = pagalb;
                    }
                }
            }
            return index;
        }

        public int PelnytaMaziauTskNeiK(int k)
        {
            int kiek = 0;

            int tsk = 0;
            for (int i = 0; i < nn; i++)
            {
                tsk += taskai[i, k];
            }

            for (int j = 0; j < mm; j++)
            {
                if (j != k)
                {
                    int pagalb = 0;
                    for (int i = 0; i < nn; i++)
                    {
                        pagalb += taskai[i, j];
                    }
                    if (pagalb < tsk)
                    {
                        kiek++;
                    }
                }                
            }

            return kiek;
        }
    }

    class Program
    {
        const string duom = "..\\..\\Komanda.txt";

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.GetEncoding(1257);
            Komanda komanda = new Komanda();
            string pavadinimas;
            Skaityti(duom, komanda, out pavadinimas);
            SpausdintiZaidejus(komanda, pavadinimas, "Pradiniai žaidėjų asmeniniai duomenys:");
            SpausdintiTaskus(komanda, "Pradiniai žaidėjų pelnyti taškai:");

            int ind = komanda.DaugiausiaiTaskuPelnesZaidejas();
            Žaidėjas laikinas = komanda.ImtiZaideja(ind);
            Console.WriteLine("Pirmojo žaidėjo, kuris per vienas rungtynes pelnė daugiausia taškų asmeninė informacija:\nNr.: {0}; Vardas Pavardė: {1}; Amžius: {2}; Ūgis: {3, 5:f}; Pozicija: {4};\n", ind + 1, laikinas.ImtiVardaPavarde(), laikinas.ImtiAmziu(), laikinas.ImtiUgi(), laikinas.ImtiPozicija());

            Console.WriteLine("ĮŽ - įžaidėjas;\nAG - atakuojantis gynėjas;\nLK - lengvasis krašto puolėjas;\nSK - sunkusis krašto puolėjas;\nC - centras;");
            Console.WriteLine("Įveskite, kurios pozicijos daugiausiai taškų pelniusį žaidėją norite surasti: ");
            string pozicija = Console.ReadLine();
            ind = komanda.DaugiausiaiPagalPozicija(pozicija);
            if (ind > -1)
            {
                laikinas = komanda.ImtiZaideja(ind);
                Console.WriteLine("Pirmojo nurodytos pozicijos žaidėjo, per sezoną pelniusio daugiausiai taškų, asmeninė informacija:\nNr.: {0}; Vardas Pavardė: {1}; Amžius: {2}; Ūgis: {3, 5:f}; Pozicija: {4};\n", ind + 1, laikinas.ImtiVardaPavarde(), laikinas.ImtiAmziu(), laikinas.ImtiUgi(), laikinas.ImtiPozicija());
            }

            Console.WriteLine("Rungtynių, per kurias buvo pelnyta mažiau taškų nei paskutinėse, buvo {0}.\n", komanda.PelnytaMaziauTskNeiK(komanda.ImtiM() - 1));
            Console.WriteLine("Programa baigė darbą!");
        }

        static void Skaityti(string fr, Komanda A, out string pav)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string line;
                string pavvrd, poz;
                int amz;
                double ugis;
                string[] parts;
                int nn, mm;

                line = reader.ReadLine();
                parts = line.Split(';');
                pav = parts[0].Trim();
                nn = int.Parse(parts[1].Trim());
                A.DetiN(nn);
                mm = int.Parse(parts[2].Trim());
                A.DetiM(mm);

                for (int i = 0; i < A.ImtiN(); i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pavvrd = parts[0].Trim();
                    amz = int.Parse(parts[1].Trim());
                    ugis = double.Parse(parts[2].Trim());
                    poz = parts[3].Trim();
                    Žaidėjas zaid = new Žaidėjas(pavvrd, amz, ugis, poz);
                    A.DetiZaideja(zaid);
                }

                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    for (int j = 0; j < mm; j++)
                    {
                        int skaic = int.Parse(parts[j]);
                        A.DetiTaskus(i, j, skaic);
                    }
                }
            }
        }

        static void SpausdintiZaidejus(Komanda A, string pav, string antraštė)
        {
            const string virsus =
            "------------------------------------------------------\r\n" +
            " Nr. Pavardė ir vardas     Amžius    Ūgis    Pozicija \r\n" +
            "------------------------------------------------------";

            Console.WriteLine(antraštė);
            Console.WriteLine(pav);
            Console.WriteLine(virsus);
            for (int i = 0; i < A.Imti(); i++)
            {
                Žaidėjas ob = A.ImtiZaideja(i);
                Console.WriteLine("{0, 3}  {1, -20}    {2, 2}     {3, 5:f}       {4, -5} ", i + 1, ob.ImtiVardaPavarde(), ob.ImtiAmziu(), ob.ImtiUgi(), ob.ImtiPozicija());
            }
            Console.WriteLine("------------------------------------------------------\n");

        }

        static void SpausdintiTaskus(Komanda A, string antraštė)
        {
            Console.WriteLine(antraštė);

            for (int i = 0; i < A.ImtiN(); i++)
            {
                for (int j = 0; j < A.ImtiM(); j++)
                {
                    Console.Write("{0, 3:d};", A.ImtiTaskus(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
