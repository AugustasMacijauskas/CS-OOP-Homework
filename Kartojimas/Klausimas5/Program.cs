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

            if (tinkami.Count < 2)
            {
                return line;
            }
            string zodisPakeisti = tinkami[tinkami.Count - 2];
            string paskutinisZodis = words[words.Length - 1];

            MatchCollection matches = Regex.Matches(line, $@"(\G|[{skyrikliai}])({zodisPakeisti})([{skyrikliai}]|$)");
            Match match1;
            if (tinkami[tinkami.Count - 1] == zodisPakeisti)
            {
                match1 = matches[matches.Count - 2];
            }
            else
            {
                match1 = matches[matches.Count - 1];
            }
            matches = Regex.Matches(line, $@"(\G|[{skyrikliai}])({paskutinisZodis})([{skyrikliai}]|$)");
            Match match2 = matches[matches.Count - 1];
            Group gr1 = match1.Groups[2];
            Group gr2 = match2.Groups[2];
            line = line.Remove(gr2.Index, gr2.Length).Insert(gr2.Index, zodisPakeisti);
            line = line.Remove(gr1.Index, gr1.Length).Insert(gr1.Index, paskutinisZodis);

            return line;
        }

        static bool BaigiasiLotyniskaPriebalse(string z)
        {
            const string lotPrieb = "qwrtpsdfghjklzxcvbnmQWRTPSDFGHJKLZXCVBNM";
            if (lotPrieb.Contains(z[z.Length - 1]))
            {
                return true;
            }

            return false;
        }
    }
}

//static string SukeistiZodzius(string line, string skyrikliai)
//{
//    string[] words = line.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
//    List<string> tinkami = new List<string>();

//    foreach (string word in words)
//    {
//        if (BaigiasiLotyniskaPriebalse(word))
//        {
//            tinkami.Add(word);
//        }
//    }

//    if (tinkami.Count < 2)
//    {
//        return line;
//    }
//    string zodisPakeisti = tinkami[tinkami.Count - 2];
//    string paskutinisZodis = words[words.Length - 1];

//    MatchCollection matches = Regex.Matches(line, $@"\b{zodisPakeisti}\b");
//    Match match;
//    if (tinkami[tinkami.Count - 1] == zodisPakeisti)
//    {
//        match = matches[matches.Count - 2];
//    }
//    else
//    {
//        match = matches[matches.Count - 1];
//    }
//    line = line.Remove(match.Index, match.Length);
//    line = line.Insert(match.Index, paskutinisZodis);

//    matches = Regex.Matches(line, $@"\b{paskutinisZodis}\b");
//    match = matches[matches.Count - 1];
//    line = line.Remove(match.Index, match.Length);
//    line = line.Insert(match.Index, zodisPakeisti);
//    return line;
//}

//static string SukeistiZodzius(string line, string skyrikliai)
//{
//    string[] words = line.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
//    List<string> tinkami = new List<string>();

//    foreach (string word in words)
//    {
//        if (BaigiasiLotyniskaPriebalse(word))
//        {
//            tinkami.Add(word);
//        }
//    }

//    if (tinkami.Count < 2)
//    {
//        return line;
//    }
//    string zodisPakeisti = tinkami[tinkami.Count - 2];
//    string paskutinisZodis = words[words.Length - 1];

//    // Console.WriteLine(line);
//    // Console.WriteLine(zodisPakeisti + " --> " + paskutinisZodis);
//    // const string lotPrieb = "qwrtpsdfghjklzxcvbnm";
//    // Regex r = new Regex($@"(\G|^|[{skyrikliai}])([a-z0-9]*[{lotPrieb}])([{skyrikliai}]|$)", RegexOptions.IgnoreCase);
//    // Regex r = new Regex($@"(\b([a-z0-9]*[{lotPrieb}])\b)", RegexOptions.IgnoreCase);
//    // Surasti ir pašalinti
//    Match match1 = Regex.Match(line, $@"\b{zodisPakeisti}\b", RegexOptions.RightToLeft);
//    if (tinkami[tinkami.Count - 1] == zodisPakeisti)
//    {
//        // Console.WriteLine("!");
//        match1 = match1.NextMatch();
//    }
//    //MatchCollection matches = Regex.Matches(line, $@"\b{zodisPakeisti}\b");
//    //Match match1 = matches[matches.Count - ((tinkami[tinkami.Count - 1] == zodisPakeisti) ? 2 : 1)];
//    line = line.Remove(match1.Index, match1.Length);
//    line = line.Insert(match1.Index, paskutinisZodis);
//    line = new Regex($@"\b{paskutinisZodis}\b", RegexOptions.RightToLeft).Replace(line, zodisPakeisti, 1);
//    return line;
//}
