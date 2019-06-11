using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LD_2_Krepsinis_Augustas_Macijauskas
{
    class Krepsininkas
    {
        private string vp;
        private int amzius;
        private double ugis;

        public Krepsininkas(string vp, int amzius, double ugis)
        {
            this.vp = vp;
            this.amzius = amzius;
            this.ugis = ugis;
        }

        public string GautiVarda() { return vp; }

        public int GautiAmziu() { return amzius; }

        public double GautiUgi() { return ugis; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            const int maxDuom = 500;
            const string duom1 = "...\\...\\duom3.txt";
            const string duom2 = "...\\...\\duom4.txt";
            const string rez = "...\\...\\rez.txt";
            const string virsus = "|----------------------------------------------------------------|\r\n" +
                                  "|                                        |          |            |\r\n" +
                                  "|              Krepšininkas              |  Amžius  |    Ūgis    |\r\n" +
                                  "|                                        |          |            |\r\n" +
                                  "|----------------------------------------------------------------|";

            Krepsininkas[] pirma = new Krepsininkas[maxDuom];
            Krepsininkas[] antra = new Krepsininkas[maxDuom];
            Krepsininkas[] auksciausi = new Krepsininkas[maxDuom];
            Krepsininkas[] filtras = new Krepsininkas[maxDuom];
            string pav1, pav2;
            int n1, n2;

            skaitymas(duom1, pirma, out pav1, out n1);
            skaitymas(duom2, antra, out pav2, out n2);

            if (File.Exists(rez))
                File.Delete(rez);

            Spausdinimas(rez, pirma, n1, pav1, virsus);
            Spausdinimas(rez, antra, n2, pav2, virsus);

            //Darbas su amziumi
            double amziausVidurkis1, amziausVidurkis2, bendrasAmziausVidurkis;
            amziausVidurkis1 = amziausVidurkis(pirma, n1);
            amziausVidurkis2 = amziausVidurkis(antra, n2);
            bendrasAmziausVidurkis = (amziausVidurkis1 + amziausVidurkis2) / 2;
            pridetiTeksto(rez, "Krepsininku amziaus vidurkis:");
            spausdintiVidurkius(rez, pav1, amziausVidurkis1, "metu(-ai)");
            spausdintiVidurkius(rez, pav2, amziausVidurkis2, "metu(-ai)");
            pridetiTeksto(rez, "");
            spausdintiVidurkius(rez, "Bendras", bendrasAmziausVidurkis, "metu(-ai)");
            pridetiTeksto(rez, "");

            //Darbas su ugiais
            double ugioVidurkis1, ugioVidurkis2, bendrasUgioVidurkis;
            ugioVidurkis1 = ugioVidurkis(pirma, n1);
            ugioVidurkis2 = ugioVidurkis(antra, n2);
            bendrasUgioVidurkis = (ugioVidurkis1 + ugioVidurkis2) / 2;
            pridetiTeksto(rez, "Krepsininku ugio vidurkis:");
            spausdintiVidurkius(rez, pav1, ugioVidurkis1, "m");
            spausdintiVidurkius(rez, pav2, ugioVidurkis2, "m");
            pridetiTeksto(rez, "");
            spausdintiVidurkius(rez, "Bendras", bendrasUgioVidurkis, "m");
            pridetiTeksto(rez, "");

            //Auksciausio ieskojimas
            double auksciausias1, auksciausias2;
            auksciausias1 = rastiAuksciausia(pirma, n1);
            auksciausias2 = rastiAuksciausia(antra, n2);

            pridetiTeksto(rez, "Auksciausias sportininkas mokosi:");
            if (auksciausias1 == auksciausias2)
            {
                spausdintiAuksciausius(rez, pirma, n1, auksciausias1, pav1);
                spausdintiAuksciausius(rez, antra, n2, auksciausias2, pav2);
            }
            else if (auksciausias1 > auksciausias2)
            {
                spausdintiAuksciausius(rez, pirma, n1, auksciausias1, pav1);
            }
            else
            {
                spausdintiAuksciausius(rez, antra, n2, auksciausias2, pav2);
            }
            pridetiTeksto(rez, "");

            //Ugis didesnis uz vidurki
            int kiekis = 0;
            pridetiTeksto(rez, "Naujas rinkinys (krepsininkai, kuriu ugis didesnis uz vidurki):");
            ugisDidesnisUzVidurki(pirma, auksciausi, n1, kiekis, ref kiekis, bendrasUgioVidurkis);
            ugisDidesnisUzVidurki(antra, auksciausi, n2, kiekis, ref kiekis, bendrasUgioVidurkis);
            Spausdinimas(rez, auksciausi, kiekis, "", virsus);

            //Jauniausi krepsininkai
            int jauniausias1, jauniausias2;
            jauniausias1 = jauniausioAmzius(pirma, n1);
            jauniausias2 = jauniausioAmzius(antra, n2);
            int sk = 0;
            pridetiTeksto(rez, "Jauniausi krepsininkai:");
            if (jauniausias1 == jauniausias2)
            {
                pridetiTeksto(rez, "Krepsininkai, kuriu amzius yra " + jauniausias1 + " m.");
                rastiJauniausius(pirma, n1, filtras, ref sk, jauniausias1);
                Spausdinimas(rez, filtras, sk, pav1, virsus);
                sk = 0;
                rastiJauniausius(antra, n2, filtras, ref sk, jauniausias2);
                Spausdinimas(rez, filtras, sk, pav2, virsus);
            }
            else if (jauniausias1 < jauniausias2)
            {
                pridetiTeksto(rez, "Krepsininkai, kuriu amzius yra " + jauniausias1 + " m.");
                rastiJauniausius(pirma, n1, filtras, ref sk, jauniausias1);
                Spausdinimas(rez, filtras, sk, pav1, virsus);
            }
            else if (jauniausias2 < jauniausias1)
            {
                pridetiTeksto(rez, "Krepsininkai, kuriu amzius yra " + jauniausias2 + " m.");
                rastiJauniausius(antra, n2, filtras, ref sk, jauniausias2);
                Spausdinimas(rez, filtras, sk, pav2, virsus);
            }

            Console.WriteLine("Programa baige darba!");
        }

        static void rastiJauniausius(Krepsininkas[] krepsininkai, int n, Krepsininkas[] filtras, ref int sk, int jauniausias)
        {
            for (int i = 0; i < n; i++) {
                if (krepsininkai[i].GautiAmziu() == jauniausias) {
                    filtras[sk] = new Krepsininkas(krepsininkai[i].GautiVarda(), krepsininkai[i].GautiAmziu(), krepsininkai[i].GautiUgi());
                    sk++;
                }
            }
        }

        static void spausdintiAuksciausius(string rez, Krepsininkas[] krepsininkai, int n, double auksciausias, string pav)
        {
            using (var prideti = File.AppendText(rez))
            {
                for (int i = 0; i < n; i++)
                {
                    if (krepsininkai[i].GautiUgi() == auksciausias)
                        prideti.WriteLine(pav);
                }
            }
        }

        static void spausdintiVidurkius(string rez, string pav, double vidurkis, string txt)
        {
            using (var prideti = File.AppendText(rez))
            {
                prideti.WriteLine("{0}: {1,5:f} {2}", pav, vidurkis, txt);
            }
        }

        static void pridetiTeksto(string rez, string tekstas)
        {
            using (var prideti = File.AppendText(rez))
            {
                prideti.WriteLine(tekstas);
            }
        }

        static void Spausdinimas(string rez, Krepsininkas[] krepsininkai, int n, string pav, string virsus)
        {
            using (var prideti = File.AppendText(rez))
            {
                if (n > 0) {
                    prideti.WriteLine(pav);
                    prideti.WriteLine(virsus);
                    for (int i = 0; i < n; i++)
                    {
                        prideti.WriteLine("| {0,-39}|    {1}    |    {2}    |", krepsininkai[i].GautiVarda(), krepsininkai[i].GautiAmziu(), krepsininkai[i].GautiUgi());
                    }
                    prideti.WriteLine("------------------------------------------------------------------");
                    prideti.WriteLine("");
                }
                else {
                    prideti.WriteLine("Sarasas tuscias");
                }
            }
        }

        static int jauniausioAmzius(Krepsininkas[] krepsininkai, int n)
        {
            int jauniausias = krepsininkai[0].GautiAmziu();

            for (int i = 1; i < n; i++)
            {
                if (krepsininkai[i].GautiAmziu() < jauniausias)
                {
                    jauniausias = krepsininkai[i].GautiAmziu();
                }
            }

            return jauniausias;
        }

        static void ugisDidesnisUzVidurki(Krepsininkas[] krepsininkai, Krepsininkas[] auksciausi, int n, int ilgis, ref int kiekis, double bendrasUgioVidurkis)
        {
            for (int i = 0; i < n; i++)
            {
                if (krepsininkai[i].GautiUgi() > bendrasUgioVidurkis)
                {
                    auksciausi[ilgis] = new Krepsininkas(krepsininkai[i].GautiVarda(), krepsininkai[i].GautiAmziu(), krepsininkai[i].GautiUgi());
                    ilgis++;
                }
            }

            kiekis = ilgis;
        }

        static double rastiAuksciausia(Krepsininkas[] krepsininkai, int n)
        {
            double auksciausias = krepsininkai[0].GautiUgi();

            for (int i = 1; i < n; i++)
            {
                if (krepsininkai[i].GautiUgi() > auksciausias)
                    auksciausias = krepsininkai[i].GautiUgi();
            }

            return auksciausias;
        }

        static double ugioVidurkis(Krepsininkas[] krepsininkai, int n)
        {
            double ugiuSuma = 0;
            double ugioVidurkis;
            for (int i = 0; i < n; i++)
            {
                ugiuSuma += krepsininkai[i].GautiUgi();
            }

            ugioVidurkis = ugiuSuma / n;

            return ugioVidurkis;
        }

        static double amziausVidurkis(Krepsininkas[] krepsininkai, int n)
        {
            double amziuSuma = 0, amziausVidurkis;
            for (int i = 0; i < n; i++)
            {
                amziuSuma += krepsininkai[i].GautiAmziu();
            }

            return amziausVidurkis = amziuSuma / n;
        }

        static void skaitymas(string duom, Krepsininkas[] krepsininkai, out string pav, out int n)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string eilute;
                string[] skaidymas;
                pav = reader.ReadLine();

                string vp;
                int amzius;
                double ugis;
                int iterator = 0;

                while ((eilute = reader.ReadLine()) != null)
                {
                    skaidymas = eilute.Split(';');
                    vp = skaidymas[0];
                    amzius = int.Parse(skaidymas[1]);
                    ugis = double.Parse(skaidymas[2]);
                    krepsininkai[iterator] = new Krepsininkas(vp, amzius, ugis);
                    iterator++;
                }
                n = iterator;
            }
        }
    }
}