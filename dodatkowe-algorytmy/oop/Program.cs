namespace oop
{
    internal class Program
    {
        public static class RejestracjaZwierzat
        {
            // Prywatne pola statyczne
            private static int licznikZwierzat = 0;
            private static readonly List<string> zarejestrowaneGatunki = new List<string>();

            // Getter i setter jako właściwość statyczna z pełną implementacją
            public static int LicznikZwierzat
            {
                get { return licznikZwierzat; }
                private set { licznikZwierzat = value; }
            }

            // Getter tylko do odczytu dla listy gatunków
            public static IReadOnlyList<string> ZarejestrowaneGatunki
            {
                get { return zarejestrowaneGatunki.AsReadOnly(); }
            }

            public static void DodajGatunek(string gatunek)
            {
                if (!zarejestrowaneGatunki.Contains(gatunek))
                {
                    zarejestrowaneGatunki.Add(gatunek);
                }
            }

            public static int ZwiekszLicznikZwierzat()
            {
                return ++LicznikZwierzat; // Używamy właściwości zamiast pola
            }
        }

        public abstract class Zwierze
        {
            // Prywatne pola
            private string imie;
            private int wiek;
            private readonly string gatunek;
            private double waga;
            private DateTime dataOstatniegoBadania;

            // Prosty getter i setter z walidacją
            public string Imie
            {
                get { return imie; }
                set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new ArgumentException("Imię nie może być puste!");
                    imie = value;
                }
            }

            // Właściwość tylko do odczytu (readonly)
            public string Gatunek
            {
                get { return gatunek; }
            }

            // Auto-implementowana właściwość z prywatnym setterem
            public int NumerIdentyfikacyjny { get; private set; }

            // Właściwość z pełną implementacją i walidacją
            public int Wiek
            {
                get { return wiek; }
                set
                {
                    if (value < 0)
                        throw new ArgumentException("Wiek nie może być ujemny!");
                    if (value > 100)
                        throw new ArgumentException("Wiek wydaje się zbyt wysoki!");
                    wiek = value;
                }
            }

            // Właściwość obliczana (computed property)
            public bool WymagaBadania
            {
                get
                {
                    return (DateTime.Now - dataOstatniegoBadania).TotalDays > 365;
                }
            }

            // Właściwość z różnymi poziomami dostępu dla get i set
            public double Waga
            {
                get { return waga; }
                protected set
                {
                    if (value <= 0)
                        throw new ArgumentException("Waga musi być większa od 0!");
                    waga = value;
                }
            }

            protected Zwierze(string imie, int wiek, string gatunek, double waga)
            {
                this.gatunek = gatunek;
                this.dataOstatniegoBadania = DateTime.Now;

                // Używamy właściwości zamiast bezpośredniego przypisania do pól
                Imie = imie;
                Wiek = wiek;
                Waga = waga;
                NumerIdentyfikacyjny = RejestracjaZwierzat.ZwiekszLicznikZwierzat();
            }

            // Metoda do aktualizacji daty badania
            public void PrzeprowadzBadanie()
            {
                dataOstatniegoBadania = DateTime.Now;
            }

            public abstract void WydajDzwiek();

            public virtual string PobierzInformacje()
            {
                return $"{Gatunek} {Imie} (Wiek: {Wiek}, Waga: {Waga}kg, ID: {NumerIdentyfikacyjny})";
            }
        }

        public class Ptak : Zwierze, ILatajace
        {
            // Prywatne pole
            private int wysokoscLotu;

            // Implementacja właściwości z interfejsu
            public int WysokoscLotu
            {
                get { return wysokoscLotu; }
                private set
                {
                    if (value < 0)
                        throw new ArgumentException("Wysokość lotu nie może być ujemna!");
                    wysokoscLotu = value;
                }
            }

            // Właściwość automatyczna z wartością domyślną
            public bool CzyMigruje { get; set; } = false;

            // Expression-bodied property (skrócona składnia dla gettera)
            public bool CzyMozeLatac => WysokoscLotu > 0;

            public Ptak(string imie, int wiek, string gatunek, int wysokoscLotu, double waga)
                : base(imie, wiek, gatunek, waga)
            {
                WysokoscLotu = wysokoscLotu;
            }

            public override void WydajDzwiek()
            {
                Console.WriteLine($"{Imie} ćwierka!");
            }

            public void Lec()
            {
                if (CzyMozeLatac)
                {
                    Console.WriteLine($"{Imie} leci na wysokości {WysokoscLotu} metrów.");
                }
                else
                {
                    Console.WriteLine($"{Imie} nie może latać!");
                }
            }
        }

        public interface ILatajace
        {
            // Właściwość w interfejsie
            int WysokoscLotu { get; }
            void Lec();
        }

        static void Main(string[] args)
        {
            // Demonstracja użycia właściwości
            var orzel = new Ptak("Orzeł Biały", 3, "Orzeł", 500, 5.5);

            // Użycie gettera
            Console.WriteLine($"Imię: {orzel.Imie}");
            Console.WriteLine($"Czy może latać: {orzel.CzyMozeLatac}");

            // Użycie settera
            orzel.Imie = "Białozór"; // Zadziała
            orzel.CzyMigruje = true; // Zmiana właściwości automatycznej

            try
            {
                orzel.Wiek = -1; // Wywoła wyjątek
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }

            // Sprawdzenie czy wymaga badania
            if (orzel.WymagaBadania)
            {
                orzel.PrzeprowadzBadanie();
                Console.WriteLine("Przeprowadzono badanie");
            }

            Console.WriteLine(orzel.PobierzInformacje());
            Console.ReadKey();
        }
    }
}
