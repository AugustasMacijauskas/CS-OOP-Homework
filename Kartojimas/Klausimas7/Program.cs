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
                        // Panaudokite metodus, kurie randa paskutinį kiekvienos eilutės žodį, 
                        // pasibaigiantį lyginiu skaitmeniu, ir metodą, kuris randa paskutinį
                        // trumpiausią eilutės žodį, pasibaigiantį skaitmeniu.
                        // Rastus žodžius sukeiskite vietomis. Skyrikliai nekeičiami.
                        string paskutinisSuLyginiu = RastiPaskutinįSuLyginiu(line, skyrikliai);
                        string paskutinisSuSkaitmeniu = RastiPaskutinįSuSkaitmeniu(line, skyrikliai);

                        if (paskutinisSuLyginiu != "" && paskutinisSuSkaitmeniu != "" && paskutinisSuLyginiu != paskutinisSuSkaitmeniu)
                        {
                            Console.WriteLine(paskutinisSuLyginiu + " --> " + paskutinisSuSkaitmeniu);
                            Match match1 = Regex.Match(line, $@"\b{paskutinisSuLyginiu}\b");
                            Match match2 = Regex.Match(line, $@"\b{paskutinisSuSkaitmeniu}\b");
                            if (match1.Index < match2.Index)
                            {
                                Console.WriteLine(match1.Value + " ir " + match2.Value);
                                Console.WriteLine("1");
                            }
                            if (match1.Index > match2.Index)
                            {
                                Console.WriteLine(match1.Value + " ir " + match2.Value);
                                Console.WriteLine("2");
                            }
                            // line = new Regex($@"{}").Replace();
                        }
                        else if (paskutinisSuLyginiu != "" && paskutinisSuSkaitmeniu != "" && paskutinisSuLyginiu == paskutinisSuSkaitmeniu)
                        {
                            Console.WriteLine("Surastas tas pats žodis!");
                        }
                        else
                        {
                            Console.WriteLine("Kažkurio iš žodžių eilutėje nėra!");
                        }

                        ats.WriteLine(line);
                    }
                }
            }
        }


        // Naujas metodas1
        // Užrašykite metodą, kuris randa paskutinį kiekvienos eilutės žodį, pasibaigiantį lyginiu skaitmeniu.
        static string RastiPaskutinįSuLyginiu(string line, string skyrikliai)
        {
            string[] words = line.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<string> tinkami = new List<string>();
            string lyginiai = "02468";

            foreach(string word in words)
            {
                if (lyginiai.IndexOf(word[word.Length - 1]) != -1)
                {
                    tinkami.Add(word);
                }
            }

            if (tinkami.Count > 0)
            {
                return tinkami[tinkami.Count - 1];
            }
            else
            {
                return "";
            }
        }



        // Naujas metodas2
        // Užrašykite metodą, kuris randa paskutinį trumpiausią eilutės žodį, pasibaigiantį skaitmeniu.
        static string RastiPaskutinįSuSkaitmeniu(string line, string skyrikliai)
        {
            string[] words = line.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string tinkamas = "";
            string skaitmenys = "0123456789";

            foreach (string word in words)
            {
                if ((skaitmenys.IndexOf(word[word.Length - 1]) != -1) && ((word.Length <= tinkamas.Length) || (tinkamas == "")))
                {
                    tinkamas = word;
                }
            }

            return tinkamas;
        }


       
    }
}
