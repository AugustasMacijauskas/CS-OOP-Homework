using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Studentai_GUI_List
{
    public partial class Form1 : Form
    {
        //const string duom1 = "..\\..\\Studentai.txt";
        //const string rez = "..\\..\\Rezultatai.txt";
        const string duom2 = "..\\..\\VertinimoSistema.txt";
        const string uzd = "..\\..\\Uzduotis.txt";
        const string nurodymai = "..\\..\\Nurodymai.txt";

        private List<Studentas> StudentuTestas;
        private List<Pazymys> Pazymiai;

        public Form1()
        {
            InitializeComponent();

            //label1.Text = "Studentų skaičius: " + Kiekis(StudentuTestas, 5).ToString();
            //label1.Text = "Studento indeksas: " + StudentoIndeksas(StudentuTestas, "Petraitis Petras").ToString();

            //MessageBox.Show(Kiekis(StudentuTestas, 5).ToString(), "Studentų skaičius:");
            //MessageBox.Show(StudentoIndeksas(StudentuTestas, "Petraitis Petras").ToString());
        }

        private void pavardeVrd_click(object sender, EventArgs e)
        {
            if (pavardeVrd.Text.Trim() != "" || pavardeVrd.Text != null)
            {
                pavardeVrd.Text = "";
            }
        }

        private void įvestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pazymiai = SkaitytiVertinimoSistema(duom2); // Komponento vertinimai užpildymas pažymiais
            foreach (Pazymys paz in Pazymiai)
                vertinimai.Items.Add(paz.ToString());
            vertinimai.SelectedIndex = 0; // parenkama 1-oji reikšmė 
            //OpenFileDialog komponento savybių nustatymas 
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // jeigu pasirinktas failas
            {
                string fv = openFileDialog1.FileName;
                //richTextBox1.LoadFile(fv, RichTextBoxStreamType.PlainText);
                string x = File.ReadAllText(fv);
                richTextBox1.Text = x;
                StudentuTestas = SkaitytiStudList(fv);
                // Meniu punktų nustatymai
                įvestiToolStripMenuItem.Enabled = false;
                spausdintiToolStripMenuItem.Enabled = true;
                studentųSkaičiusToolStripMenuItem.Enabled = true;
                studentoĮvertinimaiToolStripMenuItem.Enabled = true;
            }
        }

        private void spausdintiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Pasirinkite rezultatų failą";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fv = saveFileDialog1.FileName;
                if (File.Exists(fv))
                    File.Delete(fv);
                SpausdintiStudList(fv, StudentuTestas, "Studentų sąrašas (testo rezultatai):");

                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "Nr."; 
                dataGridView1.Columns[0].Width = 40;
                dataGridView1.Columns[1].Name = "Pavardė ir vardas";
                dataGridView1.Columns[1].Width = 280;
                dataGridView1.Columns[2].Name = "Pažymys";
                dataGridView1.Columns[2].Width = 80;
                for (int i = 0; i < StudentuTestas.Count; i++)
                {
                    Studentas studentas = StudentuTestas[i];
                    dataGridView1.Rows.Add(i + 1, studentas.PavVrd, studentas.Pazym);
                }
            }
        }

        private void studentųSkaičiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ivertis = vertinimai.SelectedItem.ToString().TrimStart();
            string[] eilDalis = ivertis.Split(' ');
            int pazymys = Int32.Parse(eilDalis[0]);
            int kiekis = Kiekis(StudentuTestas, pazymys);
            if (kiekis > 0)
                rezultatas.Text = "Studentų skaičius: " + kiekis.ToString();
            else 
                rezultatas.Text = "Tokių studentų nėra";
        }

        private void studentoĮvertinimaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pavVrd = pavardeVrd.Text;
            int index = StudentoIndeksas(StudentuTestas, pavVrd);
            if (index > -1)
            {
                Studentas stud = StudentuTestas[index];
                int pazymys = stud.Pazym;
                pavardeVrd.Text = pavardeVrd.Text + " -> pažymys: " + pazymys.ToString();
            }
            else
            {
                pavardeVrd.Text = pavardeVrd.Text + " -> tokio studento (-ės) nėra.";
            }
        }

        private void baigtiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void užduotisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string x = File.ReadAllText(uzd);
            richTextBox1.Text = x;
        }

        private void nurodymaiVartotojuiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string x = File.ReadAllText(nurodymai);
            richTextBox1.Text = x;
        }

        static int Kiekis(List<Studentas> StudTestas, int pazymys)
        {
            int kiek = 0;
            for (int i = 0; i < StudTestas.Count; i++)
            {
                if (StudTestas[i].Pazym == pazymys)
                    kiek++;
            }
            return kiek;
        }

        static int StudentoIndeksas(List<Studentas> StudTestas, string pavVrd)
        {
            for (int i = 0; i < StudTestas.Count; i++)
            {
                if (StudTestas[i].PavVrd == pavVrd)
                    return i;
            }
            return -1;
        }

        static List<Studentas> SkaitytiStudList(string fv)
        {
            List<Studentas> StudTestas = new List<Studentas>();
            using (StreamReader srautas = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string eilute; // visa duomenų failo eilutė
                while ((eilute = srautas.ReadLine()) != null)
                {
                    string[] eilDalis = eilute.Split(';');
                    string pavVrd = eilDalis[0];
                    int pazym = int.Parse(eilDalis[1]);
                    Studentas studentas = new Studentas(pavVrd, pazym);
                    StudTestas.Add(studentas);
                }
            }

            return StudTestas;
        }

        static List<Pazymys> SkaitytiVertinimoSistema(string fv)
        {
            List<Pazymys> VertSistema = new List<Pazymys>();
            using (StreamReader srautas = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string eilute;
                while ((eilute = srautas.ReadLine()) != null)
                {
                    string[] eilDalis = eilute.Split(';');
                    int pazym = int.Parse(eilDalis[0]);
                    string pazReiksme = eilDalis[1];
                    Pazymys pazymys = new Pazymys(pazym, pazReiksme);
                    VertSistema.Add(pazymys);
                }
            }

            return VertSistema;
        }

        static void SpausdintiStudList(string fv, List<Studentas> StudTestas, string antraste)
        {
            const string virsus = "-----------------------------------\r\n" +
                                  " Nr. Pavardė ir vardas     Pažymys \r\n" +
                                  "-----------------------------------";
            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append)))
            {
                fr.WriteLine("\n " + antraste);
                fr.WriteLine(virsus);
                for (int i = 0; i < StudTestas.Count; i++)
                {
                    Studentas stud = StudTestas[i];
                    fr.WriteLine("{0, 3}  {1}", i + 1, stud);
                }
                fr.WriteLine("-----------------------------------\n");
            }
        }
    }
}
