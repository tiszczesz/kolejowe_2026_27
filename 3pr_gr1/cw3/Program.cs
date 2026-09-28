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
n1.Name = null;
Console.WriteLine(n1.Name);
Console.WriteLine(" ========================================================================= ");
var prods = GetProducts();
ShowTab<Product>(prods);

Product[] GetProducts()
{
    //definicja tablicy 5 elementowej typu Product
    Product[] products = new Product[5];
    products[0] = new Product( "Myszka", 50.5M, "Myszka optyczna", DateTime.Now.AddDays(30));
    products[1] = new Product( "Klawiatura", 100.5M, "Klawiatura mechaniczna", DateTime.Now.AddDays(60));
    products[2] = new Product( "Monitor", 500.5M, "Monitor 4K", DateTime.Now.AddDays(90));
    products[3] = new Product( null, 2000.5M, "Laptop gamingowy", DateTime.Now.AddDays(120));
    products[4] = new Product( "Smartfon", 1500.5M, "Smartfon z dużym ekranem", DateTime.Now.AddDays(150));
    return products;
}
void ShowTab<T>(T[] products)
{
    foreach(var p in products)
    {
        Console.WriteLine(p);
    }
}
void GetLinesFromFile(string filename)
{
    string[] result = File.ReadAllLines(filename);
    foreach(string line in result)
    {
        Console.WriteLine(line);
    }
}
int[]? GetRandomNumbers(int size)
{
    Random rnd = new Random(); //Next
    return null;
}
Console.WriteLine(" ========================================================================= ");
GetLinesFromFile("data.txt");
var result = GetRandomNumbers(200);
ShowTab<int>(result);
