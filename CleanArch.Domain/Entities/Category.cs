using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities;

public sealed class Category : EntityBase
{
    public Category(string name)
    {
        ValidateDomain(name);
    }

    public Category(int id, string name)
    {
        Id = id;
        ValidateDomain(name);
    }

    public void Update(string name)
    {
        ValidateDomain(name);
    }

    public ICollection<Product> Products { get; set; } = null!;

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");

        DomainExceptionValidation.When(name.Length < 3, "Name too short, minimum 3 char");

        Name = name;
    }
}