using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace L1
{
    public partial class Form1 : Form
    {
        const string duom1 = "..\\..\\duom1.txt";
        const string duom2 = "..\\..\\duom2.txt";
        const string rez = "..\\..\\rez.txt";


        string mokPav1;
        string mokPav2;
        Krepsininkai mokykla1;
        Krepsininkai mokykla2;
        Krepsininkai naujasKonteineris;

        public Form1()
        {
            InitializeComponent();

            print.Enabled = false;
            skaiciuoti.Enabled = false;

            if (File.Exists(rez))
                File.Delete(rez);

        }

        private void read_Click(object sender, EventArgs e)
        {
            mokykla1 = Skaityti(duom1, out mokPav1);
            mokykla2 = Skaityti(duom2, out mokPav2);

            Spausdinti(rez, mokykla1, mokPav1, "Pradiniai pirmos mokyklos duomenys:");
            Spausdinti(rez, mokykla2, mokPav2, "Pradiniai antros mokyklos duomenys:");

            naujasKonteineris = new Krepsininkai();

            string x = File.ReadAllText(rez);
            richTextBox1.Text = x;

            skaiciuoti.Enabled = true;
        }

        private void skaiciuoti_Click(object sender, EventArgs e)
        {
            double amzVid1 = AmziausVidurkis(mokykla1);
            SpausdintiTeksta(rez, string.Format("Amžiaus vidurkis pirmoje ({0}) mokykloje yra: {1, 5:f} m.", mokPav1, amzVid1));
            double amzVid2 = AmziausVidurkis(mokykla2);
            SpausdintiTeksta(rez, string.Format("Amžiaus vidurkis antroje ({0}) mokykloje yra: {1, 5:f} m.\n", mokPav2, amzVid2));

            double ugioVid1 = ŪgioVidurkis(mokykla1);
            SpausdintiTeksta(rez, string.Format("Ūgio vidurkis pirmoje ({0}) mokykloje yra: {1, 5:f} m.", mokPav1, ugioVid1));
            double ugioVid2 = ŪgioVidurkis(mokykla2);
            SpausdintiTeksta(rez, string.Format("Ūgio vidurkis antroje ({0}) mokykloje yra: {1, 5:f} m.\n", mokPav2, ugioVid2));

            UgisDidesnisUzVidurki(mokykla1, naujasKonteineris, Math.Round(((ugioVid1 + ugioVid2) / 2), 2));
            UgisDidesnisUzVidurki(mokykla2, naujasKonteineris, Math.Round(((ugioVid1 + ugioVid2) / 2), 2));
            Spausdinti(rez, naujasKonteineris, "Abi mokyklos", "Konteineris studentų, kurių ūgis didesnis už vidurkį:");

            mokykla1.Rikiuoti();
            Spausdinti(rez, mokykla1, mokPav1, "Surikiuotas konteineris:");
            mokykla2.Rikiuoti();
            Spausdinti(rez, mokykla2, mokPav2, "Surikiuotas konteineris:");
            naujasKonteineris.Rikiuoti();
            Spausdinti(rez, naujasKonteineris, "Abi mokyklos", "Surikiuotas konteineris:");

            int amz = int.Parse(textBox1.Text);
            mokykla1.Šalinti(amz);
            Spausdinti(rez, mokykla1, mokPav1, "Pašalinti moksleiviai, kurių amžius didesnis už nurodytą:");
            mokykla2.Šalinti(amz);
            Spausdinti(rez, mokykla2, mokPav2, "Pašalinti moksleiviai, kurių amžius didesnis už nurodytą:");
            naujasKonteineris.Šalinti(amz);
            Spausdinti(rez, naujasKonteineris, "Abi mokyklos", "Pašalinti moksleiviai, kurių amžius didesnis už nurodytą:");

            print.Enabled = true;
        }

        private void print_Click(object sender, EventArgs e)
        {
            string x = File.ReadAllText(rez);
            richTextBox1.Text = x;
        }

        private void baigti_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AtliktiSkaiciavimus()
        {

        }

        /// <summary>
        /// Formuoja naują konteinerį iš krepšininkų, kurių ūgis didesnis už vidurkį
        /// </summary>
        /// <param name="kont1">Pirmas konteineris</param>
        /// <param name="kont2">Antras kont</param>
        /// <param name="naujas">Trečias kont</param>
        private void UgisDidesnisUzVidurki(Krepsininkai kont, Krepsininkai naujas, double ugis)
        {
            for (int i = 0; i < kont.Kiek; i++)
            {
                if (kont.ImtiKrepsininka(i).Ūgis > ugis)
                {
                    naujas.DetiStudenta(kont.ImtiKrepsininka(i));
                }
            }
        }

        /// <summary>
        /// Randa krepšininkų amžiaus vidurkį
        /// </summary>
        /// <param name="kont">Konteineris</param>
        /// <returns>Amžiaus vidurkis</returns>
        static double AmziausVidurkis(Krepsininkai kont)
        {
            double suma = 0;
            for (int i = 0; i < kont.Kiek; i++)
            {
                suma += kont.ImtiKrepsininka(i).Amžius;
            }

            return suma / kont.Kiek;
        }

        /// <summary>
        /// Randa krepšininkų ūgio vidurkį
        /// </summary>
        /// <param name="kont">Konteineris</param>
        /// <returns>Ūgio vidurkis</returns>
        static double ŪgioVidurkis(Krepsininkai kont)
        {
            double suma = 0;
            for (int i = 0; i < kont.Kiek; i++)
            {
                suma += kont.ImtiKrepsininka(i).Ūgis;
            }

            return suma / kont.Kiek;
        }

        //Nuskaito failus
        private Krepsininkai Skaityti(string fr, out string pav)
        {
            Krepsininkai konteineris = new Krepsininkai();
            using(StreamReader reader = new StreamReader(fr, Encoding.GetEncoding(1257)))
            {
                string line;
                line = reader.ReadLine();
                pav = line;

                while((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string pavVrd = parts[0];
                    int amz = int.Parse(parts[1]);
                    double ug = double.Parse(parts[2]);
                    Krepsininkas krep = new Krepsininkas(pavVrd, amz, ug);
                    konteineris.DetiStudenta(krep);
                }

                return konteineris;
            }
        }

        //Rašo į failus
        private void Spausdinti(string fw, Krepsininkai kont, string pav, string antraste)
        {
            const string virsus =
            "------------------------------------------\r\n" +
            " Nr. Pavardė ir vardas     Amžius    Ūgis \r\n" +
            "------------------------------------------";

            using (var fr = new StreamWriter(File.Open(fw, FileMode.Append)))
            {
                if (kont.Kiek > 0)
                {
                    fr.WriteLine(antraste);
                    fr.WriteLine(pav);
                    fr.WriteLine(virsus);
                    for (int i = 0; i < kont.Kiek; i++)
                    {
                        Krepsininkas krep = kont.ImtiKrepsininka(i);
                        fr.WriteLine("{0, 3} {1}", i + 1, krep);
                    }
                    fr.WriteLine("------------------------------------------\n");
                }
                else
                {
                    fr.WriteLine("Studentų konteineris tuščias!\n");
                }
            }
        }

        private void SpausdintiTeksta(string rez, string x)
        {
            using (StreamWriter fw = new StreamWriter(File.Open(rez, FileMode.Append)))
            {
                fw.WriteLine(x);
            }
        }
    }
}
