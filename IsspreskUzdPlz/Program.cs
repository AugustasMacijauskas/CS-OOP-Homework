using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsspreskUzdPlz
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b, c, d;

            for (b = 0; b <= 9; b++)
            {
                for (c = 0; c < 10; c++)
                {
                    for (d = 0; d < 10; d++)
                    {
                        int sk = 1000 * a + 100 * b + 10 * c + d;
                        if (((a + b + c + d) % 5 == 0) && ((sk + 7452) == 1000 * d + 100 * c + 10 * b + a))
                        {
                            Console.WriteLine(sk);
                        }
                    }
                }
            }
        }
    }
}
