using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Klausimas5
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



                        // Panaudokite metodą, kuris randa priešpaskutinį kiekvienos eilutės žodį, pasibaigiantį lotyniška priebalse,
                        // ir jį sukeičia vietomis su paskutiniu eilutės žodžiu. Skyrikliai nekeičiami.
                        line = SukeistiZodzius(line, skyrikliai);
                        ats.WriteLine(line);
                        Console.WriteLine(line);
                    }
                }
            }
        }



        // Užrašykite metodą, kuris randa priešpaskutinį kiekvienos eilutės žodį, pasibaigiantį lotyniška priebalse,
        // ir jį sukeičia vietomis su paskutiniu eilutės žodžiu. Skyrikliai nekeičiami.
        static string SukeistiZodzius(string line, string skyrikliai)
        {
            string[] words = line.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<string> tinkami = new List<string>();

            foreach (string word in words)
            {
                if (BaigiasiLotyniskaPriebalse(word))
                {
                    tinkami.Add(word);
                }
            }

            if (tinkami.Count >= 2)
            {
                string zodisPakeisti = tinkami[tinkami.Count - 2];
                string paskutinisZodis = words[words.Length - 1];
                // Console.WriteLine(line);
                // Console.WriteLine(zodisPakeisti + " --> " + paskutinisZodis);
                line = new Regex($@"\b({paskutinisZodis})([{skyrikliai}]*)$").Replace(line, $"{zodisPakeisti}$2", 1);
                line = new Regex($@"\b({zodisPakeisti})\b").Replace(line, paskutinisZodis, 1);
                return line;
            }
            else
            {
                return line;
            }
        }

        static bool BaigiasiLotyniskaPriebalse(string z)
        {
            string lotPrieb = "qwrtpsdfghjklzxcvbnm";
            if (lotPrieb.Contains(z[z.Length - 1]))
            {
                return true;
            }

            return false;
        }


       
    }
}
