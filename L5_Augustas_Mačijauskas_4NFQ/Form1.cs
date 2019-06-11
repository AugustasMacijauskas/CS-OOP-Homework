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
        const string duom1 = "..\\..\\duom1_2.txt";
        const string duom2 = "..\\..\\duom2_2.txt";
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

        /// <summary>
        /// Atlieka duomenų nuskaitymą ir surašymą į konteinerius.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Atliekami reikiami skaičiavimai, jų rezultatai įvedami į duomenų failą.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skaiciuoti_Click(object sender, EventArgs e)
        {
            double amzVid1 = AmziausVidurkis(mokykla1);
            SpausdintiTeksta(rez, string.Format("Amžiaus vidurkis pirmoje ({0}) mokykloje yra: {1, 5:f} m.", mokPav1, amzVid1));
            double amzVid2 = AmziausVidurkis(mokykla2);
            SpausdintiTeksta(rez, string.Format("Amžiaus vidurkis antroje ({0}) mokykloje yra: {1, 5:f} m.\r\n", mokPav2, amzVid2));

            double ugiovid1 = ŪgioVidurkis(mokykla1);
            SpausdintiTeksta(rez, string.Format("Ūgio vidurkis pirmoje ({0}) mokykloje yra: {1, 5:f} m.", mokPav1, ugiovid1));
            double ugiovid2 = ŪgioVidurkis(mokykla2);
            SpausdintiTeksta(rez, string.Format("Ūgio vidurkis antroje ({0}) mokykloje yra: {1, 5:f} m.\r\n", mokPav2, ugiovid2));

            double vidur = Math.Round(((ugiovid1 + ugiovid2) / 2), 2);
            UgisDidesnisUzVidurki(mokykla1, naujasKonteineris, vidur);
            UgisDidesnisUzVidurki(mokykla2, naujasKonteineris, vidur);
            Spausdinti(rez, naujasKonteineris, "Abi mokyklos", $"Konteineris krepšininkų, kurių ūgis didesnis už vidurkį: {vidur}");

            naujasKonteineris.Sort();
            Spausdinti(rez, naujasKonteineris, "Abi mokyklos", "Surikiuotas konteineris:");

            string text = File.ReadAllText(rez);
            richTextBox1.Text = text;

            int amz = int.Parse(textBox1.Text);
            naujasKonteineris.Filter(amz);
            Spausdinti(rez, naujasKonteineris, "Abi mokyklos", "Pašalinti moksleiviai, kurių amžius didesnis už nurodytą:");

            print.Enabled = true;
        }

        /// <summary>
        /// Spaudina tekstą iš duomenų failo į programos langą.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void print_Click(object sender, EventArgs e)
        {
            string x = File.ReadAllText(rez);
            richTextBox1.Text = x;
        }

        /// <summary>
        /// Užėjus ant teksto lauko, jį išvalo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        /// <summary>
        /// Baigia programos veikimą.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baigti_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Formuoja naują konteinerį iš krepšininkų, kurių ūgis didesnis už vidurkį.
        /// </summary>
        /// <param name="kont1">Pirmas konteineris</param>
        /// <param name="kont2">Antras kont</param>
        /// <param name="naujas">Trečias kont</param>
        private void UgisDidesnisUzVidurki(Krepsininkai kont, Krepsininkai naujas, double ugis)
        {
            for (kont.Start(); !kont.isEmpty(); kont.Next())
            {
                if (kont.ImtiKrepsininka().Ūgis > ugis)
                {
                    naujas.AddFirst(kont.ImtiKrepsininka());
                }
            }
        }

        /// <summary>
        /// Randa krepšininkų amžiaus vidurkį.
        /// </summary>
        /// <param name="kont">Konteineris</param>
        /// <returns>Amžiaus vidurkis</returns>
        static double AmziausVidurkis(Krepsininkai kont)
        {
            double suma = 0;
            int kiekis = 0;

            for (kont.Start(); !kont.isEmpty(); kont.Next())
            {
                suma += kont.ImtiKrepsininka().Amžius;
                kiekis++;
            }

            if (kiekis != 0)
                return suma / kiekis;
            else return 0.0;
        }

        /// <summary>
        /// Randa krepšininkų ūgio vidurkį.
        /// </summary>
        /// <param name="kont">Konteineris</param>
        /// <returns>Ūgio vidurkis</returns>
        static double ŪgioVidurkis(Krepsininkai kont)
        {
            double suma = 0;
            int kiekis = 0;

            for (kont.Start(); !kont.isEmpty(); kont.Next())
            {
                suma += kont.ImtiKrepsininka().Ūgis;
                kiekis++;
            }

            if (kiekis != 0)
                return suma / kiekis;
            else return 0.0;
        }

        /// <summary>
        /// Nuskaito duomenų failus.
        /// </summary>
        /// <param name="fr"></param>
        /// <param name="pav"></param>
        /// <returns></returns>
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
                    konteineris.AddLast(krep);
                }

                return konteineris;
            }
        }

        /// <summary>
        /// Spausdina duomenis į failą lentele.
        /// </summary>
        /// <param name="fw"></param>
        /// <param name="kont"></param>
        /// <param name="pav"></param>
        /// <param name="antraste"></param>
        private void Spausdinti(string fw, Krepsininkai kont, string pav, string antraste)
        {
            const string virsus =
            "--------------------------------------\r\n" +
            " Pavardė ir vardas     Amžius    Ūgis \r\n" +
            "--------------------------------------";

            using (var fr = new StreamWriter(File.Open(fw, FileMode.Append)))
            {
                kont.Start();
                if (!kont.isEmpty())
                {
                    fr.WriteLine(antraste);
                    fr.WriteLine(pav);
                    fr.WriteLine(virsus);
                    for (kont.Start(); !kont.isEmpty(); kont.Next())
                    {
                        Krepsininkas krep = kont.ImtiKrepsininka();
                        fr.WriteLine("{0}", krep);
                    }
                    fr.WriteLine("--------------------------------------\r\n");
                }
                else
                {
                    fr.WriteLine("Krepšininkų konteineris tuščias!\r\n");
                }
            }
        }

        /// <summary>
        /// Spausdina tekstą į failą.
        /// </summary>
        /// <param name="rez"></param>
        /// <param name="x"></param>
        private void SpausdintiTeksta(string rez, string x)
        {
            using (StreamWriter fw = new StreamWriter(File.Open(rez, FileMode.Append)))
            {
                fw.WriteLine(x);
            }
        }
    }
}
