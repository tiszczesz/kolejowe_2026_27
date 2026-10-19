using System;

namespace cw6.Models;

public class Menu
{
    private string menuText;
    public char choice;
    public Menu()
    {
        menuText = @"           ==== M E N U  ======  
                         1. Pokaz wszystkie
                         2. Ddaj gre
                         3. Usun gre
                         4. Zakoncz   
                         ---------
                         Wybierz opcje: ";
    }
    public void ShowMenu()
    {
        Console.Write(menuText);
    }
    public void DoMenu()
    {
        do
        {
            ShowMenu();
        } while (choice != '4');
        Console.WriteLine(" ---- KONIEC -------");
    }

}
