using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Konstruktoriai
{
    class pizonas
    {
        private string piz;
        private int pizo;
        private double pizon;
        private char pizona;

        public pizonas() 
        {
            piz = "ayee";
            pizo = 3;
            pizon = 3.14;
            pizona = 'l';
        }

        public pizonas(int i)
        {
            piz = "ayee";
            pizo = i;
            pizon = 3.14;
            pizona = 'l';
        }

        public pizonas(string z = "yass", int i = 99, double x = 2.77)
        {
            piz = z;
            pizo = i;
            pizon = x;
            pizona = 'l';
        }

        public pizonas(string z, int i, double x, char y)
        {
            piz = z;
            pizo = i;
            pizon = x;
            pizona = y;
        }

        public string piz1() { return piz; }
        public int piz2() { return pizo; }
        public double piz3() { return pizon; }
        public char piz4() { return pizona; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            pizonas p = new pizonas("birkis", 1000, 5.55);
            Console.WriteLine(p.piz1());
            Console.WriteLine(p.piz2());
            Console.WriteLine(p.piz3());
            Console.WriteLine(p.piz4());
            Console.WriteLine("{0} {1}",
            (int)Math.Sqrt(5.0), (int)Math.Sqrt(8.0));
        }
    }
}
