namespace L5_Autobusai_Augustas_Mačijauskas_4NFQ
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
            this.įvestiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baigtiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.skaičiuotiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atrinktiMaršrutusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rastiPelningiausiąToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failasToolStripMenuItem,
            this.skaičiuotiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1353, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // failasToolStripMenuItem
            // 
            this.failasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.įvestiToolStripMenuItem,
            this.baigtiToolStripMenuItem});
            this.failasToolStripMenuItem.Name = "failasToolStripMenuItem";
            this.failasToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.failasToolStripMenuItem.Text = "Failas";
            // 
            // įvestiToolStripMenuItem
            // 
            this.įvestiToolStripMenuItem.Name = "įvestiToolStripMenuItem";
            this.įvestiToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.įvestiToolStripMenuItem.Text = "Įvesti";
            this.įvestiToolStripMenuItem.Click += new System.EventHandler(this.įvestiToolStripMenuItem_Click);
            // 
            // baigtiToolStripMenuItem
            // 
            this.baigtiToolStripMenuItem.Name = "baigtiToolStripMenuItem";
            this.baigtiToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.baigtiToolStripMenuItem.Text = "Baigti";
            this.baigtiToolStripMenuItem.Click += new System.EventHandler(this.baigtiToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 31);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1329, 750);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // skaičiuotiToolStripMenuItem
            // 
            this.skaičiuotiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atrinktiMaršrutusToolStripMenuItem,
            this.rastiPelningiausiąToolStripMenuItem});
            this.skaičiuotiToolStripMenuItem.Name = "skaičiuotiToolStripMenuItem";
            this.skaičiuotiToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.skaičiuotiToolStripMenuItem.Text = "Skaičiuoti";
            // 
            // atrinktiMaršrutusToolStripMenuItem
            // 
            this.atrinktiMaršrutusToolStripMenuItem.Name = "atrinktiMaršrutusToolStripMenuItem";
            this.atrinktiMaršrutusToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.atrinktiMaršrutusToolStripMenuItem.Text = "Atrinkti maršrutus";
            this.atrinktiMaršrutusToolStripMenuItem.Click += new System.EventHandler(this.atrinktiMaršrutusToolStripMenuItem_Click);
            // 
            // rastiPelningiausiąToolStripMenuItem
            // 
            this.rastiPelningiausiąToolStripMenuItem.Name = "rastiPelningiausiąToolStripMenuItem";
            this.rastiPelningiausiąToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.rastiPelningiausiąToolStripMenuItem.Text = "Rasti pelningiausią";
            this.rastiPelningiausiąToolStripMenuItem.Click += new System.EventHandler(this.rastiPelningiausiąToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 793);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Autobusai";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem įvestiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baigtiToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem skaičiuotiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atrinktiMaršrutusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rastiPelningiausiąToolStripMenuItem;
    }
}

