using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mazosios_raides
{
    class Program
    {
        static void Main(string[] args)
        {
            char i;

            Console.Write("Iveskite reiksme: ");
            i = (char)Console.Read();

            Console.WriteLine((int)i);
            Console.WriteLine("{0}", i);
        }
    }
}
