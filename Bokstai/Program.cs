using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokstai
{

    class PiliesSiena {
        private double aukstis, ilgis, plotis;

        public PiliesSiena(double ilgis, double plotis, double aukstis) {
            this.ilgis = ilgis;
            this.plotis = plotis;
            this.aukstis = aukstis;
        }

        public double koksAukstis() { return aukstis; }

        public double koksIlgis() { return ilgis; }

        public double koksPlotis() { return plotis; }

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
            double bokstoAukstis = 2.5;
            double bokstoSpindulys = 2.6;
            double bokstoStoris = 0.5;
            double bokstoTuris;
            bokstoTuris= (3.14 * bokstoSpindulys * bokstoSpindulys) * bokstoAukstis;

            double bokstoErtme;
            bokstoErtme = (3.14 * (bokstoSpindulys - bokstoStoris) * (bokstoSpindulys - bokstoStoris)) * bokstoAukstis;

            bokstoTuris = bokstoTuris - bokstoErtme;

            Plyta p = new Plyta(90, 120, 250);
            PiliesSiena s1 = new PiliesSiena(5.2, 26.5, 0.7);
            PiliesSiena s2 = new PiliesSiena(5.2, 50.5, 0.5);



            double sienoms;
            sienoms = skaiciuotiViska(p, s1, s2, s1, s2);
            double bokstams;
            bokstams = bokstui(p, bokstoTuris) * 4;
            double isViso;
            isViso = sienoms + bokstams;

            Console.WriteLine("Sienoms reikes: {0,8:f0}", sienoms);
            Console.WriteLine("Bokstams reikes: {0,8:f0}", bokstams);
            Console.WriteLine("");
            Console.WriteLine("Piliai is viso reikes: {0,8:f0}", isViso);
            Console.WriteLine("");

        }

        static double vienaSiena(Plyta p, PiliesSiena s)
        {
            return (double)((s.koksIlgis() * s.koksAukstis() * s.koksPlotis() * 1000000000) / (p.koksIlgis() * p.koksAukstis() * p.koksPlotis()));
        }

        static double bokstui(Plyta p, double turis)
        {
            return (double)(turis * 1000000000/ (p.koksIlgis() * p.koksAukstis() * p.koksPlotis()));
        }

        static double skaiciuotiViska(Plyta p, PiliesSiena s1, PiliesSiena s2, PiliesSiena s3, PiliesSiena s4)
        {
            return (double)vienaSiena(p, s1) + vienaSiena(p, s2) + vienaSiena(p, s3) + vienaSiena(p, s4);
        }
    }
}
