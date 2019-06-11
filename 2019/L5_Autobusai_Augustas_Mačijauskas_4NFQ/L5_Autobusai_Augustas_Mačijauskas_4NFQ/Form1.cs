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

namespace L5_Autobusai_Augustas_Mačijauskas_4NFQ
{
    public partial class Form1 : Form
    {
        const string marsrutaiDuomenys = "..\\..\\U2a.txt";
        const string keleiviaiDuomenys = "..\\..\\U2b.txt";
        const string rezultatai = "..\\..\\rez.txt";

        private List<Marsrutas> marsrutai = new List<Marsrutas>();
        private List<Keleivis> keleiviai = new List<Keleivis>();

        private List<Marsrutas> atrinktiMarsrutai = new List<Marsrutas>();
        private List<Marsrutas> pelningiausiMarsrutai = new List<Marsrutas>();

        public Form1()
        {
            InitializeComponent();

            if (File.Exists(rezultatai))
                File.Delete(rezultatai);

            atrinktiMaršrutusToolStripMenuItem.Enabled = false;
            rastiPelningiausiąToolStripMenuItem.Enabled = false;
        }

        private void įvestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SkaitytiMarsrutus(marsrutaiDuomenys, marsrutai);
            SkaitytiKeleivius(keleiviaiDuomenys, keleiviai);
            Spausdinti(rezultatai, marsrutai, "Pradiniai maršrutų duomenys:", Marsrutas.Header, Marsrutas.Divider);
            Spausdinti(rezultatai, keleiviai, "Pradiniai keleivių duomenys:", Keleivis.Header, Keleivis.Divider);
            string x = File.ReadAllText(rezultatai);
            richTextBox1.Text = x;

            įvestiToolStripMenuItem.Enabled = false;
            atrinktiMaršrutusToolStripMenuItem.Enabled = true;
            rastiPelningiausiąToolStripMenuItem.Enabled = true;
        }

        private void atrinktiMaršrutusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtrinktiMarsrutus(marsrutai, keleiviai, atrinktiMarsrutai);
            Spausdinti(rezultatai, atrinktiMarsrutai, "Atrinkti maršrutai:", Marsrutas.Header, Marsrutas.Divider);
            string x = File.ReadAllText(rezultatai);
            richTextBox1.Text = x;

            atrinktiMaršrutusToolStripMenuItem.Enabled = false;
        }

        private void rastiPelningiausiąToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PelningiausiMarsrutai(marsrutai, keleiviai, pelningiausiMarsrutai);
            Spausdinti(rezultatai, pelningiausiMarsrutai, "Pelningiausi maršrutai:", Marsrutas.Header, Marsrutas.Divider);
            string x = File.ReadAllText(rezultatai);
            richTextBox1.Text = x;

            rastiPelningiausiąToolStripMenuItem.Enabled = false;
        }

        private void baigtiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AtrinktiMarsrutus(List<Marsrutas> marsrutai, List<Keleivis> keleiviai, List<Marsrutas> naujas)
        {
            for (int i = 0; i < marsrutai.Count; i++)
            {
                for (int j = 0; j < keleiviai.Count; j++)
                {
                    if (keleiviai[j].MarsrutoNumeris == marsrutai[i].MarsrutoNumeris
                        && keleiviai[j].SavaitesDiena == marsrutai[i].SavaitesDiena
                        && keleiviai[j].IsvykimoLaikas == marsrutai[i].IsvykimoLaikas)
                    {
                        naujas.Add(marsrutai[i]);
                        break;
                    }
                }
            }
        }

        private void PelningiausiMarsrutai(List<Marsrutas> marsrutai, List<Keleivis> keleiviai, List<Marsrutas> naujas)
        {
            double didziausiasPelnas = 0.0;
            for (int i = 0; i < marsrutai.Count; i++)
            {
                double tarpineSuma = 0.0;
                for (int j = 0; j < keleiviai.Count; j++)
                {
                    if (keleiviai[j].MarsrutoNumeris == marsrutai[i].MarsrutoNumeris
                        && keleiviai[j].SavaitesDiena == marsrutai[i].SavaitesDiena
                        && keleiviai[j].IsvykimoLaikas == marsrutai[i].IsvykimoLaikas)
                    {
                        tarpineSuma += marsrutai[i].Kaina;
                    }
                }

                // Galima butu sudeti i lista, kad nereiktu antra karta skaiciuoti
                if (tarpineSuma > didziausiasPelnas)
                {
                    didziausiasPelnas = tarpineSuma;
                }
            }

            for (int i = 0; i < marsrutai.Count; i++)
            {
                double tarpineSuma = 0.0;
                for (int j = 0; j < keleiviai.Count; j++)
                {
                    if (keleiviai[j].MarsrutoNumeris == marsrutai[i].MarsrutoNumeris
                        && keleiviai[j].SavaitesDiena == marsrutai[i].SavaitesDiena
                        && keleiviai[j].IsvykimoLaikas == marsrutai[i].IsvykimoLaikas)
                    {
                        tarpineSuma += marsrutai[i].Kaina;
                    }
                }

                if (Math.Abs(tarpineSuma - didziausiasPelnas) <= 0.0001)
                {
                    naujas.Add(marsrutai[i]);
                }
            }
        }

        private void SkaitytiMarsrutus(string file, List<Marsrutas> marsrutai)
        {
            using (var reader = new StreamReader(file))
            {
                string line;

                while((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    Marsrutas naujas = new Marsrutas(
                        int.Parse(parts[0].Trim()),
                        (SavaitesDienos)int.Parse(parts[1].Trim()),
                        DateTime.Parse(parts[2].Trim()),
                        double.Parse(parts[3].Trim())
                    );
                    marsrutai.Add(naujas);
                }
            }
        }

        private void SkaitytiKeleivius(string file, List<Keleivis> keleiviai)
        {
            using (var reader = new StreamReader(file))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    Keleivis naujas = new Keleivis(
                        parts[0].Trim(),
                        parts[1].Trim(),
                        (SavaitesDienos)int.Parse(parts[2].Trim()),
                        DateTime.Parse(parts[3].Trim()),
                        int.Parse(parts[4].Trim())
                    );
                    keleiviai.Add(naujas);
                }
            }
        }

        private void Spausdinti<T>(string file, List<T> sarasas, string antraste, string header, string divider)
        {
            using (var writer = new StreamWriter(file, true))
            {
                writer.WriteLine(antraste);
                if (sarasas.Count > 0)
                {
                    writer.WriteLine(header);
                    for (int i = 0; i < sarasas.Count; i++)
                    {
                        writer.WriteLine(sarasas[i]);
                    }
                    writer.WriteLine(divider + "\r\n");
                }
                else
                {
                    writer.WriteLine("Sąrašas tuščias!\r\n");
                }
            }
        }
    }
}
