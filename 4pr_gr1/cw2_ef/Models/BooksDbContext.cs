using System;
using Microsoft.EntityFrameworkCore;

namespace cw2_ef.Models;

public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options)
    : base(options) //konstruktor przekazujący opcje do DbContext klasa bazowa
    {

    }
    //Odpowiednik tabeli w bazie danych
    public DbSet<Book> Books { get; set; }
    //Zainicjowanie bazy danych i wypełnienie jej przykładowymi danymi
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Władca Pierścieni", Author = "J.R.R. Tolkien", Year = 1954, Price = 49.99m },
            new Book { Id = 2, Title = "Hobbit", Author = "J.R.R. Tolkien", Year = 1937, Price = 34.99m },
            new Book { Id = 3, Title = "1984", Author = "George Orwell", Year = 1949, Price = 29.99m },
            new Book { Id = 4, Title = "Zbrodnia i kara", Author = "Fiodor Dostojewski", Year = 1866, Price = 39.99m },
            new Book { Id = 5, Title = "Lalka", Author = "Bolesław Prus", Year = 1890, Price = 32.99m },
            new Book { Id = 6, Title = "Pan Tadeusz", Author = "Adam Mickiewicz", Year = 1834, Price = 27.99m },
            new Book { Id = 7, Title = "Mistrz i Małgorzata", Author = "Michaił Bułhakow", Year = 1967, Price = 36.99m },
            new Book { Id = 8, Title = "Mały Książę", Author = "Antoine de Saint-Exupéry", Year = 1943, Price = 24.99m },
            new Book { Id = 9, Title = "Harry Potter i Kamień Filozoficzny", Author = "J.K. Rowling", Year = 1997, Price = 44.99m },
            new Book { Id = 10, Title = "Wiedźmin: Ostatnie życzenie", Author = "Andrzej Sapkowski", Year = 1993, Price = 39.99m }
        );
    }
}
