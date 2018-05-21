using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PašalintiEilutes
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

            string skyrikliai = " .,!?:;()\t'   ";
            string vardas = "Arvydas";
            string pavarde = " Sabonis";

            Apdoroti(duom, rez, skyrikliai, vardas, pavarde);

            Console.WriteLine("Programa baigė darbą!");
        }

        static void Apdoroti(string duom, string rez, string skyrikliai, string vardas, string pavarde)
        {
            string[] lines = File.ReadAllLines(duom, Encoding.GetEncoding(1257));

            using (var fw = File.CreateText(rez))
            {
                foreach (string line in lines)
                {
                    StringBuilder nauja = new StringBuilder();
                    Zodziai(line, skyrikliai, vardas, pavarde, nauja);
                    if (nauja != null && nauja.ToString() != "")
                        fw.WriteLine(nauja);
                }
            }
        }

        static void Zodziai(string line, string skyrikliai, string vardas, string pavarde, StringBuilder nauja)
        {
            string papild = " " + line + " ";
            int prad = 1;
            int ind = papild.IndexOf(vardas);
            Console.WriteLine(ind);

            while (ind != -1)
            {
                if (skyrikliai.IndexOf(papild[ind - 1]) != -1 && skyrikliai.IndexOf(papild[ind + vardas.Length]) != -1)
                {
                    nauja.Append(papild.Substring(prad, ind + vardas.Length - prad));
                    nauja.Append(pavarde);
                    prad = ind + vardas.Length;
                }
                ind = papild.IndexOf(vardas, ind + 1);
                Console.WriteLine(ind);
            }
            nauja.Append(line.Substring(prad - 1));
        }
    }
}
