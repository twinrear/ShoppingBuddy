namespace ShoppingBuddy.Models.DTOs;

public record ItemResponseDto
{
    public int Id {get; init;}
    public required string Name {get; init;}
    public string? Store {get; init;}
    public int Quantity {get; init;}
    public bool IsPurchased {get; init;}
}