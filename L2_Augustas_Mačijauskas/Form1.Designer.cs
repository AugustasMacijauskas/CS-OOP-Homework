namespace L2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.failasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuskaityti = new System.Windows.Forms.ToolStripMenuItem();
            this.baigti = new System.Windows.Forms.ToolStripMenuItem();
            this.skaičiavimasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skaiciuoti = new System.Windows.Forms.ToolStripMenuItem();
            this.print = new System.Windows.Forms.ToolStripMenuItem();
            this.pridėtiNaujų = new System.Windows.Forms.ToolStripMenuItem();
            this.išsaugoti = new System.Windows.Forms.ToolStripMenuItem();
            this.pagalbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nurodymaiVartotojuiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.naudojimoSąlygosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failasToolStripMenuItem,
            this.skaičiavimasToolStripMenuItem,
            this.pagalbaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(913, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // failasToolStripMenuItem
            // 
            this.failasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuskaityti,
            this.baigti});
            this.failasToolStripMenuItem.Name = "failasToolStripMenuItem";
            this.failasToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.failasToolStripMenuItem.Text = "Failas";
            // 
            // nuskaityti
            // 
            this.nuskaityti.Name = "nuskaityti";
            this.nuskaityti.Size = new System.Drawing.Size(152, 22);
            this.nuskaityti.Text = "Įvesti";
            this.nuskaityti.Click += new System.EventHandler(this.nuskaityti_Click);
            // 
            // baigti
            // 
            this.baigti.Name = "baigti";
            this.baigti.Size = new System.Drawing.Size(152, 22);
            this.baigti.Text = "Baigti";
            this.baigti.Click += new System.EventHandler(this.baigti_Click);
            // 
            // skaičiavimasToolStripMenuItem
            // 
            this.skaičiavimasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skaiciuoti,
            this.print,
            this.pridėtiNaujų,
            this.išsaugoti});
            this.skaičiavimasToolStripMenuItem.Name = "skaičiavimasToolStripMenuItem";
            this.skaičiavimasToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.skaičiavimasToolStripMenuItem.Text = "Skaičiavimas";
            // 
            // skaiciuoti
            // 
            this.skaiciuoti.Name = "skaiciuoti";
            this.skaiciuoti.Size = new System.Drawing.Size(152, 22);
            this.skaiciuoti.Text = "Skaičiuoti";
            this.skaiciuoti.Click += new System.EventHandler(this.skaiciuoti_Click);
            // 
            // print
            // 
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(152, 22);
            this.print.Text = "Spausdinti";
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // pridėtiNaujų
            // 
            this.pridėtiNaujų.Name = "pridėtiNaujų";
            this.pridėtiNaujų.Size = new System.Drawing.Size(152, 22);
            this.pridėtiNaujų.Text = "Nauji žaidėjai";
            this.pridėtiNaujų.Click += new System.EventHandler(this.pridėtiNaujų_Click);
            // 
            // išsaugoti
            // 
            this.išsaugoti.Name = "išsaugoti";
            this.išsaugoti.Size = new System.Drawing.Size(152, 22);
            this.išsaugoti.Text = "Išsaugoti";
            this.išsaugoti.Click += new System.EventHandler(this.išsaugoti_Click);
            // 
            // pagalbaToolStripMenuItem
            // 
            this.pagalbaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nurodymaiVartotojuiToolStripMenuItem,
            this.naudojimoSąlygosToolStripMenuItem});
            this.pagalbaToolStripMenuItem.Name = "pagalbaToolStripMenuItem";
            this.pagalbaToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.pagalbaToolStripMenuItem.Text = "Pagalba";
            // 
            // nurodymaiVartotojuiToolStripMenuItem
            // 
            this.nurodymaiVartotojuiToolStripMenuItem.Name = "nurodymaiVartotojuiToolStripMenuItem";
            this.nurodymaiVartotojuiToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.nurodymaiVartotojuiToolStripMenuItem.Text = "Nurodymai vartotojui";
            this.nurodymaiVartotojuiToolStripMenuItem.Click += new System.EventHandler(this.nurodymaiVartotojuiToolStripMenuItem_Click);
            // 
            // naudojimoSąlygosToolStripMenuItem
            // 
            this.naudojimoSąlygosToolStripMenuItem.Name = "naudojimoSąlygosToolStripMenuItem";
            this.naudojimoSąlygosToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.naudojimoSąlygosToolStripMenuItem.Text = "Naudojimo sąlygos";
            this.naudojimoSąlygosToolStripMenuItem.Click += new System.EventHandler(this.naudojimoSąlygosToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.richTextBox1.Location = new System.Drawing.Point(13, 28);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(887, 470);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(528, 515);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pranešimas";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textBox1.Location = new System.Drawing.Point(13, 515);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(274, 26);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Įveskite norimą amžių";
            this.textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 592);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Krepšininkai";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuskaityti;
        private System.Windows.Forms.ToolStripMenuItem baigti;
        private System.Windows.Forms.ToolStripMenuItem skaičiavimasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skaiciuoti;
        private System.Windows.Forms.ToolStripMenuItem print;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem pridėtiNaujų;
        private System.Windows.Forms.ToolStripMenuItem išsaugoti;
        private System.Windows.Forms.ToolStripMenuItem pagalbaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nurodymaiVartotojuiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem naudojimoSąlygosToolStripMenuItem;
    }
}

