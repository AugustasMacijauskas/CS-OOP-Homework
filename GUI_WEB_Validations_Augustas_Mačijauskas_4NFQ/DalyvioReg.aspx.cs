using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DalyvioReg : System.Web.UI.Page
{
    class Dalyvis
    {
        public string Vardas { get; set; }
        public string Pavardė { get; set; }
        public string Mokykla { get; set; }
        public int Amžius { get; set; }
        private List<string> Kalbos;

        public Dalyvis(string vardas, string pavarde, string mokykla, int amzius, List<string> kalbos)
        {
            this.Vardas = vardas;
            this.Pavardė = pavarde;
            this.Mokykla = mokykla;
            this.Amžius = amzius;
            this.Kalbos = kalbos;
        }

        public string KalbosToString()
        {
            string ret = "";
            for (int i = 0; i < Kalbos.Count - 1; i++)
            {
                ret += Kalbos[i] + ", ";
            }
            ret += Kalbos[Kalbos.Count - 1];

            return ret;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Session["dalyviai"] is List<Dalyvis>))
            Session["dalyviai"] = new List<Dalyvis>();
        FillDropDownList();
        FillTableHeadings();
        FillTable();
    }

    protected void FillTable()
    {
        List<Dalyvis> dalyviai = (List<Dalyvis>)Session["dalyviai"];
        Table1.Rows.Clear();
        FillTableHeadings();

        for (int i = 0; i < dalyviai.Count; i++)
        {
            TableRow temp = new TableRow();
            TableCell numeris = new TableCell();
            numeris.Text = "" + (i + 1);
            temp.Cells.Add(numeris);

            TableCell v = new TableCell();
            v.Text = dalyviai[i].Vardas;
            temp.Cells.Add(v);

            TableCell p = new TableCell();
            p.Text = dalyviai[i].Pavardė;
            temp.Cells.Add(p);

            TableCell mokykla = new TableCell();
            mokykla.Text = dalyviai[i].Mokykla;
            temp.Cells.Add(mokykla);

            TableCell amzius = new TableCell();
            amzius.Text = "" + dalyviai[i].Amžius;
            temp.Cells.Add(amzius);

            TableCell kalbos = new TableCell();
            kalbos.Text = "" + dalyviai[i].KalbosToString();
            temp.Cells.Add(kalbos);

            Table1.Rows.Add(temp);
        }

        Label5.Text = "Iš viso: " + dalyviai.Count;
    }

    protected void FillTableHeadings()
    {
        TableHeaderCell nr = new TableHeaderCell();
        nr.Text = "Nr.";
        TableHeaderCell v = new TableHeaderCell();
        v.Text = "Vardas";
        TableHeaderCell p = new TableHeaderCell();
        p.Text = "Pavardė";
        TableHeaderCell mokykla = new TableHeaderCell();
        mokykla.Text = "Mokykla";
        TableHeaderCell amzius = new TableHeaderCell();
        amzius.Text = "Amžius";
        TableHeaderCell kalbos = new TableHeaderCell();
        kalbos.Text = "Kalbos";

        TableRow row = new TableRow();
        row.Cells.Add(nr);
        row.Cells.Add(v);
        row.Cells.Add(p);
        row.Cells.Add(mokykla);
        row.Cells.Add(amzius);
        row.Cells.Add(kalbos);
        Table1.Rows.Add(row);
    }

    protected void FillDropDownList()
    {
        if (DropDownList1.Items.Count == 0)
        {
            DropDownList1.Items.Add("-");
            for (int i = 14; i <= 25; i++)
            {
                DropDownList1.Items.Add(i.ToString());
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        VardasError.Text = "";
        PavardeError.Text = "";
        Label6.Text = "*";
        List<Dalyvis> dalyviai = (List<Dalyvis>)Session["dalyviai"];
        string vardas = TextBox1.Text;
        string pavarde = TextBox3.Text;
        string mokykla = TextBox4.Text;
        int amzius = int.Parse(DropDownList1.Text);
        List<string> kalbos = CheckBoxList1.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.ToString()).ToList();
        if (vardas != null && vardas != "" && !containsNumbers(vardas) && !containsNumbers(pavarde) && kalbos.Count > 0)
        {
            Dalyvis naujas = new Dalyvis(vardas, pavarde, mokykla, amzius, kalbos);
            dalyviai.Add(naujas);
            Session["dalyviai"] = dalyviai;
            FillTable();
        }
        else
        {
            if (containsNumbers(vardas))
            {
                VardasError.Text = "Neteisingas vardo formatas.";
            }
            if (containsNumbers(pavarde))
            {
                PavardeError.Text = "Neteisingas pavardės formatas.";
            }
            if (kalbos.Count == 0)
            {
                Label6.Text = "Privaloma pasirinkti bent vieną programavimo kalbą.";
            }
        }

    }

    protected bool containsNumbers(string s)
    {
        const string numbers = "0123456789";
        for (int i = 0; i < numbers.Length; i++)
        {
            if (s.Contains(numbers[i]))
            {
                return true;
            }
        }

        return false;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        List<Dalyvis> dalyviai = (List<Dalyvis>)Session["dalyviai"];
        dalyviai.Clear();
        Session["dalyviai"] = dalyviai;
        FillTable();
    }
}