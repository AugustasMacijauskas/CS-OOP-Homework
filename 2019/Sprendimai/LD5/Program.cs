using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LD5
{
    class Komanda
    {
        public string pav { get; set; }
        public string miestas { get; set; }
        public string pavarde { get; set; }
        public string vardas { get; set; }
        public int taskai { get; set; }

        public Komanda(string pav, string miestas, string pavarde, string vardas)
        {
            this.pav = pav;
            this.miestas = miestas;
            this.pavarde = pavarde;
            this.vardas = vardas;
        }

        public override string ToString()
        {
            string eil = string.Format("          {0, -15}   {1, -15}  {2, -15}        {3, -15}", pav, miestas, pavarde, vardas);
            return eil;
        }
    }

    class KomanduKonteineris
    {
        const int Max = 30;
        private Komanda[] A;
        private int n;


        public KomanduKonteineris()
        {
            n = 0;
            A = new Komanda[Max];
        }

        public int Imti()
        {
            return n;
        }

        public void Dėti(Komanda ob)
        {
            A[n++] = ob;
        }

        public Komanda Imti(int i)
        {
            return A[i];
        }

        public void Rikiuoti()
        {
            Komanda pagalb;

            for (int i = 0; i < n - 1; i++)
            {
                pagalb = A[i];
                int ind = 0;

                for (int j = i + 1; j < n; j++)
                {
                    if (A[j].taskai > pagalb.taskai)
                    {
                        ind = j;
                    }
                }

                pagalb = A[i];
                A[i] = A[j];
                A[j] = pagalb;
            }
        }
    }

    class Rezultatai
    {
        const int MaxEil = 30;
        const int MaxSt = 30;
        private int[,] A;
        public int n { get; set; }
        public int m { get; set; }


        public Rezultatai()
        {
            n = 0;
            m = 0;
            A = new int[MaxEil, MaxSt];
        }

        public void Dėti(int i, int j, int ivarciai)
        {
            A[i, j] = ivarciai;
        }

        public int ImtiReiksme(int i, int j)
        {
            return A[i, j];
        }

    }
    class Program
    {
        const string duom = "..\\..\\duom.txt";
        const string rez = "..\\..\\rez.txt";

        static void Main(string[] args)
        {
            KomanduKonteineris komandos = new KomanduKonteineris();
            Rezultatai rezultatai = new Rezultatai();

            if (File.Exists(rez))
                File.Delete(rez);

            Skaityti(duom, komandos, rezultatai);
            Spausdinti(rez, komandos, rezultatai, "Pradiniai duomenys:");

            Console.WriteLine("Programa baigė darbą!");
        }

        static void SkaiciuotiKomanduTaskus(KomanduKonteineris A, Rezultatai B)
        {

        }

        static void Skaityti(string duom, KomanduKonteineris A, Rezultatai B)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string line;
                string pav, miestas, pavarde, vardas;
                int kiek = int.Parse(reader.ReadLine());

                for (int i = 0; i < kiek; i++)
                {
                    line = reader.ReadLine();
                    string[] parts = line.Split(';');
                    pav = parts[0];
                    miestas = parts[1];
                    pavarde = parts[2];
                    vardas = parts[3];
                    Komanda nauja = new Komanda(pav, miestas, pavarde, vardas);
                    A.Dėti(nauja);
                }

                B.n = kiek;
                B.m = kiek;

                for (int i = 0; i < B.n; i++)
                {
                    line = reader.ReadLine();
                    string[] parts = line.Split(';');
                    for (int j = 0; j < B.m; j++)
                    {
                        int sk = int.Parse(parts[j]);
                        B.Dėti(i, j, sk);
                    }
                }

            }
        }

        static void Spausdinti(string rez, KomanduKonteineris A, Rezultatai B, string antraste)
        {
            using (var fw = new StreamWriter(rez))
            {
                string virsus = "-------------------------------------------------------------------------------------\r\n" +
                                " Nr.    Komandos pavadinimas     Miestas      Trenerio pavardė       Trenerio vardas \r\n" +
                                "-------------------------------------------------------------------------------------";

                fw.WriteLine(antraste);
                fw.WriteLine(virsus);
                for (int i = 0; i < A.Imti(); i++)
                {
                    fw.WriteLine(" {0,2:d} {1}", i + 1, A.Imti(i).ToString());
                }

                fw.WriteLine();

                fw.WriteLine("Turnyrinė lentelė: ");
                for (int i = 0; i < B.n; i++)
                {
                    for (int j = 0; j < B.m; j++)
                    {
                        fw.Write(B.ImtiReiksme(i, j) + " ");
                    }
                    fw.WriteLine();
                }
            }
        }
    }
}
