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
        // Zmienna przechowująca wygenerowane hasło
        private string haslo = string.Empty;

        // Konstruktor formularza
        public Form1()
        {
            InitializeComponent();

            // Dodanie dostępnych stanowisk do ComboBox (wskazuje, jakie stanowiska będą dostępne do wyboru)
            stanowiskoComboBox.Items.AddRange(new string[]
            {
                "Kierownik",
                "Starszy programista",
                "Młodszy programista",
                "Tester"
            });

            // Ustawienie domyślnego stanu zaznaczenia dla Checkboxa "Małe i wielkie litery" na "True"
            // co oznacza, że w wygenerowanym haśle domyślnie będą używane wielkie litery.
            wielkieLiteryCheckBox.Checked = true;
        }

        // Obsługuje kliknięcie przycisku "Generuj hasło"
        private void generujHasloButton_Click(object sender, EventArgs e)
        {
            int liczbaZnakow = 0;

            // Próba konwersji wprowadzonej liczby znaków z TextBox na typ int
            if (int.TryParse(ileZnakowTextBox.Text, out liczbaZnakow))
            {
                // Sprawdzenie, które opcje zostały wybrane przez użytkownika (czy mają być wielkie litery, cyfry, znaki specjalne)
                bool wielkieLitery = wielkieLiteryCheckBox.Checked;
                bool cyfry = cyfryCheckBox.Checked;
                bool znakiSpecjalne = znakiSpecjalneCheckBox.Checked;

                // Wywołanie metody do generowania hasła z danymi parametrami
                GenerujHaslo(liczbaZnakow, wielkieLitery, cyfry, znakiSpecjalne);

                // Wyświetlenie wygenerowanego hasła w oknie komunikatu
                MessageBox.Show($"{this.haslo}", "Hasło", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Jeśli użytkownik nie podał prawidłowej liczby znaków, wyświetlamy komunikat o błędzie
                MessageBox.Show("Proszę podać liczbę znaków.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Obsługuje kliknięcie przycisku "Zatwierdź"
        private void zatwierdzButton_Click(object sender, EventArgs e)
        {
            // Pobranie wartości z pól tekstowych oraz wybranego stanowiska z ComboBox
            // Zmienna "stanowisko" przechowuje wybrany przez użytkownika element w ComboBoxie
            string imie = imieTextBox.Text;
            string nazwisko = nazwiskoTextBox.Text;
            string stanowisko = stanowiskoComboBox.SelectedItem.ToString();

            // Wyświetlenie komunikatu z danymi pracownika oraz wygenerowanym hasłem
            MessageBox.Show($"Dane pracownika: {imie} {nazwisko} {stanowisko}, Hasło: {this.haslo}", "Dane pracownika", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Metoda generująca hasło na podstawie danych parametrów
        private void GenerujHaslo(int liczbaZnakow, bool wielkieLitery, bool cyfry, bool znakiSpecjalne)
        {
            // Definicje dostępnych grup znaków, z których będzie generowane hasło:
            // - Małe litery (a-z)
            // - Wielkie litery (A-Z)
            // - Cyfry (0-9)
            // - Znaki specjalne (!@#$%^&*()_+-=)
            string maleLiteryPula = "abcdefghijklmnopqrstuvwxyz";
            string wielkieLiteryPula = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string cyfryPula = "0123456789";
            string znakiSpecjalnePula = "!@#$%^&*()_+-=";

            // Utworzenie obiektu Random do losowania znaków z powyższych grup
            Random random = new Random();

            // Tablica do przechowywania wygenerowanego hasła o danej długości
            char[] haslo = new char[liczbaZnakow];

            // Zmienna i do kontrolowania, które miejsca w tablicy hasła zostały już wypełnione
            int i = 0;

            // Jeśli użytkownik zaznaczył opcję "wielkie litery" i liczba znaków jest większa niż i,
            // przypisujemy pierwszy losowy znak z puli wielkich liter
            if (liczbaZnakow > i && wielkieLitery)
            {
                haslo[i++] = wielkieLiteryPula[random.Next(wielkieLiteryPula.Length)];
            }

            // Jeśli użytkownik zaznaczył opcję "cyfry" i liczba znaków jest większa niż i,
            // przypisujemy pierwszy losowy znak z puli cyfr
            if (liczbaZnakow > i && cyfry)
            {
                haslo[i++] = cyfryPula[random.Next(cyfryPula.Length)];
            }

            // Jeśli użytkownik zaznaczył opcję "znaki specjalne" i liczba znaków jest większa niż i,
            // przypisujemy pierwszy losowy znak z puli znaków specjalnych
            if (liczbaZnakow > i && znakiSpecjalne)
            {
                haslo[i++] = znakiSpecjalnePula[random.Next(znakiSpecjalnePula.Length)];
            }

            // Uzupełniamy pozostałą część hasła (jeśli pozostały miejsca) losowymi małymi literami
            for (int j = i; j < liczbaZnakow; j++)
            {
                haslo[j] = maleLiteryPula[random.Next(maleLiteryPula.Length)];
            }

            // Przekształcamy tablicę znaków na łańcuch tekstowy i zapisujemy go w zmiennej "haslo"
            this.haslo = new string(haslo);
        }

    }
}
