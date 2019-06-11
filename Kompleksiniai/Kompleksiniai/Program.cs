using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Kompleksiniai
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex num = -32;
            double realAns = -Math.Pow(32, 1 / 5.0);
            Complex ans = Complex.Pow(num, 1 / 5.0);
            Console.WriteLine(ans.Magnitude);
            Console.WriteLine(ans.Phase * 180 / Math.PI);
            Console.WriteLine(Math.Pow(ans.Real, 2) + Math.Pow(ans.Imaginary, 2));
            Console.WriteLine(ans);

            if (realAns == ans.Real)
            {
                Console.WriteLine("Success!");
            }
        }
    }
}
