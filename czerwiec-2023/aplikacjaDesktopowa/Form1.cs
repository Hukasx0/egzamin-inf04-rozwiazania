using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplikacjaDesktopowa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Zdarzenie kliknięcia przycisku "Sprawdź Cenę"
        private void sprawdzCeneButton_Click(object sender, EventArgs e)
        {
            if (listRadioButton.Checked)
            {
                // Ładowanie obrazu "list" do PictureBox
                pictureBox1.Image = Properties.Resources.list;
                cenaLabel.Text = "Cena: 1,5 zł";
            }
            else if (pocztowkaRadioButton.Checked)
            {
                // Ładowanie obrazu "pocztowka" do PictureBox
                pictureBox1.Image = Properties.Resources.pocztowka;
                cenaLabel.Text = "Cena: 1 zł";
            }
            else if (paczkaRadioButton.Checked)
            {
                // Ładowanie obrazu "paczka" do PictureBox
                pictureBox1.Image = Properties.Resources.paczka;
                cenaLabel.Text = "Cena: 10 zł";
            }
        }

        // Zdarzenie kliknięcia przycisku "Zatwierdź"
        private void zatwierdzButton_Click(object sender, EventArgs e)
        {
            var kodPocztowy = kodPocztowyTextBox.Text;
            if (kodPocztowy.Length != 5) 
            {
                MessageBox.Show("Nieprawidłowa liczba cyfr w kodzie pocztowym");
            }
            else if (!int.TryParse(kodPocztowy, out int _))
            {
                MessageBox.Show("Kod pocztowy powinien się składać z samych cyfr");
            }
            else
            {
                MessageBox.Show("Dane przesyłki zostały wprowadzone");
            }
        }

        /*
            Dodawanie obrazów do zasobów projektu:

            Aby dodać obrazki do zasobów projektu w Visual Studio, postępuj zgodnie z poniższymi krokami:

                Krok 1: Przejdź do Solution Explorer (Eksplorator rozwiązań).
                Krok 2: Kliknij dwa razy na "Properties" w drzewie projektu i wybierz "zasoby" w menu po lewo
                Krok 4: Kliknij "Dodaj zasób" i potem "Dodaj istniejący plik"
                Krok 5: Wybierz pliki obrazów (np. list.png, pocztowka.png, paczka.png) z dysku

            Obrazy zostaną dodane do zasobów projektu i będą dostępne pod ścieżką `Properties.Resources.<nazwa_pliku>`.
        */
    }
}
