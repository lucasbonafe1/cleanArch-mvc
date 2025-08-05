namespace CleanArch.WebUI.Models;

public record ProductResponseModel(int Id, decimal Price, int Stock, string? Image, string? NameCategory)
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;


    public ProductResponseModel() : this(0, 0.0M, 0, null, null)
    {}

    public ProductResponseModel(int id, string name, string description, decimal price, int stock, string? image, string nameCategory) : this(id, price, stock, image, nameCategory)
    {
        Name = name;
        Description = description;
    }
}