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

                // Surasti ir pašalinti
                //Match match1 = Regex.Match(line, $@"\b{zodisPakeisti}\b", RegexOptions.RightToLeft);
                //if (tinkami[tinkami.Count - 1] == zodisPakeisti)
                //{
                //    Console.WriteLine("!");
                //    match1 = match1.NextMatch();
                //}
                MatchCollection matches = Regex.Matches(line, $@"\b{zodisPakeisti}\b");
                Match match1 = matches[matches.Count - ((tinkami[tinkami.Count - 1] == zodisPakeisti) ? 2 : 1)];
                line = line.Remove(match1.Index, match1.Length);
                line = line.Insert(match1.Index, paskutinisZodis);
                line = new Regex($@"\b{paskutinisZodis}\b", RegexOptions.RightToLeft).Replace(line, zodisPakeisti, 1);
                return line;

                //line = line.Re
                //MatchCollection matches = Regex.Matches(line, $@"\b({zodisPakeisti})\b");
                //Match tinkamas = matches[matches.Count - 1];
                //Console.WriteLine("\n" + tinkamas.Index + "\n");
                //line = line.Remove(tinkamas.Index, tinkamas.Length);
                //matches = Regex.Matches(line, $@"\b({paskutinisZodis})([{skyrikliai}]*)$");
                //Match paskutinis = matches[matches.Count - 1];
                //Group pask = paskutinis.Groups[1];
                //Console.WriteLine("\n" + pask.Index + "\n");
                //line = line.Remove(paskutinis.Index, pask.Length);

                //// Įterpti naujus
                //line = line.Insert(tinkamas.Index, pask.Value);
                //line = line.Insert(paskutinis.Index + (pask.Length - tinkamas.Length), tinkamas.Value);

                //if (pask.Length > tinkamas.Length)
                //{
                //    line = line.Insert(paskutinis.Index + (pask.Length - tinkamas.Length), tinkamas.Value);
                //}
                //else if (pask.Length < tinkamas.Length)
                //{

                //}
                //else
                //{
                //    line = line.Insert(paskutinis.Index, tinkamas.Value);
                //}
                //line = line.Insert(paskutinis.Index, tinkamas.Value);
                //if (tinkamas.Value != "" && paskutinis.Value != "")
                //{
                //    Console.WriteLine("Success?");

                //    // Pašalinti
                //    line = line.Remove(tinkamas.Index, tinkamas.Length);
                //    line = line.Remove(paskutinis.Index, paskutinis.Length);
                //}
                //line = string.Split()
                //string x = ;
                //line = new Regex($@"\b({paskutinisZodis})([{skyrikliai}]*)$").Replace(line, $"{zodisPakeisti}$2", 1);
                //line = new Regex($@"\b({zodisPakeisti})\b").Replace(line, paskutinisZodis, 1);
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
