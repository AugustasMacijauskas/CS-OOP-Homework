using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PasalintiZodzius
{
    class Program
    {
        const string duom = "..\\..\\duom.txt";
        const string rez = "..\\..\\rez.txt";

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.GetEncoding(1257);
            Console.OutputEncoding = Encoding.GetEncoding(1257);

            if (File.Exists(rez))
                File.Delete(rez);

            string skyrikliai = " .,!?:;()\t'";
            string pasalinti = "Sabonis";

            Apdoroti(duom, rez, skyrikliai, pasalinti);

            Console.WriteLine("Programa baigė darbą!");
        }

        static void Apdoroti(string duom, string rez, string skyrikliai, string pasalinti)
        {
            string[] lines = File.ReadAllLines(duom, Encoding.GetEncoding(1257));

            using (var fw = File.CreateText(rez))
            {
                string tinkami = ".?!";
                foreach (string line in lines)
                {
                    string[] parts = line.Split(' ');

                    for (int i = 0; i < parts.Length; i++)
                    {
                        StringBuilder nauja = new StringBuilder();
                        Zodziai(parts[i], skyrikliai, pasalinti, nauja);
                        if (nauja != null && nauja.ToString() != "")
                        {
                            if (i == 0 || (nauja.Length == 1 && tinkami.Contains(nauja.ToString())))
                            {
                                fw.Write(nauja);
                                Console.Write(nauja);
                            }
                            else
                            {
                                fw.Write(" " + nauja);
                                Console.Write(" " + nauja);
                            }
                        }
                    }
                    Console.WriteLine();
                    fw.WriteLine();
                }
            }
        }

        static void Zodziai(string word, string skyrikliai, string pasalinti, StringBuilder nauja)
        {
            int ind = word.IndexOf(pasalinti);

            if (ind >= 0)
            {
                nauja.Append(word.Substring(ind + pasalinti.Length));
                if (nauja.Length > 0)
                {
                    //Console.WriteLine(word);
                    //Console.WriteLine(nauja);
                    if (ContainsOnly(nauja))
                    {
                        nauja.Remove(0, nauja.Length);
                    }
                    //Console.WriteLine(nauja);
                }
            }
            else
            {
                nauja.Append(word);
            }
        }

        static bool ContainsOnly(StringBuilder word)
        {
            string znkl = ",:;'";

            for (int i = 0; i < word.Length; i++)
            {
                if (!znkl.Contains(word[i]))
                    return false;
            }

            return true;
        }
    }
}


