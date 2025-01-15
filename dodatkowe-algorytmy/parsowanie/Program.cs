using System.Globalization;

namespace parsowanie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== MENU GŁÓWNE ===");
                Console.WriteLine("1. Parsowanie danych z konsoli");
                Console.WriteLine("2. Parsowanie danych z pliku tekstowego");
                Console.WriteLine("3. Parsowanie CSV");
                Console.WriteLine("4. Parsowanie złożonych danych");
                Console.WriteLine("5. Wyjście");

                if (int.TryParse(Console.ReadLine(), out int wybor))
                {
                    switch (wybor)
                    {
                        case 1:
                            ParsowanieKonsoli();
                            break;
                        case 2:
                            ParsowaniePliku();
                            break;
                        case 3:
                            ParsowanieCSV();
                            break;
                        case 4:
                            ParsowanieZlozonychDanych();
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Nieprawidłowy wybór!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wprowadź poprawną liczbę!");
                }
            }
        }

        static void ParsowanieKonsoli()
        {
            Console.WriteLine("\n=== PARSOWANIE Z KONSOLI ===");

            // 1. Parsowanie liczb całkowitych
            Console.Write("Podaj liczbę całkowitą: ");
            // Bezpieczne parsowanie z użyciem TryParse
            if (int.TryParse(Console.ReadLine(), out int liczbaCalkowita))
            {
                Console.WriteLine($"Wprowadzona liczba: {liczbaCalkowita}");
            }
            else
            {
                Console.WriteLine("Błąd parsowania liczby całkowitej!");
            }

            // 2. Parsowanie liczb zmiennoprzecinkowych z różnymi kulturami
            Console.Write("Podaj liczbę zmiennoprzecinkową (użyj kropki lub przecinka): ");
            string liczbaText = Console.ReadLine();

            // Próba parsowania z kulturą polską (przecinek)
            if (double.TryParse(liczbaText, NumberStyles.Any, new CultureInfo("pl-PL"), out double liczbaDouble))
            {
                Console.WriteLine($"Liczba (kultura polska): {liczbaDouble}");
            }
            // Próba parsowania z kulturą amerykańską (kropka)
            else if (double.TryParse(liczbaText, NumberStyles.Any, new CultureInfo("en-US"), out liczbaDouble))
            {
                Console.WriteLine($"Liczba (kultura amerykańska): {liczbaDouble}");
            }
            else
            {
                Console.WriteLine("Błąd parsowania liczby zmiennoprzecinkowej!");
            }

            // 3. Parsowanie daty
            Console.Write("Podaj datę (format: dd.MM.yyyy): ");
            if (DateTime.TryParseExact(Console.ReadLine(),
                                     "dd.MM.yyyy",
                                     CultureInfo.InvariantCulture,
                                     DateTimeStyles.None,
                                     out DateTime data))
            {
                Console.WriteLine($"Data: {data:D}");
            }
            else
            {
                Console.WriteLine("Błąd parsowania daty!");
            }

            // 4. Parsowanie wartości enum
            Console.WriteLine("Dostępne dni tygodnia:");
            foreach (DayOfWeek dzien in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine($"- {dzien}");
            }
            Console.Write("Podaj dzień tygodnia: ");
            if (Enum.TryParse<DayOfWeek>(Console.ReadLine(), true, out DayOfWeek dzienTygodnia))
            {
                Console.WriteLine($"Wybrany dzień: {dzienTygodnia}");
            }
            else
            {
                Console.WriteLine("Błąd parsowania dnia tygodnia!");
            }

            // 5. Parsowanie tablicy liczb
            Console.Write("Podaj liczby oddzielone spacjami: ");
            string[] liczbyText = Console.ReadLine().Split(' ');
            try
            {
                int[] liczby = liczbyText.Select(int.Parse).ToArray();
                Console.WriteLine($"Suma podanych liczb: {liczby.Sum()}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Błąd parsowania tablicy liczb!");
            }
        }

        static void ParsowaniePliku()
        {
            Console.WriteLine("\n=== PARSOWANIE Z PLIKU ===");

            // Tworzymy przykładowy plik
            const string nazwaPliku = "przyklad.txt";
            File.WriteAllText(nazwaPliku,
                "123\n" +
                "3.14\n" +
                "Hello World\n" +
                "01.01.2024\n" +
                "true");

            Console.WriteLine("Utworzono plik przykładowy. Parsowanie różnych typów danych:");

            try
            {
                // Wczytujemy wszystkie linie z pliku
                string[] linie = File.ReadAllLines(nazwaPliku);

                // 1. Parsowanie liczby całkowitej
                int liczba = int.Parse(linie[0]);
                Console.WriteLine($"Liczba całkowita: {liczba}");

                // 2. Parsowanie liczby zmiennoprzecinkowej
                double liczbaZmiennoprzecinkowa = double.Parse(linie[1], CultureInfo.InvariantCulture);
                Console.WriteLine($"Liczba zmiennoprzecinkowa: {liczbaZmiennoprzecinkowa}");

                // 3. String nie wymaga parsowania
                string tekst = linie[2];
                Console.WriteLine($"Tekst: {tekst}");

                // 4. Parsowanie daty
                DateTime data = DateTime.ParseExact(linie[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine($"Data: {data:D}");

                // 5. Parsowanie wartości logicznej
                bool wartoscLogiczna = bool.Parse(linie[4]);
                Console.WriteLine($"Wartość logiczna: {wartoscLogiczna}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas parsowania pliku: {ex.Message}");
            }
            finally
            {
                // Sprzątanie - usuwamy utworzony plik
                if (File.Exists(nazwaPliku))
                {
                    File.Delete(nazwaPliku);
                }
            }
        }

        static void ParsowanieCSV()
        {
            Console.WriteLine("\n=== PARSOWANIE CSV ===");

            // Tworzymy przykładowy plik CSV
            const string nazwaPliku = "dane.csv";
            File.WriteAllText(nazwaPliku,
                "Imie,Wiek,DataUrodzenia,Wzrost,CzyAktywny\n" +
                "Jan,25,1999-01-15,180.5,true\n" +
                "Anna,30,1994-03-20,165.3,false\n" +
                "Piotr,28,1996-07-10,178.9,true");

            try
            {
                // Pomijamy pierwszy wiersz (nagłówki)
                var wiersze = File.ReadLines(nazwaPliku).Skip(1);
                var osoby = new List<Osoba>();

                foreach (var wiersz in wiersze)
                {
                    // Dzielimy wiersz na kolumny
                    string[] kolumny = wiersz.Split(',');

                    // Parsujemy dane do obiektu
                    var osoba = new Osoba
                    {
                        Imie = kolumny[0],
                        Wiek = int.Parse(kolumny[1]),
                        DataUrodzenia = DateTime.Parse(kolumny[2]),
                        Wzrost = double.Parse(kolumny[3], CultureInfo.InvariantCulture),
                        CzyAktywny = bool.Parse(kolumny[4])
                    };

                    osoby.Add(osoba);
                }

                // Wyświetlamy sparsowane dane
                Console.WriteLine("\nSparsowane dane z CSV:");
                foreach (var osoba in osoby)
                {
                    Console.WriteLine(osoba);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas parsowania CSV: {ex.Message}");
            }
            finally
            {
                if (File.Exists(nazwaPliku))
                {
                    File.Delete(nazwaPliku);
                }
            }
        }

        static void ParsowanieZlozonychDanych()
        {
            Console.WriteLine("\n=== PARSOWANIE ZŁOŻONYCH DANYCH ===");

            // 1. Parsowanie zakresu liczb
            Console.Write("Podaj zakres liczb (format: start-koniec, np. 1-10): ");
            string zakresText = Console.ReadLine();
            if (ParsujZakres(zakresText, out int start, out int koniec))
            {
                Console.WriteLine($"Zakres od {start} do {koniec}");
            }
            else
            {
                Console.WriteLine("Błędny format zakresu!");
            }

            // 2. Parsowanie współrzędnych
            Console.Write("Podaj współrzędne (format: x,y,z, np. 1,2,3): ");
            string wspolrzedneText = Console.ReadLine();
            if (ParsujWspolrzedne(wspolrzedneText, out double x, out double y, out double z))
            {
                Console.WriteLine($"Współrzędne: X={x}, Y={y}, Z={z}");
            }
            else
            {
                Console.WriteLine("Błędny format współrzędnych!");
            }

            // 3. Parsowanie adresu IP
            Console.Write("Podaj adres IP (format: xxx.xxx.xxx.xxx): ");
            string ipText = Console.ReadLine();
            if (ParsujIP(ipText, out byte[] ipBytes))
            {
                Console.WriteLine($"Adres IP: {string.Join(".", ipBytes)}");
            }
            else
            {
                Console.WriteLine("Błędny format adresu IP!");
            }
        }

        static bool ParsujZakres(string tekst, out int start, out int koniec)
        {
            start = 0;
            koniec = 0;

            if (string.IsNullOrEmpty(tekst))
                return false;

            string[] czesci = tekst.Split('-');
            if (czesci.Length != 2)
                return false;

            return int.TryParse(czesci[0], out start) &&
                   int.TryParse(czesci[1], out koniec) &&
                   start <= koniec;
        }

        static bool ParsujWspolrzedne(string tekst, out double x, out double y, out double z)
        {
            x = 0;
            y = 0;
            z = 0;

            if (string.IsNullOrEmpty(tekst))
                return false;

            string[] czesci = tekst.Split(',');
            if (czesci.Length != 3)
                return false;

            return double.TryParse(czesci[0], out x) &&
                   double.TryParse(czesci[1], out y) &&
                   double.TryParse(czesci[2], out z);
        }

        static bool ParsujIP(string tekst, out byte[] ipBytes)
        {
            ipBytes = new byte[4];

            if (string.IsNullOrEmpty(tekst))
                return false;

            string[] czesci = tekst.Split('.');
            if (czesci.Length != 4)
                return false;

            for (int i = 0; i < 4; i++)
            {
                if (!byte.TryParse(czesci[i], out ipBytes[i]))
                    return false;
            }

            return true;
        }

        class Osoba
        {
            public string Imie { get; set; }
            public int Wiek { get; set; }
            public DateTime DataUrodzenia { get; set; }
            public double Wzrost { get; set; }
            public bool CzyAktywny { get; set; }

            public override string ToString()
            {
                return $"{Imie}, {Wiek} lat, ur. {DataUrodzenia:d}, wzrost: {Wzrost}cm, " +
                       $"aktywny: {(CzyAktywny ? "tak" : "nie")}";
            }
        }
    }
}
