using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Klausimas9
{
    class Program
    {
        const string duom = "..\\..\\duom.txt";
        const string rez = "..\\..\\rez.txt";

        static void Main(string[] args)
        {
            string skyrikliai = " !?.,<>/?;:'\"\\|{[}]()";
            int antrasBalseIlgiausias;
            int trumpiausiasPriebalse;
            Skaityti(duom, skyrikliai, out antrasBalseIlgiausias, out trumpiausiasPriebalse);
            if (antrasBalseIlgiausias != -1 && trumpiausiasPriebalse != -1)
            {
                Sukeisti(rez, antrasBalseIlgiausias, trumpiausiasPriebalse);
            }
            else
            {
                Console.WriteLine("Klaida");
            }

            Console.WriteLine("Programa baigė darbą!");
        }

        static void Sukeisti(string rez, int eil1, int eil2)
        {

        }

        static string SurastiAntrąPagalDydįSuBalse(string eil, string skyrikliai)
        {
            string[] words = eil.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<string> tinkami = new List<string>();

            foreach (string word in words)
            {
                if (TuriBalse(word))
                {
                    tinkami.Add(word);
                }
            }


            string ilgiausias = "";
            string antrasIlgiausias = "";
            if (tinkami.Count >= 2)
            {
                ilgiausias = tinkami[0];
                antrasIlgiausias = tinkami[1];
                if (antrasIlgiausias.Length > ilgiausias.Length)
                {
                    string temp = ilgiausias;
                    ilgiausias = antrasIlgiausias;
                    antrasIlgiausias = temp;
                }

                for (int i = 2; i < tinkami.Count; i++)
                {
                    string temp = tinkami[i];
                    if (temp.Length > ilgiausias.Length && temp.Length > antrasIlgiausias.Length)
                    {
                        string pag = ilgiausias;
                        ilgiausias = temp;
                        antrasIlgiausias = pag;
                    }
                    else if (temp.Length < ilgiausias.Length && temp.Length > antrasIlgiausias.Length)
                    {
                        antrasIlgiausias = temp;
                    }
                }
            }
            
            return antrasIlgiausias;
        }

        static bool TuriBalse(string word)
        {
            string balses = "eyuioaEYUIOA";
            for (int i = 0; i < word.Length; i++)
            {
                if (balses.Contains(word[word.Length - 1]))
                {
                    return true;
                }
            }

            return false;
        }

        static bool TuriPriebalse(string word)
        {
            string priebalses = "qwrtpsdfghjklzxcvbnmQWRTPSDFGHJKLZXCVBNM";
            for (int i = 0; i < word.Length; i++)
            {
                if (priebalses.Contains(word[word.Length - 1]))
                {
                    return true;
                }
            }

            return false;
        }

        static string SurastiSuPriebalse(string eil, string skyrikliai)
        {
            string[] words = eil.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<string> tinkami = new List<string>();

            foreach (string word in words)
            {
                if (TuriPriebalse(word))
                {
                    tinkami.Add(word);
                }
            }

            string trumpiausias = "";

            if (tinkami.Count >= 1)
            {
                trumpiausias = tinkami[0];

                for (int i = 1; i < tinkami.Count; i++)
                {
                    string temp = tinkami[i];
                    if (temp.Length < trumpiausias.Length)
                    {
                        trumpiausias = temp;
                    }
                }
            }

            return trumpiausias;
        }

        static void Skaityti(string duom, string skyrikliai, out int balse, out int prieb)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string line;
                int i = 0;
                string ilgiausiasSuBalse = "";
                string trumpiausiasSuPriebalse = "";
                balse = -1;
                prieb = -1;
                while ((line = reader.ReadLine()) != null)
                {
                    string temp1 = SurastiAntrąPagalDydįSuBalse(line, skyrikliai);
                    string temp2 = SurastiSuPriebalse(line, skyrikliai);
                    if (temp1 != "")
                    {
                        if (temp1.Length > ilgiausiasSuBalse.Length || ilgiausiasSuBalse == "")
                        {
                            ilgiausiasSuBalse = temp1;
                            balse = i;
                        }
                    }
                    if (temp2 != "")
                    {
                        if (temp2.Length < trumpiausiasSuPriebalse.Length || trumpiausiasSuPriebalse == "")
                        {
                            trumpiausiasSuPriebalse = temp1;
                            prieb = i;
                        }
                    }
                    i++;
                }
            }
        }
    }
}
