using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Program
    {
        static int plotas = 0;

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("Duomenys.txt");
            string[] input = sr.ReadLine().Split(' ');
            int Mapx = int.Parse(input[0]);
            int Mapy = int.Parse(input[1]);
            
            char[,] map = new char[Mapy, Mapx];
            List<int> visiPlotai = new List<int>();
            int kurmiuSk = 0;

            for (int i = 0; i < Mapy; i++)
            {
                string eilute = sr.ReadLine();
                for (int j = 0; j < Mapx; j++)
                {
                    map[i, j] = eilute[j];
                }
            }
            sr.Close();

            while (urvoVieta(map).y != -1)
            {
                Point vieta = urvoVieta(map);
                rastiKita(map, vieta);
                kurmiuSk++;
                visiPlotai.Add(plotas);
                plotas = 0;
            }

            Console.WriteLine("Kurmiu skaicius: " + kurmiuSk);
            foreach(int i in visiPlotai)
                Console.WriteLine(i);
        }


        static Point urvoVieta(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if(map[i, j] == 'u')
                    {
                        return new Point(j, i);
                    }
                }
            }
            return new Point(-1, -1);
        }


        static void rastiKita(char[,] map, Point taskas)
        {
            map[taskas.y, taskas.x] = 'z';
            plotas += 5;

            if (taskas.y + 1 < map.GetLength(0) && map[taskas.y + 1, taskas.x] == 'u')
                rastiKita(map, new Point(taskas.x, taskas.y + 1));

            if (taskas.y - 1 >= 0 && map[taskas.y - 1, taskas.x] == 'u')
                rastiKita(map, new Point(taskas.x, taskas.y - 1));

            if (taskas.x + 1 < map.GetLength(1) && map[taskas.y, taskas.x + 1] == 'u')
                rastiKita(map, new Point(taskas.x + 1, taskas.y));

            if (taskas.x - 1 >= 0 && map[taskas.y, taskas.x - 1] == 'u')
                rastiKita(map, new Point(taskas.x - 1, taskas.y));
        }
    }
}
