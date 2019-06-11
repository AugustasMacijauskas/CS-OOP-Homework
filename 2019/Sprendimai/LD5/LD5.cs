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
        public int pergales { get; set; }
        public int pralaimejimai { get; set; }
        public int lygiosios { get; set; }
        public int imusta { get; set; }
        public int praleista { get; set; }
        public int svariosrungtynes { get; set; }

        public Komanda(string pav, string miestas, string pavarde, string vardas)
        {
            this.pav = pav;
            this.miestas = miestas;
            this.pavarde = pavarde;
            this.vardas = vardas;
            pergales = 0;
            pralaimejimai = 0;
            lygiosios = 0;
            imusta = 0;
            praleista = 0;
            svariosrungtynes = 0;
        }

        public override string ToString()
        {
            string eil = string.Format(" {0, -15}   {1, -15}  {2, -15}        {3, -15}       {4, 2:d}/{5, 2:d}/{6, 2:d}                            {7, 2:d}/{8, 2:d}/{9, 2:d}                            {10, 2:d}", pav, miestas, pavarde, vardas, pergales, pralaimejimai, lygiosios, imusta, praleista, svariosrungtynes, KiekTasku());
            return eil;
        }

        public static bool operator <=(Komanda k1, Komanda k2)
        {
            return ((k1.KiekTasku() > k2.KiekTasku()) || ((k1.KiekTasku() == k2.KiekTasku()) && (k1.pergales > k2.pergales)));
        }

        public static bool operator >=(Komanda k1, Komanda k2)
        {
            return ((k1.KiekTasku() < k2.KiekTasku()) || ((k1.KiekTasku() == k2.KiekTasku()) && (k1.pergales < k2.pergales)));
        }

        public void SkaiciuotiTaskus(Rezultatai B, int x)
        {
            pergales = 0;
            pralaimejimai = 0;
            lygiosios = 0;
            imusta = 0;
            praleista = 0;

            for (int j = 0; j < B.m; j++)
            {
                if (x != j)
                {
                    imusta += B.ImtiReiksme(x, j);
                    praleista += B.ImtiReiksme(j, x);
                    if (B.ImtiReiksme(j, x) == 0)
                    {
                        svariosrungtynes++;
                    }

                    if (B.ImtiReiksme(x, j) == B.ImtiReiksme(j, x))
                    {
                        lygiosios++;
                    }
                    else if (B.ImtiReiksme(x, j) > B.ImtiReiksme(j, x))
                    {
                        pergales++;
                    }
                    else
                    {
                        pralaimejimai++;
                    }
                }
            }
        }

        public int KiekTasku()
        {
            return pergales * 3 + lygiosios;
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

        public void Rikiuoti(Rezultatai B)
        {
            for (int i = 0; i < n - 1; i++)
            {
                Komanda pagalb = A[i];
                int ind = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (A[j] <= pagalb)
                    {
                        pagalb = A[j];
                        ind = j;
                    }
                }

                A[ind] = A[i];
                A[i] = pagalb;

                B.Sukeisti(i, ind);
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

        public void Sukeisti(int k, int l)
        {
            for (int j = 0; j < m; j++)
            {
                int pagalb = A[k, j];
                A[k, j] = A[l, j];
                A[l, j] = pagalb;
            }
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
            Spausdinti(rez, komandos, "Pradiniai duomenys:");
            SpausdintiRezultatus(rez, rezultatai, "Turnyrinė lentelė:");

            KomanduKonteineris pagalb = new KomanduKonteineris();

            int iv = DaugiausiaiPelnytuIvarciu(komandos);
            FormuotiIv(komandos, pagalb, iv);
            Spausdinti(rez, pagalb, "Daugiausiai įvarčių:");

            pagalb = new KomanduKonteineris();

            int r = DaugiausiaiRungtyniuNepraleista(komandos);
            if (r > 0)
            {
                FormuotiRung(komandos, pagalb, r);
                Spausdinti(rez, pagalb, "Daugiausiai rungtynių nepraleido įvarčių:");
            }
            else
            {
                Print(rez, "Komandų, kurios nepraleido įvarčių, nebuvo\n");
            }

            komandos.Rikiuoti(rezultatai);
            Spausdinti(rez, komandos, "Surikiuoti duomenys:");
            SpausdintiRezultatus(rez, rezultatai, "Turnyrinė lentelė:");

            Console.WriteLine("Programa baigė darbą!");
        }

        static void Print(string rez, string x)
        {
            using (var fw = File.AppendText(rez))
            {
                fw.WriteLine(x);
            }
        }

        static void FormuotiRung(KomanduKonteineris senas, KomanduKonteineris naujas, int k)
        {
            for (int i = 0; i < senas.Imti(); i++)
            {
                if (senas.Imti(i).svariosrungtynes == k)
                {
                    naujas.Dėti(senas.Imti(i));
                }
            }
        }

        static void FormuotiIv(KomanduKonteineris senas, KomanduKonteineris naujas, int k)
        {
            for (int i = 0; i < senas.Imti(); i++)
            {
                if (senas.Imti(i).imusta == k)
                {
                    naujas.Dėti(senas.Imti(i));
                }
            }
        }

        static int DaugiausiaiRungtyniuNepraleista(KomanduKonteineris A)
        {
            int r = 0;

            for (int i = 0; i < A.Imti(); i++)
            {
                if (A.Imti(i).svariosrungtynes > r)
                {
                    r = A.Imti(i).svariosrungtynes;
                }
            }

            return r;
        }


        static int DaugiausiaiPelnytuIvarciu(KomanduKonteineris A)
        {
            int iv = 0;

            for (int i = 0; i < A.Imti(); i++)
            {
                if (A.Imti(i).imusta > iv)
                {
                    iv = A.Imti(i).imusta;
                }
            }

            return iv;
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

                for (int i = 0; i < A.Imti(); i++)
                {
                    A.Imti(i).SkaiciuotiTaskus(B, i);
                }
            }
        }

        static void SpausdintiRezultatus(string rez, Rezultatai B, string antraste)
        {
            using (var fw = File.AppendText(rez))
            {
                fw.WriteLine("Turnyrinė lentelė: ");
                for (int i = 0; i < B.n; i++)
                {
                    for (int j = 0; j < B.m; j++)
                    {
                        fw.Write(B.ImtiReiksme(i, j) + " ");
                    }
                    fw.WriteLine();
                }
                fw.WriteLine();
            }
        }

        static void Spausdinti(string rez, KomanduKonteineris A, string antraste)
        {
            using (var fw = File.AppendText(rez))
            {
                string virsus = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------\r\n" +
                                " Nr.    Komandos pavadinimas     Miestas      Trenerio pavardė       Trenerio vardas       Perg./Pral./Lyg.      Įmušta/Praleista/Kiek rungtynių nepraleido         Taškai \r\n" +
                                "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
                if (A.Imti() > 0)
                {
                    fw.WriteLine(antraste);
                    fw.WriteLine(virsus);
                    for (int i = 0; i < A.Imti(); i++)
                    {
                        fw.WriteLine(" {0,2:d}          {1}              ", i + 1, A.Imti(i).ToString());
                    }
                    fw.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    fw.WriteLine();
                }
            }
        }
    }
}