using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klausimas1
{
    class Krepsininkas
    {
        string vardas;
        int metai;
        int ugis;
        double taskai;
        public Krepsininkas()
        {

        }
        public Krepsininkas(string vardas, int metai, int ugis, double taskai)
        {
            this.vardas = vardas;
            this.metai = metai;
            this.ugis = ugis;
            this.taskai = taskai;
        }
        public void DetiVarda(string vardas)
        {
            this.vardas = vardas;
        }
        public string ImtiVarda()
        {
            return vardas;
        }
        public void DetiMetus(int metai)
        {
            this.metai = metai;
        }
        public int ImtiMetus()
        {
            return metai;
        }
        public void DetitUgi(int ugis)
        {
            this.ugis = ugis;
        }
        public int ImtiUgi()
        {
            return ugis;
        }
        public void DetiTaskus(double taskai)
        {
            this.taskai = taskai;
        }
        public double ImtiTaskus()
        {
            return taskai;
        }


        //Užrašykite palyginimo pagal taškus ir vardus operatorius (>=; <=).
        public static bool operator <=(Krepsininkas k1, Krepsininkas k2)
        {
            int poz = string.Compare(k1.ImtiVarda(), k2.ImtiVarda(), StringComparison.CurrentCulture);

            return ((k1.ImtiTaskus() > k2.ImtiTaskus()) || ((k1.ImtiTaskus() == k2.ImtiTaskus()) && (poz < 0)));
        }

        public static bool operator >=(Krepsininkas k1, Krepsininkas k2)
        {
            int poz = string.Compare(k1.ImtiVarda(), k2.ImtiVarda(), StringComparison.CurrentCulture);

            return ((k1.ImtiTaskus() < k2.ImtiTaskus()) || ((k1.ImtiTaskus() == k2.ImtiTaskus()) && (poz > 0)));
        }
    }

    class Komanda
    {
        int max = 100;
        Krepsininkas[] komanda;
        int n = 0;
        public Komanda()
        {
            komanda = new Krepsininkas[max];
        }
        public int ImtiN()
        {
            return n;
        }
        public Krepsininkas ImtiKrepsininka(int index)
        {
            return komanda[index];
        }
        public void DetiKrepsininka(Krepsininkas krepsininkas)
        {
            komanda[n] = krepsininkas;
            n++;
        }
        

        // Užrašykite naujo žaidėjo įterpimo į rikiuotą konteinerį metodą.
        // Konteineryje žaidėjai rikiuoti taškų mažėjimo ir vardų alfabetine tvarka.
        public void Įterpti(int k, Krepsininkas naujas)
        {
            for (int i = n; i > k; i--)
            {
                komanda[i] = komanda[i - 1];
            }
            komanda[k] = naujas;
            n++;
        }

        public int RastiVieta(Krepsininkas naujas)
        {
            int ind = 0;
            while (ind < n && komanda[ind] <= naujas)
                ind++;

            return ind;
        }







        // Užrašykite konteinerio žaidėjų, kurių ūgis > už duotą dydį y, taškų 
        // vidurkio radimo metodą.
        public double TaskuVidurkis(int y)
        {
            double sum = 0;
            int kiek = 0;
            for (int i = 0; i < n; i++)
            {
                if (komanda[i].ImtiUgi() > y)
                {
                    sum += komanda[i].ImtiTaskus();
                    kiek++;
                }
            }

            if (kiek > 0)
            {
                return sum / kiek;
            }
            else
            {
                return -1;
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1257);
            const string fileIn = "..\\..\\Komanda.txt";
            const string fileIn1 = "..\\..\\Komandan.txt";
            const string fileOut = "..\\..\\Rez.txt";

            if (File.Exists(fileOut))
                File.Delete(fileOut);

            Komanda Komanda1 = Read(fileIn);
            Print(fileOut, Komanda1,"Komanda");
            Komanda Papildoma = Read(fileIn1);
            Print(fileOut, Papildoma,"Nauji žaidėjai");

            // Atlikite visus nurodytus skaičiavimus.
            IterptiVienaIKita(Komanda1, Papildoma);
            Print(fileOut, Komanda1, "Įterpti nauji žaidėjai: ");
            double taskuVidurkis = Komanda1.TaskuVidurkis(200);
            if (taskuVidurkis != -1)
            {
                Console.WriteLine("Taškų vidurkis: {0}", taskuVidurkis);
            }
            else
            {
                Console.WriteLine("Tokio ūgio žaidėjų nebuvo!");
            }
        }



        // Užrašykite vieno konteinerio žaidėjų įterpimo į kitą, rikiuotą konteinerį metodą.
        static void IterptiVienaIKita(Komanda senas, Komanda naujas)
        {
            for (int i = 0; i < naujas.ImtiN(); i++)
            {
                Krepsininkas temp = naujas.ImtiKrepsininka(i);
                int ind = senas.RastiVieta(temp);
                senas.Įterpti(ind, temp);
            }
        }



        static Komanda Read(string fileIn)
        {
            Komanda komanda = new Komanda();
            using (StreamReader reader = new StreamReader(fileIn))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string vardas = parts[0];
                    int metai = int.Parse(parts[1]);
                    int ugis = int.Parse(parts[2]);
                    double taskai = double.Parse(parts[3]);
                    komanda.DetiKrepsininka(new Krepsininkas(vardas, metai, ugis, taskai));
                }
                return komanda;
            }
        }
        static void Print(string fv, Komanda komanda, string tekstas)
        {
            using (var writer = File.AppendText(fv))
            {
                if (komanda.ImtiN() != 0)
                {
                    writer.WriteLine();
                    writer.WriteLine("       " + tekstas);
                    writer.WriteLine();
                    writer.WriteLine("|            Vardas Pavardė    |    Metai    |    Ūgis     |    Taškai     |");
                    for (int i = 0; i < komanda.ImtiN(); i++)
                    {
                        Krepsininkas k = komanda.ImtiKrepsininka(i);
                        writer.WriteLine("|{0, 29} |{1, 12} |{2, 12} |{3, 14} |", k.ImtiVarda(), k.ImtiMetus(), k.ImtiUgi(), k.ImtiTaskus());
                    }
                }
                else writer.WriteLine("Konteineryje nėra elementų");
            }
        }
    }
}
