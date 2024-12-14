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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stanowiskoComboBox = new System.Windows.Forms.ComboBox();
            this.nazwiskoTextBox = new System.Windows.Forms.TextBox();
            this.imieTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ileZnakowTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.generujHasloButton = new System.Windows.Forms.Button();
            this.wielkieLiteryCheckBox = new System.Windows.Forms.CheckBox();
            this.znakiSpecjalneCheckBox = new System.Windows.Forms.CheckBox();
            this.cyfryCheckBox = new System.Windows.Forms.CheckBox();
            this.zatwierdzButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stanowiskoComboBox);
            this.groupBox1.Controls.Add(this.nazwiskoTextBox);
            this.groupBox1.Controls.Add(this.imieTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(28, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 196);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dane pracownika";
            // 
            // stanowiskoComboBox
            // 
            this.stanowiskoComboBox.FormattingEnabled = true;
            this.stanowiskoComboBox.Location = new System.Drawing.Point(108, 116);
            this.stanowiskoComboBox.Name = "stanowiskoComboBox";
            this.stanowiskoComboBox.Size = new System.Drawing.Size(121, 21);
            this.stanowiskoComboBox.TabIndex = 5;
            // 
            // nazwiskoTextBox
            // 
            this.nazwiskoTextBox.Location = new System.Drawing.Point(108, 78);
            this.nazwiskoTextBox.Name = "nazwiskoTextBox";
            this.nazwiskoTextBox.Size = new System.Drawing.Size(121, 20);
            this.nazwiskoTextBox.TabIndex = 4;
            // 
            // imieTextBox
            // 
            this.imieTextBox.Location = new System.Drawing.Point(108, 43);
            this.imieTextBox.Name = "imieTextBox";
            this.imieTextBox.Size = new System.Drawing.Size(121, 20);
            this.imieTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Stanowisko";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nazwisko";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Imię";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ileZnakowTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.generujHasloButton);
            this.groupBox2.Controls.Add(this.wielkieLiteryCheckBox);
            this.groupBox2.Controls.Add(this.znakiSpecjalneCheckBox);
            this.groupBox2.Controls.Add(this.cyfryCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(389, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 185);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generowanie hasła";
            // 
            // ileZnakowTextBox
            // 
            this.ileZnakowTextBox.Location = new System.Drawing.Point(103, 29);
            this.ileZnakowTextBox.Name = "ileZnakowTextBox";
            this.ileZnakowTextBox.Size = new System.Drawing.Size(114, 20);
            this.ileZnakowTextBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ile znaków?";
            // 
            // generujHasloButton
            // 
            this.generujHasloButton.BackColor = System.Drawing.Color.SteelBlue;
            this.generujHasloButton.ForeColor = System.Drawing.Color.White;
            this.generujHasloButton.Location = new System.Drawing.Point(70, 145);
            this.generujHasloButton.Name = "generujHasloButton";
            this.generujHasloButton.Size = new System.Drawing.Size(109, 23);
            this.generujHasloButton.TabIndex = 6;
            this.generujHasloButton.Text = "Generuj hasło";
            this.generujHasloButton.UseVisualStyleBackColor = false;
            this.generujHasloButton.Click += new System.EventHandler(this.generujHasloButton_Click);
            // 
            // wielkieLiteryCheckBox
            // 
            this.wielkieLiteryCheckBox.AutoSize = true;
            this.wielkieLiteryCheckBox.Location = new System.Drawing.Point(24, 69);
            this.wielkieLiteryCheckBox.Name = "wielkieLiteryCheckBox";
            this.wielkieLiteryCheckBox.Size = new System.Drawing.Size(115, 17);
            this.wielkieLiteryCheckBox.TabIndex = 3;
            this.wielkieLiteryCheckBox.Text = "Małe i wielkie litery";
            this.wielkieLiteryCheckBox.UseVisualStyleBackColor = true;
            // 
            // znakiSpecjalneCheckBox
            // 
            this.znakiSpecjalneCheckBox.AutoSize = true;
            this.znakiSpecjalneCheckBox.Location = new System.Drawing.Point(24, 115);
            this.znakiSpecjalneCheckBox.Name = "znakiSpecjalneCheckBox";
            this.znakiSpecjalneCheckBox.Size = new System.Drawing.Size(101, 17);
            this.znakiSpecjalneCheckBox.TabIndex = 5;
            this.znakiSpecjalneCheckBox.Text = "Znaki specjalne";
            this.znakiSpecjalneCheckBox.UseVisualStyleBackColor = true;
            // 
            // cyfryCheckBox
            // 
            this.cyfryCheckBox.AutoSize = true;
            this.cyfryCheckBox.Location = new System.Drawing.Point(24, 92);
            this.cyfryCheckBox.Name = "cyfryCheckBox";
            this.cyfryCheckBox.Size = new System.Drawing.Size(49, 17);
            this.cyfryCheckBox.TabIndex = 4;
            this.cyfryCheckBox.Text = "Cyfry";
            this.cyfryCheckBox.UseVisualStyleBackColor = true;
            // 
            // zatwierdzButton
            // 
            this.zatwierdzButton.BackColor = System.Drawing.Color.SteelBlue;
            this.zatwierdzButton.ForeColor = System.Drawing.Color.White;
            this.zatwierdzButton.Location = new System.Drawing.Point(249, 251);
            this.zatwierdzButton.Name = "zatwierdzButton";
            this.zatwierdzButton.Size = new System.Drawing.Size(171, 23);
            this.zatwierdzButton.TabIndex = 2;
            this.zatwierdzButton.Text = "Zatwierdź";
            this.zatwierdzButton.UseVisualStyleBackColor = false;
            this.zatwierdzButton.Click += new System.EventHandler(this.zatwierdzButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(669, 281);
            this.Controls.Add(this.zatwierdzButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Dodaj pracownika 00000000000";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox znakiSpecjalneCheckBox;
        private System.Windows.Forms.CheckBox cyfryCheckBox;
        private System.Windows.Forms.CheckBox wielkieLiteryCheckBox;
        private System.Windows.Forms.Button generujHasloButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nazwiskoTextBox;
        private System.Windows.Forms.TextBox imieTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ileZnakowTextBox;
        private System.Windows.Forms.ComboBox stanowiskoComboBox;
        private System.Windows.Forms.Button zatwierdzButton;
    }
}

