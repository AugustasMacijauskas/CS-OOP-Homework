using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Testinukas
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, z = 15.15;
            int k;
            k = (int)z;

            Console.WriteLine(k);
            x = double.Parse(String.Format("{0}", z));
            Console.WriteLine("{0}", x);
            string eilute;
            eilute = string.Format("{0}", x);
            Console.WriteLine("{0}", eilute);

            eilute = "" + x;
            Console.WriteLine(eilute);

            string s = k.ToString();
            Console.WriteLine(s);
            s = Convert.ToString(k);
            Console.WriteLine(s);
            s = string.Format("{0}", k);
            Console.WriteLine(s);
            s = $"{k}";
            Console.WriteLine(s);
            s = "" + k;
            Console.WriteLine(s);
            s = string.Empty + k;
            Console.WriteLine(s);
            s = new StringBuilder().Append(k).ToString();

        }
    }
}
