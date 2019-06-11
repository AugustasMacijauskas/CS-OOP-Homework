using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BendrinesKlases
{
    public partial class studentai : Form
    {
        const string CFGrupes = "..\\..\\Grupes.txt";
        const string CFBakalaurai = "..\\..\\Bakalaurai.txt";
        const string CFMagistrantai = "..\\..\\Magistrantai.txt";

        private Dictionary<string, Grupe<Bakalauras>> bakalauruGrupes = new Dictionary<string, Grupe<Bakalauras>>();
        private Dictionary<string, Grupe<Magistrantas>> magistrantuGrupes = new Dictionary<string, Grupe<Magistrantas>>();

        public studentai()
        {
            InitializeComponent();

            parodytiSarasus.Enabled = false;
        }

        private void ivestiMeniu_Click(object sender, EventArgs e)
        {
            ivestiMeniu.Enabled = false;
            parodytiSarasus.Enabled = true;

            SkaitytiGrupes(CFGrupes, bakalauruGrupes, magistrantuGrupes);
            SkaitytiBakalaurus(CFBakalaurai, bakalauruGrupes);
            SkaitytiMagistrantus(CFMagistrantai, magistrantuGrupes);

            foreach (KeyValuePair<string, Grupe<Bakalauras>> irasas in bakalauruGrupes)
            {
                SukurtiGrupesPuslapi(irasas.Value);
            }

            foreach (KeyValuePair<string, Grupe<Magistrantas>> irasas in magistrantuGrupes)
            {
                SukurtiGrupesPuslapi(irasas.Value);
            }
        }

        private void parodytiSarasus_Click(object sender, EventArgs e)
        {
            parodytiSarasus.Enabled = false;

            SukurtiPuslapi(bakalauruGrupes, "Bakalaurai");
            SukurtiPuslapi(magistrantuGrupes, "Magistrantai");
        }

        private void baigtiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SukurtiPuslapi<T>(Dictionary<string, Grupe<T>> grupes, string tabName) where T : Studentas
        {
            List<Studentas> sarasas = new List<Studentas>();
            foreach (var irasas in grupes)
            {
                sarasas.AddRange(irasas.Value.StudentuSarasas);
            }

            sarasas.Sort();

            TabPage naujasPuslapis = new TabPage(tabName);
            tabControl1.TabPages.Add(naujasPuslapis);

            FlowLayoutPanel skydelis = new FlowLayoutPanel();
            skydelis.Dock = DockStyle.Fill;
            skydelis.FlowDirection = FlowDirection.TopDown;
            naujasPuslapis.Controls.Add(skydelis);

            DataGridView tinklelis = new DataGridView();

            tinklelis.AutoGenerateColumns = false;
            tinklelis.RowHeadersVisible = false;
            tinklelis.AllowUserToAddRows = false;
            tinklelis.AllowUserToDeleteRows = false;

            tinklelis.AutoSize = true;
            tinklelis.BackgroundColor = Color.White;

            BindingSource duomenuModelis = new BindingSource();
            foreach (Studentas s in sarasas)
            {
                duomenuModelis.Add(s);
            }

            tinklelis.DataSource = duomenuModelis;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "PazymejimoNr"; //nurodome Studento objekto sąvybės pavadinimą
            column.Name = "Paž. nr."; //nurodome stulpelio pavadinimą
            column.ReadOnly = true;
            tinklelis.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Vardas";
            column.Name = "Vardas";
            column.ReadOnly = true;
            tinklelis.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Pavarde";
            column.Name = "Pavarde";
            column.ReadOnly = true;
            tinklelis.Columns.Add(column);

            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.DataSource = Enum.GetValues(typeof(Statusas));
            combo.DataPropertyName = "Statusas";
            combo.Name = "Statusas";
            tinklelis.Columns.Add(combo);

            if (typeof(T) == typeof(Magistrantas))
            {
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "Tema";
                column.Name = "Darbo tema";
                column.ReadOnly = true;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                tinklelis.Columns.Add(column);
            }

            skydelis.Controls.Add(tinklelis);
        }

        private void SukurtiGrupesPuslapi<T>(Grupe<T> grupe) where T : Studentas
        {
            TabPage puslapis = new TabPage(grupe.Pavadinimas);
            tabControl1.TabPages.Add(puslapis);

            FlowLayoutPanel skydelis = new FlowLayoutPanel();
            skydelis.Dock = DockStyle.Fill;
            skydelis.FlowDirection = FlowDirection.TopDown;
            puslapis.Controls.Add(skydelis);

            Label kursas = new Label();
            kursas.Text = "Kursas: " + grupe.Kursas;
            kursas.AutoSize = true;
            skydelis.Controls.Add(kursas);

            Label specializacija = new Label();
            specializacija.Text = "Specializacija: " + grupe.Specializacija;
            specializacija.AutoSize = true;
            skydelis.Controls.Add(specializacija);

            Label kuratorius = new Label();
            kuratorius.Text = "Kuratorius: " + grupe.Kuratorius;
            kuratorius.AutoSize = true;
            skydelis.Controls.Add(kuratorius);


            // Kuriame studentų lentelę:
            DataGridView tinklelis = new DataGridView();

            tinklelis.AutoGenerateColumns = false;
            tinklelis.RowHeadersVisible = false;
            tinklelis.AllowUserToAddRows = false;
            tinklelis.AllowUserToDeleteRows = false;

            tinklelis.AutoSize = true;
            tinklelis.BackgroundColor = Color.White;

            BindingSource duomenuModelis = new BindingSource();
            foreach (Studentas s in grupe.StudentuSarasas)
            {
                duomenuModelis.Add(s);
            }

            tinklelis.DataSource = duomenuModelis;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "PazymejimoNr"; //nurodome Studento objekto sąvybės pavadinimą
            column.Name = "Paž. nr."; //nurodome stulpelio pavadinimą
            column.ReadOnly = true;
            tinklelis.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Vardas";
            column.Name = "Vardas";
            column.ReadOnly = true;
            tinklelis.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Pavarde";
            column.Name = "Pavarde";
            column.ReadOnly = true;
            tinklelis.Columns.Add(column);

            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.DataSource = Enum.GetValues(typeof(Statusas));
            combo.DataPropertyName = "Statusas";
            combo.Name = "Statusas";
            tinklelis.Columns.Add(combo);

            if (typeof(T) == typeof(Magistrantas))
            {
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "Tema";
                column.Name = "Darbo tema";
                column.ReadOnly = true;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                tinklelis.Columns.Add(column);
            }

            skydelis.Controls.Add(tinklelis);

            // Geriausio studento atvaizdavimas:
            Label geriausiasTitle = new Label();
            geriausiasTitle.Text = "\nGeriausi studentai";
            geriausiasTitle.AutoSize = true;
            skydelis.Controls.Add(geriausiasTitle);

            DataGridView geriausias = new DataGridView();

            geriausias.AutoGenerateColumns = false;
            geriausias.RowHeadersVisible = false;
            geriausias.AllowUserToAddRows = false;
            geriausias.AllowUserToDeleteRows = false;

            geriausias.AutoSize = true;
            geriausias.BackgroundColor = Color.White;

            BindingSource geriausioDuomenuModelis = new BindingSource();
            foreach (Studentas s in grupe.GeriausiStudentai())
            {
                geriausioDuomenuModelis.Add(s);
            }

            geriausias.DataSource = geriausioDuomenuModelis;

            DataGridViewColumn geriausiasColumn = new DataGridViewTextBoxColumn();
            geriausiasColumn.DataPropertyName = "PazymejimoNr"; //nurodome Studento objekto sąvybės pavadinimą
            geriausiasColumn.Name = "Paž. nr."; //nurodome stulpelio pavadinimą
            geriausiasColumn.ReadOnly = true;
            geriausias.Columns.Add(geriausiasColumn);

            geriausiasColumn = new DataGridViewTextBoxColumn();
            geriausiasColumn.DataPropertyName = "Vardas";
            geriausiasColumn.Name = "Vardas";
            geriausiasColumn.ReadOnly = true;
            geriausias.Columns.Add(geriausiasColumn);

            geriausiasColumn = new DataGridViewTextBoxColumn();
            geriausiasColumn.DataPropertyName = "Pavarde";
            geriausiasColumn.Name = "Pavarde";
            geriausiasColumn.ReadOnly = true;
            geriausias.Columns.Add(geriausiasColumn);

            DataGridViewComboBoxColumn geriausiasCombo = new DataGridViewComboBoxColumn();
            geriausiasCombo.DataSource = Enum.GetValues(typeof(Statusas));
            geriausiasCombo.DataPropertyName = "Statusas";
            geriausiasCombo.Name = "Statusas";
            geriausias.Columns.Add(geriausiasCombo);

            if (typeof(T) == typeof(Magistrantas))
            {
                geriausiasColumn = new DataGridViewTextBoxColumn();
                geriausiasColumn.DataPropertyName = "Tema";
                geriausiasColumn.Name = "Darbo tema";
                geriausiasColumn.ReadOnly = true;
                geriausiasColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                geriausias.Columns.Add(geriausiasColumn);
            }

            skydelis.Controls.Add(geriausias);

            puslapis.Refresh();
        }

        static void SkaitytiGrupes(string failas,
            Dictionary<string, Grupe<Bakalauras>> bakalauruGrupes, Dictionary<string, Grupe<Magistrantas>> magistrantuGrupes)
        {
            using (StreamReader reader = new StreamReader(failas, Encoding.GetEncoding(1257)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string pozymis = parts[0].Trim();
                    int kursas = int.Parse(parts[1].Trim());
                    string grupe = parts[2].Trim();
                    string specializacija = parts[3].Trim();
                    string kuratorius = parts[4].Trim();

                    switch (pozymis)
                    {
                        case "B":
                            Grupe<Bakalauras> bg = new Grupe<Bakalauras>(grupe, kursas, specializacija, kuratorius);
                            bakalauruGrupes.Add(grupe, bg);
                            break;

                        case "M":
                            Grupe<Magistrantas> mg = new Grupe<Magistrantas>(grupe, kursas, specializacija, kuratorius);
                            magistrantuGrupes.Add(grupe, mg);
                            break;
                    }
                }
            }
        }

        static void SkaitytiBakalaurus(string failas, Dictionary<string, Grupe<Bakalauras>> bakalauruGrupes)
        {
            using (StreamReader reader = new StreamReader(failas, Encoding.GetEncoding(1257)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string vardas = parts[0].Trim();
                    string pavarde = parts[1].Trim();
                    string pazymejimoNr = parts[2].Trim();
                    string grupe = parts[3].Trim();
                    double vidurkis = double.Parse(parts[4].Trim());
                    Statusas statusas = (Statusas)Enum.Parse(typeof(Statusas), parts[5].Trim());
                    Bakalauras bakalauras = new Bakalauras(vardas, pavarde, pazymejimoNr, vidurkis, statusas);
                    bakalauruGrupes[grupe].StudentuSarasas.Add(bakalauras);
                }
            }
        }

        static void SkaitytiMagistrantus(string failas, Dictionary<string, Grupe<Magistrantas>> magistrantuGrupes)
        {
            using (StreamReader reader = new StreamReader(failas, Encoding.GetEncoding(1257)))
            {
                string line; while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string vardas = parts[0].Trim();
                    string pavarde = parts[1].Trim();
                    string pazymejimoNr = parts[2].Trim();
                    string grupe = parts[3].Trim();
                    double vidurkis = double.Parse(parts[4].Trim());
                    Statusas statusas = (Statusas)Enum.Parse(typeof(Statusas), parts[5].Trim());
                    string tema = parts[6].Trim();
                    Magistrantas magistrantas = new Magistrantas(vardas, pavarde, pazymejimoNr, vidurkis, statusas, tema);
                    magistrantuGrupes[grupe].StudentuSarasas.Add(magistrantas);
                }
            }
        }
    }
}
