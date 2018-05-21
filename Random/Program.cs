using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bandymas
{
    class Program
    {
        const string fvd = "../../duom.txt";
        const string fvr = "../../rez.txt";

        static int SkirtBalsiuSkaicius(string e)
        {
            string balses = "aeiyou";
            string naudotos = "";
            int kiek = 0;
            for (int i = 0; i < e.Length; i++)
            {
                if (balses.Contains(e[i]) && !naudotos.Contains(e[i]))
                {
                    kiek++;
                    naudotos += e[i];
                }
            }
            return kiek;
        }

        static string RastiZodiEil(string e, string sk)
        {
            string[] zodziai = e.Split(sk.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int eta = 0;
            string rez = "";
            for (int i = 0; i < zodziai.Length; i++)
            {
                if (SkirtBalsiuSkaicius(zodziai[i]) == 3 && zodziai[i].Length > eta)
                {
                    rez = zodziai[i];
                    eta = zodziai[i].Length;
                }
            }
            return rez;
        }

        static void RastiZTekste(string fv, string sk, out string zod, ref int me)
        {
            using (var reader = new StreamReader(fv))
            {
                zod = "";
                int eta = 0;
                int i = 0;
                string line = reader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    string a = RastiZodiEil(line, sk);
                    if (a.Length > eta)
                    {
                        eta = a.Length;
                        zod = a;
                        me = i;
                    }
                    line = reader.ReadLine();
                    i++;
                }
            }
        }

        static void PerkeltiEilute(string fvd, string fvr, int n)
        {
            using (var reader = new StreamReader(fvd))
            {
                string line = reader.ReadLine();
                string a = "";
                string b = line;
                int i = 0;
                while (!string.IsNullOrEmpty(line))
                {
                    if (i == n)
                    {
                        a = line;
                        break;
                    }
                    line = reader.ReadLine();
                    i++;
                }
                using (var reader1 = new StreamReader(fvd))
                {
                    using (var writer = new StreamWriter(fvr))
                    {
                        line = reader1.ReadLine();
                        line = reader1.ReadLine();
                        writer.WriteLine(a);
                        int j = 1;
                        while (!string.IsNullOrEmpty(line))
                        {
                            if (j == n) writer.WriteLine(b);
                            else writer.WriteLine(line);
                            line = reader1.ReadLine();
                            j++;
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int nr = 100;
            string skyr = ",. ;\"!?\\/–";
            string zod;
            RastiZTekste(fvd, skyr, out zod, ref nr);
            Console.WriteLine("Ilgiausias zodis: " + zod);
            PerkeltiEilute(fvd, fvr, nr);
        }
    }
}
