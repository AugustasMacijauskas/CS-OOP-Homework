using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] masyvas = new int[] { 1, 2, 4, 5, 8, 9, 10, 11, 15, 22, 33, 34, 35 };
            Console.WriteLine(BinarySearch(masyvas, 4));
            Console.WriteLine(BinarySearchRecursion(masyvas, 4));
            Console.WriteLine(DvejetainėPaieška(masyvas, 4));
            Console.WriteLine(BinaryRecursion(masyvas, 0, masyvas.Length - 1, 1));
        }

        static int BinaryRecursion(int[] mas, int start, int end, int value)
        {
            if (start <= end)
            {
                int mid = (start + end) / 2;
                if (mas[mid] == value)
                    return mid;
                if (mas[start] == value)
                    return start;
                if (mas[end] == value)
                    return end;
                if (mas[mid] < value)
                    return BinaryRecursion(mas, mid + 1, end, value);
                else 
                    return BinaryRecursion(mas, start, mid - 1, value);
            }
            return -1;
        }

        static int BinarySearch(int[] masyvas, int reiksme)
        {
            int from = 0;
            int to = masyvas.Length - 1;

            if (masyvas[from] == reiksme)
                return from;

            if (masyvas[to] == reiksme)
                return to;

            while (to - from != 1)
            {
                int mid = (to + from) / 2;

                if (masyvas[mid] == reiksme)
                    return mid;

                if (masyvas[mid] > reiksme)
                    to = mid;
                else from = mid;
            }

            if (masyvas[from] == reiksme)
                return from;
            else return -1;
        }

        static int BinarySearchRecursion(int[] masyvas, int reiksme, [Optional] int? from, [Optional] int? to)
        {
            if (!from.HasValue)
                from = 0;

            if (!to.HasValue)
                to = masyvas.Length - 1;

            if (masyvas[from.Value] == reiksme)
                return from.Value;

            if (masyvas[to.Value] == reiksme)
                return to.Value;

            int mid = (to.Value + from.Value) / 2;

            if (masyvas[mid] == reiksme)
                return mid;

            if (masyvas[mid] > reiksme)
                to = mid;
            else from = mid;

            if (to - from == 1 && masyvas[from.Value] != reiksme)
                return -1;

            return BinarySearchRecursion(masyvas, reiksme, from, to);
        }

        static int DvejetainėPaieška(int[] Mas, int x)
        { // Intervalo pradžios, pabaigosir vidurio indeksaiintpi, gi, vi;
            int pi = 0, gi = Mas.Length - 1, vi;
            while (pi <= gi) // kol nesusikirs intervalo rėžiai
            {
                vi = (pi + gi) / 2;
                if (Mas[vi] == x)
                    return vi; // elementas surastaselseif(Mas[vi] <x) pi = vi + 1;elsegi = vi –1;
                else if (Mas[vi] < x) pi = vi + 1; else gi = vi - 1;
            }
            return -1; // elementas nerastas
        }
    }
}
