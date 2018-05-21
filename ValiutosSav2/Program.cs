using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Turistai
{
    class Pinigai
    {
        double litai, centai, kursas;

        public Pinigai(double litai, double centai, double kursas)
        {
            this.litai = litai;
            this.centai = centai;
            this.kursas = kursas;
        }

        public double kiekLitu() { return litai; }

        public double kiekCentu() { return centai; }

        public double koksKursas() { return kursas; } 
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int maxDuom = 100;
            const string A = "...\\...\\A.txt";
            const string B = "...\\...\\B.txt";

            int an, bn;

            Pinigai[] anupras = new Pinigai[maxDuom];
            Pinigai[] barbora = new Pinigai[maxDuom];
            // List<Pinigai> Barbora = new List<Pinigai>();

            skaitymas(A, anupras, out an);
            skaitymas(B, barbora, out bn);

            double kiekAnupro, kiekBarboros, isViso;
            skaiciuoti(anupras, barbora, an, bn, out kiekAnupro, out kiekBarboros, out isViso);

            Console.WriteLine("Barbora turi: {0,6:f2}", kiekBarboros);
            Console.WriteLine("Anupras turi: {0,6:f2}", kiekAnupro);
            Console.WriteLine("Bendra suma: {0,6:f2}", isViso);
            Console.WriteLine("Programa baigė darbą");

        }

        static void skaiciuoti(Pinigai[] anupras, Pinigai[] barbora, int an, int bn, out double kiekAnupro, out double kiekBarboros, out double isViso)
        {
            double visiLitai = 0, visiCentai = 0;

            for (int i = 0; i < an; i++)
            {
                visiLitai += anupras[i].kiekLitu() * anupras[i].koksKursas();
                visiCentai += anupras[i].kiekCentu() * anupras[i].koksKursas();
            }

            kiekAnupro = visiLitai + (visiCentai / 100);

            visiLitai = 0;
            visiCentai = 0;

            for (int i = 0; i < bn; i++)
            {
                visiLitai += barbora[i].kiekLitu() * barbora[i].koksKursas();
                visiCentai += barbora[i].kiekCentu() * barbora[i].koksKursas();
            }

            kiekBarboros = visiLitai + (visiCentai / 100);

            isViso = kiekAnupro + kiekBarboros;
        }

        static void skaitymas(string duom, Pinigai[] vaikai, out int n)
        {
            double litai, centai, kursas;

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
                    kursas = double.Parse(skaidymas[2]);
                    vaikai[i] = new Pinigai(litai, centai, kursas);
                }
            }
        }
    }
}
