using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Miestas
    {
        public int nr { get; set; }
        public Vartai[] miestoVartai { get; set; }
        public bool aplankytas { get; set; }

        public Miestas(int nr)
        {
            this.nr = nr;
            aplankytas = false;
        }

        public void KurieVartai(Vartai[] miestoVartai)
        {
            Array.Sort(miestoVartai, (x, y) => x.kelinti.CompareTo(y.kelinti));
            this.miestoVartai = miestoVartai;
        }

        public override string ToString()
        {
            return String.Format("Miesto nr: " + nr + " {0}, {1}, {2}, {3}", miestoVartai[0].nr,
                                    miestoVartai[1].nr, miestoVartai[2].nr, miestoVartai[3].nr);
        }
    }

    class Vartai
    {
        public Miestas miestas { get; set; }
        public int kelinti { get; set; }
        public int nr { get; set; }
        public Vartai kiti { get; set; }
        public bool panaudoti { get; set; }

        public Vartai(int kelinti, int nr)
        {
            this.kelinti = kelinti;
            this.nr = nr;
            panaudoti = false;
        }

        public void Susijungia(Vartai kiti)
        {
            this.kiti = kiti;
        }

        public void KurisMiestas(Miestas miestas)
        {
            this.miestas = miestas;
        }

        public override string ToString()
        {
            return String.Format("Vartu nr: {0}, kelinti: {1}, kitu vartu nr: {2}", kelinti, nr, kiti.nr);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            string[] duomenys = Duomenys(ref n);

            List<Vartai> visiVartai = new List<Vartai>();
            Miestas[] visiMiestai = new Miestas[n];
            DuomenuSkaidymas(duomenys, visiVartai);
            Miestai(visiVartai, visiMiestai);

            PasiekiamiMiestai(visiMiestai[0], visiMiestai);

            //foreach(var m in visiMiestai)
            //{
            //    Console.WriteLine(m.ToString());
            //}
            //foreach(var v in visiVartai)
            //{
            //    Console.WriteLine(v.ToString());
            //}
        }

        static string[] Duomenys(ref int n)
        {
            StreamReader sr = new StreamReader("Duomenys.txt");
            n = int.Parse(sr.ReadLine());
            string[] duomenys = new string[n * 2];

            for (int i = 0; i < n * 2; i++)
            {
                duomenys[i] = sr.ReadLine();
            }
            sr.Close();
            return duomenys;
        }

        static void DuomenuSkaidymas(string[] duomenys, List<Vartai> vartai)
        {
            foreach (string eile in duomenys)
            {
                string[] numeriai = eile.Split(' ');
                int nr1 = int.Parse(numeriai[0]);
                int nr2 = int.Parse(numeriai[1]);

                int pirmiNr;
                if (nr1 % 4 == 0)
                    pirmiNr = 4;
                else pirmiNr = nr1 % 4;

                int antriNr;
                if (nr2 % 4 == 0)
                    antriNr = 4;
                else antriNr = nr2 % 4;

                Vartai pirmi = new Vartai(pirmiNr, nr1);
                Vartai antri = new Vartai(antriNr, nr2);
                pirmi.Susijungia(antri);
                antri.Susijungia(pirmi);
                vartai.Add(pirmi);
                vartai.Add(antri);
            }
        }

        static void Miestai(List<Vartai> vartai, Miestas[] miestai)
        {
            for (int i = 0; i < miestai.Length; i++)
            {
                miestai[i] = new Miestas(i + 1);
                foreach (Vartai v in vartai)
                {
                    if ((v.nr - 1) / 4 == i)
                        v.miestas = miestai[i];
                }
            }

            for (int i = 0; i < miestai.Length; i++)
            {
                miestai[i].KurieVartai(vartai.FindAll(x => x.miestas.nr == i + 1).ToArray());
            }
        }

        static void PasiekiamiMiestai(Miestas miestas, Miestas[] miestai)
        {
            if(miestas.nr != 1)
                miestas.aplankytas = true;

            if (miestas.miestoVartai.Any(x => x.panaudoti == true) && Array.FindLastIndex(miestai, y => y.aplankytas == false) == 0)
            {
                if (miestas.miestoVartai.Any(x => x.kiti.miestas.nr == 1))
                {
                    Vartai temp = Array.Find(miestas.miestoVartai, x => x.kiti.miestas.nr == 1);
                    Console.WriteLine(temp.nr + " " + temp.kiti.nr);
                    Console.WriteLine("Taip");
                }
                else Console.WriteLine("Ne");
                return;
            }

            foreach (Vartai vartai in miestas.miestoVartai)
            {
                if (!vartai.panaudoti && !vartai.kiti.miestas.aplankytas)
                {
                    Console.WriteLine(vartai.nr + " " + vartai.kiti.nr);
                    vartai.panaudoti = true;
                    vartai.kiti.panaudoti = true;
                    PasiekiamiMiestai(vartai.kiti.miestas, miestai);
                }
            }
        }
    }
}
