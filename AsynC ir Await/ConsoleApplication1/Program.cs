using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task t = new Task(() => Funkcija());
            //t.Start();
            //t.Wait();
            //Thread.Sleep(5000);
            Task t1 = Funkcija();
            t1.Wait();
            Console.WriteLine("Main pabaiga");
        }

        static async Task Funkcija()
        {
            for (int i = 0; i < 100; i++)
                Console.WriteLine(i);
            int x = await Count();
            Console.WriteLine("Rezultatas" + " " + x);
            int y = await Method();
            //Thread.Sleep(4000);
            Console.WriteLine(y);
        }

        static async Task<int> Method()
        {
            Console.WriteLine("Beginning");
            await Task.Delay(4000);
            //Thread.Sleep(4000);
            Console.WriteLine("Finishing");
            return 1;
        }

        static async Task<int> Count()
        {
            Thread.Sleep(1000);
            return 0;
        }
    }
}
