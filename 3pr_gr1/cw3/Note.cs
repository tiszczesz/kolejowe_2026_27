namespace cw3;

public class Note
{
    private DateOnly date;
    private string name;
    private string content;

    //konstruktory
    //1. Bez argumentow
    public Note()
    {
        date = DateOnly.FromDateTime(DateTime.Now);
        name = "noname";
        content = "";
    }
    //2. Konstruktor z 3 argumentami
    public Note(DateOnly date, string name, string content)
    {
        this.date = date;
        this.name = name;
        this.content = content;
    }
    public string ShowNote()
    {
        return $"Nazwa: {name} tresc: {content} "
          +$"data: {date.ToShortDateString()}";
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
            name = value;      //n1.Name = "dddd"
        }
    }
}