using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            double x;
            double y;
            double fxy = 0;

            Console.Write("Iveskite x reiksme: ");
            x = double.Parse(Console.ReadLine());
            Console.Write("Iveskite y reiksme: ");
            y = double.Parse(Console.ReadLine());

            if (((x * x * x) - y) != 0)
            {
                fxy = (Math.Pow(y, 2) - 2 * x * y + Math.Pow(x, 2)) / (Math.Pow(x, 3) - y);
                Console.WriteLine("x = {0,5:f}    y = {1,5:f}    f(x, y) = {2,8:f3}", x, y, fxy);
            }
            else
            {
                Console.WriteLine("Funkcijos vardiklyje 0");
            }
        }
    }
}
