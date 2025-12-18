# Przykłady ze szkolenia .NET MAUI

## Wprowadzenie

Witaj w repozytorium z materiałami do szkolenia **Tworzenie aplikacji mobilnych** w .NET MAUI**. Czyli nie tylko konsumujemy treści na ekranie naszego smartfona ale tworzymy aplikacje!
Ten projekt zawiera kompleksowe przykłady i ćwiczenia demonstrujące kluczowe koncepcje tworzenia aplikacji mobilnych w .NET MAUI  z wykorzystaniem wzorca Model-View-ViewModel (MVVM) i biblioteki MVVM Toolkit.

### Cele szkolenia
- Poznanie architektury .NET MAUI w celu tworzenia natywnych i multiplatformowych aplikacji mobilnych
- Poznanie podstaw XAML i tworzenia interfejsów użytkownika
- Zrozumienie wzorca MVVM i jego implementacji
- Tworzenie rzeczywistych aplikacji biznesowych

## Wymagania techniczne

Do rozpoczęcia tego kursu potrzebujesz następujących rzeczy:

1. [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
2. Visual Studio 2022 lub Visual Studio Code
3. Podstawowa znajomość C# i programowania obiektowego

## Struktura projektu

Projekt jest zorganizowany w dwóch głównych sekcjach:

```
maui/
├── docs/                          # Dokumentacja szkolenia
│   ├── drafts.bmpr                # Diagramy i schematy
│   └── drafts.pdf                 # Materiały szkoleniowe
├── src/                           # Kod źródłowy
│   ├── Fundamentals/              # Podstawowe koncepcje
│   └── RealWorld/                 # Praktyczne przykłady
└── README.md                      # Ten plik
```

## Opis projektów

### Fundamentals - Podstawowe koncepcje

#### HelloWolrdMauiApp
Najprostsza aplikacja demonstracyjna .NET MAUI. Zawiera podstawowy interfejs z przyciskiem licznika, który pokazuje liczbę kliknięć. Projekt służy jako wprowadzenie do struktury aplikacji MAUI i podstawowych kontrolek XAML.

#### HelloWorldMauiApp
Rozszerzona wersja aplikacji Hello World z nawigacją między stronami. Zawiera:
- **HomePage** - strona główna z licznikiem kliknięć
- **AboutPage** - strona informacyjna o aplikacji
- Demonstracja nawigacji w .NET MAUI przy użyciu `AppShell`

### RealWorld - Praktyczne przykłady

#### LibrusMauiApp
Aplikacja do zarządzania osobami demonstrująca wzorzec MVVM (Model-View-ViewModel). Zawiera:
- **Model**: `Person` - reprezentacja osoby z imieniem, nazwiskiem i zdjęciem
- **View**: `PersonsPage` - interfejs użytkownika do wyświetlania listy osób
- **ViewModel**: `PersonsPageModel` - logika biznesowa i zarządzanie danymi
- **Abstrakcje**: `IPersonService` - interfejs serwisu do zarządzania osobami
- **Implementacje**: `FakePersonService` i `SqlPersonService` - przykłady implementacji serwisu

### ZadaniaEgz - Przykłady egzaminacyjne

#### GaleriaApi
Proste API REST napisane w ASP.NET Core, które zwraca listę zdjęć w formacie JSON. API udostępnia endpoint `/api/zdjecia` z danymi o zdjęciach, w tym kategoriami (kwiaty, zwierzęta, samochody) i liczbą pobrań.

#### GaleriaMauiApp
Aplikacja galerii zdjęć łącząca się z `GaleriaApi`. Funkcjonalności:
- Pobieranie zdjęć z API przez HTTP
- Filtrowanie zdjęć po kategoriach (kwiaty, zwierzęta, samochody) przy użyciu przełączników
- Nawigacja między zdjęciami (przyciski Wstecz/Dalej)
- Śledzenie liczby pobrań każdego zdjęcia
- Obsługa różnych adresów bazowych dla różnych platform (Android emulator vs lokalny host)

#### GraWKosciMauiApp
Gra w kości demonstrująca:
- Losowanie wartości dla 5 kości
- Sumowanie wyników z każdego rzutu
- Akumulowanie wyniku całej gry
- Resetowanie gry
- Użycie `ObservableCollection` do automatycznej aktualizacji interfejsu użytkownika

#### NotatkiMauiApp
Aplikacja do zarządzania notatkami z funkcjami:
- Dodawanie nowych notatek
- Wyświetlanie listy notatek w `CollectionView`
- Usuwanie notatek
- Obsługa zdarzeń `CollectionChanged` do powiadamiania o zmianach w kolekcji
- Użycie `ObservableCollection` do reaktywnego UI

#### UrzadzeniaDomoweMauiApp
Aplikacja do kontroli urządzeń domowych demonstrująca:
- **Pralka**: Walidacja i ustawianie numeru programu prania (1-12)
- **Odkurzacz**: Przełączanie stanu włączony/wyłączony z aktualizacją interfejsu
- Separacja logiki biznesowej od aktualizacji UI
- Walidacja danych wejściowych
