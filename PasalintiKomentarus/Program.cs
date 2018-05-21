using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PasalintiKomentarus
{
    class Program
    {
        const string duom = @"..\..\duom.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1257);
            string lines = File.ReadAllText(duom);
            string x = Trinti(lines);
            Console.WriteLine(x);
            Console.WriteLine("Programa baigė darbą!");
        }

        static string Trinti(string text)
        {
            bool inline = false, multiline = false;
            string ret = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (i + 1 < text.Length && text[i] == '/' && text[i + 1] == '/' && !multiline)
                    inline = true;
                if (i + 1 < text.Length && text[i] == '/' && text[i + 1] == '*' && !inline)
                    multiline = true;
                if (text[i] == '\n')
                    inline = false;
                if (!inline && !multiline)
                    ret += text[i];
                if (i + 1 < text.Length && text[i] == '*' && text[i + 1] == '/')
                {
                    multiline = false;
                    i++;
                }
            }

            return ret;
        }
    }
}


//for (int i = 0; i<lines.Length; i++)
//            {
//                int ind;
//                if ((ind = lines[i].IndexOf("//")) > 0)
//                {
//                    lines[i].Remove(ind);
//Console.WriteLine(lines[i]);
//                }

//                if ((ind = lines[i].IndexOf("/*")) > 0 && lines[i].IndexOf("*/") < 0)
//                {
//                    lines[i].Remove(ind);
//i++;
//                    while (lines[i + 1].IndexOf("*/") < 0)
//                    {
//                        Console.WriteLine(lines[i]);
//                        i++;
//                    }
//                    Console.WriteLine(lines[i]);
//                }
//                else if ((ind = lines[i].IndexOf("/*")) > 0 && lines[i].IndexOf("*/") > 0)
//                {
//                    lines[i].Remove(ind);
//Console.WriteLine(lines[i]);
//                }
//            }