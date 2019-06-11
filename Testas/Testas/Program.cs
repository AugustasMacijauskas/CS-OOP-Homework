using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testas
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> listas = new LinkedList<int>();
            LinkedListNode<int> first = new LinkedListNode<int>(5);

            listas.AddFirst(first);
            listas.AddLast(2);

            LinkedListNode<int> node = listas.FindLast(5);
            listas.AddAfter(node, 3);
            listas.AddBefore(node, 4);
            foreach (int n in listas)
            {
                Console.Write("{0} ", n);
            }
            Console.WriteLine();
            listas.Remove(node);
            int value = listas.First.Value;

            Console.WriteLine(value);

            foreach (int n in listas)
            {
                Console.Write("{0} ", n);
            }
            Console.WriteLine();
        }
    }
}
