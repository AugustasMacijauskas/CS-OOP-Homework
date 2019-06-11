using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kontrolinis_2
{
    abstract class Prietaisas : IComparable<Prietaisas>
    {
        public string Gamintojas { get; set; }
        public string Modelis { get; set; }
        public int PagaminimoMetai { get; set; }
        public double Kaina { get; set; }

        public Prietaisas(string Gamintojas, string Modelis, int PagaminimoMetai, double Kaina)
        {
            this.Gamintojas = Gamintojas;
            this.Modelis = Modelis;
            this.PagaminimoMetai = PagaminimoMetai;
            this.Kaina = Kaina;
        }

        public override string ToString()
        {
            return string.Format("       {0, -25} {1, -15} {2, 5:d}           {3, 6:f}", this.Gamintojas, this.Modelis, this.PagaminimoMetai, this.Kaina);
        }

        public int CompareTo(Prietaisas other)
        {
            if (this is Televizorius && other is Kompiuteris)
            {
                return 1;
            }
            if (this is Kompiuteris && other is Televizorius)
            {
                return -1;
            }
            if (this is Televizorius && other is Televizorius)
            {
                return -((Televizorius)this).CompareTo((Televizorius)other);
            }
            if (this is Kompiuteris && other is Kompiuteris)
            {
                return -((Kompiuteris)this).CompareTo((Kompiuteris)other);
            }

            return 0;
        }
    }

    class Televizorius : Prietaisas, IComparable<Televizorius>
    {
        public double IstrizainesIlgis { get; set; }

        public Televizorius(string Gamintojas, string Modelis, int PagaminimoMetai, double Kaina, double IstrizainesIlgis) : base(Gamintojas, Modelis, PagaminimoMetai, Kaina)
        {
            this.IstrizainesIlgis = IstrizainesIlgis;
        }

        public override string ToString()
        {
            return string.Format("  t {0}            {1, -6:f}", base.ToString(), this.IstrizainesIlgis);
        }

        public int CompareTo(Televizorius other)
        {
            return this.IstrizainesIlgis.CompareTo(other.IstrizainesIlgis);
        }
    }

    class Kompiuteris : Prietaisas, IComparable<Kompiuteris>
    {
        public double RAM { get; set; }

        public Kompiuteris(string Gamintojas, string Modelis, int PagaminimoMetai, double Kaina, double RAM) : base(Gamintojas, Modelis, PagaminimoMetai, Kaina)
        {
            this.RAM = RAM;
        }

        public override string ToString()
        {
            return string.Format("  k {0}            {1, -6:f}", base.ToString(), this.RAM);
        }

        public int CompareTo(Kompiuteris other)
        {
            return this.RAM.CompareTo(other.RAM);
        }
    }

    class Program
    {
        const string duom1 = "..//..//duom1.txt";
        const string duom2 = "..//..//duom2.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            string parduotuvesPavadinimas1;
            string parduotuvesPavadinimas2;
            List<Prietaisas> parduotuvesPrekes1 = Skaityti(duom1, out parduotuvesPavadinimas1);
            List<Prietaisas> parduotuvesPrekes2 = Skaityti(duom2, out parduotuvesPavadinimas2);
            Spausdinti(parduotuvesPrekes1, "Pradiniai duomenys " + parduotuvesPavadinimas1 + ":");
            Spausdinti(parduotuvesPrekes2, "Pradiniai duomenys " + parduotuvesPavadinimas2 + ":");

            double kaina;
            Console.Write("Įveskite kainą, už kurią brangesnius prietaisus norite atrinkti: ");
            kaina = double.Parse(Console.ReadLine());
            int didesniUzKaina1 = KiekDidesniuUzKaina(parduotuvesPrekes1, kaina);
            int didesniUzKaina2 = KiekDidesniuUzKaina(parduotuvesPrekes2, kaina);
            Console.WriteLine("Parduotuvėje {0} yra {1} prekių brangesnių už {2, 6:f}", parduotuvesPavadinimas1, didesniUzKaina1, kaina);
            Console.WriteLine("Parduotuvėje {0} yra {1} prekių brangesnių už {2, 6:f}\r\n", parduotuvesPavadinimas2, didesniUzKaina2, kaina);

            List<Prietaisas> naujausi = new List<Prietaisas>();
            Formuoti(parduotuvesPrekes1, naujausi);
            Formuoti(parduotuvesPrekes2, naujausi);
            if (naujausi.Count > 0)
            {
                Spausdinti(naujausi, "Atrinkti naujausi:");
                Rikiuoti(naujausi);
                Spausdinti(naujausi, "Surikiuoti naujausi:");
            }
            else
            {
                Console.WriteLine("Atrinkti naujausi:");
                Console.WriteLine("Sąrašas tuščias!\r\n");
            }

            Console.WriteLine("Programa baigė darbą!");
        }

        static void Rikiuoti(List<Prietaisas> prietaisai)
        {
            int min;
            for (int i = 0; i < prietaisai.Count - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < prietaisai.Count; j++)
                {
                    if (prietaisai[min].CompareTo(prietaisai[j]) == -1)
                    {
                        min = j;
                    }
                }

                var temp = prietaisai[i];
                prietaisai[i] = prietaisai[min];
                prietaisai[min] = temp;
            }
        }

        static void Formuoti(List<Prietaisas> senas, List<Prietaisas> naujas)
        {
            int dabartiniaiMetai = DateTime.Now.Year;
            for (int i = 0; i < senas.Count; i++)
            {
                if ((senas[i] is Televizorius && (dabartiniaiMetai - senas[i].PagaminimoMetai <= 2)) || (senas[i] is Kompiuteris && (dabartiniaiMetai - senas[i].PagaminimoMetai <= 1)))
                {
                    naujas.Add(senas[i]);
                }
            }
        }

        static int KiekDidesniuUzKaina(List<Prietaisas> prietaisai, double kaina)
        {
            int kiek = 0;
        
            for (int i = 0; i < prietaisai.Count; i++)
            {
                if (prietaisai[i].Kaina > kaina)
                {
                    kiek++;
                }
            }

            return kiek;
        }

        static List<Prietaisas> Skaityti(string failas, out string parduotuvesPavadinimas)
        {
            List<Prietaisas> naujas = new List<Prietaisas>();
            using (StreamReader reader = new StreamReader(failas))
            {
                string line;
                string Gamintojas;
                string Modelis;
                int PagaminimoMetai;
                double Kaina;

                parduotuvesPavadinimas = reader.ReadLine();

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    if (parts[0].Trim() == "t")
                    {
                        Gamintojas = parts[1].Trim();
                        Modelis = parts[2].Trim();
                        PagaminimoMetai = int.Parse(parts[3].Trim());
                        Kaina = double.Parse(parts[4].Trim());
                        double istrizaine = double.Parse(parts[5].Trim());
                        Televizorius naujasTelevizorius = new Televizorius(Gamintojas, Modelis, PagaminimoMetai, Kaina, istrizaine);
                        naujas.Add(naujasTelevizorius);

                    }
                    else if (parts[0].Trim() == "k")
                    {
                        Gamintojas = parts[1].Trim();
                        Modelis = parts[2].Trim();
                        PagaminimoMetai = int.Parse(parts[3].Trim());
                        Kaina = double.Parse(parts[4].Trim());
                        double RAM = double.Parse(parts[5].Trim());
                        Kompiuteris naujasTelevizorius = new Kompiuteris(Gamintojas, Modelis, PagaminimoMetai, Kaina, RAM);
                        naujas.Add(naujasTelevizorius);
                    }
                }
            }

            return naujas;
        }

        static void Spausdinti(List<Prietaisas> prietaisai, string antraste)
        {
            const string virsus = "-----------------------------------------------------------------------------------------------------------\r\n" +
                                  " Nr. Tipas      Gamintojas              Modelis      Pagaminimo metai     Kaina     Įstraižainės ilgis/RAM \r\n" +
                                  "-----------------------------------------------------------------------------------------------------------";
            
            if (prietaisai.Count > 0)
            {
                Console.WriteLine(antraste);
                Console.WriteLine(virsus);
                for (int i = 0; i < prietaisai.Count; i++)
                {
                    Console.WriteLine(" {0, 3:d} {1}", i + 1, prietaisai[i].ToString());
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------\r\n");
            }
            else
            {
                Console.WriteLine(antraste);
                Console.WriteLine("Sąrašas tuščias!");
            }
        }
    }
}
