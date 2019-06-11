using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LinkedListExercise
{
    public sealed class Node
    {
        public Mobilus Duomenys { get; set; }
        public Node Kitas { get; set; }

        public Node() { }

        public Node(Mobilus duomenys, Node adresas)
        {
            this.Duomenys = duomenys;
            this.Kitas = adresas;
        }
    }

    public sealed class Studentas
    {
        public string VardasPavardė { get; set; }
        Node start;
        Node link;

        public Studentas()
        {
            this.start = null;
            this.link = null;
        }

        public void Pradžia()
        {
            link = start;
        }

        public void Kitas()
        {
            link = link.Kitas;
        }

        public bool isEmpty()
        {
            return link == null;
        }

        public Mobilus ImtiDuomenis()
        {
            return link.Duomenys;
        }

        public void Papildyti(Mobilus duom)
        {
            Node d1 = new Node();
            d1.Duomenys = duom;
            d1.Kitas = start;
            start = d1;
        }

        public void Naikinti()
        {
            while (start != null)
            {
                link = start;
                start.Duomenys = null;
                start = start.Kitas;
                link = null;
            }
            start = link;
        }

        public void Rikiuoti()
        {
            for (Node d1 = start; d1.Kitas != null; d1 = d1.Kitas)
            {
                Node maxValue = d1;
                for (Node d2 = d1; d2 != null; d2 = d2.Kitas)
                {
                    if (d2.Duomenys <= maxValue.Duomenys)
                    {
                        maxValue = d2;
                    }
                }

                Mobilus St = d1.Duomenys;
                d1.Duomenys = maxValue.Duomenys;
                maxValue.Duomenys = St;
            }
        }

        public Mobilus MaxTrukmė() {
            Mobilus max;
            max = start.Duomenys;
            for (Node d1 = start; d1 != null; d1 = d1.Kitas)
                if (d1.Duomenys > max)
                {
                    max = d1.Duomenys;
                }

            return max;
        }

        private Node Vieta(Mobilus duom)
        {
            Node dd = start;
            while (dd != null && dd.Kitas != null && duom >= dd.Kitas.Duomenys)
                dd = dd.Kitas;

            return dd;
        }

        // Suranda vietą, kurioje reikia įterpti naują elementą ir įterpia
        // duom – objektas papildymui
        public void Įterpti(Mobilus duom) {
            Node d = new Node();
            d.Duomenys = duom;
            d.Kitas = null;

            // jei sąrašas tuščias
            if (start == null)
            {
                start = d;
            }
            else if (start.Duomenys >= duom)
            {
                // jeigu elementą reikia sukurti sąrašo pradžioje
                d.Kitas = start;
                start = d;
            }
            else
            {
                // jeigu elementą reikia įterpti sąraše
                // randama įterpimo vieta – elementas, už kurio reikia įterpti
                Node dd = Vieta(duom);
                d.Kitas = dd.Kitas;
                // naujas elementas įterpiamas už surasto elemento
                dd.Kitas = d;
            }
        }
    }

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

        public void Dėti(string modelis, string tipas, int baterija) {
            this.Modelis = modelis;
            this.Tipas = tipas;
            this.Baterija = baterija;
        }

        public override string ToString() {
            string eilute;
            eilute = string.Format("|{0, -30}| {1, -20} | {2, 8:f}     |", Modelis, Tipas, Baterija);
            return eilute;
        }

        public override bool Equals(object objektas) { 
            Mobilus telef = objektas as Mobilus;
            return telef.Tipas == Tipas && telef.Modelis == Modelis && telef.Baterija == Baterija;
        }

        // Užklotas metodas GetHashCode()
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        // Užklotas operatorius >= (dviejų įrenginių palyginimui pagal baterijos veikimo trukmę // ir modelio pavadinimą)
        public static bool operator >=(Mobilus pirmas, Mobilus antras) {
            int poz = String.Compare(pirmas.Modelis, antras.Modelis, StringComparison.CurrentCulture);

            return pirmas.Baterija > antras.Baterija || pirmas.Baterija == antras.Baterija && poz > 0;
        }

        // Užklotas operatorius <= (dviejų įrenginių palyginimui pagal baterijos veikimo trukmę // ir modelio pavadinimą)
        public static bool operator <=(Mobilus pirmas, Mobilus antras) {
            int poz = String.Compare(pirmas.Modelis, antras.Modelis, StringComparison.CurrentCulture);

            return pirmas.Baterija < antras.Baterija || pirmas.Baterija == antras.Baterija && poz < 0;
        }

        // Užklotas operatorius == (įrenginių tipui palyginti)
        public static bool operator ==(Mobilus pirmas, Mobilus antras) {
            return pirmas.Tipas == antras.Tipas;
        }

        // Užklotas operatorius != (įrenginių tipui palyginti)
        public static bool operator !=(Mobilus pirmas, Mobilus antras) {
            return pirmas.Tipas != antras.Tipas;
        }

        // Užklotas operatorius > (dviejų įrenginių palyginimui pagal baterijos veikimo trukmę)
        public static bool operator >(Mobilus pirmas, Mobilus antras) {
            return pirmas.Baterija > antras.Baterija;
        }

        // Užklotas operatorius < (dviejų įrenginių palyginimui pagal baterijos veikimo trukmę)
        public static bool operator <(Mobilus pirmas, Mobilus antras) {
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
            Studentas A; // pirmojo studento duomenys
            Studentas B; // antrojo studento duomenys
            A = Skaityti(CFd1);
            B = Skaityti(CFd2);
            if (File.Exists(CFr))
                File.Delete(CFr);

            Spausdinti(CFr, A, A.VardasPavardė);
            Spausdinti(CFr, B, B.VardasPavardė);
            using (var failas = new StreamWriter(CFr, true))
            {
                Mobilus max;
                max = A.MaxTrukmė();
                failas.WriteLine("Studentas: {0}, ilgiausiai veikianti baterija \r\nModelis: " +
                    "{1}, tipas: {2}, trukmė: {3}.",
                    A.VardasPavardė, max.Modelis, max.Tipas, max.Baterija);

                failas.WriteLine();
                max = B.MaxTrukmė();
                failas.WriteLine("Studentas: {0}, ilgiausiai veikianti baterija \r\nModelis: " +
                    " {1}, tipas: {2}, trukmė: {3}.", 
                    B.VardasPavardė, max.Modelis, max.Tipas, max.Baterija);
            }

            Studentas Naujas = new Studentas();
            // atrinkti duomenys
            Console.WriteLine("Įveskite norimą įrenginio tipą:");
            string tipas = Console.ReadLine();
            // Įvedamas norimas įrenginio tipas
            Atrinkti(A, tipas, Naujas);
            Atrinkti(B, tipas, Naujas);
            // --- Suformuoto sąrašo spausdinimas ir rikiavimas ---
            Naujas.Pradžia();
            if (!Naujas.isEmpty())
            {
                Spausdinti(CFr, Naujas, "\nAtrinkti nerikiuoti");
                Naujas.Rikiuoti();
                Spausdinti(CFr, Naujas, "\nAtrinkti surikiuoti");
            }
            else
            {
                using (var failas = new StreamWriter(CFr, true))
                {
                    failas.WriteLine("Naujas sąrašas nesudarytas.");
                }
            }

            Studentas C; // trečio studento duomenys
            C = Skaityti(CFd3);
            Spausdinti(CFr, C, C.VardasPavardė);
            Įterpti(C, tipas, Naujas);
            Naujas.Pradžia();
            if (!Naujas.isEmpty())
                Spausdinti(CFr, Naujas, "Rikiuotas po papildymo");
            else
                using (var failas = new StreamWriter(CFr, true))
                {
                    failas.WriteLine("Naujas sąrašas liko nesudarytas.");
                }

            C.Naikinti();
            if (!Naujas.isEmpty())
                Spausdinti(CFr, Naujas, "Rikiuotas po papildymo");
            else
                using (var failas = new StreamWriter(CFr, true))
                {
                    failas.WriteLine("Naujas sąrašas sunaikintas.");
                }
        }

        static void Įterpti(Studentas senas, string tipas, Studentas naujas)
        {
            for (senas.Pradžia(); !senas.isEmpty(); senas.Kitas())
            {
                Mobilus duom = senas.ImtiDuomenis();
                if (duom.Tipas == tipas) naujas.Įterpti(duom);
            }
        }

        static void Atrinkti(Studentas senas, string tipas, Studentas naujas)
        {
            for (senas.Pradžia(); !senas.isEmpty(); senas.Kitas())
            {
                Mobilus duom = senas.ImtiDuomenis();
                if (duom.Tipas == tipas)
                    naujas.Papildyti(duom);
            }
        }

        static Studentas Skaityti(string fv) {
            var A = new Studentas();
            using (var failas = new StreamReader(fv))
            {
                string eilute;

                A.VardasPavardė = eilute = failas.ReadLine();
                while ((eilute = failas.ReadLine()) != null)
                {
                    string[] eilDalis = eilute.Split(';');
                    string modelis = eilDalis[0];
                    string tipas = eilDalis[1];
                    int baterija = int.Parse(eilDalis[2]);
                    Mobilus elem = new Mobilus(modelis, tipas, baterija);
                    A.Papildyti(elem);
                }
            }
            return A;
        }

        static void Spausdinti(string fv, Studentas A, string koment)
        {
            using (var failas = new StreamWriter(fv, true))
            {
                failas.WriteLine(koment);
                failas.WriteLine("+------------------------------+---------------" + "-------+--------------+");
                failas.WriteLine("|           Modelis            |      Tipas    " + "       | Veik. trukmė |");
                failas.WriteLine("+------------------------------+---------------" + "-------+--------------+");
                
                // Sąrašo peržiūra, panaudojant sąsajos metodus
                for (A.Pradžia(); !A.isEmpty(); A.Kitas())
                {
                    failas.WriteLine("{0}", A.ImtiDuomenis().ToString());
                }

                failas.WriteLine("+------------------------------+---------------" + "-------+--------------+\r\n");
            }
        }
    }
}
