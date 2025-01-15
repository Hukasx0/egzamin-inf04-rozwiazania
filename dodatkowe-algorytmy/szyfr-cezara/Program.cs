namespace szyfr_cezara
{
    internal class Program
    {
        static string Szyfruj(string tekst, int przesunięcie)
        {
            // Tablica na zaszyfrowane znaki
            char[] zaszyfrowane = new char[tekst.Length];

            // Iteracja przez każdy znak w tekście
            for (int i = 0; i < tekst.Length; i++)
            {
                char znak = tekst[i];

                // Sprawdzenie czy znak jest literą
                if (char.IsLetter(znak))
                {
                    // Określenie podstawy (ASCII) dla wielkiej lub małej litery
                    int podstawa = char.IsUpper(znak) ? 65 : 97;

                    // Zastosowanie wzoru szyfru Cezara: (x + k) mod 26
                    // gdzie x to pozycja litery w alfabecie (0-25), k to przesunięcie
                    zaszyfrowane[i] = (char)(((znak - podstawa + przesunięcie) % 26) + podstawa);
                }
                else
                {
                    // Jeśli znak nie jest literą, pozostaw bez zmian
                    zaszyfrowane[i] = znak;
                }
            }

            // Zwrócenie zaszyfrowanego tekstu
            return new string(zaszyfrowane);
        }

        // Funkcja deszyfrująca tekst
        static string Deszyfruj(string tekst, int przesunięcie)
        {
            // Deszyfrowanie to szyfrowanie z przeciwnym przesunięciem
            return Szyfruj(tekst, 26 - przesunięcie);
        }

        static void Main(string[] args)
        {
            // Wyświetlenie menu głównego
            Console.WriteLine("Program do szyfrowania/deszyfrowania tekstów szyfrem Cezara");
            Console.WriteLine("1. Szyfrowanie");
            Console.WriteLine("2. Deszyfrowanie");
            Console.Write("Wybierz opcję (1 lub 2): ");

            // Pobranie wyboru użytkownika
            int wybor;
            if (!int.TryParse(Console.ReadLine(), out wybor) || (wybor != 1 && wybor != 2))
            {
                Console.WriteLine("Błędny wybór! Program zostaje zakończony.");
                return; // Zakończenie programu, jeśli użytkownik podał niepoprawną wartość
            }

            // Pobranie tekstu do przetworzenia
            Console.Write("Podaj tekst: ");
            string tekst = Console.ReadLine()!;

            // Pobranie przesunięcia (klucza)
            int przesunięcie;
            Console.Write("Podaj przesunięcie (1-25): ");
            if (!int.TryParse(Console.ReadLine(), out przesunięcie) || przesunięcie < 1 || przesunięcie > 25)
            {
                Console.WriteLine("Błędne przesunięcie! Program zostaje zakończony.");
                return; // Zakończenie programu, jeśli użytkownik podał niepoprawną liczbę
            }

            // Upewnienie się, że przesunięcie mieści się w zakresie 0-25
            przesunięcie = przesunięcie % 26;

            // Wywołanie odpowiedniej funkcji w zależności od wyboru
            string wynik = wybor == 1
                ? Szyfruj(tekst, przesunięcie)
                : Deszyfruj(tekst, przesunięcie);

            // Wyświetlenie wyniku
            Console.WriteLine($"Wynik: {wynik}");
            Console.ReadKey();
        }

    }
}
