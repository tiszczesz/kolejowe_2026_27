using System;

namespace cw5.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }    
    public int Year { get; set; }
    public override string ToString()
    {
        return $"{Id}|{Title}|{Director}|{Year}"; 
    }
}
