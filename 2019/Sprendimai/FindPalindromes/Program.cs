using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FindPalindromes
{
    class Program
    {
        const string duom = "..\\..\\duom.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1257);
            Console.InputEncoding = Encoding.Unicode;

            char[] skyrikliai = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            string[] visas = File.ReadAllLines(duom, Encoding.GetEncoding(1257));

            Console.WriteLine("Žodžių palindromų yra {0, 3:d}", SkaitytiIrApdoroti(visas, skyrikliai));
            Console.WriteLine("Programa baigė darbą!");
        }

        static int SkaitytiIrApdoroti(string[] text, char[] skyrikliai)
        {
            int palindromu = 0;
            foreach (string line in text)
            {
                string[] parts = line.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in parts)
                {
                    if (word != null && word != "")
                    {
                        if (ArPalindromas(word))
                        {
                            palindromu++;
                        }
                    }
                }
            }

            return palindromu;
        }

        static bool ArPalindromas(string word)
        {
            if (word.Length > 1)
            {
                if (word.ToLower() == Apversti(word.ToLower()))
                    return true;
            }

            return false;
        }

        static string ReverseString(string word)
        {
            char[] arr = word.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        static string Apversti(string w)
        {
            string eil = "";

            for (int i = w.Length - 1; i >= 0; i--)
            {
                eil += w[i];
            }

            return eil;
        }
    }
}
