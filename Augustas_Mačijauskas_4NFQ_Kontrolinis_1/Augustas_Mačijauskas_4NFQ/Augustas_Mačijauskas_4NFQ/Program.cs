using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Augustas_Mačijauskas_4NFQ
{
    class Knyga
    {
        private string vardasPavarde;
        public string VardasPavardė() => vardasPavarde;

        private string knygosPavadinimas;
        public string KnygosPavadinimas() => knygosPavadinimas;

        private int isleidimoMetai;
        public int IšleidimoMetai() => isleidimoMetai;

        private int puslapiuKiekis;
        public int PuslapiųKiekis() => puslapiuKiekis;

        public Knyga(string vp = "", string pav = "", int met = 0, int kiek = 0)
        {
            this.vardasPavarde = vp;
            this.knygosPavadinimas = pav;
            this.isleidimoMetai = met;
            this.puslapiuKiekis = kiek;
        }

        public override string ToString()
        {
            return string.Format($" {vardasPavarde, -30} {knygosPavadinimas, -20}   {isleidimoMetai,4:d}               {puslapiuKiekis,4:d}");

        }

        public static bool operator !=(Knyga k1, Knyga k2)
        {
            int poz1 = String.Compare(k1.VardasPavardė(), k2.VardasPavardė(), StringComparison.CurrentCulture);
            int poz2 = String.Compare(k1.KnygosPavadinimas(), k2.KnygosPavadinimas(), StringComparison.CurrentCulture);

            return poz1 != 0 || poz2 != 0 || k1.IšleidimoMetai() != k2.IšleidimoMetai() || k1.PuslapiųKiekis() != k2.PuslapiųKiekis();
        }

        public static bool operator ==(Knyga k1, Knyga k2)
        {
            int poz1 = String.Compare(k1.VardasPavardė(), k2.VardasPavardė(), StringComparison.CurrentCulture);
            int poz2 = String.Compare(k1.KnygosPavadinimas(), k2.KnygosPavadinimas(), StringComparison.CurrentCulture);

            return poz1 == 0 && poz2 == 0 && k1.IšleidimoMetai() == k2.IšleidimoMetai() && k1.PuslapiųKiekis() == k2.PuslapiųKiekis();
        }
    }

    class Mazgas
    {
        public Knyga Duomenys { get; set; }
        public Mazgas Kitas { get; set; }

        public Mazgas() { }

        public Mazgas(Knyga duom, Mazgas kit)
        {
            this.Duomenys = duom;
            this.Kitas = kit;
        }

        public Mazgas(Mazgas kit)
        {
            this.Duomenys = null;
            this.Kitas = kit;
        }
    }

    class Sąrašas
    {
        private Mazgas pr;
        private Mazgas pb;
        private Mazgas pbt;
        private Mazgas ss;

        public Sąrašas()
        {
            this.pb = new Mazgas(null, null);
            this.pr = new Mazgas(pb);
            this.pbt = pr;
            this.ss = null;
        }

        public void Pradžia() => ss = pr.Kitas;

        public void Kitas() => ss = ss.Kitas;

        public bool Yra() => ss.Kitas != null;

        public bool isEmpty() => pr.Kitas == pb;

        public Knyga Imti() => ss.Duomenys;

        public void DetiA(Knyga nauja)
        {
            if (pr.Kitas == pb)
            {
                pbt = pr.Kitas = new Mazgas(nauja, pr.Kitas);
            }
            else
            {
                pr.Kitas = new Mazgas(nauja, pr.Kitas);
            }
        }

        public void DetiT(Knyga nauja)
        {
            pbt.Kitas = new Mazgas(nauja, pb);
            pbt = pbt.Kitas;
        }

        public void Trinti(string autorius)
        {
            Knyga pasalinti = DaugiausiaPuslapių(autorius);
            Console.Write($"Daugiausia puslapių turinti knyga: " +
                $"{pasalinti.VardasPavardė()}; {pasalinti.KnygosPavadinimas()}; {pasalinti.IšleidimoMetai()}; {pasalinti.PuslapiųKiekis()}\n");

            Mazgas ankstesnis = pr;
            for (Mazgas d = pr.Kitas; d.Kitas != null && d.Duomenys != pasalinti; d = d.Kitas)
            {
                ankstesnis = d;
            }

            if (pbt.Duomenys == ankstesnis.Kitas.Duomenys)
            {
                pbt = ankstesnis;
            }

            ankstesnis.Kitas = ankstesnis.Kitas.Kitas;
        }

        private Knyga DaugiausiaPuslapių(string autorius)
        {
            Knyga max = new Knyga();
            for (Mazgas d = pr.Kitas; d.Kitas != null; d = d.Kitas)
            {
                //Console.Write(d.Duomenys + "\n");
                if (string.Compare(d.Duomenys.VardasPavardė(), autorius, StringComparison.CurrentCulture) == 0 && d.Duomenys.PuslapiųKiekis() > max.PuslapiųKiekis())
                {
                    max = d.Duomenys;
                }
            }

            return max;
        }

        public Knyga PaskutinisElementas()
        {
            return pbt.Duomenys;
            /*
            Mazgas d;
            for (d = pr.Kitas; d.Kitas != pb; d = d.Kitas)
            {

            }

            return d.Duomenys;
            */
        }

        public void Formuoti(Sąrašas senas)
        {
            Knyga paskutine = senas.PaskutinisElementas();
            //Console.Write(paskutine + "\n");

            for (senas.Pradžia(); senas.Yra(); senas.Kitas())
            {
                if (senas.Imti().IšleidimoMetai() > paskutine.IšleidimoMetai())
                {
                    DetiA(senas.Imti());
                }
            }
        }

        public void Perkelti()
        {
            Knyga seniausia = SeniausiaKnyga();
            //Console.Write(seniausia + "\n");

            Mazgas ankstesnis = pr;
            for (Mazgas d = pr.Kitas; d.Kitas != null && d.Duomenys != seniausia; d = d.Kitas)
            {
                ankstesnis = d;
            }

            if (pbt.Duomenys == ankstesnis.Kitas.Duomenys)
            {
                pbt = ankstesnis;
            }

            ankstesnis.Kitas = ankstesnis.Kitas.Kitas;

            pbt.Kitas = new Mazgas(seniausia, pbt.Kitas);
            pbt = pbt.Kitas;
        }

        private Knyga SeniausiaKnyga()
        {
            Knyga seniausia = new Knyga("", "", int.MaxValue);

            for (Mazgas d = pr.Kitas; d.Kitas != null; d = d.Kitas)
            {
                if (d.Duomenys.IšleidimoMetai() <= seniausia.IšleidimoMetai())
                {
                    seniausia = d.Duomenys;
                }
            }

            return seniausia;
        }
    }

    class Program
    {
        const string duom = "..\\..\\Knygos.txt";

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.GetEncoding(1257);
            Console.OutputEncoding = Encoding.Unicode;

            Sąrašas A = new Sąrašas();
            Skaityti(duom, A);
            Spausdinti(A, "Pradiniai duomenys:");

            string pasalinti = "Pavardenis2 Vardenis2";
            Console.Write("Įveskite, kurio autoriaus daugiausiai puslapių turinčią knygą norite pašalinti: ");
            pasalinti = Console.ReadLine();
            A.Trinti(pasalinti);
            Spausdinti(A, $"Pašalinta pasirinkto autoriaus ({pasalinti}) daugiausiai puslapių turinti knyga:");

            /* Testavimui
            A.DetiA(new Knyga("Pavardenis2 Vardenis2", "Nauja", 2018, 210));
            A.DetiT(new Knyga("Pavardenis2 Vardenis2", "Nauja2", 2018, 210));
            A.DetiA(new Knyga("Pavardenis2 Vardenis2", "Nauja3", 2018, 210));
            A.DetiT(new Knyga("Pavardenis2 Vardenis2", "Nauja4", 2018, 210));
            Spausdinti(A, $"Nauja knyga:");
            */

            Sąrašas B = new Sąrašas();
            B.Formuoti(A);
            Spausdinti(B, "Naujas sąrašas iš knygų, kurių išleidimo metai vėlesni už paskutinės sąrašo knygos išleidimo metus:");

            /* Testavimui
            B.DetiA(new Knyga("Pavardenis2 Vardenis2", "Nauja", 2018, 210));
            B.DetiT(new Knyga("Pavardenis2 Vardenis2", "Nauja2", 2018, 210));
            B.DetiA(new Knyga("Pavardenis2 Vardenis2", "Nauja3", 2018, 210));
            B.DetiT(new Knyga("Pavardenis2 Vardenis2", "Nauja4", 2018, 210));
            Spausdinti(B, $"Nauja knyga:");
            */

            if (!B.isEmpty())
            {
                B.Perkelti();
                Spausdinti(B, "Seniausios naujo sąrašo knygos perkėlimas į pabaigą:");
            }
            else
            {
                Console.WriteLine("Sąrašas tuščias. Seniausios naujo sąrašo knygos perkėlimas negalimas.");
            }

            Console.WriteLine("Programa baigė darbą!");
        }

        static void Skaityti(string failas, Sąrašas konteineris)
        {
            using (StreamReader reader = new StreamReader(failas))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    konteineris.DetiT(new Knyga(parts[0].Trim(), parts[1].Trim(), int.Parse(parts[2].Trim()), int.Parse(parts[3].Trim())));
                }
            }
        }

        static void Spausdinti(Sąrašas konteineris, string antraste)
        {
            Console.WriteLine(antraste);
            if (!konteineris.isEmpty())
            {
                const string virsus = "-------------------------------------------------------------------------------------\r\n" +
                                      " Vardas Pavardė           Knygos pavadinimas     Išleidimo metai     Puslapių kiekis \r\n" + 
                                      "-------------------------------------------------------------------------------------";

                Console.WriteLine(virsus);
                for (konteineris.Pradžia(); konteineris.Yra(); konteineris.Kitas())
                {
                    Console.WriteLine(konteineris.Imti());
                }

                Console.WriteLine("-------------------------------------------------------------------------------------\r\n");
            }
            else
            {
                Console.WriteLine("Sąrašas tuščias!\r\n");
            }
        }
    }
}
