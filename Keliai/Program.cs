using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Keliai
{
    class Kelias
    {
        string kelias;
        double ilgis;
        double greitis;

        public Kelias(string kelias, double ilgis, double greitis)
        {
            this.kelias = kelias;
            this.ilgis = ilgis;
            this.greitis = greitis;
        }

        public string koksKelias() { return kelias; }

        public double koksIlgis() { return ilgis; }

        public double koksGreitis() { return greitis; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            const string duom = "...\\...\\duom.txt";
            const string rez = "...\\...\\rez.txt";
            int kiek;

            List<Kelias> keliai= new List<Kelias>();

            if (File.Exists(rez))
                File.Delete(rez);

            skaitymas(duom, keliai, out kiek);
            spausdinimas(rez, keliai, kiek);

            Console.WriteLine("Programa baige darba");
        }

        static void skaitymas(string duom, List<Kelias> keliai, out int kiek)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string kelias;
                double ilgis, greitis;
                string line;
                string[] skaidymas;
                line = reader.ReadLine();
                kiek = int.Parse(line);

                if (kiek >= 5 && kiek <= 500)
                {
                    for (int i = 0; i < kiek; i++)
                    {
                        line = reader.ReadLine();
                        skaidymas = line.Split(';');
                        kelias = skaidymas[0];
                        ilgis = double.Parse(skaidymas[1]);
                        greitis = double.Parse(skaidymas[2]);
                        keliai.Add(new Kelias(kelias, ilgis, greitis));
                    }
                }
            }
        }

        static void spausdinimas(string rez, List<Kelias> keliai, int kiek)
        {
            const string virsus =
               "|------------------------------------------------------------------|-----------------|---------------------|\r\n"
             + "|                                                                  |                 |                     |\r\n"
             + "|                        Kelio pavadinimas                         |   Kelio ilgis   |  Maksimalus greitis |\r\n"
             + "|                                                                  |                 |                     |\r\n"
             + "|------------------------------------------------------------------|-----------------|---------------------|";

            using (var prideti = File.AppendText(rez))
            {
                if (kiek >= 5 && kiek <= 500)
                {
                    prideti.WriteLine("Keliu kiekis: {0}", kiek);
                    prideti.WriteLine("Keliu sarasas:");
                    prideti.WriteLine(virsus);
                    Kelias laikinas;

                    for (int i = 0; i < keliai.Count; i++)
                    {
                        laikinas = keliai[i];
                        prideti.WriteLine("| {0, -64} |      {1,5:f}      |        {2,5:f}        |", laikinas.koksKelias(), laikinas.koksIlgis(), laikinas.koksGreitis());
                    }
                    prideti.WriteLine("------------------------------------------------------------------------------------------------------------");
                }
                else
                {
                    prideti.WriteLine("Netinkamas kiekis duomenu");
                }
            }
        }
    }
}
