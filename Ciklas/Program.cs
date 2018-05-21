//------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//------------------------------------------------------------------
//Ciklas for
//------------------------------------------------------------------
namespace Ciklas
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            int suma;
            Console.Write("Iveskite sveikaja reiksme a: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Iveskite sveikaja reiksme b: ");
            b = int.Parse(Console.ReadLine());
            suma = a + b;
            Console.Write(" {0,3:d} + {1,3:d} = {2,4:d} \n", a, b, suma);

            for (int i = a; i <= b; i++)
                Console.WriteLine(" {0,3:d}    {1,5:d}    {2,7:d}", i, i * i, i * i * i);
        }
    }
}
