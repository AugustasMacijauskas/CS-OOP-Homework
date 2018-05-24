using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Klausimas8
{
    //---------------------------------------------
    class MiestoTemp
    {
        public const int CMaxEil = 100;
        public const int CMaxSt = 10;
        private int[,] T;            // temperatūrų reikšmės
        public int N { get; set; }    // savybė N: eilučių skaičius
        public int M { get; set; }    // savybė M: stulpelių skaičius
        public MiestoTemp()
        {
            T = new int[CMaxEil, CMaxSt];
            N = 0; M = 0;
        }
        public void DetiTemp(int i, int j, int a)
        {
            T[i, j] = a;
        }
        public int ImtiTemp(int i, int j)
        {
            return T[i, j];
        }
    }
    //---------------------------------------------





    class Program
    {
        const string duom = "..\\..\\duom.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1257);
            MiestoTemp temp = new MiestoTemp();
            
            Įvesti(duom, temp);
            Print(temp, "Pradiniai duomenys:");

            double didzTemp;
            DidžiausiaVidTemp(temp, out didzTemp);
            Console.WriteLine("Didžiausia temperatūra: {0}", didzTemp);
            SpausdintiDidžiausius(temp, didzTemp);

            Console.WriteLine("Programa baigė darbą!");
        }

        static void SpausdintiDidžiausius(MiestoTemp temp, double didzTemp)
        {
            Console.WriteLine("Dienos, kuriomis vidutinė temperatūra yra didžiausia: ");
            for (int i = 0; i < temp.N; i++)
            {
                if (VidutinėTemperatūra(temp, i) == didzTemp)
                {
                    Console.WriteLine(i + 1);
                }
            }
        }

        static void DidžiausiaVidTemp(MiestoTemp temp, out double didzTemp)
        {
            didzTemp = VidutinėTemperatūra(temp, 0);

            for (int i = 1; i < temp.N; i++)
            {
                if (VidutinėTemperatūra(temp, i) > didzTemp)
                {
                    didzTemp = VidutinėTemperatūra(temp, i);
                }
            }
        }

        static double VidutinėTemperatūra(MiestoTemp temp, int k)
        {
            double suma = 0;

            for (int j = 0; j < temp.M; j++)
            {
                suma += temp.ImtiTemp(k, j);
            }

            return suma / temp.M;
        }

        static void Print(MiestoTemp temp, string antraste)
        {
            Console.WriteLine(antraste);
            for (int i = 0; i < temp.N; i++)
            {
                for (int j = 0; j < temp.M; j++)
                {
                    Console.Write("{0, 3:d} ", temp.ImtiTemp(i, j));
                }
                Console.WriteLine(" - {0, 5:f1}", VidutinėTemperatūra(temp, i));
            }
            Console.WriteLine();
        }

        static void Įvesti(string duom, MiestoTemp temp)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string line;
                string[] parts;
                temp.N = int.Parse(reader.ReadLine());
                temp.M = int.Parse(reader.ReadLine());

                for (int i = 0; i < temp.N; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    for (int j = 0; j < temp.M; j++)
                    {
                        int temperatūra = int.Parse(parts[j].Trim());
                        temp.DetiTemp(i, j, temperatūra);
                    }
                }
            }
        }
    }
}

//static void Main(string[] args)
//{
//    Console.OutputEncoding = Encoding.GetEncoding(1257);
//    MiestoTemp temp = new MiestoTemp();
//    Console.Write("Įveskite matricos eilučių skaičių: ");
//    int n = int.Parse(Console.ReadLine());
//    temp.N = n;
//    Console.Write("Įveskite matricos eilučių skaičių: ");
//    int m = int.Parse(Console.ReadLine());
//    temp.M = m;
//    Console.WriteLine("Po vieną įveskite {0} * {1} matricos duomenis (sveikieji skaičiai):", n, m);
//    Įvesti(temp);
//    Print(temp);

//    double didzTemp;
//    DidžiausiaVidTemp(temp, out didzTemp);
//    Console.WriteLine("Didžiausia temperatūra: {0}", didzTemp);
//    SpausdintiDidžiausius(temp, didzTemp);

//    Console.WriteLine("Programa baigė darbą!");
//}

//static void Įvesti(MiestoTemp temp)
//{
//    for (int i = 0; i < temp.N; i++)
//    {
//        Console.WriteLine("{0} eilutė:", i + 1);
//        for (int j = 0; j < temp.M; j++)
//        {
//            int temperatūra = int.Parse(Console.ReadLine());
//            temp.DetiTemp(i, j, temperatūra);
//        }
//    }
//}