namespace CleanArch.WebUI.Models;

public record ProductResponseModel(decimal Price, int Stock, string? Image, string? NameCategory)
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}