using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Klases1
{
    class Siena
    {
        private double ilgis, //plytos ilgis
                     aukstis; //plytos aukstis

        public Siena(double ilgis, double aukstis)
        {
            this.ilgis = ilgis;
            this.aukstis = aukstis;
        }

        public double koksIlgis() { return ilgis; }

        public double koksAukstis() { return aukstis; }
    }

    class Plyta
    {
        private int ilgis, //plytos ilgis
                   plotis, //plytos plotis
                  aukstis; //plytos aukstis

        public Plyta(int ilgis, int plotis, int aukstis)
        {
            this.ilgis = ilgis;
            this.plotis = plotis;
            this.aukstis = aukstis;
        }

        public int koksIlgis() { return ilgis; }

        public int koksPlotis() { return plotis; }

        public int koksAukstis() { return aukstis; }
    }




    class Program
    {

        static void Main(string[] args)
        {

            double kiekPirmuPlytu;
            double kiekAntruPlytu;

            Siena s1 = new Siena(2.5, 5.4);
            Siena s2 = new Siena(3.2, 3.7);
            Siena s3 = new Siena(3.0, 6.2);
            Siena s4 = new Siena(2.7, 4.7);

            Plyta p1 = new Plyta(88, 120, 250);
            Plyta p2 = new Plyta(71, 115, 200);

            kiekPirmuPlytu = skaiciuotiViska(p1, s1, s2, s3, s4);
            kiekAntruPlytu = skaiciuotiViska(p2, s1, s2, s3, s4);

            Console.WriteLine("Pirmu plytu kiekis: {0,5:f0} \nAntru plytu kiekis: {1,5:f0}", kiekPirmuPlytu, kiekAntruPlytu);
        }

        static double vienaSiena(Plyta p, Siena s)
        {
            Console.WriteLine("Plytos ant kiekvienos sienos: {0,8:f0}", (s.koksIlgis() * s.koksAukstis() * 1000000) / (p.koksIlgis() * p.koksAukstis()));
            return (double)((s.koksIlgis() * s.koksAukstis() * 1000000) / (p.koksIlgis() * p.koksAukstis()));
        }

        static double skaiciuotiViska(Plyta p, Siena s1, Siena s2, Siena s3, Siena s4)
        {
            return (double)vienaSiena(p, s1) + vienaSiena(p, s2) + vienaSiena(p, s3) + vienaSiena(p, s4);
        }
    }
}




