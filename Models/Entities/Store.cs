using System.Collections.Generic;

namespace ShoppingBuddy.Models.Entities;

public class Store
{
    public int Id {get; set;}
    public required string Name {get; set;}
    public List<ShoppingItem> Items { get; set; }  = new();
}