using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testukas_502_1
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan t = new TimeSpan();     // ciklo parametras
            TimeSpan intervalas = new TimeSpan(0, 10, 0); // ciklo žingsnis
            TimeSpan darboPradzia = new TimeSpan(8, 0, 0);
            TimeSpan darboPabaiga = new TimeSpan(8, 45, 0);
            DateTime data3 = new DateTime(2017, 10, 03, 16, 0, 0);

            for (t = darboPradzia; t <= darboPabaiga; t = t + intervalas)
                data3 = data3.AddMinutes(8.0);
            Console.WriteLine(String.Format("{0:y MM ddd hhh mm}     {0:yyy MMM d HHH mmm}",
                              data3, data3));

        }
    }

}

