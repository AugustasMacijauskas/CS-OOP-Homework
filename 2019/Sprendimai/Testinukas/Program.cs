using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testinukas
{
    class Program
    {
        static void Main(string[] args)
        {
            int val1 = 0, val2 = 0;
            int[] B = new int[5] { 2, 4, -3, 0, 0 };
            int[] D = new int[5] { 6, 5, 0, 0, 0 };
            Console.WriteLine(Sum(B, 0, 4) + " " + Sum(D, 1, 5));
        }

        //static void Pav1(ref int value)
        //{
        //    value = 1;
        //}

        //static void Pav2(out int value)
        //{
        //    int val2 = 2;
        //}

        static int Sum(int[] A, int pr, int ga)
        {
            int s = 0;
            for (int i = pr; i < ga; s = s+A[i], i = i+A[i])
                s = i;
            return s;
        }
    }
}
