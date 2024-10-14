namespace aplikacja_konsolowa
{
    internal class Program
    {
        class Euklides
        {
            // Funkcja obliczająca NWD za pomocą algorytmu Euklidesa
            public static int ObliczNwd(int a, int b)
            {
                while (b != 0)
                {
                    int temp = b;
                    b = a % b;
                    a = temp;
                }
                return a;
            }

            static void Main(string[] args)
            {
                int a, b;

                // Wczytywanie liczb a i b od użytkownika
                Console.Write("Wprowadź pierwszą liczbę całkowitą dodatnią (a): ");
                while (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
                {
                    Console.Write("Błąd! Proszę wprowadzić liczbę całkowitą dodatnią: ");
                }

                Console.Write("Wprowadź drugą liczbę całkowitą dodatnią (b): ");
                while (!int.TryParse(Console.ReadLine(), out b) || b <= 0)
                {
                    Console.Write("Błąd! Proszę wprowadzić liczbę całkowitą dodatnią: ");
                }

                // Obliczanie NWD
                int nwd = ObliczNwd(a, b);

                // Wyświetlanie wyniku
                Console.WriteLine($"Największy wspólny dzielnik ({a}, {b}) to: {nwd}");
            }
        }
    }
}
