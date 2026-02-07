using System.Collections.Generic;

namespace ShoppingBuddy.Models.DTOs;

public record CreateItemDto
{
    public required string Name {get; init;}
    public string? Store {get; init;}
    public int Quantity {get; init;}
    public List<string>? Categories {get; init;}
}