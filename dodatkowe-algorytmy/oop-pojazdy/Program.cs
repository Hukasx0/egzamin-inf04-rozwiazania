namespace oop_pojazdy
{
    // Interfejs IDoNaprawy - definiuje metodę naprawy
    public interface IDoNaprawy
    {
        void Napraw();
    }

    // Klasa abstrakcyjna Pojazd - zawiera wspólne właściwości dla pojazdów
    public abstract class Pojazd
    {
        // Publiczne właściwości, dostępne z każdej klasy
        public string Marka { get; set; }
        public int RokProdukcji { get; set; }

        // Pole chronione, dostępne w klasach pochodnych
        protected int Przebieg { get; set; }

        // Pole prywatne, dostępne tylko w tej klasie
        private string NumerRejestracyjny { get; set; }

        // Pusty konstruktor (bez parametrów)
        public Pojazd()
        {
            Marka = "Nieznana";
            RokProdukcji = 0;
            Przebieg = 0;
            NumerRejestracyjny = "Brak";
        }

        // Konstruktor z parametrami
        public Pojazd(string marka, int rokProdukcji)
        {
            Marka = marka;
            RokProdukcji = rokProdukcji;
            Przebieg = 0;
            NumerRejestracyjny = "Brak";
        }

        // Konstruktor kopiujący (kopiuje dane z innego obiektu)
        public Pojazd(Pojazd innyPojazd)
        {
            Marka = innyPojazd.Marka;
            RokProdukcji = innyPojazd.RokProdukcji;
            Przebieg = innyPojazd.Przebieg;
            NumerRejestracyjny = innyPojazd.NumerRejestracyjny;
        }

        // Abstrakcyjna metoda, którą muszą zaimplementować klasy pochodne
        public abstract void Uruchom();

        // Metoda ogólnodostępna dla wszystkich pojazdów
        public void WyswietlInfo()
        {
            Console.WriteLine($"Marka: {Marka}, Rok Produkcji: {RokProdukcji}, Przebieg: {Przebieg}, Numer Rejestracyjny: {NumerRejestracyjny}");
        }
    }

    // Klasa Samochod - dziedziczy po klasie Pojazd i implementuje metodę Uruchom
    public class Samochod : Pojazd, IDoNaprawy
    {
        public string TypSilnika { get; set; }
        private static int liczbaSamochodow = 0;

        // Konstruktor z parametrami
        public Samochod(string marka, int rokProdukcji, string typSilnika)
            : base(marka, rokProdukcji)  // Wywołanie konstruktora klasy bazowej Pojazd
        {
            TypSilnika = typSilnika;
            liczbaSamochodow++;
        }

        // Konstruktor kopiujący
        public Samochod(Samochod innySamochod)
            : base(innySamochod)  // Wywołanie konstruktora kopiującego klasy bazowej Pojazd
        {
            TypSilnika = innySamochod.TypSilnika;
            liczbaSamochodow++;
        }

        // Implementacja metody abstrakcyjnej z klasy Pojazd
        public override void Uruchom()
        {
            Console.WriteLine("Samochód został uruchomiony.");
        }

        // Implementacja metody z interfejsu IDoNaprawy
        public void Napraw()
        {
            Console.WriteLine("Samochód został naprawiony.");
        }

        // Metoda statyczna, która zwraca liczbę pojazdów (poza klasą statyczną)
        public static void WyswietlLiczbeSamochodow()
        {
            Console.WriteLine($"Jest {liczbaSamochodow} samochodów");
        }
    }

    // Klasa statyczna Statystyki - przechowuje globalne dane dotyczące pojazdów
    public static class Statystyki
    {
        public static int LiczbaPojazdow { get; set; } = 0;

        // Metoda statyczna, która zwraca liczbę pojazdów
        public static void DodajPojazd()
        {
            LiczbaPojazdow++;
            Console.WriteLine($"Liczba pojazdów: {LiczbaPojazdow}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Tworzenie obiektu za pomocą konstruktora z parametrami
            Samochod mojSamochod = new Samochod("Toyota", 2020, "Benzynowy");

            // Wyświetlenie informacji o samochodzie
            mojSamochod.WyswietlInfo();

            // Uruchomienie samochodu
            mojSamochod.Uruchom();

            // Naprawa samochodu
            mojSamochod.Napraw();

            // Tworzenie obiektu za pomocą konstruktora kopiującego
            Samochod skopiowanySamochod = new Samochod(mojSamochod);
            skopiowanySamochod.WyswietlInfo();  // Wyświetla te same dane co mojSamochod

            // wywoływanie metody statycznej
            Samochod.WyswietlLiczbeSamochodow();

            // Użycie klasy statycznej do dodania pojazdu
            Statystyki.DodajPojazd();
            Statystyki.DodajPojazd();

            // Dodanie pojazdu po skopiowaniu
            Statystyki.DodajPojazd();

            // Zakończenie programu
            Console.ReadKey();
        }
    }
}
