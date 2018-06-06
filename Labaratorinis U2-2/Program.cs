using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labaratorinis_U2_2
{

    class Studentas
    {
        private int amzius, //amzius studento
                    svoris; //studento svoris

        double ugis; //studento ugis

        public Studentas(int amzius, double ugis, int svoris)
        {
            this.amzius = amzius;
            this.ugis = ugis;
            this.svoris = svoris;
        }

        public int koksAmzius() { return amzius; }

        public double koksUgis() { return ugis; }

        public int koksSvoris() { return svoris; }
    }

    class Liftas
    {
        private int galia,
                    talpa;

        public Liftas(int galia, int talpa)
        {
            this.galia = galia;
            this.talpa = talpa;
        }

        public int kokiaGalia() { return galia; }

        public int kokiaTalpa() { return talpa; }

        public void DidintiGalia(int x)
        {
            galia *= x;
        }

        public void DidintiTalpa(int x)
        {
            talpa *= x;
        }

        public void MazintiTalpa(int x)
        {
            talpa /= x;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Studentas[] studentai = new Studentas[3];

            studentai[0] = new Studentas(20, 1.78, 76);
            studentai[1] = new Studentas(19, 1.85, 82);
            studentai[2] = new Studentas(21, 1.79, 73);

            Liftas l = new Liftas(150, 3);

            for (int i = 0; i < studentai.Length; i++)
            {
                if (studentai[i].koksUgis() == auksciausioAmzius(studentai))
                {
                    Console.WriteLine("Auksciausio studento amzius: {0,6:d}", studentai[i].koksAmzius());
                }
            }

            for (int j = 0; j < studentai.Length; j++)
            {
                if (studentai[j].koksAmzius() == jauniausioUgis(studentai))
                {
                    Console.WriteLine("Jauniausio studento ugis:    {0,6:f2}", studentai[j].koksUgis());
                }
            }
            Console.WriteLine("");

            int visuStudentuSvoris = svoris(studentai);
            int kiekStudentu = studentai.Length;
            int kiekKartuKelsimes;
            kiekKartuKelsimes = kiekKartuReiksKelti(kiekStudentu, studentai, l);


            Console.WriteLine("Vidutinis studentu svoris:     {0,4:d}", visuStudentuSvoris / kiekStudentu);
            Console.WriteLine("");

            int kiekKilimu = kiekKilsim(l, studentai, visuStudentuSvoris, kiekKartuKelsimes);
            Console.WriteLine("Studentai pakils per:      {0,5:d} k.", kiekKilimu);
            Console.WriteLine("");



            l.DidintiTalpa(2);
            kiekKilimu = kiekKilsim(l, studentai, visuStudentuSvoris, kiekKartuKelsimes);
            Console.WriteLine("Padidinus talpa studentai pakils per: {0,5:d} k.", kiekKilimu);
            l.MazintiTalpa(2); // Graziname talpa i pradine verte, kad nepasikeistu galios skaiciavimas



            l.DidintiGalia(2);
            kiekKilimu = kiekKilsim(l, studentai, visuStudentuSvoris, kiekKartuKelsimes);
            Console.WriteLine("Padidinus galia studentai pakils per: {0,5:d} k.", kiekKilimu);
            Console.WriteLine("");
        }

        static int kiekKartuReiksKelti(int kiekStudentu, Studentas[] studentai, Liftas l)
        {
            int kiekKartuReiksKelti;

            if (kiekStudentu % l.kokiaTalpa() == 0)
            {
                kiekKartuReiksKelti = kiekStudentu / l.kokiaTalpa();
            }
            else
            {
                kiekKartuReiksKelti = kiekStudentu / l.kokiaTalpa() + 1;
            }

            return kiekKartuReiksKelti;
        }

        static int kiekKilsim(Liftas l, Studentas[] studentai, int visuStudentuSvoris, int x)
        {
            int kiekKilimu = 0;

            if (x * l.kokiaGalia() > visuStudentuSvoris)
            {
                kiekKilimu = x;
            }
            else
            {
                kiekKilimu = x + 1;
            }

            return kiekKilimu;
        }

        static int jauniausioUgis(Studentas[] studentai)
        {
            int jauniausioAmzius = studentai[0].koksAmzius();

            for (int i = 1; i < studentai.Length; i++)
            {
                if (studentai[i].koksAmzius() < jauniausioAmzius)
                {
                    jauniausioAmzius = studentai[i].koksAmzius();
                }
            }

            return jauniausioAmzius;
        }

        static int svoris(Studentas[] studentai)
        {
            int visuSvoris = 0;

            for (int i = 0; i < studentai.Length; i++)
            {
                visuSvoris += studentai[i].koksSvoris();
            }

            return visuSvoris;
        }

        static double auksciausioAmzius(Studentas[] studentai)
        {
            double auksciausioUgis = studentai[0].koksUgis();

            for (int i = 1; i < studentai.Length; i++)
            {
                if (studentai[i].koksUgis() > auksciausioUgis)
                {
                    auksciausioUgis = studentai[i].koksUgis();
                }
            }

            return auksciausioUgis;
        }


    }
}
