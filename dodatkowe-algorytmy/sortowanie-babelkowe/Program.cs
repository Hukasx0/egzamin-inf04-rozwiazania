namespace sortowanie_babelkowe
{
    internal class Program
    {
        // Metoda implementująca algorytm sortowania bąbelkowego
        static void SortowanieBabelkowe(int[] arr)
        {
            // Długość tablicy
            int n = arr.Length;

            // Pętla zewnętrzna - kontroluje liczbę przejść przez tablicę
            for (int i = 0; i < n - 1; i++)
            {
                // Flaga informująca, czy w danym przejściu nastąpiła zamiana
                // Ta flaga jest opcjonalna, algorytm bez niej zadziała poprawnie
                // ale stosujemy ją dla optymalizacji
                // na przykład jak tablica jest już posortowana
                // to złożoność czasowa zmieni się z O(n^2) do O(n).
                bool czyBylaPrzemiana = false;

                // Pętla wewnętrzna - porównuje sąsiednie elementy
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Jeśli element po lewej jest większy od elementu po prawej
                    if (arr[j] > arr[j + 1])
                    {
                        // Zamiana miejscami
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        // Ustawienie flagi, że nastąpiła zamiana
                        czyBylaPrzemiana = true;
                    }
                }

                // Jeśli w danym przejściu nie było zamiany, tablica jest już posortowana
                if (!czyBylaPrzemiana)
                    break;
            }
        }
        static void Main(string[] args)
        {
            // Przykładowa tablica do posortowania
            int[] tablica = { 64, 34, 25, 12, 22, 11, 90 };

            Console.WriteLine("Tablica przed posortowaniem:");
            Console.WriteLine(string.Join(", ", tablica));

            SortowanieBabelkowe(tablica);

            Console.WriteLine("\nTablica po posortowaniu:");
            Console.WriteLine(string.Join(", ", tablica));
        }
    }
}
