using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace K4pavyzdinis
{
    class Program
    {
        const string duom = "..\\..\\duom.txt";
        const string rez = "..\\..\\rez.txt";

        static void Main(string[] args)
        {
            string sk = "() ;:'\"?.!,/\n\r\t";
            string zod;
            int me = 0;
            RastiZTekste(duom, sk, out zod, ref me);

            if (File.Exists(rez))
                File.Delete(rez);

            if (zod != "")
            {
                Console.WriteLine(zod + " " + me);
                PerkeltiEilute(duom, rez, me);
            }
            else
            {
                Console.WriteLine("Žodžių nėra");
            }

            //string e = "aaa, 1234 bbb, ccc, eey?!, aye lmaoe";
            //Console.WriteLine(SkirtBalsiuSkaicius(e));
            //Console.WriteLine(RastiZodiEil(e, sk));
        }

        static int SkirtBalsiuSkaicius(string e)
        {
            string balsės = "aeiuyo";
            int kiek = 0;

            for (int i = 0; i < balsės.Length; i++)
            {
                if (e.IndexOf(balsės[i]) != -1)
                {
                    kiek++;
                }
            }

            return kiek;
        }

        static string RastiZodiEil(string e, string sk)
        {
            string eil = "";
            string[] parts = e.Split(sk.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (string x in parts)
            {
                if (SkirtBalsiuSkaicius(x) == 3)
                {
                    if (eil == "" || x.Length < eil.Length)
                    {
                        eil = x;
                    }
                }
            }

            return eil;
        }

        static void RastiZTekste(string fv, string sk, out string zod, ref int me)
        {
            zod = "";
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                int n = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    n++;
                    string pagalb = RastiZodiEil(line, sk);
                    if (zod == "" || pagalb.Length < zod.Length)
                    {
                        zod = pagalb;
                        me = n;
                    }
                }
            }
        }

        static void PerkeltiEilute(string fvd, string fvr, int n)
        {
            string pagalb = "";

            using (StreamReader reader = new StreamReader(fvd))
            {
                for (int i = 0; i < n; i++)
                {
                    pagalb = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader(fvd))
            {
                using (var fr = File.AppendText(fvr))
                {
                    string line;
                    fr.WriteLine(pagalb);
                    for (int i = 1; i < n && ((line = reader.ReadLine()) != null); i++)
                    {
                        fr.WriteLine(line);
                    }
                    reader.ReadLine();
                    while((line = reader.ReadLine()) != null)
                    {
                        fr.WriteLine(line);
                    }
                }
            }
        }
    }
}
