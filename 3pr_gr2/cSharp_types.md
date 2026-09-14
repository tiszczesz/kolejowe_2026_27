# Typy w C#

## Wprowadzenie

C# jest językiem **silnie typowanym**, co oznacza, że każda zmienna musi mieć określony typ. Typy w C# dzielą się na dwie główne kategorie: **typy wartościowe** i **typy referencyjne**.

---

## 1. Typy Wartościowe (Value Types)

Typy wartościowe przechowują dane bezpośrednio w pamięci (na stosie). Zmienna zawiera rzeczywistą wartość, a nie referencję do niej.

### 1.1 Typy Całkowite (Integer Types)

| Typ      | Rozmiar  | Zakres                                                 | Zastosowanie                       |
| -------- | -------- | ------------------------------------------------------ | ---------------------------------- |
| `byte`   | 1 bajt   | 0 - 255                                                | Małe liczby dodatnie               |
| `sbyte`  | 1 bajt   | -128 - 127                                             | Małe liczby ze znakiem             |
| `short`  | 2 bajty  | -32,768 - 32,767                                       | Liczby średniej wielkości          |
| `ushort` | 2 bajty  | 0 - 65,535                                             | Liczby dodatnie średniej wielkości |
| `int`    | 4 bajty  | -2,147,483,648 - 2,147,483,647                         | Typ domyślny dla liczb całkowitych |
| `uint`   | 4 bajty  | 0 - 4,294,967,295                                      | Liczby dodatnie                    |
| `long`   | 8 bajtów | -9,223,372,036,854,775,808 - 9,223,372,036,854,775,807 | Bardzo duże liczby                 |
| `ulong`  | 8 bajtów | 0 - 18,446,744,073,709,551,615                         | Bardzo duże liczby dodatnie        |

```csharp
int liczba = 42;
long duzaLiczba = 9223372036854775807L;
byte malaLiczba = 255;
```

### 1.2 Typy Zmiennoprzecinkowe (Floating Point Types)

| Typ       | Rozmiar   | Precyzja    | Zastosowanie                                       |
| --------- | --------- | ----------- | -------------------------------------------------- |
| `float`   | 4 bajty   | ~6-9 cyfr   | Liczby z ułamkiem dziesiętnym o mniejszej precyzji |
| `double`  | 8 bajtów  | ~15-17 cyfr | Typ domyślny dla liczb zmiennoprzecinkowych        |
| `decimal` | 16 bajtów | ~28-29 cyfr | Operacje finansowe, wysoka dokładność              |

```csharp
float pi = 3.14f;
double promień = 5.0;
decimal cena = 99.99m;
```

### 1.3 Typ Logiczny

```csharp
bool czyPrawda = true;
bool czyFałsz = false;
```

### 1.4 Typ Znakowy

```csharp
char litera = 'A';
char cyfra = '5';
char znakSpecjalny = '\n'; // nowa linia
```

### 1.5 Enum

Enum to typ, który pozwala definiować zbiór nazwanych stałych.

```csharp
enum DniTygodnia
{
    Poniedziałek = 1,
    Wtorek = 2,
    Środa = 3,
    Czwartek = 4,
    Piątek = 5,
    Sobota = 6,
    Niedziela = 7
}

DniTygodnia dzisiaj = DniTygodnia.Poniedziałek;
```

### 1.6 Struct

Struct to typ wartościowy, który może zawierać pola, właściwości i metody.

```csharp
struct Punkt
{
    public int X { get; set; }
    public int Y { get; set; }

    public Punkt(int x, int y)
    {
        X = x;
        Y = y;
    }
}

Punkt p = new Punkt(10, 20);
```

---

## 2. Typy Referencyjne (Reference Types)

Typy referencyjne przechowują referencję (adres) do danych w pamięci (na stercie). Zmienna zawiera wskaźnik do rzeczywistego obiektu.

### 2.1 String

Tekst przechowywany w pamięci. Jest **niezmiennym** typem referencyjnym.

```csharp
string imię = "Jan";
string nazwisko = "Kowalski";
string pełneImię = $"{imię} {nazwisko}"; // interpolacja
```

### 2.2 Class

Klasa jest szablonem dla obiektów. Jest typem referencyjnym.

```csharp
class Osoba
{
    public string Imię { get; set; }
    public int Wiek { get; set; }

    public Osoba(string imię, int wiek)
    {
        Imię = imię;
        Wiek = wiek;
    }

    public void Przedstaw()
    {
        Console.WriteLine($"Cześć, jestem {Imię} i mam {Wiek} lat.");
    }
}

Osoba osoba = new Osoba("Anna", 30);
osoba.Przedstaw();
```

### 2.3 Interface

Interfejs definiuje kontrakt - zbiór metod i właściwości, które implementujące go klasy muszą dostarczyć.

```csharp
interface IPracownik
{
    string Imię { get; set; }
    void Pracuj();
}

class Programista : IPracownik
{
    public string Imię { get; set; }

    public void Pracuj()
    {
        Console.WriteLine("Piszę kod");
    }
}
```

### 2.4 Delegate

Delegate to typ bezpieczny dla odwołań do metod.

```csharp
// Definicja delegata
delegate int Obliczenie(int a, int b);

// Użycie
Obliczenie dodawanie = (a, b) => a + b;
int wynik = dodawanie(5, 3); // wynik = 8
```

### 2.5 Array

Tablica - zbór elementów tego samego typu.

```csharp
int[] liczby = { 1, 2, 3, 4, 5 };
string[] imiona = new string[3];
imiona[0] = "Jan";

// Tablica wielowymiarowa
int[,] macierz = new int[3, 3];
```

### 2.6 Collections (Kolekcje)

```csharp
// List<T> - dynamiczna lista
List<int> lista = new List<int> { 1, 2, 3 };
lista.Add(4);

// Dictionary<K, V> - słownik
Dictionary<string, int> wiek = new Dictionary<string, int>
{
    { "Jan", 30 },
    { "Anna", 25 }
};

// HashSet<T> - zbiór
HashSet<string> miasta = new HashSet<string> { "Warszawa", "Kraków" };

// Queue<T> - kolejka
Queue<int> kolejka = new Queue<int>();
kolejka.Enqueue(1);

// Stack<T> - stos
Stack<int> stos = new Stack<int>();
stos.Push(1);
```

---

## 3. Typy Nullable (Dopuszczające null)

Nullable pozwala typom wartościowym przechowywać wartość `null`.

```csharp
// Explicit nullable
int? liczba = null;
int? liczba2 = 42;

// Sprawdzenie czy ma wartość
if (liczba.HasValue)
{
    Console.WriteLine(liczba.Value);
}
else
{
    Console.WriteLine("Wartość jest null");
}

// Operator ?? - koalescencji
int wartosc = liczba ?? 0; // jeśli liczba to null, wartosc = 0
```

---

## 4. Różnice między Value Types i Reference Types

| Cecha          | Value Type          | Reference Type        |
| -------------- | ------------------- | --------------------- |
| Przechowywanie | Stos                | Sterta                |
| Kopiowanie     | Kopiuje wartość     | Kopiuje referencję    |
| Równość        | Porównanie wartości | Porównanie referencji |
| Wydajność      | Szybsze             | Wolniejsze            |
| Default        | Zero/false/'\0'     | null                  |

```csharp
// Value Type - kopiowanie wartości
int a = 5;
int b = a;
b = 10;
Console.WriteLine(a); // 5 - nie zmienia się

// Reference Type - kopiowanie referencji
List<int> lista1 = new List<int> { 1, 2, 3 };
List<int> lista2 = lista1;
lista2.Add(4);
Console.WriteLine(lista1.Count); // 4 - zmienia się!
```

---

## 5. Typ object

Typ `object` jest bazą dla wszystkich typów w C#. Każdy typ dziedziczy po `object`.

```csharp
object obj1 = 42;           // boxing - value type → object
object obj2 = "Tekst";      // reference type
object obj3 = true;

// Unboxing - object → value type
int liczba = (int)obj1;     // musi być rzutowanie
```

---

## 6. Konwersje Typów

### 6.1 Konwersja Niejawna (Implicit)

```csharp
int liczba = 10;
double zmiennoprzecinkowa = liczba; // int → double (bez straty precyzji)
```

### 6.2 Konwersja Jawna (Explicit/Casting)

```csharp
double liczba = 10.5;
int calkowita = (int)liczba; // double → int (może być strata danych)
```

### 6.3 Konwersja za pomocą metod

```csharp
string tekst = "42";
int liczba = int.Parse(tekst);        // rzuca wyjątek jeśli się nie uda
int liczba2 = Convert.ToInt32(tekst); // alternatywa

// Bezpieczna konwersja
if (int.TryParse(tekst, out int wynik))
{
    Console.WriteLine($"Konwersja udana: {wynik}");
}
```

---

## 7. Typy Generyczne (Generics)

Generyki pozwalają na tworzenie typów parametrycznych.

```csharp
// Generyczna klasa
class Pojemnik<T>
{
    private T zawartość;

    public void Dodaj(T item)
    {
        zawartość = item;
    }

    public T Pobierz()
    {
        return zawartość;
    }
}

// Użycie
Pojemnik<int> pojemnikInt = new Pojemnik<int>();
pojemnikInt.Dodaj(42);

Pojemnik<string> pojemnikString = new Pojemnik<string>();
pojemnikString.Dodaj("Tekst");
```

---

## 8. Typ dynamic

Typ `dynamic` pozwala na dynamiczne typowanie - typ jest sprawdzany w runtime.

```csharp
dynamic zmienna = 42;
Console.WriteLine(zmienna); // 42

zmienna = "Tekst";
Console.WriteLine(zmienna); // Tekst

// Uwaga: brak sprawdzania typu w compile-time
```

---

## 9. var - Niejawne Typowanie

Słowo kluczowe `var` pozwala kompilatorowi wnioskować typ zmiennej.

```csharp
var liczba = 42;           // int
var tekst = "Cześć";       // string
var lista = new List<int>(); // List<int>
```

---

## Podsumowanie

- **Typy wartościowe**: int, float, double, bool, char, decimal, enum, struct
- **Typy referencyjne**: string, class, interface, delegate, array, collections
- **Nullable**: Umożliwia przechowywanie wartości null w typach wartościowych
- **Konwersje**: Mogą być niejawne, jawne lub za pośrednictwem metod
- **Generyki**: Pozwalają na elastyczne, bezpieczne typowo struktury danych
- **var i dynamic**: Specjalne sposoby pracy z typami

Zrozumienie typów jest kluczowe dla pisania wydajnego i bezpiecznego kodu w C#!
