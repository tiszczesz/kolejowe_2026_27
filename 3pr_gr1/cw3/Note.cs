namespace cw3;

public class Note
{
    //private DateOnly date;
    private string name;
    //private string content;
    
    //auto-property
    public string Content { get; set; }
    public DateOnly Date { get; set; }

    //konstruktory
    //1. Bez argumentow
    public Note()
    {
        Date = DateOnly.FromDateTime(DateTime.Now);
        Name = "noname";
        Content = "";
    }
    //2. Konstruktor z 3 argumentami
    public Note(DateOnly date, string name, string content)
    {
        Date = date;
        Name = name;
        Content = content;
    }
    public string ShowNote()
    {
        return $"Nazwa: {Name} tresc: {Content} "
          +$"data: {Date.ToShortDateString()}";
    }
    // public string GetName()
    // {
    //     return name;
    // }
    // public void SetName(string name)
    // {
    //     this.name = name;
    // }
    //property w klasie Note
    public string Name
    {
        get
        {
            return name.ToUpper();
        }
        set
        {
            name = String.IsNullOrEmpty(value) ? "noname": value ;      //n1.Name = "dddd"
        }
    }
}