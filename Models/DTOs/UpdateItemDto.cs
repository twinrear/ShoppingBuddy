namespace ShoppingBuddy.Models.DTOs;

public record UpdateItemDto
{
    public required int Id { get; init; }
    public string? Name {get; init;}
    public string? Store {get; init;}
    public int? Quantity {get; init;}
    public bool? IsPurchased {get; init;}
}