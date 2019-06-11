using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SesijaWEB : System.Web.UI.Page
{
    private String text;
    protected void Page_Load(object sender, EventArgs e)
    {
        text = (string)Session["text"];
        insertEntry(text);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        text = TextBox1.Text;
        insertEntry(text);
        Session["text"] = text;
    }

    private void insertEntry(string tekstas)
    {
        TableCell cell = new TableCell();
        cell.Text = tekstas;

        TableRow row = new TableRow();
        row.Cells.Add(cell);

        Table1.Rows.Add(row);
    }
}