//Ex1();
Ex2(200);//100
void Ex1()
{
    Console.WriteLine("podaj ilosc liczb: ");
    int n = int.Parse(Console.ReadLine() ?? "10");
    for (int i = 0; i < n; i++)
    {
        Console.WriteLine($"{i}\t{Math.Pow(i, 2)}\t{Math.Pow(i, 3)}");
    }
}
void Ex2(uint range = 100)
{
    //while(){...}
    int sum = 0;
    Random rnd = new Random(); //losowacz
    while(sum < range)
    {
        int randomNumber = rnd.Next(20);
        sum += randomNumber;
        Console.Write(randomNumber + " ");
    }
    Console.WriteLine($"\nSuma: {sum}");
}