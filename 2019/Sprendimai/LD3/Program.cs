using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LD3
{
    class Operatorius
    {
        private string pavadinimas;
        private double pradSum, tarifSav, tarifKit, smsSav, smsKit;

        public Operatorius(string pavadinimas, double pradSum, double tarifSav, double tarifKit, double smsSav, double smsKit)
        {
            this.pavadinimas = pavadinimas;
            this.pradSum = pradSum;
            this.tarifSav = tarifSav;
            this.tarifKit = tarifKit;
            this.smsSav = smsSav;
            this.smsKit = smsKit;
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format(" {0, -12}      {1, 6:f}            {2, 6:f}             {3, 6:f}           {4, 6:f}         {5, 6:f} ", pavadinimas, pradSum, tarifSav, tarifKit, smsSav, smsKit);
            return eilute;
        }

        public static bool operator <=(Operatorius op1, Operatorius op2)
        {
            int p = String.Compare(op1.pavadinimas, op2.pavadinimas, StringComparison.CurrentCulture);
            return (op1.pradSum > op2.pradSum || (op1.pradSum == op2.pradSum && p < 0));
        }

        public static bool operator >=(Operatorius op1, Operatorius op2)
        {
            int p = String.Compare(op1.pavadinimas, op2.pavadinimas, StringComparison.CurrentCulture);
            return (op1.pradSum < op2.pradSum || (op1.pradSum == op2.pradSum && p > 0));
        }

        public string KoksPavadinimas() { return pavadinimas; }

        public double KokiaPradineSuma() { return pradSum; }
        
        public double KoksTarifasISavusTinklus() { return tarifSav; }

        public double KoksTarifasIKitusTinklus() { return tarifKit; }

        public double SMSiSavus() { return smsSav; }

        public double SMSiKitus() { return smsKit; }
    }

    class Korteles
    {
        const int CMax = 100;
        private Operatorius[] Op;
        private int n;

        public Korteles()
        {
            n = 0;
            Op = new Operatorius[CMax];
        }

        public int Max() { return CMax; }

        public int Imti() { return n; }

        public Operatorius Imti(int i) { return Op[i]; }

        public void Dėti(Operatorius ob) { Op[n++] = ob; }

        public void Sort()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Operatorius min = Op[i];
                int mazindex = i;
                for (int j = i + 1; j < n; j++)
                    if (Op[j] <= min)
                    {
                        min = Op[j];
                        mazindex = j;
                    }
                Op[mazindex] = Op[i];
                Op[i] = min;
            }
        }
    }

    class Program
    {
        const string duom = "...\\...\\duom.txt";
        const string rez = "...\\...\\rez.txt";

        static void Main(string[] args)
        {
            Korteles korteles = new Korteles();
            Skaityti(duom, ref korteles);

            if (File.Exists(rez))
                File.Delete(rez);
            Spausdinti(rez, korteles, "Pradiniai duomenys:");

            double maziausiaKaina = MaziausiosSMSKainos(korteles);
            SpausdintiMaziausiosSMSKainos(rez, korteles, "SMS tarifai mažiausi:", maziausiaKaina);

            Korteles naujas = new Korteles();
            Nemokamai(korteles, naujas);
            Spausdinti(rez, naujas, "Paliktos tik tos kortelės, su kuriomis į savus tinklus galima skambinti ir rašyti nemokamai:");

            if (naujas.Imti() > 0)
            {
                naujas.Sort();
                Spausdinti(rez, naujas, "Surikiuotos kortelės:");
            }
            
            Console.WriteLine("Programa baige darba!");
        }

        static void Nemokamai(Korteles korteles, Korteles naujas)
        {
            for (int i = 0; i < korteles.Imti(); i++)
            {
                if (korteles.Imti(i).KoksTarifasISavusTinklus() == 0 && korteles.Imti(i).SMSiSavus() == 0)
                    naujas.Dėti(korteles.Imti(i));
            }
        }

        static void SpausdintiMaziausiosSMSKainos(string rez, Korteles korteles, string antraste, double mazK)
        {
            string virsus =
                "--------------------------------------------------------------------------------------------------\r\n" +
                " Pavadinimas    Pradinė suma     Tarifas į savus    Tarifas į kitus    SMS į savus    SMS į kitus \r\n" +
                "--------------------------------------------------------------------------------------------------";

            using (var fr = File.AppendText(rez))
            {
                fr.WriteLine(antraste);
                fr.WriteLine(virsus);
                for (int i = 0; i < korteles.Imti(); i++)
                {
                    if (korteles.Imti(i).SMSiKitus() == mazK)
                        fr.WriteLine("{0}", korteles.Imti(i).ToString());
                }
                fr.WriteLine("--------------------------------------------------------------------------------------------------\r\n");
            }
        }

        static double MaziausiosSMSKainos(Korteles korteles)
        {
            double maziausiaKaina = korteles.Imti(0).SMSiKitus();
            for (int i = 1; i < korteles.Imti(); i++)
            {
                if (korteles.Imti(i).SMSiKitus() < maziausiaKaina)
                    maziausiaKaina = korteles.Imti(i).SMSiKitus();
            }
            return maziausiaKaina;
        }

        static void Skaityti(string duom, ref Korteles korteles)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string pav;
                double prad, t1, t2, sms1, sms2;
                string eilute;
                string[] skaidymas;

                while ((eilute = reader.ReadLine()) != null && korteles.Imti() < korteles.Max())
                {
                    skaidymas = eilute.Split(';');
                    pav = skaidymas[0].Trim();
                    prad = double.Parse(skaidymas[1].Trim());
                    t1 = double.Parse(skaidymas[2].Trim());
                    t2 = double.Parse(skaidymas[3].Trim());
                    sms1 = double.Parse(skaidymas[4].Trim());
                    sms2 = double.Parse(skaidymas[5].Trim());
                    Operatorius op = new Operatorius(pav, prad, t1, t2, sms1, sms2);
                    korteles.Dėti(op);
                }
            }
        }

        static void Spausdinti(string rez, Korteles korteles, string antraste)
        {
            string virsus =
                "--------------------------------------------------------------------------------------------------\r\n" +
                " Pavadinimas    Pradinė suma     Tarifas į savus    Tarifas į kitus    SMS į savus    SMS į kitus \r\n" +
                "--------------------------------------------------------------------------------------------------";

            using (var fr = File.AppendText(rez))
            {
                fr.WriteLine(antraste);
                if (korteles.Imti() > 0)
                {
                    fr.WriteLine(virsus);
                    for (int i = 0; i < korteles.Imti(); i++)
                        fr.WriteLine("{0}", korteles.Imti(i).ToString());
                    fr.WriteLine("--------------------------------------------------------------------------------------------------\r\n");
                }
                else
                    fr.WriteLine("Sąrašas tuščias");
            }
        }
    }
}