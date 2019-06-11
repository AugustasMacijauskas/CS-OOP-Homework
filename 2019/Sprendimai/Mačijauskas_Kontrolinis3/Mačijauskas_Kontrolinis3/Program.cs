using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mačijauskas_Kontrolinis3
{
    class Program
    {
        const string duom = "..\\..\\Tekstas.txt";
        const string rez = "..\\..\\RedTekstas.txt";

        static void Main(string[] args)
        {
            if (File.Exists(rez))
                File.Delete(rez);

            string skyrikliai = " ,.?!/:;\'\"\n\r\t()";

            int nr = 0;
            string zod;

            RastiZTekste(duom, skyrikliai, out zod, ref nr);

            if (zod == "")
            {
                Console.WriteLine("Žodžio, kuriame būtų 3 lyginiai skaitmenys duotame faile nėra!");
            }
            else
            {
                Console.WriteLine("Trumpiausias žodis: {0}, jo eilutės nr.: {1}", zod, nr);
                PerkeltiEilute(duom, rez, nr);
            }

            Console.WriteLine("Programa baigė darbą!");
        }

        static int SkaitmenuSkaicius(string e)
        {
            int kiek = 0;
            string lyg_skaitmenys = "02468";

            for (int i = 0; i < e.Length; i++)
            {
                if (lyg_skaitmenys.Contains(e[i]))
                {
                    kiek++;
                }
            }

            return kiek;
        }

        static void TrumpasZodis(string e, string s, out string zod)
        {
            string[] parts = e.Split(s.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string eil = "";

            for (int i = 0; i < parts.Length; i++)
            {
                if (SkaitmenuSkaicius(parts[i]) == 3)
                {
                    if (eil == "" || parts[i].Length < eil.Length)
                    {
                        eil = parts[i];
                    }
                }
            }

            zod = eil;
        }

        static void RastiZTekste(string fv, string s, out string zod, ref int nr)
        {
            zod = "";

            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                int count = 0;

                while((line = reader.ReadLine()) != null)
                {
                    count++;
                    string pagalb;
                    TrumpasZodis(line, s, out pagalb);
                    if (pagalb != "")
                    {
                        if (zod == "" || pagalb.Length < zod.Length)
                        {
                            zod = pagalb;
                            nr = count;
                        }
                    }
                }
            }
        }

        static void PerkeltiEilute(string fv1, string fv2, int nr)
        {
            string perkelimas = "";
            using (StreamReader reader = new StreamReader(fv1))
            {
                for (int i = 1; i <= nr; i++)
                {
                    perkelimas = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader(fv1))
            {
                string line;
                using (var fw = File.AppendText(fv2))
                {
                    fw.WriteLine(perkelimas);

                    for (int i = 1; i < nr && ((line = reader.ReadLine()) != null); i++)
                    {
                        fw.WriteLine(line);
                    }

                    reader.ReadLine();

                    while ((line = reader.ReadLine()) != null)
                    {
                        fw.WriteLine(line);
                    }
                }
            }
        }
    }
}