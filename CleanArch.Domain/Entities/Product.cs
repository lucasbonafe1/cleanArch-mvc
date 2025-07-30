using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities;

public sealed class Product : EntityBase
{
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set; } = string.Empty;

    public Product(int id, string name, string description, decimal price, int stock, string image)
    {
        Id = id;
        ValidateDomain(name, description, price, stock, image);
    }

    public Product(string name, string description, decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
    }

    public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        CategoryId = categoryId;
    }

    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Name too short, minimum 3 char");

        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description.Description is required");
        DomainExceptionValidation.When(description.Length < 5, "Description too short, minimum 5 char");

        DomainExceptionValidation.When(price < 0, "Invalid Price Value");
        DomainExceptionValidation.When(stock < 0, "Invalid Stock Value");

        DomainExceptionValidation.When(Image.Length > 250, "Invalid Image Name, minimum 250 char");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
