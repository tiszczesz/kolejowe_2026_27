using System;

namespace cw1.Models;

public class RentalItem
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int Duration { get; set; }
    public Item? ActualItem { get; set; }
    public string? Description { get; set; }
    

}
