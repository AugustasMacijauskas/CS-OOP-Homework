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
            eilute = string.Format("{0, -45}       {1, 4:d}           {2, 3:d}            {3, -5:f}", vp, gimM, ugis, taskai);
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

        public void Rikiuoti()
        {
            Krepsininkas pag;
            int minInd;

            for (int i = 0; i < n - 1; i++)
            {
                minInd = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (krep[minInd] >= krep[j])
                    {
                        minInd = j;
                    }
                }

                pag = krep[i];
                krep[i] = krep[minInd];
                krep[minInd] = pag;
            }
        }

        public void Įterpti(string vardas, int gimimoM, int ug, double tsk)
        {
            if (n + 1 <= max)
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
            else
            {
                Console.WriteLine("\nDaugiau elementų įterpti nebegalima - masyvas pilnas.");
            }
        }

        public void ŠalintiSuIndexu(int z)
        {
            if (z < n && z >= 0)
            {
                for (int i = z; i < n - 1; i++)
                {
                    krep[i] = krep[i + 1];
                }

                n = n - 1;
            }
            else
            {
                Console.WriteLine("Negalima pašalinti - norimas indeksas išeina iš masyvo ribų");
            }
        }

        public void ŠalintiVyresnius(int amz)
        {
            int m = 0;

            for (int i = 0; i < n; i++)
            {
                if (krep[i].KadaGime() >= amz)
                {
                    krep[m++] = krep[i];
                }
            }

            n = m;

            //for (int i = 0; i < n; i++)
            //{
            //    if (krep[i].KadaGime() < amz)
            //    {
            //        for (int j = i; j < n - 1; j++)
            //        {
            //            krep[j] = krep[j + 1];
            //        }
            //        n = n - 1;
            //        i = i - 1;
            //    }
            //}
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

            krep.Rikiuoti();
            Spausdinti(krep, "Surikiuoti pradiniai duomenys:");

            //Randame zaideju, kuriu ugis <200, min pelnytus tsk
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


            //Formuojame nauja masyva is krepsininku, kuriu ugis < y;
            KrepsininkuKonteineris naujas = new KrepsininkuKonteineris();
            int y;
            Console.Write("Įveskite, už kokį ūgį mažesnius žaidėjus sudėti į naują konteinerį: ");
            while(!int.TryParse(Console.ReadLine(), out y) || y < 100 || y > 272)
            {
                Console.Write("Klaida! Įveskite skaičių, o ne eilutę (nuo 100 iki 272): ");
            }
            Console.WriteLine();
            NaujoFormavimas(krep, naujas, y);
            Spausdinti(naujas, string.Format("Naujai suformuotas masyvas: žaidėjai, kurių ūgis mažesnis už {0}", y));
            //if (naujas.Imti() > 0)
            //{
            //    Spausdinti(naujas, string.Format("Naujai suformuotas masyvas: žaidėjai, kurių ūgis mažesnis už {0}", y));
            //}
            //else
            //{
            //    Console.WriteLine("Sąrašas tuščias");
            //    Console.WriteLine();
            //}



            //Iterpiame nauja elementa i masyva
            string vardas;
            int gimimoMetai, ugis;
            double tskVid;

            Console.Write("Įveskite naujo žaidėjo pavardę ir vardą (-us): ");
            vardas = Console.ReadLine();

            string[] pagalbinis;
            int count = 0;
            bool ArVisosDidziosios = true;
            while (true)
            {
                pagalbinis = vardas.Trim().Split(' ');
                count = 0;
                ArVisosDidziosios = true;
                if (pagalbinis.Length >= 2)
                {
                    for (int i = 0; i < pagalbinis.Length; i++)
                    {
                        if (!char.IsUpper(pagalbinis[i].Trim()[0]))
                        {
                            ArVisosDidziosios = false;
                        }
                        count += pagalbinis[i].Count(c => char.IsUpper(c));
                    }
                }
                Console.WriteLine(ValidLetters(vardas));
                if (!ValidLetters(vardas) || vardas.Any(char.IsDigit) || !ArVisosDidziosios || count != pagalbinis.Length || pagalbinis.Length < 2)
                {
                    Console.Write("Klaida! Įvesti netinkami pavardė arba vardas - bandykite iš naujo: ");
                    vardas = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }

            Console.Write("Įveskite naujo žaidėjo gimimo metus: ");
            while (!int.TryParse(Console.ReadLine(), out gimimoMetai) || gimimoMetai < 1900 || gimimoMetai > 2017)
            {
                Console.Write("Klaida! Įveskite skaičių, o ne eilutę (nuo 1900 iki 2017): ");
            }
            Console.Write("Įveskite naujo žaidėjo ūgį: ");
            while (!int.TryParse(Console.ReadLine(), out ugis) || ugis < 100 || ugis > 272)
            {
                Console.Write("Klaida! Įveskite skaičių, o ne eilutę (nuo 100 iki 272): ");
            }
            Console.Write("Įveskite naujo žaidėjo įmetamų taškų vidurkį: ");
            while (!double.TryParse(Console.ReadLine(), out tskVid) || tskVid < 0 || tskVid > 45)
            {
                Console.Write("Klaida! Įveskite skaičių, o ne eilutę (nuo 0 iki 45): ");
            }

            krep.Įterpti(vardas, gimimoMetai, ugis, tskVid);
            Console.WriteLine();
            Spausdinti(krep, "Įterptas elementas:");

            //Elemento naikinimas
            int x;
            Console.Write("Įveskite, kurį elementą norite pašalinti: ");
            while (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x >= krep.Imti())
            {
                Console.Write("Klaida! Įveskite skaičių, o ne eilutę (nuo 0 iki {0}): ", krep.Imti() - 1);
            }
            krep.ŠalintiSuIndexu(x);
            Spausdinti(krep, string.Format("Pašalintas {0} elementas:", x));

            //Pasaliname visus, kurie gime anksciau, nei nurodoma
            Console.Write("Įveskite, kurių gimimo metų ir jaunesnius žaidėjus norite palikti: ");
            while (!int.TryParse(Console.ReadLine(), out x) || x < 1900 || x > 2017)
            {
                Console.Write("Klaida! Įveskite skaičių, o ne eilutę (nuo 1900 iki 2017): ");
            }
            krep.ŠalintiVyresnius(x);
            Spausdinti(krep, string.Format("Pašalinti krepšininkai, gimę anksčiau nei {0} m.:", x));

            Console.WriteLine("Programa baigė darbą!");

        }

        static bool ValidLetters(string x)
        {
            string allowableLetters = "aąbcčdeęėfghiįyjklmnoprsštuųūvzžAĄBCČDEĘĖFGHIĮYJKLMNOPRSŠTUŲŪVZŽ ";

            foreach (char c in x)
            {
                if (!allowableLetters.Contains(c))
                {
                    return false;

                }
            }

            return true;
        }

        static void NaujoFormavimas(KrepsininkuKonteineris krep, KrepsininkuKonteineris naujas, int y)
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
            const string virsus = "------------------------------------------------------------------------------------------------------\r\n" +
                                  "  Nr.    Pavardė Vardas                                   Gim. metai       Ūgis       Taškų vidurkis  \r\n" +
                                  "------------------------------------------------------------------------------------------------------";

            Console.WriteLine(etikete);
            if (krep.Imti() > 0)
            {
                Console.WriteLine(virsus);
                for (int i = 0; i < krep.Imti(); i++)
                {
                    Console.WriteLine("   {0}     {1}", i + 1, krep.Imti(i).ToString());
                }
                Console.WriteLine("------------------------------------------------------------------------------------------------------\n");
            }
            else
            {
                Console.WriteLine("Sąrašas tuščias");
            }
            
        }

        static void Skaityti(KrepsininkuKonteineris krep)
        {
            string vp; //vardas pavarde
            int gimM;
            int ugis;
            double taskai;

            string[] skaidymas;

            string[] lines = File.ReadAllLines(duom);

            foreach (string line in lines)
            {
                if (line != "" && krep.Imti() < krep.KoksMax())
                {
                    skaidymas = line.Split(';');
                    if (skaidymas.Length == 4)
                    {
                        vp = skaidymas[0].Trim();
                        string[] pagalbinis = vp.Split(' ');
                        int count = 0;
                        bool ArVisosDidziosios = true;
                        if (pagalbinis.Length >= 2)
                        {
                            for (int i = 0; i < pagalbinis.Length; i++)
                            {
                                if (!char.IsUpper(pagalbinis[i][0]))
                                {
                                    ArVisosDidziosios = false;
                                }
                                count += pagalbinis[i].Count(c => char.IsUpper(c));
                            }
                        }
                        if (vp.Any(char.IsDigit) || !ArVisosDidziosios || count != pagalbinis.Length || pagalbinis.Length < 2)
                        {
                            //vp = "Pavardenis Vardenis";
                            continue;
                        }
                        if (Int32.TryParse(skaidymas[1].Trim(), out gimM))
                        {
                            if (gimM < 1900 || gimM > 2017)
                            {
                                //gimM = 2000;
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                            //gimM = 2000;
                        }
                        if (Int32.TryParse(skaidymas[2].Trim(), out ugis))
                        {
                            if (ugis < 100 || ugis > 272)
                            {
                                //ugis = 180;
                                continue;
                            }
                        }
                        else
                        {
                            //ugis = 180;
                            continue;
                        }
                        if (double.TryParse(skaidymas[3].Trim(), out taskai))
                        {
                            if (taskai < 0 || taskai > 45)
                            {
                                //taskai = 0;
                                continue;
                            }
                        }
                        else
                        {
                            //taskai = 0;
                            continue;
                        }

                        Krepsininkas nauj = new Krepsininkas(vp, gimM, ugis, taskai);
                        krep.Dėti(nauj);
                    }
                    //else
                    //{
                    //    Krepsininkas nauj = new Krepsininkas("Pavardenis Vardenis", 2000, 180, 7.5);
                    //    krep.Dėti(nauj);
                    //}
                }            
            }
        }
    }
}
