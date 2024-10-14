namespace aplikacja_konsolowa
{
    internal class Program
    {
        static void SieveOfEratosthenes(bool[] primes, int n)
        {
            for (int i = 2; i * i <= n; i++)
            {
                if (primes[i])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        primes[j] = false;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int n = 100;
            bool[] primes = new bool[n + 1];

            // Inicjalizacja tablicy: wszystkie liczby są domyślnie uznawane za pierwsze
            for (int i = 2; i <= n; i++)
            {
                primes[i] = true;
            }

            // Wypełnienie tablicy zgodnie z algorytmem sita Eratostenesa
            SieveOfEratosthenes(primes, n);

            // Wyświetlenie liczb pierwszych
            Console.WriteLine("Liczby pierwsze w przedziale 2..100:");
            for (int i = 2; i <= n; i++)
            {
                if (primes[i])
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
