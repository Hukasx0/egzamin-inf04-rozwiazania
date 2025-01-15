# Dokumentacja kodu OOP w C#

## Klasa `RejestracjaZwierzat`
### Typ: **Statyczna**
- **Zastosowanie**: Jest to statyczna klasa, której celem jest zarządzanie rejestracją zwierząt. Statyczna klasa oznacza, że wszystkie jej pola i metody są związane z klasą, a nie z instancją obiektu. Klasa ta zarządza globalnym stanem aplikacji w kontekście rejestracji zwierząt.
- **Przykład zastosowania w kodzie**: W tej klasie przechowywane są dane takie jak licznik zwierząt oraz lista zarejestrowanych gatunków. Metody takie jak `DodajGatunek()` i `ZwiekszLicznikZwierzat()` pozwalają na dodawanie nowych gatunków oraz zwiększanie licznika zarejestrowanych zwierząt.

### Kluczowe elementy:
- **Pola statyczne**: `licznikZwierzat`, `zarejestrowaneGatunki` przechowują dane, które są wspólne dla wszystkich instancji.
- **Metody statyczne**: `DodajGatunek()`, `ZwiekszLicznikZwierzat()` pozwalają na manipulowanie tymi danymi.
- **Właściwości statyczne**: `LicznikZwierzat` oraz `ZarejestrowaneGatunki` zapewniają dostęp do tych danych w sposób bezpieczny.

## Klasa `Zwierze`
### Typ: **Abstrakcyjna**
- **Zastosowanie**: Klasa abstrakcyjna w C# to klasa, która nie może być instancjowana (nie można utworzyć obiektu tej klasy), ale może zostać dziedziczona przez inne klasy. Służy jako szablon, który wymusza implementację pewnych metod w klasach dziedziczących.
- **Przykład zastosowania w kodzie**: `Zwierze` jest klasą bazową dla różnych typów zwierząt, np. ptaków. Określa ona wspólne cechy i zachowania, takie jak `Imie`, `Wiek`, `Waga`, `PobierzInformacje()`, ale także zawiera metody abstrakcyjne jak `WydajDzwiek()`, które muszą zostać zaimplementowane w klasach dziedziczących.

### Kluczowe elementy:
- **Pola**: `imie`, `wiek`, `gatunek`, `waga`, `dataOstatniegoBadania` - przechowują dane zwierzęcia.
- **Właściwości**: `Imie`, `Wiek`, `Waga` - pozwalają na odczyt i zapis danych z odpowiednią walidacją.
- **Metody abstrakcyjne**: `WydajDzwiek()` - zmusza klasy dziedziczące do dostarczenia implementacji tej metody.
- **Metoda wirtualna**: `PobierzInformacje()` - domyślnie implementuje metodę, ale klasy dziedziczące mogą ją nadpisać.

## Klasa `Ptak`
### Typ: **Dziedzicząca po klasie abstrakcyjnej**
- **Zastosowanie**: Klasa `Ptak` dziedziczy po klasie `Zwierze` i implementuje metodę `WydajDzwiek()`, dostosowując ją do konkretnego typu zwierzęcia. Oznacza to, że `Ptak` jest konkretną implementacją ogólnej koncepcji zwierzęcia, którą definiuje klasa `Zwierze`.
- **Przykład zastosowania w kodzie**: Klasa `Ptak` wykorzystuje właściwości i metody dziedziczone z klasy `Zwierze`, ale także dodaje unikalne cechy, takie jak `WysokoscLotu` oraz `CzyMigruje`, oraz implementuje specyficzną logikę dla ptaków, np. metodę `Lec()`.

### Kluczowe elementy:
- **Pola i właściwości**: `wysokoscLotu`, `CzyMigruje`, `CzyMozeLatac` - określają specyficzne cechy ptaków, jak możliwość latania i migracji.
- **Metoda**: `Lec()` - sprawdza, czy ptak może latać, na podstawie wysokości lotu.
- **Metoda abstrakcyjna**: `WydajDzwiek()` - specyficzna implementacja dla ptaka (np. ćwierkanie).

## Interfejs `ILatajace`
### Typ: **Interfejs**
- **Zastosowanie**: Interfejs w C# to kontrakt, który wymusza na klasach implementację określonych metod. Interfejsy służą do definiowania wspólnego zestawu metod, które muszą być zaimplementowane przez klasy, które ten interfejs implementują.
- **Przykład zastosowania w kodzie**: Interfejs `ILatajace` definiuje metodę `Lec()` oraz właściwość `WysokoscLotu`, które muszą być zaimplementowane przez każdą klasę, która chce reprezentować obiekt mogący latać. W naszym przypadku, `Ptak` implementuje ten interfejs.

### Kluczowe elementy:
- **Właściwość**: `WysokoscLotu` - definiuje wysokość, na której ptak może latać.
- **Metoda**: `Lec()` - określa zachowanie ptaka w kontekście lotu.

## Metody wirtualne i abstrakcyjne

### Metoda abstrakcyjna
- **Zastosowanie**: Metody abstrakcyjne są zadeklarowane w klasach abstrakcyjnych i nie mają implementacji. Muszą być zaimplementowane w klasach dziedziczących. Dzięki temu zapewnia się, że każda konkretna klasa dostarczy własną implementację tych metod.
- **Przykład**: W metodzie `Zwierze.WydajDzwiek()`, która jest abstrakcyjna, wymusza się implementację tej metody w klasach pochodnych, jak np. w `Ptak.WydajDzwiek()`.

### Metoda wirtualna
- **Zastosowanie**: Metoda wirtualna jest metodą, która ma implementację w klasie bazowej, ale może zostać nadpisana (przedefiniowana) w klasach pochodnych. Dzięki temu klasy pochodne mogą zmienić sposób jej działania, ale nie muszą tego robić.
- **Przykład**: `Zwierze.PobierzInformacje()` jest metodą wirtualną, ponieważ klasa `Zwierze` zapewnia podstawową implementację, ale klasy dziedziczące (np. `Ptak`) mogą ją nadpisać, jeśli chcą.

## Właściwości

### Właściwość
- **Zastosowanie**: Właściwości w C# to specjalne metody, które umożliwiają odczyt i zapis wartości pola w sposób bardziej kontrolowany. Dzięki właściwościom można dodać logikę walidacji i kontrolować dostęp do danych w klasie.
- **Przykład**: Właściwości jak `Imie`, `Wiek`, `Waga` w klasie `Zwierze` są przykładami właściwości z walidacją. Dzięki tym właściwościom można zapewnić, że np. wiek nie będzie mniejszy niż 0, a waga większa niż 0.

### Właściwości tylko do odczytu
- **Zastosowanie**: Czasami chcemy, aby dane były dostępne tylko do odczytu, a nie do zapisu. W takich przypadkach używamy właściwości, które posiadają tylko getter, ale brak settera.
- **Przykład**: Właściwość `Gatunek` w klasie `Zwierze` jest tylko do odczytu, ponieważ gatunek zwierzęcia nie zmienia się po jego utworzeniu.

## Zastosowanie w praktyce

- **Abstrakcyjna klasa `Zwierze`** służy jako szablon dla konkretnych typów zwierząt, zapewniając podstawowe właściwości i metody.
- **Interfejs `ILatajace`** daje możliwość tworzenia obiektów, które mogą latać, niezależnie od ich pochodzenia w hierarchii klas.
- **Klasa `Ptak`** implementuje zarówno klasę abstrakcyjną, jak i interfejs, definiując zachowanie konkretnego zwierzęcia (ptaka) w kontekście latania i wydawania dźwięków.

## Podsumowanie

Widzimy zastosowanie różnych technik OOP w C#, takich jak:
- **Dziedziczenie** — klasy pochodne dziedziczą właściwości i metody po klasach bazowych, rozszerzając je o specyficzne implementacje.
- **Abstrakcja** — klasy abstrakcyjne pozwalają na zdefiniowanie wspólnego interfejsu dla różnych klas.
- **Polimorfizm** — dzięki metodom wirtualnym i abstrakcyjnym klasy pochodne mogą dostarczać własne implementacje metod, które różnią się w zależności od typu obiektu.
- **Interfejsy** — interfejsy pozwalają na definiowanie kontraktów, które klasy muszą spełniać, niezależnie od tego, z jakiej klasy bazowej dziedziczą.
