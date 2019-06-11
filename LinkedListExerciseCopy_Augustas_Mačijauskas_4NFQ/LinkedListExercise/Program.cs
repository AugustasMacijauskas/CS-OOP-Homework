using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LinkedListExercise
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
            eilute = string.Format("|{0, -30}| {1, -20} | {2, 8:f}     |", Modelis, Tipas, Baterija);
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

    public sealed class StudentsDevices
    {
        public string VardasPavardė { get; set; }

        private Node first; // sąrašo pradžia
        private Node last; // sąrašo pabaiga
        private Node link; // sąrašo sąsaja
        private Node insertionHelper; // sąrašo sąsaja

        // Konstruktorius: sukuriami du fiktyvūs elementai
        public StudentsDevices(){
            this.last = new Node(null, null);
            this.first = new Node(null, last);
            this.insertionHelper = first;
            this.link = null;
        }

        public void Pradžia()
        {
            link = first.Kitas;
        }

        public void Kitas()
        {
            link = link.Kitas;
        }

        public bool isEmpty()
        {
            return link.Kitas == null;
        }

        public Mobilus ImtiDuomenis()
        {
            return link.Duomenys;
        }

        public void Papildyti(Mobilus duom)
        {
            insertionHelper.Kitas = new Node(duom, last);
            insertionHelper = insertionHelper.Kitas;
        }

        public void Naikinti()
        {
            while (first.Kitas != null)
            {
                link = first.Kitas;
                first.Kitas.Duomenys = null;
                first.Kitas = first.Kitas.Kitas;
                link = null;
            }
            first.Kitas = link = null;
        }

        public void RikiuotiMinMax()
        {
            for (Node d1 = first.Kitas; d1.Kitas != null; d1 = d1.Kitas)
            {
                Node maxValue = d1;
                for (Node d2 = d1; d2.Kitas != null; d2 = d2.Kitas)
                {
                    if (d2.Duomenys <= maxValue.Duomenys)
                    {
                        maxValue = d2;
                    }
                }

                Mobilus temp = d1.Duomenys;
                d1.Duomenys = maxValue.Duomenys;
                maxValue.Duomenys = temp;
            }
        }

        public void RikiuotiBurbuliukas()
        {
            bool switchHappened = true;
            Node temp1, temp2;
            while(switchHappened)
            {
                switchHappened = false;
                temp1 = temp2 = first.Kitas;
                while (temp2.Kitas != null)
                {
                    if (temp1.Duomenys > temp2.Duomenys)
                    {
                        switchHappened = true;
                        Mobilus temp = temp1.Duomenys;
                        temp1.Duomenys = temp2.Duomenys;
                        temp2.Duomenys = temp;
                    }

                    temp1 = temp2;
                    temp2 = temp2.Kitas;
                }
            }
        }

        public Mobilus MaxTrukmė() {
            Mobilus max;
            max = first.Kitas.Duomenys;
            for (Node d1 = first.Kitas; d1 != last; d1 = d1.Kitas)
            {
                if (d1.Duomenys > max)
                {
                    max = d1.Duomenys;
                }
            }

            return max;
        }

        private Node Vieta(Mobilus duom)
        {
            Node dd = first.Kitas;
            while (dd != null && dd.Kitas != last && duom >= dd.Kitas.Duomenys)
                dd = dd.Kitas;

            return dd;
        }

        // Suranda vietą, kurioje reikia įterpti naują elementą ir įterpia
        // duom – objektas papildymui
        public void Įterpti(Mobilus duom) {
            // jei sąrašas tuščias
            if (first.Kitas == last)
            {
                first.Kitas = new Node(duom, last);
            }
            else
            {
                // jeigu elementą reikia įterpti sąraše
                // randama įterpimo vieta – elementas, už kurio reikia įterpti
                Node dd = Vieta(duom);
                // naujas elementas įterpiamas už surasto elemento
                dd.Kitas = new Node(duom, dd.Kitas);
            }
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
            StudentsDevices A; // pirmojo studento duomenys
            StudentsDevices B; // antrojo studento duomenys
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
                failas.WriteLine("StudentsDevices: {0}, ilgiausiai veikianti baterija \r\nModelis: " +
                    "{1}, tipas: {2}, trukmė: {3}.",
                    A.VardasPavardė, max.Modelis, max.Tipas, max.Baterija);

                failas.WriteLine();
                max = B.MaxTrukmė();
                failas.WriteLine("StudentsDevices: {0}, ilgiausiai veikianti baterija \r\nModelis: " +
                    " {1}, tipas: {2}, trukmė: {3}.", 
                    B.VardasPavardė, max.Modelis, max.Tipas, max.Baterija);
            }

            StudentsDevices Naujas = new StudentsDevices();
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
                Spausdinti(CFr, Naujas, "\nAtrinkti nerikiuoti (" + tipas + ")");
                Naujas.RikiuotiMinMax();
                Spausdinti(CFr, Naujas, "\nAtrinkti surikiuoti (" + tipas + ")");
            }
            else
            {
                using (var failas = new StreamWriter(CFr, true))
                {
                    failas.WriteLine("\r\n(" + tipas + ")\r\nNaujas sąrašas nesudarytas.\r\n");
                }
            }

            StudentsDevices C; // trečio studento duomenys
            C = Skaityti(CFd3);
            Spausdinti(CFr, C, C.VardasPavardė);
            Įterpti(C, tipas, Naujas);
            Naujas.Pradžia();
            if (!Naujas.isEmpty())
                Spausdinti(CFr, Naujas, "Rikiuotas po papildymo");
            else
                using (var failas = new StreamWriter(CFr, true))
                {
                    failas.WriteLine("\r\n(" + tipas + ")\r\nNaujas sąrašas liko nesudarytas.\r\n");
                }

            C.Naikinti();
            if (!Naujas.isEmpty())
                Spausdinti(CFr, Naujas, "Sąrašas po sunaikinomo.");
            else
                using (var failas = new StreamWriter(CFr, true))
                {
                    failas.WriteLine("Naujas sąrašas sunaikintas.\r\n");
                }
        }

        static void Įterpti(StudentsDevices senas, string tipas, StudentsDevices naujas)
        {
            for (senas.Pradžia(); !senas.isEmpty(); senas.Kitas())
            {
                Mobilus duom = senas.ImtiDuomenis();
                if (duom.Tipas == tipas)
                {
                    naujas.Įterpti(duom);
                }
            }
        }

        static void Atrinkti(StudentsDevices senas, string tipas, StudentsDevices naujas)
        {
            for (senas.Pradžia(); !senas.isEmpty(); senas.Kitas())
            {
                Mobilus duom = senas.ImtiDuomenis();
                if (duom.Tipas == tipas)
                {
                    naujas.Papildyti(duom);
                }
            }
        }

        static StudentsDevices Skaityti(string fv) {
            var A = new StudentsDevices();
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

        static void Spausdinti(string fv, StudentsDevices A, string koment)
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
