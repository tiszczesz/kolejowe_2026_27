using System;
using Microsoft.EntityFrameworkCore;

namespace cw2_ef.Models;

public class AppDbContext : DbContext
{
    //konstruktor z wywołanie konstruktora klasy bazowej DbContext
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
        
    }
    //odpowiednik tabeli w bazie danych
    public DbSet<Movie> Movies { get; set; }

    //zainicjowanie bazy danych przy pierwszym uruchomieniu aplikacji
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "Inception", Director = "Christopher Nolan", ReleaseDate = new DateTime(2010, 7, 16) },
            new Movie { Id = 2, Title = "The Shawshank Redemption", Director = "Frank Darabont", ReleaseDate = new DateTime(1994, 9, 23) },
            new Movie { Id = 3, Title = "The Godfather", Director = "Francis Ford Coppola", ReleaseDate = new DateTime(1972, 3, 24) }
        );
    }
}
