//Ex1();
Ex2();


void Ex1()
{
    Console.Write("Hello, World!\n");
    Console.Write("Hello, World!" + Environment.NewLine);
    Console.WriteLine("Hello, World!");
}
void Ex2()
{
    //operacje wejścia/wyjścia
    Console.Write("Podaj a: ");
    int a = Convert.ToInt32(Console.ReadLine());
    Console.Write("Podaj b: ");
    int b = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"{a} + {b} = {a + b}");
    Console.WriteLine($"{a} - {b} = {a - b}");
    Console.WriteLine($"{a} * {b} = {a * b}");
    if (b != 0)
    {
        Console.WriteLine($"{a} / {b} = {(double)a / b}");
    }
    else
    {
        Console.WriteLine("Nie można dzielić przez 0");
    }
    Console.WriteLine(b != 0 ? $"{a} / {b} = {(double)a / b}"
                                 : "Nie można dzielić przez 0");
    //Console.WriteLine(a + " + " + b + " = " + (a + b));
}

