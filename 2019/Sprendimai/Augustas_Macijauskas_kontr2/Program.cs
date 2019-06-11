using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace K2_117
{
    class Krepsininkas
    {
        private string vp; //vardas pavarde
        private int gimM;
        private int ugis;
        private double taskai;

        public Krepsininkas()
        {

        }

        public Krepsininkas(string vardpav, int gim, int ug, double task)
        {
            vp = vardpav;
            gimM = gim;
            ugis = ug;
            taskai = task;
        }
        public string KoksVardas() { return vp; }

        public int KadaGime() { return gimM; }

        public int KoksUgis() { return ugis; }

        public double KiekTasku() { return taskai; }

        public static bool operator <=(Krepsininkas k1, Krepsininkas k2)
        {
            int poz = String.Compare(k1.vp, k2.vp, StringComparison.CurrentCulture);

            return ((k1.taskai < k2.taskai) || ((k1.taskai == k2.taskai) && poz < 0));
        }

        public static bool operator >=(Krepsininkas k1, Krepsininkas k2)
        {
            int poz = String.Compare(k1.vp, k2.vp, StringComparison.CurrentCulture);

            return ((k1.taskai > k2.taskai) || ((k1.taskai == k2.taskai) && poz > 0));
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -20}       {1, 4:d}           {2, 3:d}            {3, -5:f}", vp, gimM, ugis, taskai);
            return eilute;
        }
    }

    class KrepsininkuKonteineris
    {
        const int max = 100;
        private int n = 0;
        private Krepsininkas[] krep;

        public KrepsininkuKonteineris()
        {
            krep = new Krepsininkas[max];
        }

        public void Dėti(Krepsininkas ob) { krep[n++] = ob; }

        public int Imti() { return n; }

        public Krepsininkas Imti(int k) { return krep[k]; }

        public int KoksMax() { return max; }

        public void Įterpti(string vardas, int gimimoM, int ug, double tsk)
        {
            Krepsininkas naujas = new Krepsininkas(vardas, gimimoM, ug, tsk);

            int i;
            for (i = 0; (i < n) && (krep[i] <= naujas); i++)
            {

            }

            for (int j = n; j > i; j--)
            {
                krep[j] = krep[j - 1];
            }

            krep[i] = naujas;
            n = n + 1;
        }

        public double MinTaskai()
        {
            double minTsk = -1;

            int i;
            for (i = 0; i < n; i++)
            {
                if (krep[i].KoksUgis() < 200)
                {
                    minTsk = krep[i].KiekTasku();
                    break;
                }
            }

            for (int j = i; j < n; j++)
            {
                if (krep[j].KoksUgis() < 200)
                {
                    if (krep[j].KiekTasku() < minTsk)
                    {
                        minTsk = krep[j].KiekTasku();
                    }
                }
            }

            return minTsk;
        }
    }

    class Program
    {
        const string duom = "..\\..\\Komanda.txt";

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.GetEncoding(1257);
            KrepsininkuKonteineris krep = new KrepsininkuKonteineris();

            //Skaitymas ir spausdinimas
            Skaityti(krep);
            Spausdinti(krep, "Pradiniai duomenys:");



            //Randame ziadeju, kuriu ugis <200, min pelnytus tsk
            double minTsk = krep.MinTaskai();
            if (minTsk > -1)
            {
                Console.WriteLine("Krepšininkų kurių ūgis <200, min taškų kiekis: {0}", minTsk);
            }
            else
            {
                Console.WriteLine("Mažiausio taškų kiekio surasti negalima, nes nėra tinkamų žaidėjų");
            }
            Console.WriteLine();



            //Iterpiame nauja elementa i masyva
            string vardas;
            int gimimoMetai, ugis;
            double tskVid;

            Console.Write("Įveskite naujo žaidėjo pavardę ir vardą: ");
            vardas = Console.ReadLine();
            Console.Write("Įveskite naujo žaidėjo gimimo metus: ");
            gimimoMetai = int.Parse(Console.ReadLine());
            Console.Write("Įveskite naujo žaidėjo ūgį: ");
            ugis = int.Parse(Console.ReadLine());
            Console.Write("Įveskite naujo žaidėjo įmetamų taškų vidurkį: ");
            tskVid = double.Parse(Console.ReadLine());

            krep.Įterpti(vardas, gimimoMetai, ugis, tskVid);
            Console.WriteLine();
            Spausdinti(krep, "Įterptas elementas:");



            //Formuojame nauja masyva is krepsininku, kuriu ugis < y;
            KrepsininkuKonteineris naujas = new KrepsininkuKonteineris();
            double y;
            Console.Write("Įveskite, už kokį ūgį mažesnius žaidėjus sudėti į naują konteinerį: ");
            y = double.Parse(Console.ReadLine());
            Console.WriteLine();
            NaujoFormavimas(krep, naujas, y);
            if (naujas.Imti() > 0)
            {
                Spausdinti(naujas, string.Format("Naujai suformuotas masyvas: žaidėjai, kurių ūgis mažesnis už {0}", y));
            }
            else
            {
                Console.WriteLine("Sąrašas tuščias");
                Console.WriteLine();
            }

            Console.WriteLine("Programa baigė darbą!");

        }

        static void NaujoFormavimas(KrepsininkuKonteineris krep, KrepsininkuKonteineris naujas, double y)
        {
            for (int i = 0; i < krep.Imti(); i++)
            {
                if (krep.Imti(i).KoksUgis() < y)
                {
                    naujas.Dėti(krep.Imti(i));
                }
            }
        }

        static void Spausdinti(KrepsininkuKonteineris krep, string etikete)
        {
            const string virsus = "-----------------------------------------------------------------------------\r\n" +
                                  "  Nr.    Pavardė Vardas          Gim. metai       Ūgis       Taškų vidurkis  \r\n" +
                                  "-----------------------------------------------------------------------------";

            Console.WriteLine(etikete);
            if (krep.Imti() > 0)
            {
                Console.WriteLine(virsus);
                for (int i = 0; i < krep.Imti(); i++)
                {
                    Console.WriteLine("   {0}     {1}", i + 1, krep.Imti(i).ToString());
                }
                Console.WriteLine("-----------------------------------------------------------------------------\n");
            }
            else
            {
                Console.WriteLine("Sąrašas tuščias");
            }
            
        }

        static void Skaityti(KrepsininkuKonteineris krep)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string vp; //vardas pavarde
                int gimM;
                int ugis;
                double taskai;

                string line;
                string[] skaidymas;

                while(((line = reader.ReadLine()) != null) && krep.Imti() < krep.KoksMax())
                {
                    skaidymas = line.Split(';');
                    vp = skaidymas[0].Trim();
                    gimM = int.Parse(skaidymas[1].Trim());
                    ugis = int.Parse(skaidymas[2].Trim());
                    taskai = double.Parse(skaidymas[3].Trim());

                    Krepsininkas nauj = new Krepsininkas(vp, gimM, ugis, taskai);
                    krep.Dėti(nauj);
                }
            }
        }
    }
}
