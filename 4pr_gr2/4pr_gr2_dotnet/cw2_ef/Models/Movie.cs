using System;

namespace cw2_ef.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Director { get; set; } = null!;
    public DateTime ReleaseDate { get; set; }

}
