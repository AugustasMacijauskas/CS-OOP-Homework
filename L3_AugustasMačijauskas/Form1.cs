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
        List<Automobilis> automobiliai = new List<Automobilis>();
        string rez = "";

        public Form1()
        {
            InitializeComponent();
            Skaiciuoti.Enabled = false;
            Spausdinti.Enabled = false;
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

            label1.Text = "Duomenys nuskaityti. Pasirinkite failą, į kurį norite spausdinti.";
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
        }

        private List<Automobilis> Read(string fn)
        {
            List<Automobilis> ret = new List<Automobilis>();
            using (StreamReader reader = new StreamReader(fn))
            {
                string line;
                string[] parts;
                string vn, gam, mod;
                DateTime pag, tech;
                double kur, san;

                while ((line = reader.ReadLine()) != null)
                {
                    parts = line.Split(';');
                    vn = parts[0].Trim();
                    gam = parts[1].Trim();
                    mod = parts[2].Trim();
                    //string[] splitDate = parts[3].Trim().Split(" -".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    //pag = new DateTime(int.Parse(splitDate[0].Trim()), int.Parse(splitDate[1].Trim()), DateTime.Now.Day);
                    pag = DateTime.Parse(parts[3].Trim());
                    tech = DateTime.Parse(parts[4].Trim());
                    kur = double.Parse(parts[5].Trim());
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
            "---------------------------------------------------------------------------------------------------------------------------------\r\n" +
            " Nr. Valstybinis numeris     Gamintojas     Modelis     Pagaminimo data     Techninė apžiūra      Kuro likutis     Kuro sąnaudos \r\n" +
            "---------------------------------------------------------------------------------------------------------------------------------";

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
                    writer.WriteLine("---------------------------------------------------------------------------------------------------------------------------------\n");
                }
            }
        }

        private void Baigti_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void skaičiavimasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Spausdinti_Click(object sender, EventArgs e)
        {

        }

        private void Informacija_Click(object sender, EventArgs e)
        {
            string x = File.ReadAllText(rez);
            MessageBox.Show(x);
        }
    }
}
