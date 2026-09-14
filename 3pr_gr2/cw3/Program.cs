Ex1();
void Ex1()
{
    //if else if else
    //zapytanie o wiek
    //ujemny to jeszcze nie urodziłeś się
    //0-12 dziecko
    //13-19 nastolatek
    //20+ dorosły
    //130+ nie żyjesz
    //przykład z if else if else
    try
    {
        Console.Write("Podaj swój wiek: ");
        int age = Convert.ToInt32(Console.ReadLine());
        if (age <= 0)
        {
            Console.WriteLine("Jeszcze się nie urodziłeś");
        }
        else if (age <= 12)
        {
            Console.WriteLine("Jesteś dzieckiem");
        }
        else if (age <= 19)
        {
            Console.WriteLine("Jesteś nastolatkiem");
        }
        else if (age <= 130)
        {
            Console.WriteLine("Jesteś dorosły");
        }
        else
        {
            Console.WriteLine("Nie żyjesz");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Wystąpił błąd: " + ex.Message);
        return;
    }
}
