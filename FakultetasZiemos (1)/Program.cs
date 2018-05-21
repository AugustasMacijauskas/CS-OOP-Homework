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

        public double PažymiųSuma()
        {
            double sum = 0;
            foreach (int pz in paž)
                sum += pz;
            return sum / paž.Count;
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

        public string KokiaGrupė() { return grupė; }
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

        public int Max() { return CMax; }

        public int Imti() { return n; }

        public Studentas Imti(int i) { return St[i]; }

        public void Dėti(Studentas ob) { St[n++] = ob; }

        public void Sort()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Studentas min = St[i];
                int mazindex = i;
                for (int j = i + 1; j < n; j++)
                    if (St[j] <= min)
                    {
                        min = St[j];
                        mazindex = j;
                    }
                St[mazindex] = St[i];
                St[i] = min;
            }
        }
    }

    class Grupes
    {
        private string name;
        private Fakultetas grupe;
        private double vidurkis = 0;

        public Grupes (string name)
        {
            this.name = name;
            grupe = new Fakultetas();
        }

        public void Dėti(Studentas ob) { grupe.Dėti(ob); }

        public void SkaiciuotiVidurki()
        {
            vidurkis = 0;
            for (int i = 0; i < grupe.Imti(); i++)
            {
                vidurkis += grupe.Imti(i).PažymiųSuma();
            }
            vidurkis /= grupe.Imti();
        }

        public int Kiekis() { return grupe.Imti(); }

        public string KoksPavadinimas() { return name; }

        public double KoksVidurkis()
        {
            SkaiciuotiVidurki();
            return vidurkis;
        }

        public void Sort() { grupe.Sort(); }

        public Studentas Imti(int n) { return grupe.Imti(n); }

        public static bool operator <=(Grupes gr1, Grupes gr2)
        {
            int p = String.Compare(gr1.KoksPavadinimas(), gr2.KoksPavadinimas(), StringComparison.CurrentCulture);
            return p < 0;
        }

        public static bool operator >=(Grupes gr1, Grupes gr2)
        {
            int p = String.Compare(gr1.KoksPavadinimas(), gr2.KoksPavadinimas(), StringComparison.CurrentCulture);
            return p > 0;
        }
    }

    class GrupesKonteineris
    {
        const int CMax = 50; // maksimalus grupių skaičius
        private Grupes[] Gr; // grupių duomenys
        private int n; // grupių skaičius

        public GrupesKonteineris()
        {
            n = 0;
            Gr = new Grupes[CMax];
        }

        public int Max() { return CMax; }

        public int Imti() { return n; }

        public Grupes Imti(int i) { return Gr[i]; }

        public void Dėti(Grupes ob) { Gr[n++] = ob; }

        public void Sort()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Grupes min = Gr[i];
                int mazindex = i;
                for (int j = i + 1; j < n; j++)
                    if (Gr[j] <= min)
                    {
                        min = Gr[j];
                        mazindex = j;
                    }
                Gr[mazindex] = Gr[i];
                Gr[i] = min;
            }
        }
    }

    class Program
    {
        const string duom = "...\\...\\duom.txt";
        const string rez = "...\\...\\rez.txt";

        static void Main(string[] args)
        {
            string FPavadinimas;
            Fakultetas grupes = new Fakultetas();
            Skaityti(duom, ref grupes, out FPavadinimas);

            GrupesKonteineris gr = new GrupesKonteineris();

            if (File.Exists(rez))
                File.Delete(rez);
            Spausdinti(rez, grupes, String.Format("Pradiniai duomenys: " + FPavadinimas));
            Formuoti(grupes, gr);
            Atspausdinti(rez, gr, "Grupiu masyvas: ");
            AtspausdintiVidurkius(rez, gr, "Grupiu vidurkiai: ");

            Console.WriteLine("Programa baige darba!");
        }

        static void AtspausdintiVidurkius(string duom, GrupesKonteineris grupes, string antraste)
        {
            using (var fr = File.AppendText(rez))
            {
                if (grupes.Imti() > 0)
                {
                    fr.WriteLine(antraste);
                    for (int i = 0; i < grupes.Imti(); i++)
                    {
                        fr.WriteLine("Grupės {0} vidurkis yra {1,5:f}", grupes.Imti(i).KoksPavadinimas(), grupes.Imti(i).KoksVidurkis());
                    }
                    fr.WriteLine("\r\n");
                }
                else fr.WriteLine("Sarasas tuscias");
            }
        }

        static void Atspausdinti(string duom, GrupesKonteineris grupes, string antraste)
        {
            string virsus =
                "------------------------------------------\r\n" +
                " Pavardė    Vardas     Grupė    Pažymiai  \r\n" +
                "------------------------------------------";

            using (var fr = File.AppendText(rez))
            {
                if (grupes.Imti() > 0)
                {
                    grupes.Sort();
                    fr.WriteLine(antraste);
                    fr.WriteLine(virsus);
                    for (int i = 0; i < grupes.Imti(); i++)
                    {
                        fr.WriteLine("Grupė nr. {0}, {1}", i + 1, grupes.Imti(i).KoksPavadinimas());
                        grupes.Imti(i).Sort();
                        for (int j = 0; j < grupes.Imti(i).Kiekis(); j++)
                            fr.WriteLine("{0}", grupes.Imti(i).Imti(j).ToString());
                        fr.WriteLine("------------------------------------------");
                    }
                    fr.WriteLine("\r\n");
                }
                else fr.WriteLine("Sarasas tuscias");
            }
        }

        static bool ContainsSubstring(List<string> A, string sub)
        {
            foreach (string str in A)
            {
                int p = String.Compare(str, sub);
                if (p == 0)
                    return true;
            }

            return false;
        }

        static void Formuoti(Fakultetas pradinis, GrupesKonteineris naujas)
        {
            List<string> grup = new List<string>();
            for (int i = 0; i < pradinis.Imti(); i++)
            {
                if (!ContainsSubstring(grup, pradinis.Imti(i).KokiaGrupė()))
                    grup.Add(pradinis.Imti(i).KokiaGrupė());
            }

            foreach(string gr in grup)
            {
                Grupes grupe = new Grupes(gr);
                for (int i = 0; i < pradinis.Imti(); i++)
                {
                    if (pradinis.Imti(i).KokiaGrupė() == gr)
                    {
                        grupe.Dėti(pradinis.Imti(i));
                    }
                }
                naujas.Dėti(grupe);
            }
        }

        static void Skaityti(string duom, ref Fakultetas grupes, out string Fakult)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string pav, vard, grupe;
                int pazK;
                ArrayList pazymiai = new ArrayList();
                string eilute;
                string[] skaidymas;

                eilute = reader.ReadLine();
                Fakult = eilute;

                while ((eilute = reader.ReadLine()) != null && grupes.Imti() < grupes.Max())
                {
                    skaidymas = eilute.Split(';');
                    pav = skaidymas[0].Trim();
                    vard = skaidymas[1].Trim();
                    grupe = skaidymas[2].Trim();
                    pazK = int.Parse(skaidymas[3].Trim());
                    string[] paz = skaidymas[4].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    pazymiai.Clear();
                    for (int i = 0; i < pazK; i++)
                    {
                        int pazym = int.Parse(paz[i]);
                        pazymiai.Add(pazym);
                    }
                    Studentas stud = new Studentas();
                    stud.Dėti(pav, vard, grupe, pazymiai);
                    grupes.Dėti(stud);
                }
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
                    fr.WriteLine("------------------------------------------\r\n");
                }
                else fr.WriteLine("Sarasas tuscias");
            }
        }
    }
}


