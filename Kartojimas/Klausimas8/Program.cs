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





        }
    }
}
