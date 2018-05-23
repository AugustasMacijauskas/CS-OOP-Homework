using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1257);
            MiestoTemp temp = new MiestoTemp();
            Console.Write("Įveskite matricos eilučių skaičių: ");
            int n = int.Parse(Console.ReadLine());
            temp.N = n;
            Console.Write("Įveskite matricos eilučių skaičių: ");
            int m = int.Parse(Console.ReadLine());
            temp.M = m;
            Console.WriteLine("Po vieną įveskite {0} * {1} matricos duomenis (sveikieji skaičiai):", n, m);
            Įvesti(temp);
            Print(temp);

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
                    Console.WriteLine(i);
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
            int suma = 0;

            for (int j = 0; j < temp.M; j++)
            {
                suma += temp.ImtiTemp(k, j);
            }

            return suma / temp.M;
        }

        static void Print(MiestoTemp temp)
        {
            for (int i = 0; i < temp.N; i++)
            {
                for (int j = 0; j < temp.M; j++)
                {
                    Console.Write(temp.ImtiTemp(i, j) + " ");
                }
                Console.WriteLine();
            }
        }

        static void Įvesti(MiestoTemp temp)
        {
            for (int i = 0; i < temp.N; i++)
            {
                Console.WriteLine("Nauja eilutė");
                for (int j = 0; j < temp.M; j++)
                {
                    int temperatūra = int.Parse(Console.ReadLine());
                    temp.DetiTemp(i, j, temperatūra);
                }
            }
        }
    }
}
