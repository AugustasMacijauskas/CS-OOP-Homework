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

namespace L2
{
    public partial class Form1 : Form
    {
        const string rez = "..\\..\\rez.txt";
        const string naujokai = "..\\..\\Naujokai.txt";
        const string nurodymai = "..\\..\\Nurodymai.txt";
        const string salygos = "..\\..\\NaudojimoSąlygos.txt";

        List<Krepsininkas> mokykla1;
        List<Krepsininkas> mokykla2;
        List<Krepsininkas> naujasKonteineris;
        List<Krepsininkas> naujiKrepsininkai;

        string mokPav1;
        string mokPav2;
        string Vadybininkas;

        public Form1()
        {
            InitializeComponent();

            print.Enabled = false;
            skaiciuoti.Enabled = false;
            pridėtiNaujų.Enabled = false;
            išsaugoti.Enabled = false;

            if (File.Exists(rez))
                File.Delete(rez);

        }

        /// <summary>
        /// Vykdo failų nuskaitymą.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nuskaityti_Click(object sender, EventArgs e)
        {
            label1.Text = "Vyksta duomenų įvedimas. Laukite.";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite pirmąjį duomenų failą";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fv = openFileDialog1.FileName;
                mokykla1 = Skaityti(fv, out mokPav1);

            }

            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog2.Title = "Pasirinkite antrąjį duomenų failą";
            DialogResult result2 = openFileDialog2.ShowDialog();
            if (result2 == DialogResult.OK)
            {
                string fv = openFileDialog2.FileName;
                mokykla2 = Skaityti(fv, out mokPav2);
            }

            Spausdinti(rez, mokykla1, mokPav1, "Pradiniai pirmos mokyklos duomenys:");
            Spausdinti(rez, mokykla2, mokPav2, "Pradiniai antros mokyklos duomenys:");

            naujasKonteineris = new List<Krepsininkas>();

            string x = File.ReadAllText(rez);
            richTextBox1.Text = x;

            skaiciuoti.Enabled = true;
            nuskaityti.Enabled = false;
            label1.Text = "Duomenys įvesti ir atspausdinti,\ngalima skaičiuoti.";
        }

        /// <summary>
        /// Vykdo skaičiavimus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skaiciuoti_Click(object sender, EventArgs e)
        {
            label1.Text = "Vykdomi skaičiavimai";
            double amzVid1 = AmziausVidurkis(mokykla1);
            SpausdintiTeksta(rez, string.Format("Amžiaus vidurkis pirmoje ({0})" +
            " mokykloje yra: {1, 5:f} m.", mokPav1, amzVid1));
            double amzVid2 = AmziausVidurkis(mokykla2);
            SpausdintiTeksta(rez, string.Format("Amžiaus vidurkis antroje ({0})" +
            " mokykloje yra: {1, 5:f} m.\n", mokPav2, amzVid2));

            double ugioVid1 = ŪgioVidurkis(mokykla1);
            SpausdintiTeksta(rez, string.Format("Ūgio vidurkis pirmoje ({0})" +
            " mokykloje yra: {1, 5:f} m.", mokPav1, ugioVid1));
            double ugioVid2 = ŪgioVidurkis(mokykla2);
            SpausdintiTeksta(rez, string.Format("Ūgio vidurkis antroje ({0})" +
            " mokykloje yra: {1, 5:f} m.\n", mokPav2, ugioVid2));

            double vidur = Math.Round(((ugioVid1 + ugioVid2) / 2), 2);
            UgisDidesnisUzVidurki(mokykla1, naujasKonteineris, vidur);
            UgisDidesnisUzVidurki(mokykla2, naujasKonteineris, vidur);
            Spausdinti(rez, naujasKonteineris, "Abi mokyklos",
            "Konteineris studentų, kurių ūgis didesnis už vidurkį:");


            Rikiuoti(naujasKonteineris);
            Spausdinti(rez, naujasKonteineris, "Abi mokyklos",
            "Surikiuotas konteineris:");

            int amz = int.Parse(textBox1.Text);
            Šalinti(naujasKonteineris, amz);
            Spausdinti(rez, naujasKonteineris, "Abi mokyklos",
            "Pašalinti moksleiviai, kurių amžius didesnis už nurodytą:");

            print.Enabled = true;
            skaiciuoti.Enabled = false;

            label1.Text = "Skaičiavimai atlikti,\ngalima spausdinti.";

            pridėtiNaujų.Enabled = true;
        }

        /// <summary>
        /// Spausdina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void print_Click(object sender, EventArgs e)
        {
            string x = File.ReadAllText(rez);
            richTextBox1.Text = x;
            label1.Text = "Duomenys atspausdinti.";
        }

        /// <summary>
        /// Prideda naujus žaidėjus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pridėtiNaujų_Click(object sender, EventArgs e)
        {
            label1.Text = "Pridedami nauji krepšininkai.";

            naujiKrepsininkai = Skaityti(naujokai, out Vadybininkas);

            for (int i = 0; i < naujiKrepsininkai.Count; i++)
            {
                Krepsininkas krep = naujiKrepsininkai[i];
                int ind = RastiIndeksą(naujasKonteineris, krep);
                naujasKonteineris.Insert(ind, krep);
            }

            Spausdinti(rez, naujasKonteineris, Vadybininkas, "Sąrašas su" +
            " pridėtais naujais krepšininkais:");

            label1.Text = "Duomenys pridėti,\ngalima spausdinti.";

            išsaugoti.Enabled = true;
            pridėtiNaujų.Enabled = false;
        }

        /// <summary>
        /// Leidžia saugoti rezultatus į .csv failą
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void išsaugoti_Click(object sender, EventArgs e)
        {
            label1.Text = "Krepšininkai spausdinami į .csv failą.";

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV|*.csv";
            saveFileDialog1.Title = "Pasirinkite .csv failą, į kurį norite" +
            " spausdinti";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fv = saveFileDialog1.FileName;
                if (File.Exists(fv))
                    File.Delete(fv);
                SpausdintiĮCSVFailą(fv, naujasKonteineris, "Abi mokyklos",
                "Spausdinimas į .csv failą:");
            }

            label1.Text = "Krepšininkai atspaudinti į .csv failą.";
        }

        /// <summary>
        /// Spausdina nurodymus vartotojui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nurodymaiVartotojuiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string x = File.ReadAllText(nurodymai);
            MessageBox.Show(x);
        }

        /// <summary>
        /// Spausdina naudojimo sąlygas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void naudojimoSąlygosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string x = File.ReadAllText(salygos);
            MessageBox.Show(x);
        }

        /// <summary>
        /// Išvalo teksto lauką ant jo paspaudus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        /// <summary>
        /// Baigia programos darbą
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baigti_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Rikiuoja duomenis
        /// </summary>
        /// <param name="A"></param>
        private void Rikiuoti(List<Krepsininkas> A)
        {
            int i = 0;
            bool bk = true;

            while (bk)
            {
                bk = false;
                for (int j = A.Count - 1; j > i; j--)
                {
                    if (A[j] <= A[j - 1])
                    {
                        bk = true;
                        Krepsininkas krep = A[j];
                        A[j] = A[j - 1];
                        A[j - 1] = krep;
                    }
                }
                i++;
            }
        }

        /// <summary>
        /// Šalina duomenis
        /// </summary>
        /// <param name="A"></param>
        /// <param name="amz"></param>
        private void Šalinti(List<Krepsininkas> A, int amz)
        {
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i].Amžius > amz)
                {
                    A.Remove(A[i]);
                    i--;
                }
            }
        }

        /// <summary>
        /// Spausdina į .csv failą
        /// </summary>
        /// <param name="fw"></param>
        /// <param name="kont"></param>
        /// <param name="pav"></param>
        /// <param name="antraste"></param>
        private void SpausdintiĮCSVFailą(string fw, List<Krepsininkas> kont, string pav,
        string antraste)
        {
            using (var fr = new StreamWriter(File.Open(fw, FileMode.Append)))
            {
                if (kont.Count > 0)
                {
                    fr.WriteLine(";" + antraste);
                    fr.WriteLine(";" + pav);
                    fr.WriteLine(" {0, -5} ; {1, -20} ; {2, -8} ; {3, -6} ", "Nr.",
                        "Vardas Pavardė", "Amžius", "Ūgis");
                    for (int i = 0; i < kont.Count; i++)
                    {
                        Krepsininkas krep = kont[i];
                        fr.WriteLine(" {0, -3} ; {1, -20} ; {2, 3:d} ; {3, 5:f} ",
                            (i + 1).ToString(), krep.VP, krep.Amžius, krep.Ūgis);
                    }
                }
                else
                {
                    fr.WriteLine("Studentų konteineris tuščias!\n");
                }
            }
        }

        /// <summary>
        /// Randa įterpiamų krepšininkų indeksus
        /// </summary>
        /// <param name="A"></param>
        /// <param name="krep"></param>
        /// <returns></returns>
        private int RastiIndeksą(List<Krepsininkas> A, Krepsininkas krep)
        {
            int ind = A.Count;
            for (int i = 0; i < A.Count; i++)
            {
                if (krep <= A[i])
                {
                    ind = i;
                }
            }

            return ind;
        }

        /// <summary>
        /// Formuoja naują konteinerį iš krepšininkų, kurių ūgis didesnis už vidurkį
        /// </summary>
        /// <param name="kont1">Pirmas konteineris</param>
        /// <param name="kont2">Antras kont</param>
        /// <param name="naujas">Trečias kont</param>
        private void UgisDidesnisUzVidurki(List<Krepsininkas> kont, List<Krepsininkas> naujas,
        double ugis)
        {
            for (int i = 0; i < kont.Count; i++)
            {
                if (kont[i].Ūgis > ugis)
                {
                    naujas.Add(kont[i]);
                }
            }
        }

        /// <summary>
        /// Randa krepšininkų amžiaus vidurkį
        /// </summary>
        /// <param name="kont">Konteineris</param>
        /// <returns>Amžiaus vidurkis</returns>
        static double AmziausVidurkis(List<Krepsininkas> kont)
        {
            double suma = 0;
            for (int i = 0; i < kont.Count; i++)
            {
                suma += kont[i].Amžius;
            }

            return suma / kont.Count;
        }

        /// <summary>
        /// Randa krepšininkų ūgio vidurkį
        /// </summary>
        /// <param name="kont">Konteineris</param>
        /// <returns>Ūgio vidurkis</returns>
        static double ŪgioVidurkis(List<Krepsininkas> kont)
        {
            double suma = 0;
            for (int i = 0; i < kont.Count; i++)
            {
                suma += kont[i].Ūgis;
            }

            return suma / kont.Count;
        }

        /// <summary>
        /// Failų nuskaitymas
        /// </summary>
        /// <param name="fr"></param>
        /// <param name="pav"></param>
        /// <returns></returns>
        private List<Krepsininkas> Skaityti(string fr, out string pav)
        {
            List<Krepsininkas> konteineris = new List<Krepsininkas>();
            using (StreamReader reader = new StreamReader(fr, Encoding.GetEncoding(1257)))
            {
                string line;
                line = reader.ReadLine();
                pav = line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string pavVrd = parts[0];
                    int amz = int.Parse(parts[1]);
                    double ug = double.Parse(parts[2]);
                    Krepsininkas krep = new Krepsininkas(pavVrd, amz, ug);
                    konteineris.Add(krep);
                }

                return konteineris;
            }
        }

        /// <summary>
        /// Spausdina rezultatus į failus
        /// </summary>
        /// <param name="fw"></param>
        /// <param name="kont"></param>
        /// <param name="pav"></param>
        /// <param name="antraste"></param>
        private void Spausdinti(string fw, List<Krepsininkas> kont, string pav,
        string antraste)
        {
            const string virsus =
            "------------------------------------------\r\n" +
            " Nr. Pavardė ir vardas     Amžius    Ūgis \r\n" +
            "------------------------------------------";

            using (var fr = new StreamWriter(File.Open(fw, FileMode.Append)))
            {
                if (kont.Count > 0)
                {
                    fr.WriteLine(antraste);
                    fr.WriteLine(pav);
                    fr.WriteLine(virsus);
                    for (int i = 0; i < kont.Count; i++)
                    {
                        Krepsininkas krep = kont[i];
                        fr.WriteLine("{0, 3} {1}", i + 1, krep.ToString());
                    }
                    fr.WriteLine("------------------------------------------\n");
                }
                else
                {
                    fr.WriteLine("Studentų konteineris tuščias!\n");
                }
            }
        }

        /// <summary>
        /// Spausdina tekstą į failus
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