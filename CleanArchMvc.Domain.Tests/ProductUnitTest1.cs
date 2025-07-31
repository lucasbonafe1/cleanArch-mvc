using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class ProductUnitTest1
{
    [Fact]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "NameCategory", "DescriptionValid", 11.4M, 12, "Image");

        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_ShortNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Product(1, "Na", "DescriptionValid", 11.4M, 12, "Image");

        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("Name too short, minimum 3 char");
    }

    [Fact]
    public void CreateProduct_DescriptionInvalid_DomainExceptionInvalidName()
    {
        Action action = () => new Product(1, "Namevalid", null, 11.4M, 12, "Image");

        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("description.Description is required");
    }

    [Fact]
    public void CreateProduct_InvalidPrice_DomainExceptionInvalidName()
    {
        Action action = () => new Product(1, "Namevalid", "DescriptionValid", -12.2M, 12, "Image");

        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("Invalid Price Value");
    }

    [Fact]
    public void CreateProduct_NullName_DomainExceptionRequiredName()
    {
        Action action = () => new Product(1, null, "DescriptionValid", 11.4M, 12, "Image");

        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("Invalid name.Name is required");
    }
}