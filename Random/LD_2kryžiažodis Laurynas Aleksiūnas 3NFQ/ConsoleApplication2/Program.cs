using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public Point senas { get; set; }

        public Point(int x, int y, Point senas)
        {
            this.x = x;
            this.y = y;
            this.senas = senas;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", x, y);
        }
    }

    class KryziazodzioSprendimas
    {
        private char[,] kryziazodis;
        private List<Point> kelias;
        private static StreamReader sr = new StreamReader("Duomenys.txt");

        public KryziazodzioSprendimas(char[,] kryziazodis)
        {
            this.kryziazodis = kryziazodis;
            kelias = new List<Point>();
        }

        public char[,] SprestiKryziazodi()
        {
            for (int i = 0; i < kryziazodis.GetLength(0); i++)
            {
                string zodis = sr.ReadLine().Split(' ').Last();
                List<Point> PirmosiosRaides = pirmosiosRaides(zodis[0]);
                bool arEgzistuojaZodis = false;
                foreach (var p in PirmosiosRaides)
                {
                    kelias.Add(p);
                    bool susidaro = false;
                    ArSusidaroZodis(zodis, 1, p, ref susidaro);

                    if (susidaro)
                    {
                        arEgzistuojaZodis = true;
                        Point current = kelias.Find(taskas => taskas.x == -1 && taskas.y == -1).senas;

                        while (current.senas != null)
                        {
                            kryziazodis[current.y, current.x] = Convert.ToChar((i + 1).ToString());
                            current = current.senas;
                        }
                        kryziazodis[current.y, current.x] = Convert.ToChar((i + 1).ToString());
                    }
                    kelias.Clear();
                }

                if (!arEgzistuojaZodis)
                    Console.WriteLine("Zodzio {0} nera", zodis);
                kelias.Clear();
            }
            sr.Close();
            return kryziazodis;
        }

        private List<Point> pirmosiosRaides(char raide)
        {
            List<Point> listas = new List<Point>();
            for (int i = 0; i < kryziazodis.GetLength(0); i++)
            {
                for (int j = 0; j < kryziazodis.GetLength(1); j++)
                {
                    if (kryziazodis[i, j] == raide)
                        listas.Add(new Point(j, i, null));
                }
            }
            return listas;
        }

        private void ArSusidaroZodis(string zodis, int raidesIndex, Point taskas, ref bool susidaro)
        {
            if (zodis.Length == raidesIndex)
            {
                susidaro = true;
                kelias.Add(new Point(-1, -1, taskas));
                return;
            }

            if (taskas.x - 1 >= 0 && kryziazodis[taskas.y, taskas.x - 1] == zodis[raidesIndex])
            {
                kelias.Add(new Point(taskas.x - 1, taskas.y, taskas));
                ArSusidaroZodis(zodis, raidesIndex + 1, new Point(taskas.x - 1, taskas.y, taskas), ref susidaro);
            }


            if (taskas.x + 1 < kryziazodis.GetLength(1) && kryziazodis[taskas.y, taskas.x + 1] == zodis[raidesIndex])
            {
                kelias.Add(new Point(taskas.x + 1, taskas.y, taskas));
                ArSusidaroZodis(zodis, raidesIndex + 1, new Point(taskas.x + 1, taskas.y, taskas), ref susidaro);
            }


            if (taskas.y - 1 >= 0 && kryziazodis[taskas.y - 1, taskas.x] == zodis[raidesIndex])
            {
                kelias.Add(new Point(taskas.x, taskas.y - 1, taskas));
                ArSusidaroZodis(zodis, raidesIndex + 1, new Point(taskas.x, taskas.y - 1, taskas), ref susidaro);
            }


            if (taskas.y + 1 < kryziazodis.GetLength(0) && kryziazodis[taskas.y + 1, taskas.x] == zodis[raidesIndex])
            {
                kelias.Add(new Point(taskas.x, taskas.y + 1, taskas));
                ArSusidaroZodis(zodis, raidesIndex + 1, new Point(taskas.x, taskas.y + 1, taskas), ref susidaro);
            }
        }

        static public char[,] GautiKryziazodi(int n, int m)
        {
            sr.ReadLine();
            char[,] map = new char[n, m];
            for (int i = 0; i < n; i++)
            {
                string eile = sr.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    map[i, j] = eile[j];
                }
            }
            return map;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("Duomenys.txt");
            string[] kryziazodzioDydziai = sr.ReadLine().Split(' ');
            int n = int.Parse(kryziazodzioDydziai[0]);
            int m = int.Parse(kryziazodzioDydziai[1]);
            sr.Close();

            char[,] kryziazodis = KryziazodzioSprendimas.GautiKryziazodi(n, m);
            KryziazodzioSprendimas pirmasKryziazodis = new KryziazodzioSprendimas(kryziazodis);
            kryziazodis = pirmasKryziazodis.SprestiKryziazodi();
            Spausdinimas(kryziazodis);
        }

        static void Spausdinimas(char[,] kryziazodis)
        {
            for (int i = 0; i < kryziazodis.GetLength(0); i++)
            {
                for (int j = 0; j < kryziazodis.GetLength(1); j++)
                {
                    Console.Write(kryziazodis[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
