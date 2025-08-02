namespace CleanArch.WebUI.Models;

public record CategoryResponseModel(int ProductsQuantity)
{
    public string Name { get; set; } = string.Empty;
}
