using cw3;
//tworzenie obiektu klasy Person
Person person1 = new Person();
person1.firstname = "Jan";
person1.lastname = "Nowak";
person1.age = 22;
Console.WriteLine(person1);
Console.WriteLine(person1.ToString());
Console.WriteLine(person1.GetHashCode());
Console.WriteLine(person1.GetType());

//zadanie napisz klasę Game z polami publicznymi
// name price(decimal) genre
//nadpisz metodę ToString aby pokazc informacje o grze
//Game g1 = new Game();

Console.WriteLine("  ==== ==========    =======\n");
var n1 = new Note();
var n2 = new Note(DateOnly.FromDateTime(DateTime.Now),
             "notatka 2", "tresc notatki 2");
Console.WriteLine(n1.ShowNote());
Console.WriteLine(n2.ShowNote());
n1.Name = "Zmieniona wartosc";
Console.WriteLine(n1.Name);

