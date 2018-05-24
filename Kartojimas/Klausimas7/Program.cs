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
                            MatchCollection matches1 = Regex.Matches(line, $@"(\G|[{skyrikliai}])({paskutinisSuLyginiu})([{skyrikliai}]|$)");
                            MatchCollection matches2 = Regex.Matches(line, $@"(\G|[{skyrikliai}])({paskutinisSuSkaitmeniu})([{skyrikliai}]|$)");
                            Group gr1 = matches1[matches1.Count - 1].Groups[2];
                            Group gr2 = matches2[matches2.Count - 1].Groups[2];
                            if (gr1.Index > gr2.Index)
                            {
                                Group temp = gr1;
                                gr1 = gr2;
                                gr2 = temp;
                            }
                            line = line.Remove(gr2.Index, gr2.Length).Insert(gr2.Index, gr1.Value);
                            line = line.Remove(gr1.Index, gr1.Length).Insert(gr1.Index, gr2.Value);
                        }

                        ats.WriteLine(line);
                        Console.WriteLine(line);
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

//static void RastiZTekste(string fr, string fv, string skyrikliai)
//{
//    using (var ats = File.CreateText(fv))
//    {
//        using (StreamReader reader = new StreamReader(fr))
//        {
//            string line = "pradzia";
//            int i = 1;
//            while ((line = reader.ReadLine()) != null)
//            {
//                // Panaudokite metodus, kurie randa paskutinį kiekvienos eilutės žodį, 
//                // pasibaigiantį lyginiu skaitmeniu, ir metodą, kuris randa paskutinį
//                // trumpiausią eilutės žodį, pasibaigiantį skaitmeniu.
//                // Rastus žodžius sukeiskite vietomis. Skyrikliai nekeičiami.
//                string paskutinisSuLyginiu = RastiPaskutinįSuLyginiu(line, skyrikliai);
//                string paskutinisSuSkaitmeniu = RastiPaskutinįSuSkaitmeniu(line, skyrikliai);

//                Console.WriteLine(i + " eilute   -----------------------------------------------------");
//                Console.WriteLine(line);
//                i++;

//                if (paskutinisSuLyginiu != "" && paskutinisSuSkaitmeniu != "" && paskutinisSuLyginiu != paskutinisSuSkaitmeniu)
//                {
//                    Console.WriteLine(paskutinisSuLyginiu + " --> " + paskutinisSuSkaitmeniu);
//                    Match match1 = Regex.Match(line, $@"\b{paskutinisSuLyginiu}\b");
//                    Match match2 = Regex.Match(line, $@"\b{paskutinisSuSkaitmeniu}\b");
//                    if (match1.Index < match2.Index)
//                    {
//                        Console.WriteLine(match1.Index + " ir " + match2.Index);
//                        Console.WriteLine(match1.Value + " ir " + match2.Value);
//                        Console.WriteLine("1");
//                        Match match = Regex.Match(line, $@"\b{paskutinisSuSkaitmeniu}\b");
//                        line = line.Remove(match.Index, match.Length);
//                        line = line.Insert(match.Index, paskutinisSuLyginiu);

//                        line = new Regex($@"\b{paskutinisSuLyginiu}\b").Replace(line, paskutinisSuSkaitmeniu, 1);
//                    }
//                    if (match1.Index > match2.Index)
//                    {
//                        Console.WriteLine(match1.Index + " ir " + match2.Index);
//                        Console.WriteLine(match1.Value + " ir " + match2.Value);
//                        Console.WriteLine("2");
//                        Match match = Regex.Match(line, $@"\b{paskutinisSuLyginiu}\b");
//                        line = line.Remove(match.Index, match.Length);
//                        line = line.Insert(match.Index, paskutinisSuSkaitmeniu);

//                        line = new Regex($@"\b{paskutinisSuSkaitmeniu}\b").Replace(line, paskutinisSuLyginiu, 1);
//                    }
//                }
//                else if (paskutinisSuLyginiu != "" && paskutinisSuSkaitmeniu != "" && paskutinisSuLyginiu == paskutinisSuSkaitmeniu)
//                {
//                    Console.WriteLine("Surastas tas pats žodis!");
//                }
//                else
//                {
//                    Console.WriteLine("Kažkurio iš žodžių eilutėje nėra!");
//                }

//                ats.WriteLine(line);
//                Console.WriteLine(line);
//            }
//        }
//    }
//}