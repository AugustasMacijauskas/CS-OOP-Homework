namespace Studentai_GUI_List
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.vertinimai = new System.Windows.Forms.ComboBox();
            this.rezultatas = new System.Windows.Forms.Label();
            this.pavardeVrd = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.failasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.įvestiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spausdintiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lenteleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baigtiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.skaičiavimaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentųSkaičiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentoĮvertinimaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vaikinųVidurkisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.merginųVidurkisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagalbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.užduotisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nurodymaiVartotojuiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.richTextBox1.Location = new System.Drawing.Point(22, 48);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(422, 287);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // vertinimai
            // 
            this.vertinimai.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.vertinimai.FormattingEnabled = true;
            this.vertinimai.Location = new System.Drawing.Point(476, 48);
            this.vertinimai.Name = "vertinimai";
            this.vertinimai.Size = new System.Drawing.Size(181, 30);
            this.vertinimai.TabIndex = 7;
            this.vertinimai.Text = "Pasirinkite pažymį";
            // 
            // rezultatas
            // 
            this.rezultatas.AutoSize = true;
            this.rezultatas.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rezultatas.ForeColor = System.Drawing.Color.Blue;
            this.rezultatas.Location = new System.Drawing.Point(472, 95);
            this.rezultatas.Name = "rezultatas";
            this.rezultatas.Size = new System.Drawing.Size(175, 19);
            this.rezultatas.TabIndex = 8;
            this.rezultatas.Text = "Čia bus rodomi rezultatai";
            // 
            // pavardeVrd
            // 
            this.pavardeVrd.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.pavardeVrd.Location = new System.Drawing.Point(22, 341);
            this.pavardeVrd.Name = "pavardeVrd";
            this.pavardeVrd.Size = new System.Drawing.Size(635, 26);
            this.pavardeVrd.TabIndex = 10;
            this.pavardeVrd.Text = "Čia užrašykite pavardę ir vardą";
            this.pavardeVrd.Click += new System.EventHandler(this.pavardeVrd_click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failasToolStripMenuItem,
            this.skaičiavimaiToolStripMenuItem,
            this.pagalbaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(714, 29);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // failasToolStripMenuItem
            // 
            this.failasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.įvestiToolStripMenuItem,
            this.spausdintiToolStripMenuItem,
            this.lenteleToolStripMenuItem,
            this.baigtiToolStripMenuItem1});
            this.failasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.failasToolStripMenuItem.Name = "failasToolStripMenuItem";
            this.failasToolStripMenuItem.Size = new System.Drawing.Size(60, 25);
            this.failasToolStripMenuItem.Text = "Failas";
            // 
            // įvestiToolStripMenuItem
            // 
            this.įvestiToolStripMenuItem.Name = "įvestiToolStripMenuItem";
            this.įvestiToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.įvestiToolStripMenuItem.Text = "Įvesti";
            this.įvestiToolStripMenuItem.Click += new System.EventHandler(this.įvestiToolStripMenuItem_Click);
            // 
            // spausdintiToolStripMenuItem
            // 
            this.spausdintiToolStripMenuItem.Name = "spausdintiToolStripMenuItem";
            this.spausdintiToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.spausdintiToolStripMenuItem.Text = "Spausdinti";
            this.spausdintiToolStripMenuItem.Click += new System.EventHandler(this.spausdintiToolStripMenuItem_Click);
            // 
            // lenteleToolStripMenuItem
            // 
            this.lenteleToolStripMenuItem.Name = "lenteleToolStripMenuItem";
            this.lenteleToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.lenteleToolStripMenuItem.Text = "Lentelė";
            this.lenteleToolStripMenuItem.Click += new System.EventHandler(this.lenteleToolStripMenuItem_Click);
            // 
            // baigtiToolStripMenuItem1
            // 
            this.baigtiToolStripMenuItem1.Name = "baigtiToolStripMenuItem1";
            this.baigtiToolStripMenuItem1.Size = new System.Drawing.Size(153, 26);
            this.baigtiToolStripMenuItem1.Text = "Baigti";
            this.baigtiToolStripMenuItem1.Click += new System.EventHandler(this.baigtiToolStripMenuItem1_Click);
            // 
            // skaičiavimaiToolStripMenuItem
            // 
            this.skaičiavimaiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentųSkaičiusToolStripMenuItem,
            this.studentoĮvertinimaiToolStripMenuItem,
            this.vaikinųVidurkisToolStripMenuItem,
            this.merginųVidurkisToolStripMenuItem});
            this.skaičiavimaiToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skaičiavimaiToolStripMenuItem.Name = "skaičiavimaiToolStripMenuItem";
            this.skaičiavimaiToolStripMenuItem.Size = new System.Drawing.Size(103, 25);
            this.skaičiavimaiToolStripMenuItem.Text = "Skaičiavimai";
            // 
            // studentųSkaičiusToolStripMenuItem
            // 
            this.studentųSkaičiusToolStripMenuItem.Name = "studentųSkaičiusToolStripMenuItem";
            this.studentųSkaičiusToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.studentųSkaičiusToolStripMenuItem.Text = "Studentų skaičius";
            this.studentųSkaičiusToolStripMenuItem.Click += new System.EventHandler(this.studentųSkaičiusToolStripMenuItem_Click);
            // 
            // studentoĮvertinimaiToolStripMenuItem
            // 
            this.studentoĮvertinimaiToolStripMenuItem.Name = "studentoĮvertinimaiToolStripMenuItem";
            this.studentoĮvertinimaiToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.studentoĮvertinimaiToolStripMenuItem.Text = "Studento įvertinimai";
            this.studentoĮvertinimaiToolStripMenuItem.Click += new System.EventHandler(this.studentoĮvertinimaiToolStripMenuItem_Click);
            // 
            // vaikinųVidurkisToolStripMenuItem
            // 
            this.vaikinųVidurkisToolStripMenuItem.Name = "vaikinųVidurkisToolStripMenuItem";
            this.vaikinųVidurkisToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.vaikinųVidurkisToolStripMenuItem.Text = "Vaikinų vidurkis";
            this.vaikinųVidurkisToolStripMenuItem.Click += new System.EventHandler(this.vaikinųVidurkisToolStripMenuItem_Click);
            // 
            // merginųVidurkisToolStripMenuItem
            // 
            this.merginųVidurkisToolStripMenuItem.Name = "merginųVidurkisToolStripMenuItem";
            this.merginųVidurkisToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.merginųVidurkisToolStripMenuItem.Text = "Merginų vidurkis";
            this.merginųVidurkisToolStripMenuItem.Click += new System.EventHandler(this.merginųVidurkisToolStripMenuItem_Click);
            // 
            // pagalbaToolStripMenuItem
            // 
            this.pagalbaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.užduotisToolStripMenuItem,
            this.nurodymaiVartotojuiToolStripMenuItem});
            this.pagalbaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagalbaToolStripMenuItem.Name = "pagalbaToolStripMenuItem";
            this.pagalbaToolStripMenuItem.Size = new System.Drawing.Size(76, 25);
            this.pagalbaToolStripMenuItem.Text = "Pagalba";
            // 
            // užduotisToolStripMenuItem
            // 
            this.užduotisToolStripMenuItem.Name = "užduotisToolStripMenuItem";
            this.užduotisToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.užduotisToolStripMenuItem.Text = "Užduotis";
            this.užduotisToolStripMenuItem.Click += new System.EventHandler(this.užduotisToolStripMenuItem_Click);
            // 
            // nurodymaiVartotojuiToolStripMenuItem
            // 
            this.nurodymaiVartotojuiToolStripMenuItem.Name = "nurodymaiVartotojuiToolStripMenuItem";
            this.nurodymaiVartotojuiToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.nurodymaiVartotojuiToolStripMenuItem.Text = "Nurodymai vartotojui";
            this.nurodymaiVartotojuiToolStripMenuItem.Click += new System.EventHandler(this.nurodymaiVartotojuiToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(22, 383);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(565, 174);
            this.dataGridView1.TabIndex = 13;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "..\\\\..\\\\";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.InitialDirectory = "..\\\\..\\\\";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 569);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pavardeVrd);
            this.Controls.Add(this.rezultatas);
            this.Controls.Add(this.vertinimai);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Studentai";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox vertinimai;
        private System.Windows.Forms.Label rezultatas;
        private System.Windows.Forms.TextBox pavardeVrd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem įvestiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spausdintiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lenteleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skaičiavimaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentųSkaičiusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentoĮvertinimaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagalbaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem užduotisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nurodymaiVartotojuiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baigtiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vaikinųVidurkisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem merginųVidurkisToolStripMenuItem;
    }
}

