void Ex1()
{
    //tablice jednowymiarowe
    Console.Write("Podaj rozmiar tablicy: ");
    int size = Convert.ToInt32(Console.ReadLine());
    int[] numbers = new int[size];//deklaracja tablicy o rozmiarze 5
    FillTab(numbers);
    ShowTab(numbers);
    GetMin(numbers);
    GetMax(numbers);  //numbers.Min();
    GetSum(numbers);  //numbers.Sum();
}
Ex1();
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
    foreach(var elem in tab)
    {
        sum += elem;
    }
    return sum;
    //return tab.Sum();
}