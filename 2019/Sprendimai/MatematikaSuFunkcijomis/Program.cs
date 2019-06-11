using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematikaSuFunkcijomis
{
    class Program
    {

        static void skaiciuoti(double x, double y, char op)
        {
            double res = 0;

            Console.WriteLine("x = {0,5:f3}    y = {1,5:f3}", x, y);

            switch (op)
            {
                case '+':
                    Console.WriteLine("{0,5:f3}  " + op + "  {1,5:f3} = {2,8:f3}", x, y, x + y);
                    break;
                case '-':
                    res = x - y;
                    Console.WriteLine("{0,5:f3}  " + op + "  {1,5:f3} = {2,8:f3}", x, y, res);
                    break;
                case '*':
                    res = x * y;
                    Console.WriteLine("{0,5:f3}  " + op + "  {1,5:f3} = {2,8:f3}", x, y, res);
                    break;
                case '/':
                    if (y != 0) {
                        res = x / y;
                        Console.WriteLine("{0,5:f3}  " + op + "  {1,5:f3} = {2,8:f3}", x, y, res);
                    }           
                    else
                        Console.WriteLine("Dalyba is 0 negalima");

                    break;
                default:
                    Console.WriteLine("Netinkamas operatorius.");
                    break;
            }

            Console.WriteLine("");
        }
        static void Main(string[] args)
        {
            double x;
            double y;
            char op;
            double rez = 0;

            Console.Write("Iveskite x : ");
            x = double.Parse(Console.ReadLine());

            Console.Write("Iveskite y : ");
            y = double.Parse(Console.ReadLine());

            Console.Write("Iveskite operatoriu: ");
            op = (char)Console.Read();

            skaiciuoti(x, y, op);
            
            
        }
    }
}



