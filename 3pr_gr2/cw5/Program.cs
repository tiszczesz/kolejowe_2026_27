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
