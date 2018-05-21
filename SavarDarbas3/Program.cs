using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavarDarbas3
{
    class Program
    {
        static void Main(string[] args)
        {
            double x;
            double fx = 0;

            Console.Write("Iveskite x: ");
            x = double.Parse(Console.ReadLine());

            if (x >= -4 && x <= 0) {
                fx = Math.Cos(x);
            }
            else if (x > 0 && x <= 4) {
                if (Math.Pow(x + 5, 3) != 0) {
                    fx = 1 / Math.Pow(x + 5, 3);
                }
                else {
                    Console.WriteLine("Klaida");
                }
            }
            else {
                if (x * x + 1 >= 0) {
                    fx = Math.Pow(x * x + 1, 0.5);
                }
                else
                {
                    Console.WriteLine("Klaida");
                }
            }

            Console.WriteLine("x = {0,5:f3}    fx = {1,8:f3}", x, fx);
        }
    }
}
