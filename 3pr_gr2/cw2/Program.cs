FirstElem();
SecondElem();

void FirstElem()
{
    //tworzenie nowej zmiennej
    // zmienna liczba całkowita
    int number = 10; //typ nazwa = wartosc
    Console.WriteLine($" a = {number}");
    //a = "ala ma kota"; // błąd kompilacji, nie można przypisać string do int
    string text = "ala ma kota"; //inna zmienna typu string
    Console.WriteLine($"tekst = {text}\t liczba = {number}"); // \t - tabulator
}

void SecondElem()
{
    Console.Write("Podaj imie: ");
    string? firstName = Console.ReadLine();// wczytanie danych z konsoli
    Console.Write("Podaj wiek: ");
    int age = Convert.ToInt32(Console.ReadLine());
    if (age < 18) //instrukcja warunkowa
    {
        Console.WriteLine($"Witaj {firstName} wiek: {age}, jesteś niepełnoletni");
    }
    else
    {
        Console.WriteLine($"Witaj {firstName} wiek: {age}, jesteś pełnoletni");
    }
}