using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematikaSuFunkcijomis
{
    class Program
    {

        static double skaiciuoti(double x, double y, char op)
        {
            double res = 0;

            switch (op)
            {
                case '+':
                    res = x + y;
                    break;
                case '-':
                    res = x - y;
                    break;
                case '*':
                    res = x * y;
                    break;
                case '/':
                    if (x != 0)
                        res = x / y;
                    break;
                default:
                    Console.WriteLine("Netinkamas operatorius.");
                    break;
            }

            return res;
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

            if (op == '+')
            {
                rez = skaiciuoti(x, y, op);
            }
            else if (op == '-')
            {
                rez = skaiciuoti(x, y, op);
            }
            else if (op == '*')
            {
                rez = skaiciuoti(x, y, op);
            }
            else if (op == '/')
            {
                rez = skaiciuoti(x, y, op);
            }
            else {
                Console.WriteLine("Netinkamas operatorius");
            }


            Console.WriteLine("x = {0,5:f3}    y = {1,5:f3}", x, y);
            Console.WriteLine("{0,5:f3}" + op + "{1,5:f3} = {2,8:f3}", x, y, rez);
            Console.WriteLine("");
        }
    }
}

