using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace StudentuPazymiai
{
    class Studentas
    {
        private string pavardė, // studento pavardė
        vardas, // studento vardas
        grupė; // mokymosi grupė
        private ArrayList paž; // pažymių masyvas

        //---------------------------------------------------
        /** Pradiniai studento duomenys, išskyrus pažymius */
        //---------------------------------------------------
        public Studentas()
        {
            pavardė = "";
            vardas = "";
            grupė = "";
            paž = new ArrayList();
        }

        public void Dėti(string pav, string vard, string grup, ArrayList pž)
        {
            pavardė = pav;
            vardas = vard;
            grupė = grup;
            foreach (int sk in pž)
                paž.Add(sk);
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -12} {1, -9} {2, -7}",
            pavardė, vardas, grupė);
            foreach (int sk in paž)
                eilute = eilute + string.Format("{0, 3:d}", sk);
            return eilute;
        }

        public static bool operator !(Studentas stud)
        {
            foreach (int paz in stud.paž)
            {
                if (paz < 9)
                    return true;
            }
            return false;
        }

        public static bool operator <=(Studentas st1, Studentas st2)
        {
            int p = String.Compare(st1.pavardė, st2.pavardė, StringComparison.CurrentCulture);
            int v = String.Compare(st1.vardas, st2.vardas, StringComparison.CurrentCulture);
            int g = String.Compare(st1.grupė, st2.grupė, StringComparison.CurrentCulture);
            return (p < 0 || (p == 0 && v < 0) || (p == 0 && v == 0 && g < 0));
        }

        public static bool operator >=(Studentas st1, Studentas st2)
        {
            int p = String.Compare(st1.pavardė, st2.pavardė, StringComparison.CurrentCulture);
            int v = String.Compare(st1.vardas, st2.vardas, StringComparison.CurrentCulture);
            return (p > 0 || (p == 0 && v > 0));
        }

        public string KokiaPavardė() { return pavardė; }
    }

    class Fakultetas
    {
        const int CMax = 100; // maksimalus studentų skaičius
        private Studentas[] St; // studentų duomenys
        private int n; // studentų skaičius

        public Fakultetas()
        {
            n = 0;
            St = new Studentas[CMax];
        }

        /** Grąžina studentų skaičių */
        public int Imti() { return n; }

        /** Grąžina nurodyto indekso studento objektą
        @param i - studento indeksas */
        public Studentas Imti(int i) { return St[i]; }

        /** Padeda į studentų objektų masyvą naują studentą ir
        // masyvo dydį padidina vienetu
        @param ob - studento objektas */
        public void Dėti(Studentas ob) { St[n++] = ob; }

        public void Keisti(Studentas ob, int n)
        {
            St[n] = ob;
        }

        public void Sort()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Studentas min = St[i];
                int mazIndex = i;
                for (int j = i + 1; j < n; j++)
                    if (St[j] <= min)
                    {
                        min = St[j];
                        mazIndex = j;
                    }
                St[mazIndex] = St[i];
                St[i] = min;
            }
        }
    }

    class Program
    {
        const string duom = "...\\...\\duom.txt";
        const string rez = "...\\...\\rez.txt";

        static void Main(string[] args)
        {
            Fakultetas grupes = new Fakultetas();
            Skaityti(duom, ref grupes);

            if (File.Exists(rez))
                File.Delete(rez);
            Spausdinti(rez, grupes, "Pradiniai duomenys:");

            Fakultetas geriausi = new Fakultetas();
            Formuoti(grupes, ref geriausi);
            Spausdinti(rez, geriausi, "Geriausi studentai:");
            geriausi.Sort();
            Spausdinti(rez, geriausi, "Surikiuoti geriausi studentai:");

            Naikinti(ref grupes);
            SpausdintiGeriausius(rez, grupes, "Sarasas, kuriame palikti tik geriausi studentai:");
            Console.WriteLine("Programa baige darba!");
        }

        static void SpausdintiGeriausius(string rez, Fakultetas grupes, string antraste)
        {
            string virsus =
                "------------------------------------------\r\n" +
                " Pavardė    Vardas     Grupė    Pažymiai  \r\n" +
                "------------------------------------------";

            using (var fr = File.AppendText(rez))
            {
                if (grupes.Imti() > 0)
                {
                    fr.WriteLine(antraste);
                    fr.WriteLine(virsus);
                    for (int i = 0; i < grupes.Imti(); i++)
                        if (grupes.Imti(i).KokiaPavardė() != "")
                            fr.WriteLine("{0}", grupes.Imti(i).ToString());
                    fr.WriteLine("------------------------------------------\r\n\n");
                }
                else fr.WriteLine("Sarasas tuscias");
            }
        }

        static void Naikinti(ref Fakultetas geriausi)
        {
            for (int i = 0; i < geriausi.Imti(); i++)
            {
                if (!geriausi.Imti(i))
                {
                    Studentas temp = new Studentas();
                    geriausi.Keisti(temp, i);
                }
            }
        }

        static void Formuoti(Fakultetas pradinis, ref Fakultetas naujas)
        {
            for (int i = 0; i < pradinis.Imti(); i++)
                if (!pradinis.Imti(i))
                    ;
                else
                    naujas.Dėti(pradinis.Imti(i));
        }

        static void Skaityti(string duom, ref Fakultetas grupes)
        {
            string pav, vard, grupe;
            ArrayList pazymiai = new ArrayList();
            string[] lines = File.ReadAllLines(duom, Encoding.GetEncoding(1257));
            foreach (string line in lines)
            {
                string[] skaidymas = line.Split(';');
                pav = skaidymas[0].Trim();
                vard = skaidymas[1].Trim();
                grupe = skaidymas[2].Trim();

                string[] paz = skaidymas[3].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                pazymiai.Clear();
                foreach (string pz in paz)
                {
                    int pazym = int.Parse(pz);
                    pazymiai.Add(pazym);
                }
                Studentas stud = new Studentas();
                stud.Dėti(pav, vard, grupe, pazymiai);
                grupes.Dėti(stud);
            }
        }

        static void Spausdinti(string rez, Fakultetas grupes, string antraste)
        {
            string virsus =
                "------------------------------------------\r\n" +
                " Pavardė    Vardas     Grupė    Pažymiai  \r\n" +
                "------------------------------------------";

            using (var fr = File.AppendText(rez))
            {
                if (grupes.Imti() > 0)
                {
                    fr.WriteLine(antraste);
                    fr.WriteLine(virsus);
                    for (int i = 0; i < grupes.Imti(); i++)
                        fr.WriteLine("{0}", grupes.Imti(i).ToString());
                    fr.WriteLine("------------------------------------------\r\n\n");
                }
                else fr.WriteLine("Sarasas tuscias");
            }
        }
    }
}
