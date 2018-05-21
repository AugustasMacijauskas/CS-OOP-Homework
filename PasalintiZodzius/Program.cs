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

            string skyrikliai = "*;:";
            string pasalinti = "Sabonis";

            Apdoroti(duom, rez, skyrikliai, pasalinti);

            Console.WriteLine("Programa baigė darbą!");
        }

        static void Apdoroti(string duom, string rez, string skyrikliai, string pasalinti)
        {
            string[] lines = File.ReadAllLines(duom, Encoding.GetEncoding(1257));

            using (var fw = File.CreateText(rez))
            {
                foreach (string line in lines)
                {
                    StringBuilder nauja = new StringBuilder();
                    Zodziai(line, skyrikliai, pasalinti, nauja);
                    Console.WriteLine(nauja);
                }
            }
        }

        static void Zodziai(string line, string skyrikliai, string pasalinti, StringBuilder nauja)
        {
            string pagalbine = " " + line + " ";
            int ind = pagalbine.IndexOf(pasalinti);

            while(ind != -1)
            {
                if ((pagalbine[ind - 1] == '"' && pagalbine[ind + pasalinti.Length] == '"') || (pagalbine[ind - 1] == '\'' && pagalbine[ind + pasalinti.Length] == '\''))
                {
                    pagalbine = pagalbine.Remove(ind - 2, pasalinti.Length + 3);

                    if (skyrikliai.IndexOf(pagalbine[ind - 2]) != -1)
                    {
                        pagalbine = pagalbine.Remove(ind - 2, 1);
                    }
                }
                else if (ind + pasalinti.Length < pagalbine.Length && skyrikliai.IndexOf(pagalbine[ind + pasalinti.Length]) != -1)
                {
                    pagalbine = pagalbine.Remove(ind, pasalinti.Length + 2);
                }
                else
                {
                    if (ind + pasalinti.Length + 1 < pagalbine.Length)
                    {
                        pagalbine = pagalbine.Remove(ind - 1, pasalinti.Length + 1);
                    }
                    else
                    {
                        pagalbine = pagalbine.Remove(ind, pasalinti.Length);
                    }
                }

                ind = pagalbine.IndexOf(pasalinti, ind + 1);
            }
            if (pagalbine[0] == ' ')
                pagalbine = pagalbine.Remove(0, 1);
            nauja.Append(pagalbine);
        }
    }
}


