namespace aplikacja_konsolowa
{
    internal class Program
    {
        class ArraySorter
        {
            private int[] numbers; // Tablica do sortowania

            // Konstruktor klasy, inicjalizuje tablicę
            public ArraySorter(int size)
            {
                numbers = new int[size];
            }

            // Metoda do wczytywania wartości do tablicy
            public void ReadNumbers()
            {
                Console.WriteLine("Wprowadź 10 liczb całkowitych:");
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.Write($"Liczba {i + 1}: ");

                    // Jeżeli zamiast liczby całkowitej podano coś innego, pokazujemy komunikat i
                    // próbujemy pobrać liczbę pod tym samym indeksem jeszcze raz
                    if (!int.TryParse(Console.ReadLine(), out numbers[i]))
                    {
                        Console.WriteLine("Błąd! Niepoprawna wartość. Spróbuj jeszcze raz.");
                        --i;
                    }
                }
            }

            // Metoda do sortowania tablicy w porządku malejącym
            public void SortDescending()
            {
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    int maxIndex = FindMaxIndex(i);
                    // Zamiana wartości
                    Swap(i, maxIndex);
                }
            }

            // Metoda szukająca indeks maksymalnej wartości od i do końca tablicy
            private int FindMaxIndex(int start)
            {
                int maxIndex = start;
                for (int j = start + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] > numbers[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                return maxIndex;
            }

            // Metoda zamieniająca dwa elementy w tablicy
            private void Swap(int index1, int index2)
            {
                int temp = numbers[index1];
                numbers[index1] = numbers[index2];
                numbers[index2] = temp;
            }

            // Metoda do wyświetlania posortowanej tablicy
            public void DisplaySortedNumbers()
            {
                Console.WriteLine("Tablica po sortowaniu malejącym:");
                
                Console.WriteLine(string.Join(", ", numbers));
            }

            static void Main(string[] args)
            {
                ArraySorter sorter = new ArraySorter(10);
                sorter.ReadNumbers();
                sorter.SortDescending();
                sorter.DisplaySortedNumbers();
            }
        }
    }
}
