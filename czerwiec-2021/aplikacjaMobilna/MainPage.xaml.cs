namespace aplikacjaMobilna
{
    public partial class MainPage : ContentPage
    {
        // Konstruktor klasy MainPage
        public MainPage()
        {
            InitializeComponent();
            // Ustawienie początkowego komunikatu przy starcie aplikacji, który zawiera identyfikator autora (PESEL)
            MessageLabel.Text = $"Autor: 00000000000"; // Zmień na odpowiedni numer PESEL
        }

        // Metoda obsługująca kliknięcie przycisku "ZATWIERDŹ"
        private void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            // Pobranie wartości z pól edycyjnych (Entry)
            string email = ((Entry)EmailEntry).Text;
            string password = ((Entry)PasswordEntry).Text;
            string confirmPassword = ((Entry)ConfirmPasswordEntry).Text;

            // Sprawdzenie, czy e-mail zawiera znak '@'
            if (!email.Contains("@"))
            {
                MessageLabel.Text = "Nieprawidłowy adres e-mail"; // Komunikat o błędzie
            }
            // Sprawdzenie, czy hasła się zgadzają
            else if (password != confirmPassword)
            {
                MessageLabel.Text = "Hasła się różnią"; // Komunikat o błędzie
            }
            // Jeśli nie wystąpiły błędy
            else
            {
                MessageLabel.Text = $"Witaj {email}"; // Powitanie użytkownika
            }
        }
    }
}
