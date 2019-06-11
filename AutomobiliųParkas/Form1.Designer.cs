namespace AutomobiliųParkas
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
            this.spausdinti = new System.Windows.Forms.ToolStripMenuItem();
            this.baigti = new System.Windows.Forms.ToolStripMenuItem();
            this.skaičiuotiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geriausiAuto = new System.Windows.Forms.ToolStripMenuItem();
            this.seniausiMikroautobusai = new System.Windows.Forms.ToolStripMenuItem();
            this.krovininiaiAutomobiliai = new System.Windows.Forms.ToolStripMenuItem();
            this.techninėApžiūra = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pagalbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nurodymaiVartotojui = new System.Windows.Forms.ToolStripMenuItem();
            this.naudojimoSąlygos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failasToolStripMenuItem,
            this.skaičiuotiToolStripMenuItem,
            this.pagalbaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1385, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // failasToolStripMenuItem
            // 
            this.failasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuskaityti,
            this.spausdinti,
            this.baigti});
            this.failasToolStripMenuItem.Name = "failasToolStripMenuItem";
            this.failasToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.failasToolStripMenuItem.Text = "Failas";
            // 
            // nuskaityti
            // 
            this.nuskaityti.Name = "nuskaityti";
            this.nuskaityti.Size = new System.Drawing.Size(129, 22);
            this.nuskaityti.Text = "Nuskaityti";
            this.nuskaityti.Click += new System.EventHandler(this.nuskaityti_Click);
            // 
            // spausdinti
            // 
            this.spausdinti.Name = "spausdinti";
            this.spausdinti.Size = new System.Drawing.Size(129, 22);
            this.spausdinti.Text = "Spausdinti";
            this.spausdinti.Click += new System.EventHandler(this.spausdinti_Click);
            // 
            // baigti
            // 
            this.baigti.Name = "baigti";
            this.baigti.Size = new System.Drawing.Size(129, 22);
            this.baigti.Text = "Baigti";
            this.baigti.Click += new System.EventHandler(this.baigti_Click);
            // 
            // skaičiuotiToolStripMenuItem
            // 
            this.skaičiuotiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.geriausiAuto,
            this.seniausiMikroautobusai,
            this.krovininiaiAutomobiliai,
            this.techninėApžiūra});
            this.skaičiuotiToolStripMenuItem.Name = "skaičiuotiToolStripMenuItem";
            this.skaičiuotiToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.skaičiuotiToolStripMenuItem.Text = "Skaičiavimas";
            // 
            // geriausiAuto
            // 
            this.geriausiAuto.Name = "geriausiAuto";
            this.geriausiAuto.Size = new System.Drawing.Size(203, 22);
            this.geriausiAuto.Text = "Geriausi automobiliai";
            this.geriausiAuto.Click += new System.EventHandler(this.geriausiAuto_Click);
            // 
            // seniausiMikroautobusai
            // 
            this.seniausiMikroautobusai.Name = "seniausiMikroautobusai";
            this.seniausiMikroautobusai.Size = new System.Drawing.Size(203, 22);
            this.seniausiMikroautobusai.Text = "Seniausi mikroautobusai";
            this.seniausiMikroautobusai.Click += new System.EventHandler(this.seniausiMikroautobusai_Click);
            // 
            // krovininiaiAutomobiliai
            // 
            this.krovininiaiAutomobiliai.Name = "krovininiaiAutomobiliai";
            this.krovininiaiAutomobiliai.Size = new System.Drawing.Size(203, 22);
            this.krovininiaiAutomobiliai.Text = "Krovininiai automobiliai";
            this.krovininiaiAutomobiliai.Click += new System.EventHandler(this.krovininiaiAutomobiliai_Click);
            // 
            // techninėApžiūra
            // 
            this.techninėApžiūra.Name = "techninėApžiūra";
            this.techninėApžiūra.Size = new System.Drawing.Size(203, 22);
            this.techninėApžiūra.Text = "Techninė apžiūra";
            this.techninėApžiūra.Click += new System.EventHandler(this.techninėApžiūra_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.richTextBox1.Location = new System.Drawing.Point(13, 28);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1360, 533);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(12, 564);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pranešimas";
            // 
            // pagalbaToolStripMenuItem
            // 
            this.pagalbaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nurodymaiVartotojui,
            this.naudojimoSąlygos});
            this.pagalbaToolStripMenuItem.Name = "pagalbaToolStripMenuItem";
            this.pagalbaToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.pagalbaToolStripMenuItem.Text = "Pagalba";
            // 
            // nurodymaiVartotojui
            // 
            this.nurodymaiVartotojui.Name = "nurodymaiVartotojui";
            this.nurodymaiVartotojui.Size = new System.Drawing.Size(188, 22);
            this.nurodymaiVartotojui.Text = "Nurodymai vartotojui";
            this.nurodymaiVartotojui.Click += new System.EventHandler(this.nurodymaiVartotojui_Click);
            // 
            // naudojimoSąlygos
            // 
            this.naudojimoSąlygos.Name = "naudojimoSąlygos";
            this.naudojimoSąlygos.Size = new System.Drawing.Size(188, 22);
            this.naudojimoSąlygos.Text = "Naudojimo sąlygos";
            this.naudojimoSąlygos.Click += new System.EventHandler(this.naudojimoSąlygos_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 591);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Automobilių parkas";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuskaityti;
        private System.Windows.Forms.ToolStripMenuItem spausdinti;
        private System.Windows.Forms.ToolStripMenuItem baigti;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem skaičiuotiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geriausiAuto;
        private System.Windows.Forms.ToolStripMenuItem seniausiMikroautobusai;
        private System.Windows.Forms.ToolStripMenuItem krovininiaiAutomobiliai;
        private System.Windows.Forms.ToolStripMenuItem techninėApžiūra;
        private System.Windows.Forms.ToolStripMenuItem pagalbaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nurodymaiVartotojui;
        private System.Windows.Forms.ToolStripMenuItem naudojimoSąlygos;
    }
}

