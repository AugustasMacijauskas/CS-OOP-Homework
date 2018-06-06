using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafineSasaja1
{
    public partial class Form1 : Form
    {
        double ilgis, plotis, plotas;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ilgis = Convert.ToDouble(textBox1.Text);
            plotis = Convert.ToDouble(textBox2.Text);
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            plotas = Plotas(ilgis, plotis);
            label3.Text = "Stačiakampio plotas: " + Convert.ToString(plotas);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        static double Plotas(double ilg, double plot)
        {
            return ilg * plot;
        }
    }
}
