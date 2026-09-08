using System;
using MySql.Data.MySqlClient;

namespace cw1.Models;

public class RentalRepo
{
    private string? connectionString;

    public RentalRepo(string? connectionString)
    {
        this.connectionString = connectionString;
    }
    public List<Item> GetAllItems()
    {
        List<Item> items = new List<Item>();
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var command = new MySqlCommand("SELECT * FROM Items", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new Item
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                        Price = reader.GetDecimal("Price")
                    };
                    items.Add(item);
                }
            }
        }
        return items;
    }
    public Item? GetItemById(int id)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var command = new MySqlCommand("SELECT * FROM Items WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Item
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                        Price = reader.GetDecimal("Price")
                    };
                }
            }
        }
        return null;
    }

    public List<RentalItem> GetAllRentalItems()
    {
        List<RentalItem> rentalItems = new List<RentalItem>();
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var command = new MySqlCommand("SELECT * FROM rental_details", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var rentalItem = new RentalItem
                    {
                        Id = reader.GetInt32("Id"),
                        ItemId = reader.GetInt32("item_id"),
                        Duration = reader.GetInt32("duration"),
                        Description = reader.IsDBNull(reader.GetOrdinal("other")) ? null : reader.GetString("description")
                    };
                    rentalItems.Add(rentalItem);
                }
            }
        }
        return rentalItems;
    }

    public void SaveRentalItem(RentalItem rentalItem)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var command = new MySqlCommand("INSERT INTO rental_details (item_id, duration, other) VALUES (@ItemId, @Duration, @Description)", connection);
            command.Parameters.AddWithValue("@ItemId", rentalItem.ItemId);
            command.Parameters.AddWithValue("@Duration", rentalItem.Duration);
            command.Parameters.AddWithValue("@Description", rentalItem.Description ?? (object)DBNull.Value);
            command.ExecuteNonQuery();
        }
    }
}  
