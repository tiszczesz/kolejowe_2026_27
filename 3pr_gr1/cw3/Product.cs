using System;

namespace cw3;

public class Product
{
    public string? Description { get; set; }
    private string name;
    public string Name
    {
        get
        {
            return name.ToUpper();
        }
        set
        {
            name = String.IsNullOrEmpty(value) ? "brak nazwy" : value;
        }
    }
    private decimal price;
    public decimal Price
    {
        get
        {
            return price;
        }
        set
        {
            price = value > 0 ? price : -value;
        }
    }
    private DateTime expirationDate;
    public DateTime ExpirationDate
    {
        get
        {
            return expirationDate;
        }
        set
        {
            expirationDate = value < DateTime.Now ? DateTime.Now : value;
        }
    }
    public Product()
    {
        Description = null;
        Price = 0M;
        Name = "";
        ExpirationDate = DateTime.Now;
    }
    public Product(string name, decimal price, string description, DateTime expirationDate)
    {
        Name = name;
        Price = price;
        Description = description;
        ExpirationDate = expirationDate;
    }
    public override string ToString()
    {
        return $"{Name} {price} zł";
    }

}
