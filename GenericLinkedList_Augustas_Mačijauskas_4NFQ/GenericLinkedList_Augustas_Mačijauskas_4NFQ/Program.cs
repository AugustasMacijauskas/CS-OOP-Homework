using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GenericLinkedList_Augustas_Mačijauskas_4NFQ
{
    public class Mobilus
    {
        public string Modelis { get; set; } // modelio pavadinimas
        public string Tipas { get; set; } // įrenginio tipas
        public int Baterija { get; set; } // baterijos veikimo trukmė

        public Mobilus(string modelis = "", string tipas = "", int baterija = 0)
        {
            this.Modelis = modelis;
            this.Tipas = tipas;
            this.Baterija = baterija;
        }

        public void Dėti(string modelis, string tipas, int baterija)
        {
            this.Modelis = modelis;
            this.Tipas = tipas;
            this.Baterija = baterija;
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("| {0, -29}| {1, -20} | {2, 8:f}     |", Modelis, Tipas, Baterija);
            return eilute;
        }

        public override bool Equals(object objektas)
        {
            Mobilus telef = objektas as Mobilus;
            return telef.Tipas == Tipas && telef.Modelis == Modelis && telef.Baterija == Baterija;
        }

        // Užklotas metodas GetHashCode()
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Užklotas operatorius >= (dviejų įrenginių palyginimui pagal baterijos veikimo trukmę // ir modelio pavadinimą)
        public static bool operator >=(Mobilus pirmas, Mobilus antras)
        {
            int poz = String.Compare(pirmas.Modelis, antras.Modelis, StringComparison.CurrentCulture);

            return pirmas.Baterija > antras.Baterija || pirmas.Baterija == antras.Baterija && poz > 0;
        }

        // Užklotas operatorius <= (dviejų įrenginių palyginimui pagal baterijos veikimo trukmę // ir modelio pavadinimą)
        public static bool operator <=(Mobilus pirmas, Mobilus antras)
        {
            int poz = String.Compare(pirmas.Modelis, antras.Modelis, StringComparison.CurrentCulture);

            return pirmas.Baterija < antras.Baterija || pirmas.Baterija == antras.Baterija && poz < 0;
        }

        // Užklotas operatorius == (įrenginių tipui palyginti)
        public static bool operator ==(Mobilus pirmas, Mobilus antras)
        {
            return pirmas.Tipas == antras.Tipas;
        }

        // Užklotas operatorius != (įrenginių tipui palyginti)
        public static bool operator !=(Mobilus pirmas, Mobilus antras)
        {
            return pirmas.Tipas != antras.Tipas;
        }

        // Užklotas operatorius > (dviejų įrenginių palyginimui pagal baterijos veikimo trukmę)
        public static bool operator >(Mobilus pirmas, Mobilus antras)
        {
            return pirmas.Baterija > antras.Baterija;
        }

        // Užklotas operatorius < (dviejų įrenginių palyginimui pagal baterijos veikimo trukmę)
        public static bool operator <(Mobilus pirmas, Mobilus antras)
        {
            return pirmas.Baterija < antras.Baterija;
        }
    }

    class Program
    {
        const string CFd1 = "..\\..\\Mikas.txt";
        const string CFd2 = "..\\..\\Darius.txt";
        const string CFd3 = "..\\..\\Rimas.txt";
        const string CFr = "..\\..\\Rezultatai.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1257);
            string[] Vardai = new string[3];
            LinkedList<Mobilus> A = new LinkedList<Mobilus>();
            LinkedList<Mobilus> B = new LinkedList<Mobilus>();
            SkaitytiAtv(CFd1, 0, Vardai, A);
            SkaitytiAtv(CFd2, 1, Vardai, B);

            if (File.Exists(CFr))
            {
                File.Delete(CFr);
            }

            Spausdinti(CFr, A, Vardai[0]);
            Spausdinti(CFr, B, Vardai[1]);

            using (var failas = new StreamWriter(CFr, true))
            {
                Mobilus max;
                max = MaxTrukmė(A);
                failas.WriteLine("Studentas: {0}, ilgiausiai veikianti baterija \r\n" + " modelis: {1}, tipas: {2}, trukmė: {3}.",
                    Vardai[0],
                    max.Modelis,
                    max.Tipas,
                    max.Baterija);
                failas.WriteLine();
                max = MaxTrukmė(B);
                failas.WriteLine("Studentas: {0}, ilgiausiai veikianti baterija \r\n" + " modelis: {1}, tipas: {2}, trukmė: {3}.",
                    Vardai[1],
                    max.Modelis,
                    max.Tipas,
                    max.Baterija);
            }
            // --- Nurodyto tipo įrenginių atrinkimas --- 
            LinkedList<Mobilus> Naujas = new LinkedList<Mobilus>(); // atrinkti duomenys
            Console.Write("Įveskite norimą įrenginio tipą: ");
            string tipas = Console.ReadLine(); // Įvedamas norimas įrenginio tipas
            Atrinkti(A, tipas, Naujas);
            Atrinkti(B, tipas, Naujas);
            // --- Suformuoto sąrašo spausdinimas ir rikiavimas ---
            if (Naujas.Count > 0)
            {
                Spausdinti(CFr, Naujas, "Atrinkti nerikiuoti");
                // -Suformuoto sąrašo rikiavimas
                Naujas = new LinkedList<Mobilus>(Naujas.OrderBy(p => p.Baterija).ThenBy(p => p.Modelis));
                Spausdinti(CFr, Naujas, "Atrinkti surikiuoti");
            }
            else
            {
                using (var failas = new StreamWriter(CFr, true))
                {
                    failas.WriteLine("\r\nNaujas sąrašas nesudarytas.\r\n");
                }
            }
            LinkedList<Mobilus> C = new LinkedList<Mobilus>(); // trečio studento duomenys
            SkaitytiAtv(CFd3, 2, Vardai, C);
            Spausdinti(CFr, C, Vardai[2]);
            Atrinkti_Į_Rikiuotą(C, tipas, Naujas);
            if (Naujas.Count() > 0)
            {
                Spausdinti(CFr, Naujas, "Rikiuotas po papildymo");
            }
            else
            {
                using (var failas = new StreamWriter(CFr, true))
                {
                    failas.WriteLine("Naujas sąrašas liko nesudarytas.");
                }
            }

            Console.WriteLine("Programa baigė darbą!");
        }

        // Skaitomi duomenys iš failo ir sudedami į sąrašą ATVIRKŠČIA tvarka
        // fv – duomenų failo vardas
        // vardo numeris Vardai masyve
        static void SkaitytiAtv(string fv, int indeksas, string[] Vardai, LinkedList<Mobilus> A) {
            using (var failas = new StreamReader(fv))
            {
                string eilute;
                Vardai[indeksas] = eilute = failas.ReadLine();
                while ((eilute = failas.ReadLine()) != null)
                {
                    string[] eilDalis = eilute.Split(';');
                    string modelis = eilDalis[0];
                    string tipas = eilDalis[1];
                    int baterija = int.Parse(eilDalis[2]);
                    Mobilus elem = new Mobilus(modelis, tipas, baterija);
                    A.AddFirst(elem);
                }
            }
        }

        // Sąrašo duomenys spausdinami faile
        // fv – duomenų failo vardas
        // A - sąrašo objekto nuoroda
        // koment - komentaras
        static void Spausdinti(string fv, LinkedList<Mobilus> A, string koment)
        {
            using (var failas = new StreamWriter(fv, true))
            {
                failas.WriteLine(koment);
                failas.WriteLine("+------------------------------+---------------" + "-------+--------------+");
                failas.WriteLine("| Modelis                      | Tipas " + "               | Veik. trukmė |");
                failas.WriteLine("+------------------------------+---------------" + "-------+--------------+");
                // Sąrašo peržiūra, panaudojant sąsajos metodus
                foreach (Mobilus elem in A)
                {
                    failas.WriteLine("{0}", elem.ToString());
                }
                failas.WriteLine("+------------------------------+---------------" + "-------+--------------+\r\n");
            }
        }

        // Suranda ir grąžina ilgiausiai veikiančio įrenginio duomenis
        static Mobilus MaxTrukmė(LinkedList<Mobilus> A)
        {
            Mobilus max;
            max = A.First();
            foreach (Mobilus elem in A)
            {
                if (elem > max)
                {
                    max = elem;
                }
            }

            return max;
        }

        // Iš sąrašo senas kopijuoja objektus į sąrašą naujas
        // senas įrenginių sąrašas
        // tipas atrenkamų įrenginių tipas
        // naujas naujo objektų sąrašo adresas
        static void Atrinkti(LinkedList<Mobilus> senas, string tipas, LinkedList<Mobilus> naujas)
        {
            foreach (Mobilus elem in senas)
            {
                if (elem.Tipas == tipas)
                {
                    naujas.AddLast(elem);
                }
            }
        }

        // Iš sąrašo senas kopijuoja objektus į sąrašą naujas
        // senas įrenginių sąrašas
        // tipas atrenkamų įrenginių tipas
        // naujas naujo objektų sąrašo adresas
        static void Atrinkti_Į_Rikiuotą(LinkedList<Mobilus> senas, string tipas, LinkedList<Mobilus> naujas)
        {
            foreach (Mobilus elem in senas)
            {
                if (elem.Tipas == tipas)
                {
                    Mobilus pagalb = Vieta(naujas, elem);
                    if (pagalb.Baterija == -1)
                    {
                        naujas.AddFirst(elem);
                    }
                    else
                    {
                        LinkedListNode<Mobilus> mazgas = naujas.Find(pagalb);
                        naujas.AddAfter(mazgas, elem);
                    }
                }
            }
        }

        // Ieškoma naujo elemento įterpimo vieta.
        // Vieta objektui elementas ieškoma, naudojantis sukurtu operatoriumi
        // sar – susietas sąrašas
        // elementas – objektas
        static Mobilus Vieta(LinkedList<Mobilus> sar, Mobilus elementas)
        {
            Mobilus rastasElem = new Mobilus();
            rastasElem.Baterija = -1;
            foreach (Mobilus elem in sar)
            {
                if (elem <= elementas)
                {
                    rastasElem = elem;
                }
                if (elementas >= elem)
                {
                    break;
                }
            }

            return rastasElem;
        }
    }
}
