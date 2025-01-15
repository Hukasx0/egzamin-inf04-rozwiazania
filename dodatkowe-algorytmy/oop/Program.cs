namespace oop
{
    internal class Program
    {
        // Statyczna klasa do rejestracji zwierząt
        public static class RejestracjaZwierzat
        {
            // Prywatne statyczne pole przechowujące licznik zarejestrowanych zwierząt
            private static int licznikZwierzat = 0;

            // Prywatna statyczna lista przechowująca unikalne gatunki zwierząt
            private static readonly List<string> zarejestrowaneGatunki = new List<string>();

            // Właściwość statyczna do odczytu liczby zarejestrowanych zwierząt
            // Umożliwia tylko odczyt wartości, ale nie zapis
            public static int LicznikZwierzat
            {
                get { return licznikZwierzat; }
                private set { licznikZwierzat = value; } // Setter jest prywatny, więc nie można ustawiać tej wartości spoza klasy
            }

            // Właściwość statyczna, która zwraca tylko do odczytu listę zarejestrowanych gatunków
            public static IReadOnlyList<string> ZarejestrowaneGatunki
            {
                get { return zarejestrowaneGatunki.AsReadOnly(); }
            }

            // Metoda statyczna, która dodaje gatunek do listy, jeśli jeszcze nie jest zarejestrowany
            public static void DodajGatunek(string gatunek)
            {
                if (!zarejestrowaneGatunki.Contains(gatunek)) // Sprawdzamy, czy gatunek już istnieje
                {
                    zarejestrowaneGatunki.Add(gatunek);
                }
            }

            // Metoda statyczna, która zwiększa licznik zwierząt
            // Zwraca nową wartość licznika
            public static int ZwiekszLicznikZwierzat()
            {
                return ++LicznikZwierzat; // Zwiększamy licznik i zwracamy nową wartość
            }
        }

        // Abstrakcyjna klasa Zwierze, która jest bazą dla wszystkich zwierząt
        public abstract class Zwierze
        {
            // Prywatne pola przechowujące dane o zwierzęciu
            private string imie;
            private int wiek;
            private readonly string gatunek;
            private double waga;
            private DateTime dataOstatniegoBadania;

            // Właściwość do odczytu i zapisu imienia zwierzęcia z walidacją (nie może być puste)
            public string Imie
            {
                get { return imie; }
                set
                {
                    if (string.IsNullOrEmpty(value)) // Walidacja, imię nie może być puste
                        throw new ArgumentException("Imię nie może być puste!");
                    imie = value;
                }
            }

            // Właściwość tylko do odczytu - gatunek jest ustalony na stałe (readonly)
            public string Gatunek
            {
                get { return gatunek; }
            }

            // Właściwość automatyczna do odczytu numeru identyfikacyjnego, tylko do odczytu
            public int NumerIdentyfikacyjny { get; private set; }

            // Właściwość z pełną implementacją i walidacją wieku
            public int Wiek
            {
                get { return wiek; }
                set
                {
                    if (value < 0) // Wiek nie może być ujemny
                        throw new ArgumentException("Wiek nie może być ujemny!");
                    if (value > 100) // Wiek nie może być większy niż 100
                        throw new ArgumentException("Wiek wydaje się zbyt wysoki!");
                    wiek = value;
                }
            }

            // Właściwość obliczana, która sprawdza, czy zwierzę wymaga badania
            public bool WymagaBadania
            {
                get
                {
                    return (DateTime.Now - dataOstatniegoBadania).TotalDays > 365; // Jeśli ostatnie badanie było ponad rok temu
                }
            }

            // Właściwość chroniona, aby tylko klasa dziedzicząca mogła zmieniać wagę zwierzęcia
            public double Waga
            {
                get { return waga; }
                protected set
                {
                    if (value <= 0) // Waga musi być większa niż 0
                        throw new ArgumentException("Waga musi być większa od 0!");
                    waga = value;
                }
            }

            // Konstruktor klasy Zwierze, który inicjalizuje wszystkie właściwości
            protected Zwierze(string imie, int wiek, string gatunek, double waga)
            {
                this.gatunek = gatunek; // Gatunek ustalony raz w konstruktorze
                this.dataOstatniegoBadania = DateTime.Now; // Ustawiamy datę ostatniego badania na teraz

                // Używamy właściwości zamiast bezpośredniego przypisania do pól, aby przeprowadzić walidację
                Imie = imie;
                Wiek = wiek;
                Waga = waga;
                NumerIdentyfikacyjny = RejestracjaZwierzat.ZwiekszLicznikZwierzat(); // Użycie licznika zarejestrowanych zwierząt
            }

            // Metoda do aktualizacji daty ostatniego badania
            public void PrzeprowadzBadanie()
            {
                dataOstatniegoBadania = DateTime.Now; // Ustawiamy bieżącą datę jako datę ostatniego badania
            }

            // Abstrakcyjna metoda do wydawania dźwięku przez zwierzę, musi być zaimplementowana w klasach dziedziczących
            public abstract void WydajDzwiek();

            // Wirtualna metoda, która zwraca informację o zwierzęciu w formacie tekstowym
            public virtual string PobierzInformacje()
            {
                return $"{Gatunek} {Imie} (Wiek: {Wiek}, Waga: {Waga}kg, ID: {NumerIdentyfikacyjny})";
            }
        }

        // Klasa Ptak, dziedzicząca po Zwierze, implementuje interfejs ILatajace
        public class Ptak : Zwierze, ILatajace
        {
            // Prywatne pole do przechowywania wysokości lotu
            private int wysokoscLotu;

            // Implementacja właściwości z interfejsu ILatajace
            public int WysokoscLotu
            {
                get { return wysokoscLotu; }
                private set
                {
                    if (value < 0) // Wysokość lotu nie może być ujemna
                        throw new ArgumentException("Wysokość lotu nie może być ujemna!");
                    wysokoscLotu = value;
                }
            }

            // Właściwość automatyczna z wartością domyślną
            public bool CzyMigruje { get; set; } = false;

            // Właściwość obliczana, która zwraca, czy ptak może latać
            public bool CzyMozeLatac => WysokoscLotu > 0;

            // Konstruktor klasy Ptak
            public Ptak(string imie, int wiek, string gatunek, int wysokoscLotu, double waga)
                : base(imie, wiek, gatunek, waga) // Wywołanie konstruktora klasy bazowej Zwierze
            {
                WysokoscLotu = wysokoscLotu; // Inicjalizacja wysokości lotu
            }

            // Implementacja abstrakcyjnej metody WydajDzwiek z klasy Zwierze
            public override void WydajDzwiek()
            {
                Console.WriteLine($"{Imie} ćwierka!"); // Przykład dźwięku ptaka
            }

            // Implementacja metody Lec z interfejsu ILatajace
            public void Lec()
            {
                if (CzyMozeLatac) // Sprawdzamy, czy ptak może latać
                {
                    Console.WriteLine($"{Imie} leci na wysokości {WysokoscLotu} metrów.");
                }
                else
                {
                    Console.WriteLine($"{Imie} nie może latać!"); // Jeśli wysokość lotu jest 0 lub ujemna
                }
            }
        }

        // Interfejs ILatajace, który wymusza implementację właściwości WysokoscLotu i metody Lec
        public interface ILatajace
        {
            int WysokoscLotu { get; }
            void Lec();
        }

        // Metoda główna aplikacji, która uruchamia program
        static void Main(string[] args)
        {
            // Demonstracja użycia klasy Ptak
            var orzel = new Ptak("Orzeł Biały", 3, "Orzeł", 500, 5.5);

            // Użycie gettera do pobrania imienia ptaka
            Console.WriteLine($"Imię: {orzel.Imie}");
            Console.WriteLine($"Czy może latać: {orzel.CzyMozeLatac}");

            // Zmiana imienia ptaka
            orzel.Imie = "Białozór"; // Zadziała, ponieważ setter sprawdza, czy imię nie jest puste
            orzel.CzyMigruje = true; // Zmiana właściwości automatycznej

            try
            {
                // Próba ustawienia nieprawidłowego wieku
                orzel.Wiek = -1; // Wywoła wyjątek
            }
            catch (ArgumentException ex)
            {
                // Obsługa błędu walidacji wieku
                Console.WriteLine($"Błąd: {ex.Message}");
            }

            // Sprawdzanie, czy ptak wymaga badania
            if (orzel.WymagaBadania)
            {
                // Przeprowadzamy badanie, jeśli minął rok od ostatniego
                orzel.PrzeprowadzBadanie();
                Console.WriteLine("Przeprowadzono badanie");
            }

            // Wyświetlanie pełnych informacji o ptaku
            Console.WriteLine(orzel.PobierzInformacje());
            Console.ReadKey(); // Oczekiwanie na naciśnięcie klawisza
        }
    }
}
