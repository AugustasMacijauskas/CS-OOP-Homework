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

namespace BendrinesKlasesSavarankiskas
{
    public partial class Form1 : Form
    {
        const string CFGrupes = "..\\..\\Grupes.txt";
        const string CFBakalaurai = "..\\..\\Bakalaurai.txt";
        const string CFMagistrantai = "..\\..\\Magistrantai.txt";

        private Dictionary<string, Grupe<Bakalauras>> bakalauruGrupes = new Dictionary<string, Grupe<Bakalauras>>();
        private Dictionary<string, Grupe<Magistrantas>> magistrantuGrupes = new Dictionary<string, Grupe<Magistrantas>>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        static void SkaitytiGrupes(string failas, Dictionary<string, Grupe<Bakalauras>> bakalauruGrupes, Dictionary<string, Grupe<Magistrantas>> magistrantuGrupes)
        {
            using (StreamReader reader = new StreamReader(failas, Encoding.GetEncoding(1257)))
            {
                string line; while ((line = reader.ReadLine()) != null)
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
    }
}
