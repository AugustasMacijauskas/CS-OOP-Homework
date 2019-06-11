using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simboliai
{
    class Program
    {
        static void Main(string[] args)
        {
            char simbolis;
            int sim_sk;
            int eil_sk;
            int liek;
            int kiekBusEiluciu;

            Console.Write("Iveskite, kiek is viso bus simboliu: ");
            sim_sk = int.Parse(Console.ReadLine());

            Console.Write("Iveskite, kiek simboliu bus eiluteje: ");
            eil_sk = int.Parse(Console.ReadLine());

            Console.Write("Iveskite, koks bus simbolis: ");
            simbolis = (char)Console.Read();

            liek = sim_sk % eil_sk;

            kiekBusEiluciu = sim_sk / eil_sk;



            for (int i = 1; i <= kiekBusEiluciu; i++) {
                for (int k = 1; k <= eil_sk; k++) {
                    Console.Write(simbolis);
                    }
                    Console.WriteLine(" ");
            }

            if (liek > 0) {
                for (int j = 1; j <= liek; j++)
                {
                    Console.Write(simbolis);
                }

                Console.WriteLine(" ");
            }
        }
    }
}
