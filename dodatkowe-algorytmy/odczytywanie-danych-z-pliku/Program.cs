using System.Collections.Generic;
using System;
using System.IO;

namespace odczytywanie_danych_z_pliku
{
    // Klasa reprezentująca dane o albumie muzycznym
    class MusicAlbum
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public long Downloads { get; set; }

        // Konstruktor klasy MusicAlbum
        public MusicAlbum(string title, string artist, int year, long downloads)
        {
            Title = title;
            Artist = artist;
            Year = year;
            Downloads = downloads;
        }

        // Metoda do wyświetlania danych albumu
        public void DisplayAlbumInfo()
        {
            Console.WriteLine($"Tytuł: {Title}");
            Console.WriteLine($"Artysta: {Artist}");
            Console.WriteLine($"Rok: {Year}");
            Console.WriteLine($"Liczba pobrań: {Downloads}");
            Console.WriteLine("------------------------------");
        }
    }

    internal class Program
    {
        // Funkcja do wczytania danych z pliku
        static List<MusicAlbum> LoadAlbums(string fileName)
        {
            List<MusicAlbum> albums = new List<MusicAlbum>();

            // Sprawdzenie, czy plik istnieje
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"Błąd: Plik '{fileName}' nie istnieje.");
                return albums;
            }

            /*try
            {
                // Odczyt pliku
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Rozdzielanie danych z linii (zakładamy format: Tytuł;Artysta;Rok;LiczbaPobrań)
                        string[] parts = line.Split(';');
                        if (parts.Length == 4)
                        {
                            string title = parts[0];
                            string artist = parts[1];
                            int year = int.Parse(parts[2]);
                            long downloads = long.Parse(parts[3]);

                            // Tworzenie obiektu albumu i dodanie go do listy
                            albums.Add(new MusicAlbum(title, artist, year, downloads));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd przy wczytywaniu danych: {ex.Message}");
            }*/

            try
            {
                // Odczyt pliku
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string title = string.Empty;
                    string artist = string.Empty;
                    int year = 0;
                    long downloads = 0;

                    int lineCount = 0; // Licznik linii

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine().Trim();

                        // Ignorujemy puste linie
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        // Zbieranie danych z 4 kolejnych linii
                        switch (lineCount % 4)
                        {
                            case 0: // Tytuł
                                title = line;
                                break;
                            case 1: // Artysta
                                artist = line;
                                break;
                            case 2: // Rok
                                if (!int.TryParse(line, out year))
                                {
                                    Console.WriteLine($"Błąd: Nieprawidłowy rok '{line}' w linii {lineCount + 1}.");
                                    return albums;
                                }
                                break;
                            case 3: // Liczba pobrań
                                if (!long.TryParse(line, out downloads))
                                {
                                    Console.WriteLine($"Błąd: Nieprawidłowa liczba pobrań '{line}' w linii {lineCount + 1}.");
                                    return albums;
                                }

                                // Po zebraniu wszystkich danych, tworzymy obiekt albumu
                                albums.Add(new MusicAlbum(title, artist, year, downloads));
                                break;
                        }

                        lineCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd przy wczytywaniu danych: {ex.Message}");
            }

            return albums;
        }

        // Funkcja do wyświetlania danych o albumach
        static void DisplayAlbums(List<MusicAlbum> albums)
        {
            if (albums.Count == 0)
            {
                Console.WriteLine("Brak danych do wyświetlenia.");
                return;
            }

            foreach (var album in albums)
            {
                album.DisplayAlbumInfo();
            }
        }

        static void Main(string[] args)
        {
            // Ścieżka do pliku z danymi
            string fileName = "Data.txt";

            // Wczytanie albumów z pliku
            List<MusicAlbum> albums = LoadAlbums(fileName);

            // Wyświetlenie albumów
            DisplayAlbums(albums);
        }
    }
}
