using System.ComponentModel.DataAnnotations.Schema;

void Ex1()
{
    //tablice jednowymiarowe
    Console.Write("Podaj rozmiar tablicy: ");
    int size = Convert.ToInt32(Console.ReadLine());
    int[] numbers = new int[size];//deklaracja tablicy o rozmiarze 5
    FillTab(numbers);
    ShowTab(numbers);
    int min = GetMin(numbers);
    int max = GetMax(numbers);  //numbers.Min();
    int sum = GetSum(numbers);  //numbers.Sum();
    Console.WriteLine($"min = {min}\tmax = {max}\tsum = {sum}");
}
//Ex1();
void FillTab(int[] numbers)
{
    Random rnd = new Random();
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = rnd.Next(1, 100);//losowanie liczb z przedziału 1-100
    }
}
void ShowTab(int[] tab)
{
    foreach (int elem in tab)
    {
        Console.Write(elem + " ");
    }
    Console.WriteLine();
}
int GetMin(int[] tab)
{
    int min = Int32.MaxValue;
    //int min2 = tab[0];
    foreach (int elem in tab)
    {
        if (elem < min) min = elem;
    }
    return min;
    //return tab.Min();
}
int GetMax(int[] tab)
{
    int max = Int32.MinValue;
    //int min2 = tab[0];
    foreach (int elem in tab)
    {
        if (elem > max) max = elem;
    }
    return max;
    //return tab.Max();    
}
int GetSum(int[] tab)
{
    int sum = 0;
    foreach (var elem in tab)
    {
        sum += elem;
    }
    return sum;
    //return tab.Sum();
}
void Ex2()
{
    //tablice wielo-wymiarowe
    int[,] tab2D = new int[10, 20]; //int tab[][]
    Random rnd = new Random();
    for (int i = 0; i < tab2D.GetLength(0); i++)
    {
        for (int j = 0; j < tab2D.GetLength(1); j++)
        {
            tab2D[i, j] = rnd.Next(0, 200);
        }
    }
    //wyswietlanie tablicy
    for (int i = 0; i < tab2D.GetLength(0); i++)
    {
        for (int j = 0; j < tab2D.GetLength(1); j++)
        {
            Console.Write(tab2D[i, j] + "\t");
        }
        Console.WriteLine();
    }
}
//Ex2();
void Ex3()
{
    //tablice tablic
    string[][] words = new string[2][];
    words[0] = ["ala", "ggg", "gfffff"];
    words[1] = ["ttt", "gggggg", "ala bela", "jjjjjj", "hghghgh"];
    foreach (var elem in words)
    {
        Console.WriteLine(String.Join("-", elem));
    }
}
Ex3();
//napisac funkcje tworzaca tablice 2-wymiarowa
// zawierajaca n n*n n*n*n
void Zad1()
{
    Console.Write("Ile chcesz liczb: ");
    int size = Convert.ToInt32(Console.ReadLine());
    Random rnd = new Random();
    int[,] numbers = new int[size,3];
}