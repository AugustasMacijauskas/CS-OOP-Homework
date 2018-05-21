using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestMatricos
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] Matrix = {
                                { 10, 1, 1, 1, 100 },
                                { 2, 2, 2, 2, 2 },
                                { 3, 3, 30, 3, 3 },
                                { 4, 4, 4, 4, 4 },
                                { 5, 5, 5, 5, 5 },
                            };

            int n = 5;
            int suma = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = Math.Max(i, n - i - 1); j < n; j++)
                {
                    Console.WriteLine(i + "; " + j);
                    suma += Matrix[i, j];
                }
            }

            Console.WriteLine(suma);


        }
    }
}
