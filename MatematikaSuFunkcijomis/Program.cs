using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematikaSuFunkcijomis
{
    class Program
    {

    static double skaiciuoti(double x, double y, char op) {
            double res;
    
            switch(op) {
                case '+':
                res
    }

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
            op = (char)Console.ReadLine();

            if (op == '+')
            {
                rez = x + y;
                Console.WriteLine("x = {0,5:f3}    y = {1,5:f3}", x, y);
                Console.WriteLine("{0,5:f3}        y = {1,5:f3}", x, y);
            }
            else if (op == '-')
            {
                rez = x - y;
            }
            else if (op == '*')
            {
                rez = x * y;
            }
            else if (op == '/')
            {
                rez = x / y;
            }
        }
    }
}
    }
}
