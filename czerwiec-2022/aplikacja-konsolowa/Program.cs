namespace aplikacja_konsolowa
{
    internal class Program
    {
        class ArraySearcher
        {
            private int[] numbers; // Tablica do przeszukiwania
            private const int Size = 5; // Rozmiar tablicy

            // Konstruktor klasy, inicjalizuje tablicę
            public ArraySearcher()
            {
                numbers = new int[Size];
            }

            // Metoda do wypełniania tablicy pseudolosowymi wartościami
            public void FillArray()
            {
                Random random = new Random();
                for (int i = 0; i < Size; i++)
                {
                    numbers[i] = random.Next(1, 101); // Liczby od 1 do 100
                }
            }

            // Metoda do przeszukiwania tablicy z wartownikiem
            public int SentinelSearch(int target)
            {
                // Tworzymy tablicę tymczasową, do której klonujemy naszą tablicę, w której będziemy szukać
                // i dodajemy do niej wartownika
                int[] tempArr = new int[Size + 1];
                Array.Copy(numbers, tempArr, Size);

                // Dodajemy wartownika na końcu tablicy
                tempArr[Size] = target;

                int i = 0;

                // Przeszukiwanie tablicy, kończymy przeszukiwanie jak znajdziemy element, lub naszego wartownika
                while (tempArr[i] != target)
                {
                    i++;
                }

                // Sprawdzamy, czy znaleziono wartownika, czy element
                if (i < Size)
                {
                    return i; // Zwracamy indeks znalezionego elementu
                }
                else
                {
                    return -1; // Element nie został znaleziony
                }
            }

            // Metoda do wyświetlania tablicy
            public void DisplayArray()
            {
                Console.WriteLine("Zawartość tablicy:");
                Console.WriteLine(string.Join(", ", numbers));
            }

            static void Main(string[] args)
            {
                ArraySearcher searcher = new ArraySearcher();
                searcher.FillArray();
                searcher.DisplayArray();

                int target = 0;
                Console.Write("Wprowadź liczbę do wyszukania: ");

                while (!int.TryParse(Console.ReadLine(), out target)) {
                    Console.Write("Błąd! Podaj prawidłową liczbę całkowitą do wyszukania: ");
                }

                int index = searcher.SentinelSearch(target);

                if (index != -1)
                {
                    Console.WriteLine($"Element {target} znaleziony pod indeksem: {index}");
                }
                else
                {
                    Console.WriteLine($"Element {target} nie został znaleziony w tablicy.");
                }
            }
        }
    }
}
