using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LD4
{
    class Program
    {
        const string duom = "..\\..\\duom.txt";
        const string rez = "..\\..\\rez.txt";

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.UTF8;

            if (File.Exists(rez))
                File.Delete(rez);

            string tustiSimboliai = "-";

            Apdoroti(duom, rez, tustiSimboliai);

            Console.WriteLine("\nPrograma baigė darbą!");
        }

        static void Apdoroti(string duom, string rez, string tustiSimboliai)
        {
            string[] lines = File.ReadAllLines(duom, Encoding.GetEncoding(1257));

            using (var fw = File.AppendText(rez))
            {
                foreach(string line in lines)
                {
                    if (line != null)
                    {
                        string prideti = "xxooxx";
                        StringBuilder spausdinimui = new StringBuilder();
                        string[] parts = line.Split(" -,.;:?!\n\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                        if (parts.Length % 2 == 1)
                        {
                            int ind = line.IndexOf(parts[(parts.Length / 2)]);

                            int i;
                            for (i = 0; i < line.Length; i++)
                            {
                                if (i == ind)
                                    break;
                                spausdinimui.Append(line[i]);
                            }
                            spausdinimui.Append(prideti);
                            spausdinimui.Append(line.Substring(i + parts[(parts.Length / 2)].Length));

                            Console.WriteLine(spausdinimui);
                            fw.WriteLine(spausdinimui);
                        }
                        else
                        {
                            Console.WriteLine(line);
                            fw.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}


//Console.WriteLine(parts[0]);
//parts[0] = "pakeistas";
//Console.WriteLine(parts[0]);

//int ilgis = parts.Length;

//int m = 0;
//for (int i = 0; i < ilgis; i++)
//{
//    Console.WriteLine(parts[i]);
//    if (parts[i] != "-")
//    {
//        Console.WriteLine(m);
//        parts[m++] = parts[i];
//    }
//    for (int j = 0; j < m; j++)
//    {
//        Console.Write(parts[j]);
//    }
//    Console.WriteLine();
//    ilgis = m;
//}

//foreach(string x in parts)
//{
//    Console.WriteLine(x);
//}
//Console.WriteLine();