using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klausimas2
{
    class Program
    {
        class Matrica
        {
            public const int Cn = 50;     // maksimalus eilučių, stulpelių skaičius           

            private int[,] DMas;          // dvimatis sveikų skaičių masyvas
            public int N { get; set; }    // savybė N: eilučių, stulpelių skaičius            

            public Matrica()
            {
                DMas = new int[Cn, Cn];
                N = 0;               
            }

            public void Deti(int i, int j, int sk)
            {
                DMas[i, j] = sk;
            }

            public int Imti(int i, int j)
            {
                return DMas[i, j];
            }

            // Užrašykite metodą, kuris suskaičiuoja kvadratinės matricos I srities
            // maksimalų neigiamą elementą.
            public int MaksimalusNeigiamasI()
            {
                int neig = int.MinValue;
                for (int i = 0; i <= N / 2; i++)
                {
                    for (int j = i; j <= N - i - 1; j++)
                    {
                        if (DMas[i, j] < 0 && DMas[i, j] > neig)
                        {
                            neig = DMas[i, j];
                        }
                    }
                }

                if (neig != int.MinValue)
                {
                    return neig;
                }
                else
                {
                    return 0;
                }
            }

            // Užrašykite metodą, kuris suskaičiuoja kvadratinės matricos I srities
            // maksimalų neigiamą elementą.
            public int MaksimalusNeigiamasII()
            {
                int neig = int.MinValue;
                for (int j = N / 2; j < N; j++)
                {
                    for (int i = N - j - 1; i <= j; i++)
                    {
                        if (DMas[i, j] < 0 && DMas[i, j] > neig)
                        {
                            neig = DMas[i, j];
                        }
                    }
                }

                if (neig != int.MinValue)
                {
                    return neig;
                }
                else
                {
                    return 0;
                }
            }

            public int MaksimalusNeigiamasIII()
            {
                int neig = int.MinValue;
                for (int i = N / 2; i < N; i++)
                {
                    for (int j = N - i - 1; j <= i; j++)
                    {
                        if (DMas[i, j] < 0 && DMas[i, j] > neig)
                        {
                            neig = DMas[i, j];
                        }
                    }
                }

                if (neig != int.MinValue)
                {
                    return neig;
                }
                else
                {
                    return 0;
                }
            }

            public int MaksimalusNeigiamasIV()
            {
                int neig = int.MinValue;
                for (int j = 0; j <= N / 2; j++)
                {
                    for (int i = j; i <= N - j - 1; i++)
                    {
                        if (DMas[i, j] < 0 && DMas[i, j] > neig)
                        {
                            neig = DMas[i, j];
                        }
                    }
                }

                if (neig != int.MinValue)
                {
                    return neig;
                }
                else
                {
                    return 0;
                }
            }

            //public int MaksimalusNeigiamas()
            //{
            //    int neig;
            //    if ((neig = ArYraNeigiamu()) != 0)
            //    {
            //        int i, j;
            //        //int pag;
            //        //pag = N / 2;
            //        //if (pag % 2 == 1)
            //        //{
            //        //    pag--;
            //        //}
            //        for (j = N / 2; j < N; j++)
            //        {
            //            for (i = N - j - 1; i <= j; i++)
            //            {
            //                if (DMas[i, j] < 0 && DMas[i, j] > neig)
            //                {
            //                    neig = DMas[i, j];
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        return 0;
            //    }

            //    return neig;
            //}

            //public int ArYraNeigiamu()
            //{
            //    int i, j;
            //    for (j = N / 2; j < N; j++)
            //    {
            //        for (i = N - j - 1; i < j; i++)
            //        {
            //            if (DMas[i, j] < 0)
            //            {
            //                return DMas[i, j];
            //            }
            //        }
            //    }

            //    return 0;
            //}
        }

            const string CFd = "..\\..\\Matrica1.txt";
            const string CFd1 = "..\\..\\Matrica2.txt";
            const string CFr= "..\\..\\Rez.txt";

           

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1257);
            if (File.Exists(CFr))
                File.Delete(CFr);

            Matrica Mtr = new Matrica();  // I konteineris su dvimačiu masyvu
            Skaityti(CFd, Mtr);
            Spausdinti(CFr, Mtr," Pirma matrica" );

            Matrica Mtr1 = new Matrica();  // II konteineris su dvimačiu masyvu
            Skaityti(CFd1, Mtr1);
            Spausdinti(CFr, Mtr1, " Antra matrica");

            int [] B = new int[Mtr.N];
            int [] B1 = new int[Mtr1.N];
            int kiek = 0;
            int kiek1 = 0;
            // Atlikite visus nurodytus skaičiavimus.

            int maksNeig = Mtr.MaksimalusNeigiamasIV();
            if (maksNeig != 0)
            {
                Console.WriteLine("Maksimalus pirmo masyvo pasirinktos srities neigiamas skaičius: {0}", maksNeig);
            }
            else
            {
                Console.WriteLine("Neigiamų skaičių srityje nėra!");
            }

            int maksNeig1 = Mtr1.MaksimalusNeigiamasIV();
            if (maksNeig1 != 0)
            {
                Console.WriteLine("Maksimalus antro masyvo pasirinktos srities neigiamas skaičius: {0}", maksNeig1);
            }
            else
            {
                Console.WriteLine("Neigiamų skaičių srityje nėra!");
            }

            RastiAntraDidziausia(B, Mtr, ref kiek);
            Spausdinti1(CFr, B, kiek, "Pirmo masyvo stulpeių antros mažiausios reikšmės:");

            RastiAntraDidziausia(B1, Mtr1, ref kiek1);
            Spausdinti1(CFr, B1, kiek1, "Antro masyvo stulpeių antros mažiausios reikšmės:");
        }

        static void Skaityti(string fv, Matrica A)
        {
            using (StreamReader reader = new StreamReader(fv))
            {
                int skaicius;
                string line = reader.ReadLine();
                char[] skyr = { ' ' };
                string[] skaiciai = line.Split(skyr,
                                      StringSplitOptions.RemoveEmptyEntries);
                A.N = int.Parse(skaiciai[0]);               
                for (int i = 0; i < A.N; i++)
                {
                    line = reader.ReadLine();
                    skaiciai = line.Split(skyr,
                                      StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < A.N; j++)
                    {
                        skaicius = int.Parse(skaiciai[j]);
                        A.Deti(i, j, skaicius);
                    }
                }
            }
        }


        // Matricos konteinerio duomenų spausdinimas faile fv
        static void Spausdinti(string fv, Matrica A, string tekstas)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine();
                fr.WriteLine("      " + tekstas);
                
                for (int i = 0; i < A.N; i++)
                {
                    for (int j = 0; j < A.N; j++)
                    {
                        fr.Write("{0, 4:d}", A.Imti(i, j));
                    }
                    fr.WriteLine();
                }
            }
        }

        // Masyvo duomenų spausdinimas faile fv
        static void Spausdinti1(string fv, int [] B, int n, string tekstas)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine();
                fr.WriteLine("      " + tekstas);

                for (int i = 0; i < n; i++)
                {                 
                    fr.Write("{0, 4:d}", B[i]);                    
                }
                fr.WriteLine();
            }
        }


        // Užrašykite metodą, kuris randa kiekvieno stulpelio antrą didžiausią elementą
        // ir jį įrašo į naują rinkinį.
        static void RastiAntraDidziausia(int[] naujas, Matrica m, ref int kiek)
        {
            for (int j = 0; j < m.N; j++)
            {
                //Console.WriteLine("-----------------------------------------");
                int pirmasDid = 0;
                int antrasDid = 0;
                if (m.Imti(0, j) > m.Imti(1, j))
                {
                    pirmasDid = m.Imti(0, j);
                    antrasDid = m.Imti(1, j);
                }
                else if (m.Imti(0, j) < m.Imti(1, j))
                {
                    pirmasDid = m.Imti(1, j);
                    antrasDid = m.Imti(0, j);
                }
                for (int i = 2; i < m.N; i++)
                {
                    if (m.Imti(i, j) > pirmasDid && m.Imti(i, j) > antrasDid)
                    {
                        //Console.WriteLine("!");
                        //Console.WriteLine(pirmasDid + " -> " + antrasDid + " -> " + m.Imti(i, j));
                        int temp = pirmasDid;
                        pirmasDid = m.Imti(i, j);
                        antrasDid = temp;
                    }
                    else if (m.Imti(i, j) < pirmasDid && m.Imti(i, j) > antrasDid)
                    {
                        //Console.WriteLine("!!");
                        //Console.WriteLine(pirmasDid + " -> " + antrasDid + " -> " + m.Imti(i, j));
                        antrasDid = m.Imti(i, j);
                    }
                }
                naujas[kiek++] = antrasDid;
            }
        }
        
    }
}
