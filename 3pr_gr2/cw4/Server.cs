namespace cw4;

public class Server
{
    //konstruktor czyli metoda do tworzenia obektów
    //danej klasy
    // konstruktor bezargumentowy - domyślny
    public Server()
    {
        IsActive = true;
        Name = "Server";
    }
    //konstruktor z argumentami
    public Server(bool isActive, string name)
    {
        // this.isActive = isActive;
        // this.name = name;
        //uzycie property zamiast pól prywatnych
        IsActive = isActive;
        Name = name;
    }
    public string ShowInfo()
    {
        // string result =  $"Nazwa serwera: {name}";
        // if(isActive) result += " serwer działa";
        // else result += " serwer wylaczony";
        // return result; 
        return $"Nazwa serwera: {Name}\t" +
                (IsActive ? "serwer działa" : " serwer wylaczony");
    }
    //private bool isActive;
    private string name;
    // public bool GetIsActive()
    // {
    //     return isActive;
    // }
    // public string GetName()
    // {
    //     return name;
    // }
    //użycie property zamiast metod GetIsActive() i GetName()
    // public bool IsActive
    // {
    //     get
    //     {
    //         return isActive;// pobranie wartości pola isActive
    //     }
    //     set
    //     {
    //         isActive = value;//ustawienie wartości pola isActive
    //     }
    // }
    //uzycie auto-implemented property
    public bool IsActive { get; set; }

    //property do pobierania i ustawiania wartości pola name
    public string Name
    {
        get
        {
            return name.ToUpper(); //pobranie wartości pola name
        }
        set
        {
            name = String.IsNullOrEmpty(value) ? "Default" : value; //ustawienie wartości pola name
        }
    }
}