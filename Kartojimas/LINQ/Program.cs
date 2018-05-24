using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LINQ
{
    class Program
    {
        const string duom = "..\\..\\duom.txt";
        const string rez = "..\\..\\rez.txt";
        const string priebalses = "qwrtpsdfghjklzxcvbnmQWRTPSDFGHJKLZXCVBNM";
        const string balses = "eyuioaEYUIOA";


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1257);
            if (File.Exists(rez))
                File.Delete(rez);
            string skyrikliai = " !?.,<>/?;:'\"\\|{[}]()";
            int ind1;
            int ind2;
            string eil1;
            string eil2;
            Skaityti(duom, skyrikliai, out ind1, out ind2, out eil1, out eil2);
            Console.WriteLine(ind1 + " " + ind2);
            Console.WriteLine(eil1 + "\n" + eil2);
            if (ind1 > ind2)
            {
                int temp = ind1;
                ind1 = ind2;
                ind2 = temp;
                string pagalb = eil1;
                eil1 = eil2;
                eil2 = pagalb;
            }
            Console.WriteLine(ind1 + " " + ind2);
            Console.WriteLine(eil1 + "\n" + eil2);
            if (ind1 != -1 && ind2 != -1 && eil1 != "" && eil2 != "" && ind1 != ind2)
            {
                Sukeisti(duom, rez, ind1, ind2, eil1, eil2);
            }
            else
            {
                Console.WriteLine("Klaida");
            }

            Console.WriteLine("Programa baigė darbą!");
        }

        static void Sukeisti(string duom, string rez, int ind1, int ind2, string eil1, string eil2)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                using (StreamWriter writer = new StreamWriter(rez))
                {
                    string line;
                    for (int i = 0; (i < ind1) && ((line = reader.ReadLine()) != null); i++)
                    {
                        writer.WriteLine(line);
                    }
                    line = reader.ReadLine();
                    writer.WriteLine(eil2);
                    for (int i = ind1 + 1; (i < ind2) && ((line = reader.ReadLine()) != null); i++)
                    {
                        writer.WriteLine(line);
                    }
                    line = reader.ReadLine();
                    writer.WriteLine(eil1);
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                    }

                }
            }
        }

        static void Skaityti(string duom, string skyrikliai, out int balse, out int prieb, out string eil1, out string eil2)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string line;
                int i = 0;
                string ilgiausiasSuBalse = "";
                string trumpiausiasSuPriebalse = "";
                eil1 = "";
                eil2 = "";
                balse = -1;
                prieb = -1;
                while ((line = reader.ReadLine()) != null)
                {
                    int ilgis = line.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .Where(x => balses.Contains(x.Last()))
                        .Select(x => x.Length)
                        .OrderByDescending(x => x)
                        .Skip(1)
                        .FirstOrDefault();
                    if (ilgis != 0)
                        Console.WriteLine(ilgis);
                    List<string> temp1 = line.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Where(x => balses.Contains(x[x.Length - 1]) && x.Length > ilgiausiasSuBalse.Length)
                        .OrderByDescending(x => x.Length).ToList();

                    if (temp1.Count >= 2)
                    {
                        string pagalb = temp1.Skip(1).FirstOrDefault().ToString();
                        Console.WriteLine(pagalb);
                        if (pagalb != "")
                        {
                            ilgiausiasSuBalse = pagalb;
                            eil1 = line;
                            balse = i;
                        }
                    }
                        
                    string temp2 = line.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Where(x => priebalses.Contains(x[x.Length - 1]))
                        .OrderBy(x => x.Length).FirstOrDefault().ToString();
                    Console.WriteLine(temp2);
                    if (temp2 != "")
                    {
                        if (temp2.Length < trumpiausiasSuPriebalse.Length || trumpiausiasSuPriebalse == "")
                        {
                            trumpiausiasSuPriebalse = temp2;
                            eil2 = line;
                            prieb = i;
                        }
                    }
                    i++;
                }
            }
        }
    }
}
