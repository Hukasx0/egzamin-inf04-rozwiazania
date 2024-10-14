namespace aplikacja_konsolowa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int liczbaKostek = PobierzLiczbęKostek();

            bool grajDalej = true;

            while (grajDalej)
            {
                int[] wyniki = RzucKostkami(liczbaKostek);
                WyswietlWyniki(wyniki);
                int punkty = ObliczPunkty(wyniki);
                Console.WriteLine($"Łączna suma punktów: {punkty}");

                grajDalej = CzyPowtorzycGre();
            }
        }

        static int PobierzLiczbęKostek()
        {
            int liczba;
            do
            {
                Console.Write("Podaj liczbę kostek do rzucenia (od 3 do 10): ");
            } while (!int.TryParse(Console.ReadLine(), out liczba) || liczba < 3 || liczba > 10);

            return liczba;
        }

        static int[] RzucKostkami(int liczbaKostek)
        {
            Random rand = new Random();
            int[] wyniki = new int[liczbaKostek];

            for (int i = 0; i < liczbaKostek; i++)
            {
                wyniki[i] = rand.Next(1, 7); // Losowanie liczby od 1 do 6
            }

            return wyniki;
        }

        static void WyswietlWyniki(int[] wyniki)
        {
            for (int i = 0; i < wyniki.Length; i++)
            {
                Console.WriteLine($"Kostka {i + 1}: {wyniki[i]}");
            }
        }

        static int ObliczPunkty(int[] wyniki)
        {
            Dictionary<int, int> liczbaWystapien = new Dictionary<int, int>();

            // Liczenie wystąpień oczek
            foreach (var oczko in wyniki)
            {
                if (liczbaWystapien.ContainsKey(oczko))
                {
                    liczbaWystapien[oczko]++;
                }
                else
                {
                    liczbaWystapien[oczko] = 1;
                }
            }

            // Obliczanie punktów
            int sumaPunktow = 0;
            foreach (var para in liczbaWystapien)
            {
                if (para.Value >= 2) // Sprawdzamy, czy liczba została wylosowana dwa razy lub więcej
                {
                    sumaPunktow += para.Key * para.Value;
                }
            }

            return sumaPunktow;
        }

        static bool CzyPowtorzycGre()
        {
            Console.Write("Czy chcesz powtórzyć grę? (t/n): ");
            char odpowiedz = Console.ReadKey().KeyChar;
            Console.WriteLine();

            return (odpowiedz == 't' || odpowiedz == 'T');
        }
    }
}
