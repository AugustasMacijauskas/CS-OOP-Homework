using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dviraciai
{
    class Dviraciai
    {
        string pavadinimas;
        int kiekis;
        int pagaminimoMetai;
        double kaina;
        string punktas;

        public Dviraciai(string pavadinimas, int kiekis, int pagaminimoMetai, double kaina, string punktas)
        {
            this.pavadinimas = pavadinimas;
            this.kiekis = kiekis;
            this.pagaminimoMetai = pagaminimoMetai;
            this.kaina = kaina;
            this.punktas = punktas;
        }

        public string koksPavadinimas() { return pavadinimas; }

        public int koksKiekis() { return kiekis; }

        public int kadaPagaminta() { return pagaminimoMetai; }

        public double kokiaKaina() { return kaina; }

        public string koksPunktas() { return punktas; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int maxDuom = 100;
            const string A = "...\\...\\A.txt";
            const string B = "...\\...\\B.txt";
            const string rez = "...\\...\\rez.txt";

            int an, bn;

            Dviraciai[] pirmas = new Dviraciai[maxDuom];
            Dviraciai[] antras = new Dviraciai[maxDuom];

            string punktas1, punktas2;

            skaitymas(A, pirmas, out punktas1, out an);
            skaitymas(B, antras, out punktas2, out bn);

            double brangiausias1 = brangiausias(pirmas, an);
            double brangiausias2 = brangiausias(antras, bn);
            List<Dviraciai> brangiausi = new List<Dviraciai>();
                        
            rastiBrangiausia(pirmas, brangiausi, an, brangiausias1);
            rastiBrangiausia(antras, brangiausi, bn, brangiausias2);
            visuBrangiausias(brangiausi, pirmas, antras, brangiausias1, brangiausias2, an, bn);

            if (File.Exists(rez))
                File.Delete(rez);

            duomenuSpausdinimas(rez, pirmas, an);
            duomenuSpausdinimas(rez, antras, bn);
            spausdinimas(rez, brangiausi);
            Console.WriteLine("Programa baige darba");
        }

        static void duomenuSpausdinimas(string rez, Dviraciai[] dviraciai, int n)
        {
            using (var prideti = File.AppendText(rez))
            {
                prideti.WriteLine("Dviraciu punktas: {0}", dviraciai[0].koksPunktas());
                for (int i = 0; i < n; i++)
                {
                    prideti.WriteLine("{0} {1} {2} {3,5:f2}", dviraciai[i].koksPavadinimas(), dviraciai[i].koksKiekis(), dviraciai[i].kadaPagaminta(), dviraciai[i].kokiaKaina());
                }
                prideti.WriteLine("");
            }
        }

        static void rastiBrangiausia(Dviraciai[] dviraciai, List<Dviraciai> brangiausi, int n, double brangiausias)
        {
            for (int i = 0; i < n; i++)
            {
                if (dviraciai[i].kokiaKaina() == brangiausias)
                {
                    brangiausi.Add(dviraciai[i]);
                }
            }
        }

        static void visuBrangiausias(List<Dviraciai> brangiausi, Dviraciai[] pirmas, Dviraciai[] antras, double brangiausias1, double brangiausias2, int an, int bn)
        {
            if (brangiausias1 > brangiausias2)
            {
                for (int i = 0; i < an; i++)
                {
                    if (pirmas[i].kokiaKaina() == brangiausias1)
                    {
                        brangiausi.Add(pirmas[i]);
                    }
                }
            }
            else if (brangiausias1 < brangiausias2)
            {
                for (int i = 0; i < bn; i++)
                {
                    if (antras[i].kokiaKaina() == brangiausias2)
                    {
                        brangiausi.Add(antras[i]);
                    }
                }
            }

        }


        static double brangiausias(Dviraciai[] dviraciai, int n)
        {
            double brangiausias = dviraciai[0].kokiaKaina();

            for (int i = 0; i < n; i++)
            {
                if (dviraciai[i].kokiaKaina() > brangiausias)
                {
                    brangiausias = dviraciai[i].kokiaKaina();
                }
            }

            return brangiausias;
        }

        static void skaitymas(string duom, Dviraciai[] dviraciai, out string punktas, out int n)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string pavadinimas;
                int kiekis, metai;
                double kaina;

                string line;
                string[] skaidymas;
                line = reader.ReadLine();
                punktas = line;
                line = reader.ReadLine();
                n = int.Parse(line);

                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    skaidymas = line.Split(';');
                    pavadinimas = skaidymas[0];
                    kiekis = int.Parse(skaidymas[1]);
                    metai = int.Parse(skaidymas[2]);
                    kaina = double.Parse(skaidymas[3]);
                    dviraciai[i] = new Dviraciai(pavadinimas, kiekis, metai, kaina, punktas);
                }
            }
        }

        static void spausdinimas(string rez, List<Dviraciai> brangiausi)
        {
            const string virsus =
              "|---------------------------|-----------|--------------------------------------------------|\r\n"
            + "|        Pavadinimas        |   Kaina   |                      Punktas                     | \r\n"
            + "|---------------------------|-----------|--------------------------------------------------|";
            using (var prideti = File.AppendText(rez))
            {
                prideti.WriteLine(virsus);
                foreach (var dviratis in brangiausi)
                {
                    prideti.WriteLine("| {0,-25} |  {1,7:f2}  | {2,-48} |", dviratis.koksPavadinimas(), dviratis.kokiaKaina(), dviratis.koksPunktas());
                }
                prideti.WriteLine("--------------------------------------------------------------------------------------------");
            }
        }
    }
}


