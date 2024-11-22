namespace aplikacjaMobilna
{
    public partial class MainPage : ContentPage
    {
        // Zmienna do przechowywania liczby polubień
        private int likesCount = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        // Funkcja obsługująca przycisk "POLUB"
        // inkrementujemy polubienia
        private void LikeButton_Clicked(object sender, EventArgs e)
        {
            likesCount++;
            UpdateLikesText();
        }

        // Funkcja obsługująca przycisk "USUŃ"
        // dekrementujemy polubienia
        private void UnlikeButton_Clicked(object sender, EventArgs e)
        {
            if (likesCount > 0)
            {
                likesCount--;
            }
            UpdateLikesText();
        }

        // Funkcja obsługująca przycisk "ZAPISZ" (bez logiki, w treści zadania ten przycisk nic nie miał robić)
        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            // Opcjonalne, nie ma tego w treści zadania
            DisplayAlert("Zapisano", "Kliknięto przycisk \"ZAPISZ\"", "OK");
        }

        // Funkcja aktualizująca tekst, który pokazuje liczbę polubień
        private void UpdateLikesText()
        {
            likesText.Text = $"{likesCount} polubień";
        }
    }

}
