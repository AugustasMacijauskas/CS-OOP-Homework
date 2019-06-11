using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
using System.IO;
=======
>>>>>>> cfc5373580dd3e017a31e595e5e73ffbdcc6884d

namespace AutomobiliųParkas
{
    public partial class Form1 : Form
    {
<<<<<<< HEAD
        const string data = "..\\..\\Miestai1.txt";
        const string output = "..\\..\\output1.txt";
        const string apziura = "..\\..\\Apžiūra1.txt";
        const string pagalba = "..\\..\\NurodymaiVartotojui.txt";
        const string salygos = "..\\..\\NaudojimoSalygos.txt";
        Dictionary<string, Filialas> filialai;
        List<Transportas> automobiliai;

        public Form1()
        {
            InitializeComponent();

            if (File.Exists(output))
                File.Delete(output);
            if (File.Exists(apziura))
                File.Delete(apziura);

            spausdinti.Enabled = false;
            label1.Text = "Nuskaitykite failus.";
        }

        private void nuskaityti_Click(object sender, EventArgs e)
        {
            filialai = Read(data);
            automobiliai = Formuoti(filialai);
            Print(output, filialai, "Pradiniai duomenys:");
            nuskaityti.Enabled = false;
            spausdinti.Enabled = true;
            label1.Text = "Duomenys nuskaityti, galima spausdinti.";
        }

        private void spausdinti_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText(output);
            richTextBox1.Text = text;
            spausdinti.Enabled = false;
            label1.Text = "Duomenys atspausdinti.";
        }

        private void geriausiAuto_Click(object sender, EventArgs e)
        {
            Lengvasis geriausiasLengvasis = (Lengvasis)RastiGeriausiaGrupeje(automobiliai, typeof(Lengvasis));
            Krovininis geriausiasKrovininis = (Krovininis)RastiGeriausiaGrupeje(automobiliai, typeof(Krovininis));
            Mikroautobusas geriausiasMikroautobusas = (Mikroautobusas)RastiGeriausiaGrupeje(automobiliai, typeof(Mikroautobusas));

            printText(output, "Duomenys apie geriausius automobilius:");
            printText(output, "Lengvieji:");
            SpausdintiGeriausius(automobiliai, geriausiasLengvasis, typeof(Lengvasis));
            printText(output, "Krovininiai:");
            SpausdintiGeriausius(automobiliai, geriausiasKrovininis, typeof(Krovininis));
            printText(output, "Mikroautobusai:");
            SpausdintiGeriausius(automobiliai, geriausiasMikroautobusas, typeof(Mikroautobusas));

            label1.Text = "Geriausi automobiliai surasti, galima spausdinti.";
            spausdinti.Enabled = true;
        }

        private void seniausiMikroautobusai_Click(object sender, EventArgs e)
        {
            double averageAge = SeniausiasFilialas(filialai);
            printText(output, "Duomenys apie filialus, kuriuose mikroautobusai seniausi:");
            SpausdintiSeniausiusFilialus(filialai, averageAge);

            label1.Text = "Filialai su seniausiai mikroautobusais surasti, galima spausdinti.";
            spausdinti.Enabled = true;
        }

        private void krovininiaiAutomobiliai_Click(object sender, EventArgs e)
        {
            Dictionary<string, Filialas> krovininiaiFilialai = KroviniaiAutomobiliai(filialai);
            Print(output, krovininiaiFilialai, "Filialų krovininių automobilių sąrašai, surikiuoti pagal gamtintoją ir modelį:");

            label1.Text = "Filialų krovininių automobilių sąrašai surasti, galima spausdinti.";
            spausdinti.Enabled = true;
        }

        private void techninėApžiūra_Click(object sender, EventArgs e)
        {
            TechninėApžiūra(automobiliai);
            label1.Text = "Automobilių techninių apžiūrų datos surastos, jas galite rasti faile Apžiūra.txt.";
        }

        private void nurodymaiVartotojui_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText(pagalba);
            MessageBox.Show(text);
        }

        private void naudojimoSąlygos_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText(salygos);
            MessageBox.Show(text);
        }

        private void baigti_Click(object sender, EventArgs e)
        {
            Close();
        }

        static void TechninėApžiūra(List<Transportas> automobiliai)
        {
            TimeSpan twoYearSpan = DateTime.Now.AddYears(2).Subtract(DateTime.Now);
            TimeSpan yearSpan = DateTime.Now.AddYears(1).Subtract(DateTime.Now);
            TimeSpan halfYearSpan = DateTime.Now.AddMonths(6).Subtract(DateTime.Now);
            for (int i = 0; i < automobiliai.Count; i++)
            {
                DateTime techninesApziurosPabaiga = automobiliai[i].TechninėApžiūra + (automobiliai[i] is Lengvasis ? twoYearSpan : (automobiliai[i] is Krovininis ? yearSpan : halfYearSpan));
                if (techninesApziurosPabaiga < DateTime.Now)
                {
                    printText(apziura, automobiliai[i].TechninėApžiūraToString(techninesApziurosPabaiga) + " TECHNINĖ APŽIŪRA PASIBAIGUSI");
                }
                if (techninesApziurosPabaiga > DateTime.Now && techninesApziurosPabaiga < DateTime.Now.AddMonths(1))
                {
                    printText(apziura, automobiliai[i].TechninėApžiūraToString(techninesApziurosPabaiga));
                }
            }
        }

        static Dictionary<string, Filialas> KroviniaiAutomobiliai(Dictionary<string, Filialas> filialai)
        {
            Dictionary<string, Filialas> krovininiaiFilialai = new Dictionary<string, Filialas>();
            foreach (KeyValuePair<string, Filialas> entry in filialai)
            {
                List<Transportas> kroviniaiAuto = filialai[entry.Key].FilialoAutomobiliai().Where(x => x is Krovininis).ToList();
                Sort(kroviniaiAuto);
                Filialas naujasFilialas = new Filialas(filialai[entry.Key].FilialoDuomenys(), kroviniaiAuto);
                krovininiaiFilialai.Add(entry.Key, naujasFilialas);
            }

            return krovininiaiFilialai;
        }

        static void Sort(List<Transportas> filialoAutomobiliai)
        {
            int ind;
            for (int i = 0; i < filialoAutomobiliai.Count - 1; i++)
            {
                ind = i;
                for (int j = i + 1; j < filialoAutomobiliai.Count; j++)
                {
                    if ((Krovininis)filialoAutomobiliai[j] < (Krovininis)filialoAutomobiliai[ind])
                    {
                        ind = j;
                    }
                }
                var tempObj = filialoAutomobiliai[i];
                filialoAutomobiliai[i] = filialoAutomobiliai[ind];
                filialoAutomobiliai[ind] = tempObj;
            }
        }

        static void SpausdintiSeniausiusFilialus(Dictionary<string, Filialas> filialai, double vidAmz)
        {
            foreach(KeyValuePair<string, Filialas> entry in filialai)
            {
                if (VidutinisAmžiusFiliale(filialai[entry.Key].FilialoAutomobiliai()) == vidAmz)
                {
                    printText(output, filialai[entry.Key].FilialoDuomenys().ToString());
                }
            }
        }

        static double SeniausiasFilialas(Dictionary<string, Filialas> filialai)
        {
            List<string> keys = filialai.Keys.ToList();
            double vidutinisAmžius = VidutinisAmžiusFiliale(filialai[keys[0]].FilialoAutomobiliai());
            for (int i = 1; i < keys.Count; i++)
            {
                double naujasVid = VidutinisAmžiusFiliale(filialai[keys[i]].FilialoAutomobiliai());
                if (naujasVid > vidutinisAmžius)
                {
                    vidutinisAmžius = naujasVid;
                }
            }

            return vidutinisAmžius;
        }

        static double VidutinisAmžiusFiliale(List<Transportas> automobiliai)
        {
            double suma = 0;
            for (int i = 0; i < automobiliai.Count; i++)
            {
                if (automobiliai[i] is Mikroautobusas)
                    suma += (DateTime.Now.Year - automobiliai[i].PagaminimoData.Year);
            }

            return suma / automobiliai.Count;
        }

        static void SpausdintiGeriausius(List<Transportas> automobiliai, Transportas geriausias, Type tipas)
        {
            double papildomasRodiklis = geriausias.PapildomasRodiklis();
            for (int i = 0; i < automobiliai.Count; i++)
            {
                if (automobiliai[i].GetType() == tipas && automobiliai[i].PapildomasRodiklis() == papildomasRodiklis)
                    printText(output, "Gamintojas: " + automobiliai[i].Gamintojas + ";\nModelis: " + automobiliai[i].Modelis + ";\nValstybinis numeris: " + automobiliai[i].ValstybinisNumeris + ";\nAmžius: " + (DateTime.Now.Year - automobiliai[i].PagaminimoData.Year) + ";\nPapildomas rodiklis: " + automobiliai[i].PapildomasRodiklis() + ";\n");

            }
        }

        static Transportas RastiGeriausiaGrupeje(List<Transportas> automobiliai, Type tipas)
        {
            Transportas geriausiasAuto = automobiliai[0];
            int i;
            for (i = 0; i < automobiliai.Count; i++)
            {
                if (automobiliai[i].GetType() == tipas)
                {
                    geriausiasAuto = automobiliai[i];
                    break;
                }
            }

            for (int j = i + 1; j < automobiliai.Count; j++)
            {
                if (automobiliai[j].GetType() == tipas && automobiliai[j].CompareTo(geriausiasAuto) == 1)
                {
                    geriausiasAuto = automobiliai[j];
                }
            }

            return geriausiasAuto;
        }

        static List<Transportas> Formuoti(Dictionary<string, Filialas> automobiliai)
        {
            List<Transportas> naujiAuto = new List<Transportas>();
            foreach (KeyValuePair<string, Filialas> entry in automobiliai)
            {
                foreach(Transportas auto in automobiliai[entry.Key].FilialoAutomobiliai())
                {
                    naujiAuto.Add(auto);
                }
            }

            return naujiAuto;
        }

        static Dictionary<string, Filialas> Read(string data)
        {
            Dictionary<string, Filialas> tempDict = new Dictionary<string, Filialas>();
            string[] filialai = File.ReadAllLines(data);
            foreach(string miestas in filialai)
            {
                using (StreamReader reader = new StreamReader("..\\..\\" + miestas + ".txt"))
                {
                    string miestoPav, adresas, elPastas;
                    string line;
                    miestoPav = reader.ReadLine();
                    adresas = reader.ReadLine();
                    elPastas = reader.ReadLine();

                    string ValstybinisNumeris;
                    string Gamintojas;
                    string Modelis;
                    DateTime PagaminimoData;
                    DateTime TechninėApžiūra;
                    string Kuras;
                    double VidutinėsSąnaudos;

                    List<Transportas> automobiliai = new List<Transportas>();

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        ValstybinisNumeris = parts[1].Trim();
                        Gamintojas = parts[2].Trim();
                        Modelis = parts[3].Trim();
                        PagaminimoData = DateTime.Parse(parts[4].Trim());
                        TechninėApžiūra = DateTime.Parse(parts[5].Trim());
                        Kuras = parts[6].Trim();
                        VidutinėsSąnaudos = double.Parse(parts[7].Trim());

                        switch (parts[0].Trim())
                        {
                            case "l":
                                double OdometroRodmenys = double.Parse(parts[8].Trim());
                                var naujasAutomobilisL = new Lengvasis(ValstybinisNumeris, Gamintojas, Modelis, PagaminimoData, TechninėApžiūra, Kuras, VidutinėsSąnaudos, OdometroRodmenys);
                                automobiliai.Add(naujasAutomobilisL);
                                break;
                            case "k":
                                double PriekabosTalpa = double.Parse(parts[8].Trim());
                                var naujasAutomobilisK = new Krovininis(ValstybinisNumeris, Gamintojas, Modelis, PagaminimoData, TechninėApžiūra, Kuras, VidutinėsSąnaudos, PriekabosTalpa);
                                automobiliai.Add(naujasAutomobilisK);
                                break;
                            case "m":
                                int SėdimųVietų = int.Parse(parts[8].Trim());
                                var naujasAutomobilisM = new Mikroautobusas(ValstybinisNumeris, Gamintojas, Modelis, PagaminimoData, TechninėApžiūra, Kuras, VidutinėsSąnaudos, SėdimųVietų);
                                automobiliai.Add(naujasAutomobilisM);
                                break;
                            default:
                                printText(output, "Klaida nuskaitant duomenis!\n");
                                break;
                        }
                    }

                    FilialoDuomenys naujoFilialoDuomenys = new FilialoDuomenys(miestoPav, adresas, elPastas);
                    Filialas naujasFilialas = new Filialas(naujoFilialoDuomenys, automobiliai);
                    tempDict.Add(miestas, naujasFilialas);
                }
            }

            return tempDict;
        }

        static void printText(string file, string text)
        {
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(text);
            }
        }

        static void Print(string file, Dictionary<string, Filialas> filialai, string title)
        {
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(title);
                foreach (KeyValuePair<string, Filialas> entry in filialai)
                {
                    writer.WriteLine(filialai[entry.Key].ToString());
                }
            }
        }
    }
}
=======
        public Form1()
        {
            InitializeComponent();
        }
    }
}
>>>>>>> cfc5373580dd3e017a31e595e5e73ffbdcc6884d
