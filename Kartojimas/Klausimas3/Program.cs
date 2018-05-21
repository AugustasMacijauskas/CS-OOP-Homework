using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Klausimas3
{
    class Program
    {
        const string duom = "...\\...\\Tekstas.txt";
        const string rez = "...\\...\\RedTekstas.txt";

        static void Main(string[] args)
        {

            string skyrikliai = " .,;:?!";
            if (File.Exists(rez))
                File.Delete(rez);
            RastiZTekste(duom, rez, skyrikliai);           
        }

        

        static void RastiZTekste(string fr, string fv, string skyrikliai)
        {
            using (var ats = File.CreateText(fv))
            {
                using (StreamReader reader = new StreamReader(fr))
                {
                    string line = "pradzia";                   
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Panaudoti metodą, kuris randa ir išmeta pirmą trumpiausią kiekvienos eilutės žodį,
                        // kuriame yra bent 2 skirtingi nelyginiai skaitmenys. Skyrikliai nemetami.
                        line = IšmestiEilutėsŽodį(line, skyrikliai);
                        ats.WriteLine(line);
                        Console.WriteLine(line);
                    }
                }
            }
        }



        // Užrašykite metodą, kuris randa ir išmeta pirmą trumpiausią kiekvienos eilutės žodį,
        // kuriame yra bent 2 skirtingi nelyginiai skaitmenys. Skyrikliai nemetami.
        static string IšmestiEilutėsŽodį(string line, string skyrikliai)
        {
            string[] words = line.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string žodisIšmesti = "";

            foreach (string word in words)
            {
                if (NelygSkaitmenuSkaicius(word) >= 2 && (word.Length < žodisIšmesti.Length || žodisIšmesti == ""))
                {
                    žodisIšmesti = word;
                }
            }

            if (žodisIšmesti != "")
            {
                // line = new Regex($@"\b{žodisIšmesti}\b").Replace(line, "", 1);
                
                int ilgis = žodisIšmesti.Length;
                int index = -1;

                while ((index = line.IndexOf(žodisIšmesti, index + 1)) != -1)
                {
                    if (index - 1 > 0)
                    {
                        if (!skyrikliai.Contains(line[index - 1]))
                        {
                            continue;
                        }
                    }
                    if (index + ilgis + 1 < line.Length)
                    {
                        if (!skyrikliai.Contains(line[index + ilgis]))
                        {
                            continue;
                        }
                    }
                    line = line.Remove(index, ilgis);
                    return line;
                }
            }
            else
            {
                return line;
            }

            return "";
        }


        static int NelygSkaitmenuSkaicius(string e)
        {
            int kiekis = 0;

            string skaiciai = "13579";

            for (int i = 0; i < skaiciai.Length; i++)
            {
                int sk = e.IndexOf(skaiciai[i]);
                if (sk != -1)
                {
                    kiekis++;
                }
            }
            return kiekis;
        }
    }
}
