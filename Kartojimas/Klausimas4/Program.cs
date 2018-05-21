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

        //Užrašykite dviejų objektų visų laukų palyginimo operatorius operatorius (==; !=).
        public static bool operator ==(Krepsininkas k1, Krepsininkas k2)
        {
            int poz = string.Compare(k1.ImtiVarda(), k2.ImtiVarda(), StringComparison.CurrentCulture);

            return ((poz == 0) && (k1.ImtiMetus() == k2.ImtiMetus()) && (k1.ImtiUgi() == k2.ImtiUgi()) && (k1.ImtiTaskus() == k2.ImtiTaskus()));
        }

        public static bool operator !=(Krepsininkas k1, Krepsininkas k2)
        {
            int poz = string.Compare(k1.ImtiVarda(), k2.ImtiVarda(), StringComparison.CurrentCulture);

            return ((poz != 0) || (k1.ImtiMetus() != k2.ImtiMetus()) || (k1.ImtiUgi() != k2.ImtiUgi()) || (k1.ImtiTaskus() != k2.ImtiTaskus()));
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

        // Užrašykite konteinerio rikiavimo taškų mažėjimo ir vardų alfabetine tvarka metodą.
        public void Rikiuoti()
        {
            int min;
            for (int i = 0; i < n - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (komanda[j] <= komanda[min])
                    {
                        min = j;
                    }
                }

                Krepsininkas temp = komanda[i];
                komanda[i] = komanda[min];
                komanda[min] = temp;
            }
        }


        
        // Užrašykite dvejetainės paieškos rikiuotame masyve metodą.
        public int DvejetainėPaieška(Krepsininkas naujas)
        {
            int start = 0;
            int end = n - 1;
            int mid;

            while (start <= end)
            {
                mid = (start + end) / 2;
                if (komanda[mid] == naujas)
                    return mid;
                else
                {
                    if (komanda[mid] <= naujas)
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
            }

            return -1;
        }



        // Užrašykite konteinerio Naujas žaidėjų išmetimo iš kito, rikiuoto konteinerio, metodą.
        // Panaudokite susikurtą dvejetainės paieškos metodą.

        public void Deti(int ind, Krepsininkas naujas)
        {
            komanda[ind] = naujas;
        }

        public void setN()
        {
            n--;
        }

        public void Išmesti(Komanda senas, Komanda naujas)
        {
            for (int i = 0; i < naujas.ImtiN(); i++)
            {
                Krepsininkas temp = naujas.ImtiKrepsininka(i);
                int index = senas.DvejetainėPaieška(temp);
                if (index != -1)
                {
                    for (int j = index; j < n - 1; j++)
                    {
                        senas.Deti(j, senas.ImtiKrepsininka(j + 1));
                    }
                    senas.setN();
                }
                else
                {
                    Console.WriteLine("Žaidėjas, kurio numeris naujame konteineryje {0}, nerastas", i + 1);
                }
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
            Print(fileOut, Komanda1, "Komanda");
            Komanda Naujas = Read(fileIn1);
            Print(fileOut, Naujas, "Nauji žaidėjai");

            // Atlikite visus nurodytus skaičiavimus.
            Komanda1.Rikiuoti();
            Print(fileOut, Komanda1, "Rikiavimas: ");

            Komanda1.Išmesti(Komanda1, Naujas);
            Print(fileOut, Komanda1, "Išmesti žaidėjai: ");



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

