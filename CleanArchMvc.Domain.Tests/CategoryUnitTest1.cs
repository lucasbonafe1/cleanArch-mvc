using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;
using System.Xml.Linq;

namespace CleanArchMvc.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "NameCategory");

        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateCategory_ShortNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, "Na");

        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("Name too short, minimum 3 char");
    }

    [Fact]
    public void CreateCategory_NullName_DomainExceptionRequiredName()
    {
        Action action = () => new Category(1, null);

        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("Invalid name.Name is required");
    }
}