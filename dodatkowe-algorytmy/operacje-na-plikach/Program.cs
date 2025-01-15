namespace operacje_na_plikach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ścieżka do pliku, na którym będą wykonywane operacje
            string filePath = "przykladowy_plik.txt";

            // 1. Tworzenie pliku i zapisanie pierwszych danych
            Console.WriteLine("Tworzenie pliku i zapisanie danych...");
            TworzenieIZapisywaniePliku(filePath);

            // 2. Odczyt danych z pliku
            Console.WriteLine("\nOdczyt danych z pliku...");
            OdczytZPliku(filePath);

            // 3. Dodanie nowych danych do pliku
            Console.WriteLine("\nDodawanie nowych danych do pliku...");
            DodajDaneDoPliku(filePath);

            // 4. Odczyt danych po dodaniu nowych informacji
            Console.WriteLine("\nOdczyt danych po dodaniu...");
            OdczytZPliku(filePath);

            // 5. Usuwanie pliku
            Console.WriteLine("\nUsuwanie pliku...");
            UsunPlik(filePath);

            // Sprawdzenie, czy plik został usunięty
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Plik został pomyślnie usunięty.");
            }
        }

        // Funkcja do tworzenia pliku i zapisywania danych
        static void TworzenieIZapisywaniePliku(string filePath)
        {
            // Sprawdzamy, czy plik już istnieje
            if (File.Exists(filePath))
            {
                Console.WriteLine("Plik już istnieje. Zostanie nadpisany.");
            }

            // Tworzymy plik i zapisujemy dane do pliku
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Pierwsza linia w pliku.");
                writer.WriteLine("To jest przykład zapisu do pliku w C#.");
            }
            Console.WriteLine("Dane zostały zapisane do pliku.");
        }

        // Funkcja do odczytu danych z pliku
        static void OdczytZPliku(string filePath)
        {
            // Sprawdzamy, czy plik istnieje, aby uniknąć błędu
            if (File.Exists(filePath))
            {
                // Otwieramy plik do odczytu
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string content = reader.ReadToEnd(); // Odczytujemy całą zawartość pliku
                    Console.WriteLine("Zawartość pliku:\n" + content);
                }
            }
            else
            {
                Console.WriteLine("Plik nie istnieje.");
            }
        }

        // Funkcja do dodawania danych do istniejącego pliku
        static void DodajDaneDoPliku(string filePath)
        {
            // Sprawdzamy, czy plik istnieje
            if (File.Exists(filePath))
            {
                // Otwieramy plik w trybie dopisywania danych
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine("Nowa linia dodana do pliku.");
                    writer.WriteLine("To jest przykład dodawania danych do pliku.");
                }
                Console.WriteLine("Nowe dane zostały dodane do pliku.");
            }
            else
            {
                Console.WriteLine("Plik nie istnieje, nie można dodać danych.");
            }
        }

        // Funkcja do usunięcia pliku
        static void UsunPlik(string filePath)
        {
            // Sprawdzamy, czy plik istnieje, aby uniknąć błędu
            if (File.Exists(filePath))
            {
                // Usuwamy plik
                File.Delete(filePath);
                Console.WriteLine("Plik został usunięty.");
            }
            else
            {
                Console.WriteLine("Plik nie istnieje, nie można go usunąć.");
            }
        }
    }
}
