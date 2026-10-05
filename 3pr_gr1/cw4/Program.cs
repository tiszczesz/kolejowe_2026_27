void Ex1()
{
    //tablice wielo-wymiarowe
    int[,] tab2D = new int[10, 20];
    Genertab2D(tab2D);
    ShowTab(tab2D);
}
Ex1();
void Genertab2D(int[,] tab2D)  //int tab[][]
{
    Random rnd = new Random();
    for (int i = 0; i < tab2D.GetLength(0); i++)
    {
        for (int j = 0; j < tab2D.GetLength(1); j++)
        {
            tab2D[i, j] = rnd.Next(100);
        }
    }
}

void ShowTab(int[,] tab2D)
{
    for (int i = 0; i < tab2D.GetLength(0); i++)
    {
        for (int j = 0; j < tab2D.GetLength(1); j++)
        {
            Console.Write(tab2D[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

void Ex2()
{
    //tablice tablic
    string[][] tab = new string[4][];
    tab[0] = new string[] { "ala", "ola", "bola", "tola" };
    tab[1] = new string[] { "ggg", "yyyy", "wewe", "gggg", "ffff" };
    tab[2] = new string[] { "---" };
    tab[3] = new string[] { "ggg", "yyyy" };
    foreach (var elem in tab)
    {
        Console.WriteLine(String.Join('-',elem));
        // foreach (var word in elem)
        // {
        //     Console.Write(word + "$");
        // }
        // Console.WriteLine();
    }
}
Ex2();