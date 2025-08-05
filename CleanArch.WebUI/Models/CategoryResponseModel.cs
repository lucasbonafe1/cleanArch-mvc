namespace CleanArch.WebUI.Models;

public record CategoryResponseModel(int Id, int ProductsQuantity)
{
    public string Name { get; set; } = string.Empty;
}
