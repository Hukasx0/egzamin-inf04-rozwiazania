namespace aplikacjaDesktopowa
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.paczkaRadioButton = new System.Windows.Forms.RadioButton();
            this.listRadioButton = new System.Windows.Forms.RadioButton();
            this.pocztowkaRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.miastoTextBox = new System.Windows.Forms.TextBox();
            this.kodPocztowyTextBox = new System.Windows.Forms.TextBox();
            this.ulicaTextBox = new System.Windows.Forms.TextBox();
            this.zatwierdzButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cenaLabel = new System.Windows.Forms.Label();
            this.sprawdzCeneButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.paczkaRadioButton);
            this.groupBox1.Controls.Add(this.listRadioButton);
            this.groupBox1.Controls.Add(this.pocztowkaRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(35, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rodzaj przesyłki";
            // 
            // paczkaRadioButton
            // 
            this.paczkaRadioButton.AutoSize = true;
            this.paczkaRadioButton.Location = new System.Drawing.Point(31, 93);
            this.paczkaRadioButton.Name = "paczkaRadioButton";
            this.paczkaRadioButton.Size = new System.Drawing.Size(61, 17);
            this.paczkaRadioButton.TabIndex = 2;
            this.paczkaRadioButton.TabStop = true;
            this.paczkaRadioButton.Text = "Paczka";
            this.paczkaRadioButton.UseVisualStyleBackColor = true;
            // 
            // listRadioButton
            // 
            this.listRadioButton.AutoSize = true;
            this.listRadioButton.Location = new System.Drawing.Point(31, 67);
            this.listRadioButton.Name = "listRadioButton";
            this.listRadioButton.Size = new System.Drawing.Size(41, 17);
            this.listRadioButton.TabIndex = 1;
            this.listRadioButton.TabStop = true;
            this.listRadioButton.Text = "List";
            this.listRadioButton.UseVisualStyleBackColor = true;
            // 
            // pocztowkaRadioButton
            // 
            this.pocztowkaRadioButton.AutoSize = true;
            this.pocztowkaRadioButton.Location = new System.Drawing.Point(31, 44);
            this.pocztowkaRadioButton.Name = "pocztowkaRadioButton";
            this.pocztowkaRadioButton.Size = new System.Drawing.Size(78, 17);
            this.pocztowkaRadioButton.TabIndex = 0;
            this.pocztowkaRadioButton.TabStop = true;
            this.pocztowkaRadioButton.Text = "Pocztówka";
            this.pocztowkaRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.miastoTextBox);
            this.groupBox2.Controls.Add(this.kodPocztowyTextBox);
            this.groupBox2.Controls.Add(this.ulicaTextBox);
            this.groupBox2.Location = new System.Drawing.Point(413, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 232);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dane adresowe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Miasto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kod pocztowy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ulica z numerem";
            // 
            // miastoTextBox
            // 
            this.miastoTextBox.Location = new System.Drawing.Point(18, 172);
            this.miastoTextBox.Name = "miastoTextBox";
            this.miastoTextBox.Size = new System.Drawing.Size(252, 20);
            this.miastoTextBox.TabIndex = 2;
            // 
            // kodPocztowyTextBox
            // 
            this.kodPocztowyTextBox.Location = new System.Drawing.Point(18, 109);
            this.kodPocztowyTextBox.Name = "kodPocztowyTextBox";
            this.kodPocztowyTextBox.Size = new System.Drawing.Size(92, 20);
            this.kodPocztowyTextBox.TabIndex = 1;
            // 
            // ulicaTextBox
            // 
            this.ulicaTextBox.Location = new System.Drawing.Point(18, 44);
            this.ulicaTextBox.Name = "ulicaTextBox";
            this.ulicaTextBox.Size = new System.Drawing.Size(252, 20);
            this.ulicaTextBox.TabIndex = 0;
            // 
            // zatwierdzButton
            // 
            this.zatwierdzButton.Location = new System.Drawing.Point(35, 308);
            this.zatwierdzButton.Name = "zatwierdzButton";
            this.zatwierdzButton.Size = new System.Drawing.Size(670, 23);
            this.zatwierdzButton.TabIndex = 2;
            this.zatwierdzButton.Text = "Zatwierdź";
            this.zatwierdzButton.UseVisualStyleBackColor = true;
            this.zatwierdzButton.Click += new System.EventHandler(this.zatwierdzButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(35, 203);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // cenaLabel
            // 
            this.cenaLabel.AutoSize = true;
            this.cenaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cenaLabel.Location = new System.Drawing.Point(171, 214);
            this.cenaLabel.Name = "cenaLabel";
            this.cenaLabel.Size = new System.Drawing.Size(90, 20);
            this.cenaLabel.TabIndex = 4;
            this.cenaLabel.Text = "Cena: 1 zł";
            // 
            // sprawdzCeneButton
            // 
            this.sprawdzCeneButton.Location = new System.Drawing.Point(35, 163);
            this.sprawdzCeneButton.Name = "sprawdzCeneButton";
            this.sprawdzCeneButton.Size = new System.Drawing.Size(272, 23);
            this.sprawdzCeneButton.TabIndex = 5;
            this.sprawdzCeneButton.Text = "Sprawdź Cenę";
            this.sprawdzCeneButton.UseVisualStyleBackColor = true;
            this.sprawdzCeneButton.Click += new System.EventHandler(this.sprawdzCeneButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 337);
            this.Controls.Add(this.sprawdzCeneButton);
            this.Controls.Add(this.cenaLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.zatwierdzButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Nadaj Przesyłkę, Pesel: 00000000000";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton paczkaRadioButton;
        private System.Windows.Forms.RadioButton listRadioButton;
        private System.Windows.Forms.RadioButton pocztowkaRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox miastoTextBox;
        private System.Windows.Forms.TextBox kodPocztowyTextBox;
        private System.Windows.Forms.TextBox ulicaTextBox;
        private System.Windows.Forms.Button zatwierdzButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label cenaLabel;
        private System.Windows.Forms.Button sprawdzCeneButton;
    }
}

