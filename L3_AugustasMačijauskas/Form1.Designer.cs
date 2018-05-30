namespace L3_AugustasMačijauskas
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
            this.Ivesti = new System.Windows.Forms.ToolStripMenuItem();
            this.Baigti = new System.Windows.Forms.ToolStripMenuItem();
            this.skaičiavimasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Skaiciuoti = new System.Windows.Forms.ToolStripMenuItem();
            this.Spausdinti = new System.Windows.Forms.ToolStripMenuItem();
            this.pagalbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Informacija = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1241, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // failasToolStripMenuItem
            // 
            this.failasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ivesti,
            this.Baigti});
            this.failasToolStripMenuItem.Name = "failasToolStripMenuItem";
            this.failasToolStripMenuItem.Size = new System.Drawing.Size(48, 19);
            this.failasToolStripMenuItem.Text = "Failas";
            // 
            // Ivesti
            // 
            this.Ivesti.Name = "Ivesti";
            this.Ivesti.Size = new System.Drawing.Size(104, 22);
            this.Ivesti.Text = "Įvesti";
            this.Ivesti.Click += new System.EventHandler(this.įvestiToolStripMenuItem_Click);
            // 
            // Baigti
            // 
            this.Baigti.Name = "Baigti";
            this.Baigti.Size = new System.Drawing.Size(104, 22);
            this.Baigti.Text = "Baigti";
            this.Baigti.Click += new System.EventHandler(this.Baigti_Click);
            // 
            // skaičiavimasToolStripMenuItem
            // 
            this.skaičiavimasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Skaiciuoti,
            this.Spausdinti});
            this.skaičiavimasToolStripMenuItem.Name = "skaičiavimasToolStripMenuItem";
            this.skaičiavimasToolStripMenuItem.Size = new System.Drawing.Size(86, 19);
            this.skaičiavimasToolStripMenuItem.Text = "Skaičiavimas";
            // 
            // Skaiciuoti
            // 
            this.Skaiciuoti.Name = "Skaiciuoti";
            this.Skaiciuoti.Size = new System.Drawing.Size(129, 22);
            this.Skaiciuoti.Text = "Skaičiuoti";
            this.Skaiciuoti.Click += new System.EventHandler(this.Skaiciuoti_Click);
            // 
            // Spausdinti
            // 
            this.Spausdinti.Name = "Spausdinti";
            this.Spausdinti.Size = new System.Drawing.Size(129, 22);
            this.Spausdinti.Text = "Spausdinti";
            this.Spausdinti.Click += new System.EventHandler(this.Spausdinti_Click);
            // 
            // pagalbaToolStripMenuItem
            // 
            this.pagalbaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Informacija});
            this.pagalbaToolStripMenuItem.Name = "pagalbaToolStripMenuItem";
            this.pagalbaToolStripMenuItem.Size = new System.Drawing.Size(61, 19);
            this.pagalbaToolStripMenuItem.Text = "Pagalba";
            // 
            // Informacija
            // 
            this.Informacija.Name = "Informacija";
            this.Informacija.Size = new System.Drawing.Size(134, 22);
            this.Informacija.Text = "Informacija";
            this.Informacija.Click += new System.EventHandler(this.Informacija_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 11.25F);
            this.richTextBox1.Location = new System.Drawing.Point(13, 35);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1215, 462);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 506);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(409, 24);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Įveskite norimą automobilio modelį";
            this.textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(722, 506);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pranešimas";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 588);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Automobiliai";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skaičiavimasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagalbaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Ivesti;
        private System.Windows.Forms.ToolStripMenuItem Baigti;
        private System.Windows.Forms.ToolStripMenuItem Skaiciuoti;
        private System.Windows.Forms.ToolStripMenuItem Spausdinti;
        private System.Windows.Forms.ToolStripMenuItem Informacija;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

