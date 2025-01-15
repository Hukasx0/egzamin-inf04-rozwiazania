namespace sortowanie_poprzez_wstawienie
{
    internal class Program
    {
        // Funkcja realizująca algorytm sortowania przez wstawianie
        static void SortowaniePrzezWstawianie(int[] tablica)
        {
            // Przechodzimy po tablicy od drugiego elementu (indeks 1)
            // Ponieważ pierwszy element uznajemy za już posortowany
            for (int i = 1; i < tablica.Length; i++)
            {
                // Zapisujemy aktualny element do zmiennej (element do wstawienia)
                int doWstawienia = tablica[i];

                // Rozpoczynamy porównywanie od poprzedniego elementu
                int j = i - 1;

                // Przesuwamy elementy w prawo, aby zrobić miejsce dla elementu do wstawienia
                // Przesuwamy tylko te elementy, które są większe od elementu do wstawienia
                while (j >= 0 && tablica[j] > doWstawienia)
                {
                    tablica[j + 1] = tablica[j];  // Przesuwamy element w prawo
                    j--;  // Przechodzimy do poprzedniego elementu
                }

                // Po przesunięciu elementów, wstawiamy element do odpowiedniego miejsca
                tablica[j + 1] = doWstawienia;
            }
        }

        // Funkcja pomocnicza do wypisania zawartości tablicy
        static void WypiszTablice(int[] tablica)
        {
            foreach (int element in tablica)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // Przykładowa tablica do posortowania
            int[] tablica = { 9, 7, 5, 11, 3, 6, 8, 2, 4, 1 };

            Console.WriteLine("Tablica przed sortowaniem:");
            WypiszTablice(tablica);  // Wypisujemy tablicę przed sortowaniem

            // Wywołujemy funkcję sortowania
            SortowaniePrzezWstawianie(tablica);

            Console.WriteLine("Tablica po sortowaniu:");
            WypiszTablice(tablica);  // Wypisujemy tablicę po sortowaniu
        }
    }
}
