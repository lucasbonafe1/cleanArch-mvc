namespace CleanArch.WebUI.Models;

public record CategoryResponseModel(int Id, int ProductsQuantity)
{
    public string Name { get; set; } = string.Empty;

    public CategoryResponseModel() : this(0, 0)
    {}

    public CategoryResponseModel(int id, int productsQuantity, string name) : this(id, productsQuantity)
    {
        Name = name;
    }
}
