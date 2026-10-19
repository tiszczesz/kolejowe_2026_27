using System;

namespace zad1.Models;

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
            choice = Console.ReadLine()[0];
        } while (choice != '4');
        Console.WriteLine(" \t\t\t---- KONIEC -------");
    }

}
