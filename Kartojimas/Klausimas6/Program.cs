﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klausimas6
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


        //Užrašykite palyginimo pagal  taškus ir vardus operatorius (==; !=).





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

    

        // Užrašykite paprastos paieškos rikiuotame masyve metodą.



        // Užrašykite konteinerio Naujas žaidėjų išmetimo iš kito, rikiuoto konteinerio, metodą.
        // Panaudokite susikurtą paprastos paieškos metodą.

    }



    class Program
    {
        static void Main(string[] args)
        {
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
