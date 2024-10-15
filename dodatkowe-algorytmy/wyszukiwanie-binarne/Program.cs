namespace wyszukiwanie_binarne
{
    internal class Program
    {
        // Iteracyjna implementacja wyszukiwania binarnego
        private static int BinarySearchIterative(int[] arr, int target)
        {
            // Inicjalizacja wskaźników lewego i prawego
            int left = 0;
            int right = arr.Length - 1;

            // Kontynuuj wyszukiwanie, dopóki wskaźnik lewy jest mniejszy lub równy wskaźnikowi prawemu
            while (left <= right)
            {
                // Oblicz indeks środkowy
                int mid = left + (right - left) / 2;

                // Jeśli środkowy element to cel, to zwróć jego indeks
                if (arr[mid] == target)
                    return mid;

                // Jeśli cel jest większy od środkowego elementu, to przeszukaj prawą połowę
                if (arr[mid] < target)
                    left = mid + 1;
                // Jeśli cel jest mniejszy od środkowego elementu, to przeszukaj lewą połowę
                else
                    right = mid - 1;
            }

            // Jeśli cel nie został znaleziony, to zwróć -1
            return -1;
        }

        // Rekurencyjna implementacja wyszukiwania binarnego
        private static int BinarySearchRecursive(int[] arr, int target, int left, int right)
        {
            // Jeśli wskaźnik lewy przekracza wskaźnik prawy, to element nie został znaleziony
            if (left > right)
                return -1;

            // Oblicz indeks środkowy
            int mid = (right+left) / 2;

            // Jeśli środkowy element to cel, to zwróć jego indeks
            if (arr[mid] == target)
                return mid;

            // Jeśli cel jest mniejszy od środkowego elementu, to przeszukaj lewą połowę
            if (target < arr[mid])
                return BinarySearchRecursive(arr, target, left, mid - 1);

            // Jeśli cel jest większy od środkowego elementu, to przeszukaj prawą połowę
            else
                return BinarySearchRecursive(arr, target, mid + 1, right);
        }

        static void Main(string[] args)
        {
            // Utwórz posortowaną tablicę do testowania
            int[] sortedArray = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };

            // nasza szukana liczba, w tym wypadku: 12
            int target = 12;

            Console.WriteLine("Tablica: " + string.Join(", ", sortedArray));
            Console.WriteLine($"Szukana: {target}");

            // Testuj iteracyjne wyszukiwanie binarne
            int iterativeResult = BinarySearchIterative(sortedArray, target);
            Console.WriteLine($"Wynik iteracyjnego wyszukiwania binarnego: {iterativeResult}");

            // Testuj rekurencyjne wyszukiwanie binarne
            int recursiveResult = BinarySearchRecursive(sortedArray, target, 0, sortedArray.Length - 1);
            Console.WriteLine($"Wynik rekurencyjnego wyszukiwania binarnego: {recursiveResult}");
        }
    }
}
