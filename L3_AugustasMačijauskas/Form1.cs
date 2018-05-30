using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace L3_AugustasMačijauskas
{
    public partial class Form1 : Form
    {
        List<Automobilis> automobiliai;
        List<Automobilis> markes;
        List<string> gamintojai;
        string rez = "";
        const string info = "..\\..\\informacijaVartotojui.txt";

        public Form1()
        {
            InitializeComponent();
            Skaiciuoti.Enabled = false;
            Spausdinti.Enabled = false;
            skaičiavimasToolStripMenuItem.Enabled = false;
        }

        private void įvestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Vyksta duomenų įvedimas. Prašome palaukti.";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFile.Title = "Pasirinkite duomenų failą";
            DialogResult result = openFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fn = openFile.FileName;
                automobiliai = Read(fn);
            }

            label1.Text = "Duomenys nuskaityti. Pasirinkite failą,\nį kurį norite spausdinti.";
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFile.Title = "Pasirinkite failą, į kurį norite spausdinti";
            result = saveFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                rez = saveFile.FileName;
                if (File.Exists(rez))
                    File.Delete(rez);
                Write(rez, automobiliai, "Pradiniai duomenys:");
            }

            string x = File.ReadAllText(rez);
            richTextBox1.Text = x;

            label1.Text = "Duomenys nuskaityti ir atspaudtinti.\nGalima atlikti skaičiavimus.";

            Skaiciuoti.Enabled = true;
            Ivesti.Enabled = false;
            skaičiavimasToolStripMenuItem.Enabled = true;
        }

        private List<Automobilis> Read(string fn)
        {
            List<Automobilis> ret = new List<Automobilis>();
            using (StreamReader reader = new StreamReader(fn))
            {
                string line;
                string[] parts;
                string vn, gam, mod, kur;
                DateTime pag, tech;
                double san;

                while ((line = reader.ReadLine()) != null)
                {
                    parts = line.Split(';');
                    vn = parts[0].Trim();
                    gam = parts[1].Trim();
                    mod = parts[2].Trim();
                    pag = DateTime.Parse(parts[3].Trim());
                    tech = DateTime.Parse(parts[4].Trim());
                    kur = parts[5].Trim();
                    san = double.Parse(parts[6].Trim());
                    Automobilis naujas = new Automobilis(vn, gam, mod, pag, tech, kur, san);
                    ret.Add(naujas);
                }
            }
            return ret;
        }

        private void Write(string fn, List<Automobilis> kont, string antraste)
        {
            const string virsus =
            "------------------------------------------------------------------------------------------------------------------------------------\r\n" +
            " Nr. Valstybinis numeris     Gamintojas     Modelis          Pagaminimo data     Techninė apžiūra      Kuro tipas     Kuro sąnaudos \r\n" +
            "------------------------------------------------------------------------------------------------------------------------------------";

            using (var writer = new StreamWriter(File.Open(fn, FileMode.Append)))
            {
                if (kont.Count < 0)
                {
                    writer.WriteLine("Studentų konteineris tuščias!\n");
                }
                else
                {
                    writer.WriteLine(antraste);
                    writer.WriteLine(virsus);
                    for (int i = 0; i < kont.Count; i++)
                    {
                        Automobilis krep = kont[i];
                        writer.WriteLine("{0, 3} {1}", i + 1, krep.ToString());
                    }
                    writer.WriteLine("------------------------------------------------------------------------------------------------------------------------------------\n");
                }
            }
        }

        private void Write(string fn, List<string> gamintojai, string antraste)
        {
            using (var writer = new StreamWriter(File.Open(fn, FileMode.Append)))
            {
                writer.WriteLine(antraste);
                foreach (string gamintojas in gamintojai)
                {
                    writer.WriteLine(gamintojas);
                }
                writer.WriteLine();
            }
        }

        private void Write(string fn, string text)
        {
            using (var writer = new StreamWriter(File.Open(fn, FileMode.Append)))
            {
                writer.WriteLine(text);
            }
        }

        private void Baigti_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Skaiciuoti_Click(object sender, EventArgs e)
        {
            label1.Text = "Atliekami skaičiavimai. Prašome palaukti.";
            Automobilis naujausias1;
            Automobilis naujausias2;
            RastiDuNaujausius(automobiliai, out naujausias1, out naujausias2);
            Write(rez, "Naujausias automobilis:\n" +
                $"{"Valstybinis numeris",25} : {naujausias1.ValstybinisNumeris,20}\n" +
                $"{"Gamintojas",25} : {naujausias1.Gamintojas,20}\n" +
                $"{"Modelis",25} : {naujausias1.Modelis,20}\n" +
                $"{"Pagaminimo data",25} : {naujausias1.PagaminimoData.ToString("yyyy MM"),20}\n" +
                $"{"Techninė apžiūra",25} : {naujausias1.TechninėApžiūra.ToString("yyyy MM dd"),20}\n" +
                $"{"Kuro tipas",25} : {naujausias1.Kuras,20}\n" +
                $"{"Kuro sąnaudos",25} : {naujausias1.VidutinėsSąnaudos,20}\n");
            Write(rez, "Antras naujausias automobilis:\n" +
                $"{"Valstybinis numeris",25} : {naujausias2.ValstybinisNumeris,20}\n" +
                $"{"Gamintojas",25} : {naujausias2.Gamintojas,20}\n" +
                $"{"Modelis",25} : {naujausias2.Modelis,20}\n" +
                $"{"Pagaminimo data",25} : {naujausias2.PagaminimoData.ToString("yyyy MM"),20}\n" +
                $"{"Techninė apžiūra",25} : {naujausias2.TechninėApžiūra.ToString("yyyy MM dd"),20}\n" +
                $"{"Kuro tipas",25} : {naujausias2.Kuras,20}\n" +
                $"{"Kuro sąnaudos",25} : {naujausias2.VidutinėsSąnaudos,20}\n");

            string marke = textBox1.Text;
            markes = AtrinktiPagalMarke(automobiliai, marke);
            if (markes.Count > 0)
            {
                Write(rez, markes, $"{marke} markės automobiliai:");
                Rikiuoti(markes);
                Write(rez, markes, $"Surikiuoti {marke} markės automobiliai:");
            }
            else
            {
                Write(rez, "Modelių sąrašas tuščias!\n");
            }
            gamintojai = AtrinktiGamintojus(automobiliai);
            Write(rez, gamintojai, "Gamintojų sąrašas:");
            Skaiciuoti.Enabled = false;
            Spausdinti.Enabled = true;
            label1.Text = "Skaičiavimai atlikti. Galima spausdinti";
        }

        private List<string> AtrinktiGamintojus(List<Automobilis> automobiliai)
        {
            List<string> ret = new List<string>();

            for (int i = 0; i < automobiliai.Count; i++)
            {
                if (!ret.Contains(automobiliai[i].Gamintojas))
                {
                    ret.Add(automobiliai[i].Gamintojas);
                }
            }

            return ret;
        }

        private void Rikiuoti(List<Automobilis> automobiliai)
        {
            int minIndex;
            for (int i = 0; i < automobiliai.Count - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < automobiliai.Count; j++)
                {
                    if (automobiliai[j] < automobiliai[minIndex])
                    {
                        minIndex = j;
                    }

                    Automobilis temp = automobiliai[i];
                    automobiliai[i] = automobiliai[minIndex];
                    automobiliai[minIndex] = temp;
                }
            }
        }

        private List<Automobilis> AtrinktiPagalMarke(List<Automobilis> automobiliai, string marke)
        {
            List<Automobilis> ret = new List<Automobilis>();
            for (int i = 0; i < automobiliai.Count; i++)
            {
                if (automobiliai[i].Modelis == marke)
                {
                    ret.Add(automobiliai[i]);
                }
            }

            return ret;
        }

        private void RastiDuNaujausius(List<Automobilis> automobiliai, out Automobilis a1, out Automobilis a2)
        {
            a1 = automobiliai[0];
            a2 = automobiliai[1];

            if (a2 >= a1)
            {
                Automobilis temp = a1;
                a1 = a2;
                a2 = temp;
            }

            for (int i = 2; i < automobiliai.Count; i++)
            {
                Automobilis temp = automobiliai[i];
                if (temp >= a1 && temp >= a2)
                {
                    a2 = a1;
                    a1 = temp;
                }
                else if (temp >= a2)
                {
                    a2 = temp;
                }
            }
        }

        private void Spausdinti_Click(object sender, EventArgs e)
        {
            string txt = File.ReadAllText(rez);
            richTextBox1.Text = txt;
        }

        private void Informacija_Click(object sender, EventArgs e)
        {
            label1.Text = "Peržiūrima informacija vartotojui.";
            string x = File.ReadAllText(info);
            MessageBox.Show(x);
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

    }
}
