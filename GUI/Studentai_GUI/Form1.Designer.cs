namespace Studentai_GUI
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
            this.ivesti = new System.Windows.Forms.Button();
            this.rezultatai = new System.Windows.Forms.RichTextBox();
            this.spausdinti = new System.Windows.Forms.Button();
            this.skaiciuoti = new System.Windows.Forms.Button();
            this.rasti = new System.Windows.Forms.Button();
            this.baigti = new System.Windows.Forms.Button();
            this.vertinimai = new System.Windows.Forms.ComboBox();
            this.rezultatas = new System.Windows.Forms.Label();
            this.pavardeVardas = new System.Windows.Forms.Label();
            this.pavardeVrd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ivesti
            // 
            this.ivesti.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ivesti.Location = new System.Drawing.Point(471, 26);
            this.ivesti.Name = "ivesti";
            this.ivesti.Size = new System.Drawing.Size(159, 57);
            this.ivesti.TabIndex = 0;
            this.ivesti.Text = "Įvesti";
            this.ivesti.UseVisualStyleBackColor = true;
            this.ivesti.Click += new System.EventHandler(this.ivesti_Click);
            // 
            // rezultatai
            // 
            this.rezultatai.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.rezultatai.Location = new System.Drawing.Point(13, 26);
            this.rezultatai.Name = "rezultatai";
            this.rezultatai.Size = new System.Drawing.Size(422, 351);
            this.rezultatai.TabIndex = 2;
            this.rezultatai.Text = "";
            // 
            // spausdinti
            // 
            this.spausdinti.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.spausdinti.Location = new System.Drawing.Point(471, 102);
            this.spausdinti.Name = "spausdinti";
            this.spausdinti.Size = new System.Drawing.Size(159, 58);
            this.spausdinti.TabIndex = 3;
            this.spausdinti.Text = "Spausdinti";
            this.spausdinti.UseVisualStyleBackColor = true;
            this.spausdinti.Click += new System.EventHandler(this.spausdinti_Click);
            // 
            // skaiciuoti
            // 
            this.skaiciuoti.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.skaiciuoti.Location = new System.Drawing.Point(471, 250);
            this.skaiciuoti.Name = "skaiciuoti";
            this.skaiciuoti.Size = new System.Drawing.Size(159, 58);
            this.skaiciuoti.TabIndex = 4;
            this.skaiciuoti.Text = "Skaičiuoti";
            this.skaiciuoti.UseVisualStyleBackColor = true;
            this.skaiciuoti.Click += new System.EventHandler(this.skaiciuoti_Click);
            // 
            // rasti
            // 
            this.rasti.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.rasti.Location = new System.Drawing.Point(506, 386);
            this.rasti.Name = "rasti";
            this.rasti.Size = new System.Drawing.Size(159, 57);
            this.rasti.TabIndex = 5;
            this.rasti.Text = "Rasti";
            this.rasti.UseVisualStyleBackColor = true;
            this.rasti.Click += new System.EventHandler(this.rasti_Click);
            // 
            // baigti
            // 
            this.baigti.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.baigti.Location = new System.Drawing.Point(506, 460);
            this.baigti.Name = "baigti";
            this.baigti.Size = new System.Drawing.Size(159, 57);
            this.baigti.TabIndex = 6;
            this.baigti.Text = "Baigti";
            this.baigti.UseVisualStyleBackColor = true;
            this.baigti.Click += new System.EventHandler(this.baigti_Click);
            // 
            // vertinimai
            // 
            this.vertinimai.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.vertinimai.FormattingEnabled = true;
            this.vertinimai.Location = new System.Drawing.Point(471, 187);
            this.vertinimai.Name = "vertinimai";
            this.vertinimai.Size = new System.Drawing.Size(181, 30);
            this.vertinimai.TabIndex = 7;
            this.vertinimai.Text = "Pasirinkite pažymį";
            // 
            // rezultatas
            // 
            this.rezultatas.AutoSize = true;
            this.rezultatas.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rezultatas.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.rezultatas.Location = new System.Drawing.Point(467, 334);
            this.rezultatas.Name = "rezultatas";
            this.rezultatas.Size = new System.Drawing.Size(175, 19);
            this.rezultatas.TabIndex = 8;
            this.rezultatas.Text = "Čia bus rodomi rezultatai";
            // 
            // pavardeVardas
            // 
            this.pavardeVardas.AutoSize = true;
            this.pavardeVardas.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pavardeVardas.ForeColor = System.Drawing.SystemColors.InfoText;
            this.pavardeVardas.Location = new System.Drawing.Point(9, 386);
            this.pavardeVardas.Name = "pavardeVardas";
            this.pavardeVardas.Size = new System.Drawing.Size(169, 24);
            this.pavardeVardas.TabIndex = 9;
            this.pavardeVardas.Text = "Pavardė ir vardas";
            // 
            // pavardeVrd
            // 
            this.pavardeVrd.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.pavardeVrd.Location = new System.Drawing.Point(13, 417);
            this.pavardeVrd.Name = "pavardeVrd";
            this.pavardeVrd.Size = new System.Drawing.Size(412, 26);
            this.pavardeVrd.TabIndex = 10;
            this.pavardeVrd.Text = "Čia užrašykite pavardę ir vardą";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 543);
            this.Controls.Add(this.pavardeVrd);
            this.Controls.Add(this.pavardeVardas);
            this.Controls.Add(this.rezultatas);
            this.Controls.Add(this.vertinimai);
            this.Controls.Add(this.baigti);
            this.Controls.Add(this.rasti);
            this.Controls.Add(this.skaiciuoti);
            this.Controls.Add(this.spausdinti);
            this.Controls.Add(this.rezultatai);
            this.Controls.Add(this.ivesti);
            this.Name = "Form1";
            this.Text = "Studentai";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ivesti;
        private System.Windows.Forms.RichTextBox rezultatai;
        private System.Windows.Forms.Button spausdinti;
        private System.Windows.Forms.Button skaiciuoti;
        private System.Windows.Forms.Button rasti;
        private System.Windows.Forms.Button baigti;
        private System.Windows.Forms.ComboBox vertinimai;
        private System.Windows.Forms.Label rezultatas;
        private System.Windows.Forms.Label pavardeVardas;
        private System.Windows.Forms.TextBox pavardeVrd;
    }
}

