using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            Tower('A', 'B', 'C', n);
        }

        static void Tower(char from, char temp, char to, int n)
        {
            if (n == 1)
            {
                Console.WriteLine("Move disk from {0} to {1}", from, to);
            }
            else
            {
                Tower(from, to, temp, n - 1);
                Tower(from, temp, to, 1);
                Tower(temp, from, to, n - 1);
            }
        }
    }
}
