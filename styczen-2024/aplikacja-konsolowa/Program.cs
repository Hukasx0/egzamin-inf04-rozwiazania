namespace aplikacja_konsolowa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pesel;

            // Wczytywanie numeru PESEL
            Console.Write("Wprowadź numer PESEL (11 cyfr): ");
            pesel = Console.ReadLine();

            // Jeśli PESEL jest pusty, użyj domyślnego
            if (string.IsNullOrEmpty(pesel))
            {
                pesel = "55030101193"; // Domyślny numer PESEL
            }

            // Sprawdzenie płci
            char plec = SprawdzPlec(pesel);
            string plecStr = plec == 'K' ? "Kobieta" : "Mężczyzna";
            Console.WriteLine($"Płeć: {plecStr}");

            // Sprawdzenie sumy kontrolnej
            bool sumaZgodna = SprawdzSumeKontrolna(pesel);
            if (sumaZgodna)
            {
                Console.WriteLine("Suma kontrolna jest zgodna.");
            }
            else
            {
                Console.WriteLine("Suma kontrolna jest niezgodna.");
            }
        }

        static char SprawdzPlec(string pesel)
        {
            // Sprawdzenie długości PESEL
            if (pesel.Length != 11)
            {
                throw new ArgumentException("Numer PESEL musi mieć 11 cyfr.");
            }

            // dziesiąta cyfra (indeks 9) decyduje o płci
            char cyfraPlec = pesel[9];
            return (cyfraPlec % 2 == 0) ? 'K' : 'M'; // K - kobieta, M - mężczyzna
        }

        static bool SprawdzSumeKontrolna(string pesel)
        {
            int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int suma = 0;

            // Obliczanie sumy
            for (int i = 0; i < 10; i++)
            {
                suma += (pesel[i] - '0') * wagi[i];
            }

            int M = suma % 10;
            int R = (M == 0) ? 0 : 10 - M;

            // Porównanie z ostatnią cyfrą PESEL
            return (R == (pesel[10] - '0'));
        }
    }
}
