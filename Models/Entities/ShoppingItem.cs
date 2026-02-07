using System;
using System.Collections.Generic;

namespace ShoppingBuddy.Models.Entities;

public class ShoppingItem
{
    public int Id {get; set;}
    public int? StoreId {get; set;}
    public required string Name {get; set;}
    public int Quantity {get; set;}
    public bool IsPurchased {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime? PurchasedAt {get; set;}
    public Store Store { get; set; }
    public List<Category> Categories { get; set; }  = new();
}