using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Turistai
{
    class Turistai
    {
        double litai;
        double centai;

        public Turistai(double litai, double centai)
        {
            this.litai = litai;
            this.centai = centai;
        }

        public double kiekLitu() { return litai; }

        public double kiekCentu() { return centai; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            const int maxDuom = 100;
            const string Duom = "...\\...\\Duom.txt";

            int n;

            Turistai[] turistai = new Turistai[maxDuom];

            skaitymas(Duom, turistai, out n);

            double isViso, vienamNariui, bendrosIslaidos;
            skaiciuoti(turistai, n, out isViso, out vienamNariui, out bendrosIslaidos);

            Console.WriteLine("Is viso: {0,6:f2} EUR", isViso);
            Console.WriteLine("Vidutiniskai vienam nariui tenka: {0,6:f2} EUR", vienamNariui);
            Console.WriteLine("Is viso: {0,6:f2} EUR", bendrosIslaidos);
            Console.WriteLine("Programa baigė darbą");

        }

        static void skaiciuoti(Turistai[] turistai, int n, out double isViso, out double vienamNariui, out double bendrosIslaidos) {
            double visiLitai = 0, visiCentai = 0;
            
            for(int i = 0; i < n; i++) {
                visiLitai += turistai[i].kiekLitu();
                visiCentai += turistai[i].kiekCentu();
            }

            isViso = visiLitai + (visiCentai / 100);

            vienamNariui = isViso / n;

            bendrosIslaidos = isViso / 4;
        }

        static void skaitymas(string duom, Turistai[] turistai, out int n)
        {
            double litai, centai;

            using (StreamReader reader = new StreamReader(duom))
            {
                string line;
                string[] skaidymas;
                line = reader.ReadLine();
                n = int.Parse(line);

                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    skaidymas = line.Split(' ');
                    litai = double.Parse(skaidymas[0]);
                    centai = double.Parse(skaidymas[1]);
                    turistai[i] = new Turistai(litai, centai);
                }
            }
        }
    }
}


