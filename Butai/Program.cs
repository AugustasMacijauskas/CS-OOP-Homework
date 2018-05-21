using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Butai
{
    class Butas
    {
        private int butoNr, kambariuSk;
        double plotas, kaina;
        string tlf;

        public Butas()
        {
            butoNr = 0;
            plotas = 0;
            kambariuSk = 0;
            kaina = 0;
            tlf = "";
        }

        public Butas(int nr, double plotas, int kamb, double kaina, string tlfnr)
        {
            butoNr = nr;
            this.plotas = plotas;
            kambariuSk = kamb;
            this.kaina = kaina;
            tlf = tlfnr;
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,3:d}   {1,6:f}          {2,2:d}         {3,7:f0}    {4}  ", butoNr, plotas, kambariuSk, kaina, tlf);
            return eilute;
        }

        public int KiekKambariu() { return kambariuSk; }

        public double KokiaKaina() { return kaina; }
    }

    class Namas
    {
        const int maxDuom = 27;
        private Butas[] butai;
        private int n;

        public Namas()
        {
            n = 0;
            butai = new Butas[maxDuom];
        }

        public Butas Imti(int i) { return butai[i]; }

        public int Imti() { return n; }

        public void Deti(Butas ob) { butai[n++] = ob; }
    }

    class Program
    {
        const string duom = "...\\...\\duom.txt";
        const string rez = "...\\...\\rez.txt";
        const int KambariuKiekis = 2;
        const double MaxKaina = 42000;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Namas namas = new Namas();
            Skaityti(duom, ref namas);

            if (File.Exists(rez))
                File.Delete(rez);
            Spausdinti(rez, namas, "Pradiniai duomenys:");

            Namas tinkami = new Namas();
            Formuoti(namas, ref tinkami);
            Spausdinti(rez, tinkami, "Tinkami butai:");

            Console.WriteLine("Programa baige darba!");
        }

        static void Formuoti(Namas namas, ref Namas tinkami)
        {
            for (int i = 0; i < namas.Imti();  i++)
            {
                if (namas.Imti(i).KiekKambariu() == KambariuKiekis && namas.Imti(i).KokiaKaina() <= MaxKaina)
                {
                    tinkami.Deti(namas.Imti(i));
                }
            }
        }

        static void Skaityti(string duom, ref Namas namas)
        {
            using(StreamReader reader = new StreamReader(duom))
            {
                string line;
                string[] skaidymas;
                int nr, kSk;
                double pl, kaina;
                string tlf;
                int n;
                n = int.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    skaidymas = line.Split(';');
                    nr = int.Parse(skaidymas[0]);
                    pl = double.Parse(skaidymas[1]);
                    kSk = int.Parse(skaidymas[2]);
                    kaina = double.Parse(skaidymas[3]);
                    tlf = skaidymas[4];
                    Butas ob = new Butas(nr, pl, kSk, kaina, tlf);
                    namas.Deti(ob);
                }
            }
        }

        static void Spausdinti(string rez, Namas namas, string antraste)
        {
            string virsus = "-------------------------------------------------------\r\n" +
                            " Nr.  Plotas  Kambariu skaicius    Kaina    Telefonas  \r\n" +
                            "-------------------------------------------------------";

            using(var fr = File.AppendText(rez))
            {
                if (namas.Imti() > 0)
                {
                    fr.WriteLine(antraste);
                    fr.WriteLine(virsus);
                    for (int i = 0; i < namas.Imti(); i++)
                    {
                        fr.WriteLine("{0}", namas.Imti(i).ToString());
                    }
                    fr.WriteLine("-------------------------------------------------------\n\n");
                }
                else fr.WriteLine("Sarasas tuscias");
            }
        }
    }
}
