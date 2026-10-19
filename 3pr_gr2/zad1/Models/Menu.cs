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
            switch (choice)
            {
                case '1':
                    {
                        //todo
                        break;
                    }
                case '2':
                    {
                        //todo
                        break;
                    }
                case '3':
                    {
                        //todo
                        break;
                    }
                case '4':
                    {
                        //todo
                        break; ;
                    }


            }
        }
        while (choice != '4');
        Console.WriteLine(" \t\t\t---- KONIEC -------");
    }
}


