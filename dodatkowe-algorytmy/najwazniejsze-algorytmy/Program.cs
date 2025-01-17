﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace najwazniejsze_algorytmy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Przykładowa tablica do testów
            int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
            Console.WriteLine("Oryginalna tablica:");
            PrintArray(arr);

            // Przykładowe wywołanie jednego z algorytmów
            QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine("\nPosortowana tablica (QuickSort):");
            PrintArray(arr);

            // Testowanie algorytmu NWD i NWW
            Console.WriteLine("\nNWD (12, 15): " + NWD(12, 15));
            Console.WriteLine("NWW (12, 15): " + NWW(12, 15));

            // Testowanie Binary Search
            int target = 22;
            int index = BinarySearch(arr, target);
            Console.WriteLine($"\nBinary Search: Szukam {target}, indeks: {index}");

            // Testowanie Linear Search
            int linearIndex = LinearSearch(arr, target);
            Console.WriteLine($"\nLinear Search: Szukam {target}, indeks: {linearIndex}");

            // Testowanie Sentinel Search
            int sentinelIndex = SentinelSearch(arr, target);
            Console.WriteLine($"\nSentinel Search: Szukam {target}, indeks: {sentinelIndex}");

            // Wyszukiwanie max i min
            int max = FindMax(arr);
            int min = FindMin(arr);
            Console.WriteLine($"\nMax: {max}, Min: {min}");

            // Wyszukiwanie max i min jednocześnie
            (int maxVal, int minVal) = FindMaxMin(arr);
            Console.WriteLine($"\nMax: {maxVal}, Min: {minVal}");

            // Sprawdzanie palindromu
            string palindrome = "madam";
            bool isPalindrome = IsPalindrome(palindrome);
            Console.WriteLine($"\nCzy '{palindrome}' jest palindromem? {isPalindrome}");

            // Test DFS i BFS na grafie
            int[,] graph = {
            { 0, 1, 0, 1, 0 },
            { 1, 0, 1, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 1, 0, 1, 0, 1 },
            { 0, 0, 0, 1, 0 }
        };
            bool[] visited = new bool[graph.GetLength(0)];
            Console.WriteLine("DFS: ");
            DFS(graph, 0, visited);  // Przeszukiwanie w głąb
            Console.WriteLine();

            Console.WriteLine("BFS: ");
            BFS(graph, 0);  // Przeszukiwanie wszerz
            Console.WriteLine();

            // Test Dijkstra
            int[] distances = Dijkstra(graph, 0);
            Console.WriteLine("Dijkstra: ");
            for (int i = 0; i < distances.Length; i++)
            {
                Console.WriteLine($"Odległość od wierzchołka 0 do wierzchołka {i}: {distances[i]}");
            }

            // Test Knapsack
            int[] weights = { 1, 2, 3 };
            int[] values = { 10, 20, 30 };
            int capacity = 4;
            int maxValue = Knapsack(weights, values, capacity);
            Console.WriteLine($"Wartość plecaka: {maxValue}");

            // Test KMP
            string text = "ABCABCAB";
            string pattern = "ABC";
            int index2 = KMPSearch(text, pattern);
            Console.WriteLine($"Wzorzec znaleziony na indeksie: {index2}");

            // Szyfrowanie tekstu przy użyciu słownika
            string text = "abcdefg";  // Przykładowy tekst do zaszyfrowania

            // Słownik szyfru literowego
            Dictionary<char, char> cipher = CreateCipher();

            // Wyświetlenie przed szyfrowaniem
            Console.WriteLine("Oryginalny tekst: " + text);

            // Szyfrowanie tekstu
            string encryptedText = EncryptText(text, cipher);

            // Wyświetlenie zaszyfrowanego tekstu
            Console.WriteLine("Zaszyfrowany tekst: " + encryptedText);
        }

        // Metoda pomocnicza do wyświetlania tablicy
        // Ta metoda wypisuje wszystkie elementy tablicy na ekranie, oddzielając je spacjami.
        static void PrintArray(int[] arr)
        {
            foreach (int element in arr)  // Dla każdego elementu w tablicy
            {
                Console.Write(element + " ");  // Wypisz element i oddziel go spacją
            }
            Console.WriteLine();  // Po zakończeniu wypisywania elementów, przejdź do nowej linii
        }

        // Funkcja tworząca słownik szyfru
        static Dictionary<char, char> CreateCipher()
        {
            // Definiujemy szyfr literowy
            return new Dictionary<char, char>()
            {
                {'a', 'g'}, {'b', 'f'}, {'c', 'z'}, {'d', 'k'}, {'e', 'm'},
                {'f', 'x'}, {'g', 'l'}, {'h', 'n'}, {'i', 'p'}, {'j', 'v'},
                {'k', 'o'}, {'l', 'y'}, {'m', 'r'}, {'n', 'q'}, {'o', 'u'},
                {'p', 't'}, {'q', 's'}, {'r', 'w'}, {'s', 'c'}, {'t', 'b'},
                {'u', 'a'}, {'v', 'd'}, {'w', 'e'}, {'x', 'i'}, {'y', 'j'},
                {'z', 'h'}
            };
        }

        // Funkcja szyfrująca tekst przy użyciu słownika
        static string EncryptText(string input, Dictionary<char, char> cipher)
        {
            char[] encryptedChars = new char[input.Length];

            // Przechodzimy przez każdy znak w tekście i zamieniamy go zgodnie z szyfrem
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                // Jeśli znak znajduje się w słowniku, zamieniamy go
                if (cipher.ContainsKey(currentChar))
                {
                    encryptedChars[i] = cipher[currentChar];
                }
                else
                {
                    // Jeśli znak nie jest literą, pozostaje bez zmian (np. spacje, cyfry)
                    encryptedChars[i] = currentChar;
                }
            }

            return new string(encryptedChars);  // Zwracamy zaszyfrowany tekst
        }

        #region Quick Sort
        // Algorytm sortowania szybkiego (QuickSort)
        // Metoda QuickSort implementuje algorytm dziel i zwyciężaj.
        // Sortuje tablicę w miejscu (nie tworzy nowych tablic).
        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)  // Sprawdzamy, czy zakres indeksów jest poprawny
            {
                // Partition dzieli tablicę na dwie części, a pi wskazuje na miejsce podziału
                int pi = Partition(arr, low, high);

                // Rekurencyjnie sortujemy dwie części tablicy
                QuickSort(arr, low, pi - 1);  // Sortowanie lewej części
                QuickSort(arr, pi + 1, high);  // Sortowanie prawej części
            }
        }

        // Metoda Partition wybiera pivot (element rozdzielający) i ustawia go w odpowiedniej pozycji
        // Wszystkie elementy mniejsze od pivota są po jego lewej stronie, a większe po prawej.
        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];  // Wybieramy ostatni element tablicy jako pivot
            int i = low - 1;  // Ustawiamy wskaźnik i na początek tablicy

            for (int j = low; j < high; j++)  // Przechodzimy przez tablicę
            {
                // Jeśli aktualny element jest mniejszy lub równy pivotowi
                if (arr[j] <= pivot)
                {
                    i++;  // Przesuwamy wskaźnik i
                    Swap(arr, i, j);  // Zamieniamy elementy
                }
            }

            // Przenosimy pivot na właściwą pozycję
            Swap(arr, i + 1, high);
            return i + 1;  // Zwracamy indeks pivota
        }

        // Metoda Swap zamienia miejscami dwa elementy w tablicy
        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];  // Zapisujemy element i do zmiennej pomocniczej
            arr[i] = arr[j];  // Przypisujemy element j do pozycji i
            arr[j] = temp;  // Przypisujemy zapisany element i do pozycji j
        }
        #endregion

        #region Selection Sort
        /// <summary>
        /// Algorytm sortowania przez wybieranie (SelectionSort)
        /// </summary>
        /// <param name="arr">Tablica do posortowania</param>
        static void SelectionSort(int[] arr)
        {
            int n = arr.Length;

            // Przechodzimy przez wszystkie elementy tablicy
            for (int i = 0; i < n - 1; i++)
            {
                // Zakładamy, że aktualny element to najmniejszy
                int minIndex = i;

                // Sprawdzamy pozostałą część tablicy, aby znaleźć najmniejszy element
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Jeśli znaleźliśmy mniejszy element, zamieniamy je miejscami
                if (minIndex != i)
                {
                    Swap(arr, i, minIndex);
                }
            }
        }

        /// <summary>
        /// Funkcja pomocnicza do zamiany miejscami dwóch elementów w tablicy.
        /// </summary>
        /// <param name="arr">Tablica liczb</param>
        /// <param name="i">Indeks pierwszego elementu</param>
        /// <param name="j">Indeks drugiego elementu</param>
        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        #endregion

        #region Bucket Sort
        /// <summary>
        /// Algorytm sortowania przez kubełki (BucketSort).
        /// Zakłada, że dane są liczbami zmiennoprzecinkowymi w zakresie [0, 1).
        /// </summary>
        /// <param name="arr">Tablica do posortowania</param>
        static void BucketSort(double[] arr)
        {
            if (arr.Length <= 1)
                return;

            // 1. Znalezienie maksymalnej wartości w tablicy, aby określić liczbę kubełków
            double maxValue = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > maxValue)
                {
                    maxValue = arr[i];
                }
            }

            // 2. Tworzymy kubełki
            int numberOfBuckets = arr.Length;
            List<double>[] buckets = new List<double>[numberOfBuckets];

            // Inicjalizujemy puste kubełki
            for (int i = 0; i < numberOfBuckets; i++)
            {
                buckets[i] = new List<double>();
            }

            // 3. Rozdzielamy elementy do odpowiednich kubełków
            for (int i = 0; i < arr.Length; i++)
            {
                int index = (int)(arr[i] * numberOfBuckets); // Określamy kubełek dla danego elementu
                buckets[index].Add(arr[i]);
            }

            // 4. Sortujemy każdy kubełek za pomocą Insertion Sort
            for (int i = 0; i < numberOfBuckets; i++)
            {
                InsertionSort(buckets[i]);
            }

            // 5. Łączymy elementy z poszczególnych kubełków z powrotem do tablicy
            int currentIndex = 0;
            for (int i = 0; i < numberOfBuckets; i++)
            {
                foreach (var item in buckets[i])
                {
                    arr[currentIndex++] = item;
                }
            }
        }

        /// <summary>
        /// Algorytm sortowania przez wstawianie (InsertionSort) na jednej liście.
        /// Jest używany do sortowania elementów w każdym kubełku.
        /// </summary>
        /// <param name="bucket">Lista elementów do posortowania</param>
        static void InsertionSort(List<double> bucket)
        {
            int n = bucket.Count;
            for (int i = 1; i < n; i++)
            {
                double current = bucket[i];
                int j = i - 1;

                // Przesuwamy większe elementy w prawo, aby zrobić miejsce dla bieżącego
                while (j >= 0 && bucket[j] > current)
                {
                    bucket[j + 1] = bucket[j];
                    j--;
                }
                bucket[j + 1] = current;
            }
        }
        #endregion

        #region Merge Sort
        // Algorytm sortowania przez scalanie (MergeSort)
        static void MergeSort(int[] arr)
        {
            // Jeśli tablica ma więcej niż jeden element, dzielimy ją i sortujemy
            if (arr.Length <= 1) return;

            int mid = arr.Length / 2;  // Znajdowanie środka tablicy
            int[] left = arr.Take(mid).ToArray();  // Lewa część tablicy
            int[] right = arr.Skip(mid).ToArray();  // Prawa część tablicy

            MergeSort(left);  // Rekurencyjnie sortujemy lewą część
            MergeSort(right);  // Rekurencyjnie sortujemy prawą część

            // Scalanie posortowanych części
            Merge(arr, left, right);
        }

        // Funkcja pomocnicza do scalania dwóch posortowanych tablic
        static void Merge(int[] arr, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;

            // Scalanie obu tablic w jedną
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            // Jeśli w lewej tablicy zostały jakieś elementy
            while (i < left.Length)
            {
                arr[k] = left[i];
                i++;
                k++;
            }

            // Jeśli w prawej tablicy zostały jakieś elementy
            while (j < right.Length)
            {
                arr[k] = right[j];
                j++;
                k++;
            }
        }
        #endregion

        // Algorytm zliczania wystąpień liczb w tablicy
        static void CountOccurrences(int[] arr)
        {
            // Tworzymy słownik, który będzie przechowywał liczbę wystąpień każdej liczby
            Dictionary<int, int> occurrences = new Dictionary<int, int>();

            // Iterujemy przez tablicę i zliczamy wystąpienia
            foreach (int num in arr)
            {
                if (occurrences.ContainsKey(num))
                {
                    occurrences[num]++;
                }
                else
                {
                    occurrences[num] = 1;
                }
            }

            // Wypisujemy liczby, które występują co najmniej dwa razy
            Console.WriteLine("\nLiczby, które występują co najmniej dwa razy:");
            foreach (var entry in occurrences)
            {
                if (entry.Value >= 2)
                {
                    Console.WriteLine($"Liczba {entry.Key} występuje {entry.Value} razy");
                }
            }
        }

        #region Insertion Sort
        // Algorytm sortowania przez wstawianie (InsertionSort)
        // Działa na zasadzie wstawiania każdego elementu w odpowiednie miejsce w posortowanej części tablicy.
        static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)  // Zaczynamy od drugiego elementu
            {
                int key = arr[i];  // Klucz to element, który chcemy wstawić
                int j = i - 1;  // Wskaźnik j wskazuje na poprzedni element

                // Przesuwamy elementy większe od klucza o jedno miejsce w prawo
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];  // Przesuwamy element w prawo
                    j--;  // Przesuwamy wskaźnik j
                }

                arr[j + 1] = key;  // Wstawiamy klucz w odpowiednie miejsce
            }
        }
        #endregion

        #region Bubble Sort
        // Algorytm sortowania bąbelkowego (BubbleSort)
        // Polega na porównywaniu kolejnych par elementów i ich zamienianiu miejscami, aż do uzyskania posortowanej tablicy.
        static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)  // Iterujemy przez całą tablicę
            {
                for (int j = 0; j < arr.Length - i - 1; j++)  // Dla każdego elementu do końca tablicy
                {
                    // Jeśli element jest większy od następnego, zamieniamy je miejscami
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(arr, j, j + 1);  // Zamiana elementów
                    }
                }
            }
        }
        #endregion

        #region Heap Sort
        /// <summary>
        /// Algorytm sortowania przez kopcowanie (Heap Sort)
        /// </summary>
        /// <param name="arr">Tablica liczb do posortowania</param>
        static void HeapSort(int[] arr)
        {
            int n = arr.Length;

            // 1. Budowanie kopca (max-heap)
            // Zaczynamy od ostatniego węzła, który ma dzieci, czyli od n/2 - 1
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            // 2. Sortowanie - Usuwanie największego elementu (korzenia kopca)
            for (int i = n - 1; i >= 1; i--)
            {
                // Zamiana korzenia (największego elementu) z ostatnim elementem
                Swap(arr, 0, i);

                // Przywracanie właściwości kopca na korzeniu (Heapify)
                Heapify(arr, i, 0);
            }
        }

        /// <summary>
        /// Funkcja Heapify zapewnia, że poddrzewo z korzeniem w indeksie i jest kopcem maksymalnym.
        /// </summary>
        /// <param name="arr">Tablica liczb</param>
        /// <param name="n">Rozmiar tablicy (lub rozmiar kopca w danym kroku)</param>
        /// <param name="i">Indeks korzenia poddrzewa, które ma zostać uporządkowane</param>
        static void Heapify(int[] arr, int n, int i)
        {
            int largest = i; // Zakładamy, że korzeń jest największy
            int left = 2 * i + 1; // Indeks lewego dziecka
            int right = 2 * i + 2; // Indeks prawego dziecka

            // Sprawdzamy, czy lewe dziecko jest większe niż korzeń
            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }

            // Sprawdzamy, czy prawe dziecko jest większe niż korzeń (lub lewe dziecko)
            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            // Jeśli największy element nie jest korzeniem, zamieniamy je miejscami
            if (largest != i)
            {
                Swap(arr, i, largest);

                // Rekurencyjnie przywracamy właściwości kopca dla zmienionego poddrzewa
                Heapify(arr, n, largest);
            }
        }

        /// <summary>
        /// Funkcja pomocnicza do zamiany miejscami dwóch elementów w tablicy.
        /// </summary>
        /// <param name="arr">Tablica liczb</param>
        /// <param name="i">Indeks pierwszego elementu</param>
        /// <param name="j">Indeks drugiego elementu</param>
        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        #endregion

        #region Cycle Sort
        /// <summary>
        /// Algorytm Cycle Sort, który sortuje tablicę bez używania dodatkowej przestrzeni.
        /// </summary>
        /// <param name="arr">Tablica do posortowania</param>
        static void CycleSort(int[] arr)
        {
            int n = arr.Length;

            // Przechodzimy przez wszystkie elementy tablicy
            for (int cycleStart = 0; cycleStart < n - 1; cycleStart++)
            {
                // Zaczynamy cykl od elementu cycleStart
                int item = arr[cycleStart];

                // Znajdujemy pozycję, do której powinien trafić element
                int pos = cycleStart;
                for (int i = cycleStart + 1; i < n; i++)
                {
                    if (arr[i] < item)
                    {
                        pos++;
                    }
                }

                // Jeśli element już znajduje się na odpowiedniej pozycji, nie wykonujemy żadnej zamiany
                if (pos == cycleStart)
                {
                    continue;
                }

                // Umieszczamy element w odpowiedniej pozycji
                if (arr[pos] == item)
                {
                    continue;  // Jeśli element jest już na tej pozycji, nic nie robimy
                }
                int temp = item;
                item = arr[pos];
                arr[pos] = temp;

                // Wykonujemy przesuwanie elementów, aby umieścić je na odpowiednich miejscach
                while (pos != cycleStart)
                {
                    pos = cycleStart;

                    // Znajdujemy nową pozycję, na którą należy przesunąć element
                    for (int i = cycleStart + 1; i < n; i++)
                    {
                        if (arr[i] < item)
                        {
                            pos++;
                        }
                    }

                    // Wstawiamy element w odpowiednie miejsce
                    if (item == arr[pos])
                    {
                        break;
                    }
                    temp = item;
                    item = arr[pos];
                    arr[pos] = temp;
                }
            }
        }
        #endregion

        #region Counting Sort
        // Algorytm sortowania przez zliczanie (CountingSort)
        // Sortowanie liczb całkowitych o określonym zakresie wartości.
        static void CountingSort(int[] arr)
        {
            // Znajdujemy maksymalny i minimalny element w tablicy
            int max = arr.Max();
            int min = arr.Min();
            int range = max - min + 1;  // Obliczamy zakres wartości

            // Tworzymy tablicę zliczającą i tablicę wyjściową
            int[] count = new int[range];
            int[] output = new int[arr.Length];

            // Zliczamy wystąpienia każdego elementu w tablicy
            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i] - min]++;  // Inkrementujemy odpowiednią komórkę w tablicy count
            }

            // Zmieniamy tablicę count, aby zawierała indeksy końcowe
            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];  // Dodajemy poprzednią wartość do bieżącej
            }

            // Budujemy posortowaną tablicę output
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                output[count[arr[i] - min] - 1] = arr[i];  // Umieszczamy element w odpowiedniej pozycji
                count[arr[i] - min]--;  // Zmniejszamy licznik
            }

            // Kopiujemy posortowaną tablicę z powrotem do oryginalnej tablicy
            Array.Copy(output, arr, arr.Length);
        }
        #endregion

        #region Radix Sort
        // Sortowanie pozycyjne (RadixSort)
        // Sortuje liczby w wielu przebiegach, sortując cyfry po kolei (od najmniej znaczącej do najbardziej znaczącej).
        static void RadixSort(int[] arr)
        {
            int max = arr.Max();  // Znajdujemy największy element w tablicy
            for (int exp = 1; max / exp > 0; exp *= 10)  // Dla każdej cyfry (od 1, 10, 100, ...)
            {
                // Sortujemy tablicę według bieżącej cyfry (exp)
                CountingSortForRadix(arr, exp);
            }
        }

        // Pomocnicza metoda sortująca za pomocą CountingSort, ale sortująca według poszczególnych cyfr
        static void CountingSortForRadix(int[] arr, int exp)
        {
            int[] output = new int[arr.Length];
            int[] count = new int[10];  // Tablica zliczająca wystąpienia cyfr (0-9)

            // Zliczamy wystąpienia cyfr w tablicy
            for (int i = 0; i < arr.Length; i++)
            {
                count[(arr[i] / exp) % 10]++;  // Zliczamy cyfrę na miejscu exp
            }

            // Zmieniamy tablicę count, aby zawierała indeksy końcowe
            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];  // Dodajemy poprzednią wartość do bieżącej
            }

            // Budujemy posortowaną tablicę output
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];  // Umieszczamy element w odpowiedniej pozycji
                count[(arr[i] / exp) % 10]--;  // Zmniejszamy licznik
            }

            // Kopiujemy posortowaną tablicę z powrotem do oryginalnej tablicy
            Array.Copy(output, arr, arr.Length);
        }
        #endregion

        #region NWD (Największy Wspólny Dzielnik)
        // Algorytm obliczania NWD (Największego Wspólnego Dzielnika) metodą Euklidesa
        static int NWD(int a, int b)
        {
            while (b != 0)  // Dopóki b nie jest równe 0
            {
                int temp = b;  // Zapisujemy wartość b
                b = a % b;  // Obliczamy resztę z dzielenia a przez b
                a = temp;  // Przypisujemy b do a
            }
            return a;  // Zwracamy wynik, który jest największym wspólnym dzielnikiem
        }
        #endregion

        #region NWW (Najmniejsza Wspólna Wielokrotność)
        // Algorytm obliczania NWW (Najmniejszej Wspólnej Wielokrotności) na podstawie NWD
        static int NWW(int a, int b)
        {
            return (a * b) / NWD(a, b);  // NWW = (a * b) / NWD(a, b)
        }
        #endregion


        #region Binary Search (Wyszukiwanie binarne)
        // Algorytm wyszukiwania binarnego
        // Złożoność czasowa: O(log n)
        // Wyszukuje element w posortowanej tablicy

        static int BinarySearch(int[] arr, int target)
        {
            int low = 0;
            int high = arr.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                // Sprawdzamy, czy znaleźliśmy element
                if (arr[mid] == target)
                    return mid;

                // Jeśli element mniejszy, to szukamy w lewej części
                if (arr[mid] > target)
                    high = mid - 1;

                // Jeśli element większy, to szukamy w prawej części
                else
                    low = mid + 1;
            }

            // Jeśli element nie został znaleziony
            return -1;
        }
        #endregion

        #region Linear Search (Wyszukiwanie liniowe)
        // Algorytm wyszukiwania liniowego - sprawdza każdy element tablicy po kolei, aż znajdzie poszukiwany element.
        // Złożoność: O(n), gdzie n to liczba elementów w tablicy, ponieważ w najgorszym przypadku trzeba sprawdzić każdy element.
        static int LinearSearch(int[] arr, int target)
        {
            // Przechodzimy po wszystkich elementach tablicy
            for (int i = 0; i < arr.Length; i++)
            {
                // Jeśli znajdziemy element równy poszukiwanemu, zwracamy jego indeks
                if (arr[i] == target)
                    return i;
            }

            // Jeśli element nie zostanie znaleziony, zwracamy -1
            return -1;
        }
        #endregion

        #region Sentinel Search (Wyszukiwanie z wartownikiem)
        // Algorytm wyszukiwania z wartownikiem - poprawia klasyczne wyszukiwanie liniowe, aby uniknąć sprawdzania warunku zakończenia pętli.
        // Złożoność: O(n), ponieważ w najgorszym przypadku musimy przejść przez wszystkie elementy. Wykorzystanie wartownika minimalizuje liczbę porównań.
        static int SentinelSearch(int[] arr, int target)
        {
            int n = arr.Length;

            // Zapamiętujemy ostatni element tablicy, aby przywrócić go po zakończeniu wyszukiwania
            int last = arr[n - 1];

            // Ustawiamy wartownika (element poszukiwany) na ostatnią pozycję w tablicy
            arr[n - 1] = target;

            int i = 0;
            // Przeszukujemy tablicę, aż znajdziemy poszukiwany element lub dotrzemy do ostatniej pozycji (z wartownikiem)
            while (arr[i] != target)
            {
                i++;
            }

            // Przywracamy wartość ostatniego elementu
            arr[n - 1] = last;

            // Jeśli znaleźliśmy element w tablicy, zwracamy jego indeks
            // Musimy również sprawdzić, czy nie trafiliśmy na wartownika, który mógł być ustawiony na ostatnią pozycję
            if (i < n - 1 || arr[n - 1] == target)
                return i;

            // Jeśli element nie został znaleziony, zwracamy -1
            return -1;
        }
        #endregion

        #region Find Max (Wyszukiwanie maksymalnej wartości)
        // Algorytm wyszukiwania maksymalnej wartości - przechodzi przez tablicę, porównując każdy element, aby znaleźć największy.
        // Złożoność: O(n), gdzie n to liczba elementów w tablicy, ponieważ musimy przejść przez każdy element, aby znaleźć największy.
        static int FindMax(int[] arr)
        {
            int max = arr[0]; // Zakładamy, że pierwszy element jest maksymalny
            for (int i = 1; i < arr.Length; i++) // Przechodzimy przez pozostałe elementy tablicy
            {
                // Jeśli znajdziemy element większy od aktualnie zapisanego maksimum, aktualizujemy maksimum
                if (arr[i] > max)
                    max = arr[i];
            }
            // Zwracamy znalezioną maksymalną wartość
            return max;
        }
        #endregion

        #region Find Min (Wyszukiwanie minimalnej wartości)
        // Algorytm wyszukiwania minimalnej wartości - przechodzi przez tablicę, porównując każdy element, aby znaleźć najmniejszy.
        // Złożoność: O(n), gdzie n to liczba elementów w tablicy, ponieważ musimy przejść przez każdy element, aby znaleźć najmniejszy.
        static int FindMin(int[] arr)
        {
            int min = arr[0]; // Zakładamy, że pierwszy element jest minimalny
            for (int i = 1; i < arr.Length; i++) // Przechodzimy przez pozostałe elementy tablicy
            {
                // Jeśli znajdziemy element mniejszy od aktualnie zapisanego minimum, aktualizujemy minimum
                if (arr[i] < min)
                    min = arr[i];
            }
            // Zwracamy znalezioną minimalną wartość
            return min;
        }
        #endregion

        #region Find Max and Min (Wyszukiwanie max i min)
        // Algorytm wyszukiwania maksymalnej i minimalnej wartości jednocześnie - przechodzi przez tablicę i porównuje elementy, aby znaleźć zarówno największy, jak i najmniejszy element.
        // Złożoność: O(n), ponieważ przechodzimy przez tablicę tylko raz, porównując każdy element zarówno z maksymalną, jak i minimalną wartością.
        static (int, int) FindMaxMin(int[] arr)
        {
            int max = arr[0]; // Zakładamy, że pierwszy element jest maksymalny
            int min = arr[0]; // Zakładamy, że pierwszy element jest minimalny

            // Przechodzimy przez pozostałe elementy tablicy
            for (int i = 1; i < arr.Length; i++)
            {
                // Jeśli znajdziemy element większy od aktualnego maksimum, aktualizujemy maksimum
                if (arr[i] > max)
                    max = arr[i];

                // Jeśli znajdziemy element mniejszy od aktualnego minimum, aktualizujemy minimum
                if (arr[i] < min)
                    min = arr[i];
            }

            // Zwracamy krotkę z maksymalną i minimalną wartością
            return (max, min);
        }
        #endregion

        #region Palindrome Check (Sprawdzanie palindromu)
        // Algorytm sprawdzający, czy dany ciąg znaków jest palindromem - porównuje elementy z dwóch końców łańcucha, przesuwając wskaźniki ku środkowi.
        // Złożoność: O(n), gdzie n to długość ciągu, ponieważ przechodzimy przez połowę ciągu, porównując pary znaków.
        static bool IsPalindrome(string str)
        {
            int left = 0; // Początkowy indeks (pierwszy znak)
            int right = str.Length - 1; // Końcowy indeks (ostatni znak)

            // Sprawdzamy, czy znaki na końcach łańcucha są takie same
            while (left < right)
            {
                // Jeśli znaki na końcach nie są takie same, zwracamy false (nie jest palindromem)
                if (str[left] != str[right])
                    return false;
                left++;  // Przechodzimy do następnego znaku z lewej strony
                right--; // Przechodzimy do poprzedniego znaku z prawej strony
            }

            // Jeśli przeszliśmy przez cały ciąg i nie znaleźliśmy różnic, zwracamy true (ciąg jest palindromem)
            return true;
        }
        #endregion

        #region Generate Random Array (Generowanie tablicy z losowymi liczbami)
        // Metoda generująca tablicę z losowymi liczbami
        // Parametry:
        // - size: liczba elementów w tablicy
        // - min: minimalna wartość
        // - max: maksymalna wartość

        static int[] GenerateRandomArray(int size, int min, int max)
        {
            Random rand = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(min, max + 1); // Losowanie liczb z zakresu [min, max]
            }

            return array;
        }
        #endregion

        #region Algorytmy grafowe
        // Przeszukiwanie w głąb (DFS) - algorytm do odwiedzania wierzchołków grafu
        static void DFS(int[,] graph, int start, bool[] visited)
        {
            visited[start] = true;  // Oznaczamy wierzchołek jako odwiedzony
            Console.Write(start + " ");  // Wypisujemy wierzchołek

            for (int i = 0; i < graph.GetLength(1); i++)  // Iterujemy po sąsiadach
            {
                if (graph[start, i] == 1 && !visited[i])  // Jeśli są sąsiedzi i nie byli jeszcze odwiedzeni
                {
                    DFS(graph, i, visited);  // Rekurencyjnie odwiedzamy sąsiadów
                }
            }
        }

        // Przeszukiwanie wszerz (BFS) - algorytm odwiedzania wierzchołków grafu
        static void BFS(int[,] graph, int start)
        {
            bool[] visited = new bool[graph.GetLength(0)];
            Queue<int> queue = new Queue<int>();

            visited[start] = true;
            queue.Enqueue(start);  // Dodajemy wierzchołek początkowy do kolejki

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();  // Zdejmujemy wierzchołek z kolejki
                Console.Write(node + " ");  // Wypisujemy wierzchołek

                for (int i = 0; i < graph.GetLength(1); i++)
                {
                    if (graph[node, i] == 1 && !visited[i])  // Sprawdzamy sąsiadów
                    {
                        visited[i] = true;  // Oznaczamy sąsiada jako odwiedzonego
                        queue.Enqueue(i);  // Dodajemy sąsiada do kolejki
                    }
                }
            }
        }
        #endregion

        #region Dijkstra (najkrótsza ścieżka)
        // Algorytm Dijkstry - znajduje najkrótsze ścieżki w grafie o nieujemnych wagach krawędzi
        static int[] Dijkstra(int[,] graph, int source)
        {
            int n = graph.GetLength(0);
            int[] distances = new int[n];
            bool[] visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                distances[i] = int.MaxValue;  // Ustawiamy początkowe odległości na nieskończoność
            }
            distances[source] = 0;  // Odległość do samego siebie wynosi 0

            for (int i = 0; i < n - 1; i++)
            {
                int u = MinDistance(distances, visited, n);  // Wybieramy wierzchołek o najmniejszej odległości
                visited[u] = true;

                // Aktualizujemy odległości do sąsiadów wierzchołka u
                for (int v = 0; v < n; v++)
                {
                    if (!visited[v] && graph[u, v] != 0 && distances[u] != int.MaxValue &&
                        distances[u] + graph[u, v] < distances[v])
                    {
                        distances[v] = distances[u] + graph[u, v];  // Aktualizujemy najmniejszą odległość
                    }
                }
            }
            return distances;
        }

        // Pomocnicza funkcja do znajdowania wierzchołka o najmniejszej odległości
        static int MinDistance(int[] distances, bool[] visited, int n)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < n; v++)
            {
                if (!visited[v] && distances[v] < min)
                {
                    min = distances[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
        #endregion

        #region Algorytmy dynamiczne

        // Problem plecakowy - dynamiczne rozwiązanie problemu plecakowego
        static int Knapsack(int[] weights, int[] values, int capacity)
        {
            int n = weights.Length;
            int[,] dp = new int[n + 1, capacity + 1];  // Tablica przechowująca wyniki podproblemów

            // Budujemy tablicę dp od dołu do góry
            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= capacity; w++)
                {
                    if (i == 0 || w == 0)  // Jeśli brak przedmiotów lub brak pojemności plecaka
                    {
                        dp[i, w] = 0;
                    }
                    else if (weights[i - 1] <= w)  // Jeśli możemy zmieścić przedmiot
                    {
                        // Zdecyduj, czy lepiej zabrać przedmiot, czy go odrzucić
                        dp[i, w] = Math.Max(values[i - 1] + dp[i - 1, w - weights[i - 1]], dp[i - 1, w]);
                    }
                    else
                    {
                        dp[i, w] = dp[i - 1, w];  // Jeśli nie możemy zmieścić przedmiotu
                    }
                }
            }

            return dp[n, capacity];  // Zwracamy wynik - maksymalną wartość, jaką możemy uzyskać
        }

        #endregion

        #region Algorytmy na ciągach
        // Algorytm KMP (Knuth-Morris-Pratt) - wyszukiwanie wzorca w ciągu tekstowym
        static int KMPSearch(string text, string pattern)
        {
            int m = pattern.Length;
            int n = text.Length;
            int[] lps = new int[m];  // Tablica do przechowywania długości najdłuższych prefiksów

            // Preprocessing wzorca (tablica LPS)
            ComputeLPSArray(pattern, m, lps);

            int i = 0;  // Indeks w tekście
            int j = 0;  // Indeks we wzorcu
            while (i < n)
            {
                if (pattern[j] == text[i])
                {
                    i++;
                    j++;
                }
                if (j == m)
                {
                    return i - j;  // Zwracamy indeks, w którym wzorzec został znaleziony
                }
                else if (i < n && pattern[j] != text[i])
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return -1;  // Zwracamy -1, jeśli nie znaleziono wzorca
        }

        // Funkcja pomocnicza do obliczania tablicy LPS
        static void ComputeLPSArray(string pattern, int m, int[] lps)
        {
            int length = 0;  // Długość poprzedniego najdłuższego prefiksu
            int i = 1;
            while (i < m)
            {
                if (pattern[i] == pattern[length])
                {
                    length++;
                    lps[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                    {
                        length = lps[length - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
        }
        #endregion
    }
}

