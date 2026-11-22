using FluentAssertions;
using InvenTracker.Application.InvenTracker.Commands.CreateCompany;
using Xunit;

namespace InvenTracker.Tests.Domain.Validators;

public class CreateCompanyCommandValidatorTests
{
    [Fact]
    public void Name_WhenEmpty_ShouldHaveValidationError()
    {
        var name = "";

        var validator = new CreateCompanyCommandValidator();
        var result = validator.Validate(new CreateCompanyCommand { Name = name });
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle(e=>e.ErrorMessage == "Name is required");
    }

    [Fact]
    public void Name_WhenExceeds100Chars_ShouldHaveValidationError()
    {
        var name = new string('x', 101);
        
        var validator = new CreateCompanyCommandValidator();
        var result = validator.Validate(new CreateCompanyCommand { Name = name });
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle(e=>e.ErrorMessage == "Name must not exceed 100 characters");
    }

    [Fact]
    public void Name_WhenExactly100Chars_ShouldNotHaveValidationError()
    {
        var name = new string('x', 100);
        
        var validator = new CreateCompanyCommandValidator();
        var result = validator.Validate(new CreateCompanyCommand { Name = name });
        
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Description_WhenExceeds500Chars_ShouldHaveValidationError()
    {
        var name = "test";
        var description = new string('x', 501);
        
        var validator = new CreateCompanyCommandValidator();
        var  result = validator.Validate(new CreateCompanyCommand { Name = name, Description = description });
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle(e=>e.ErrorMessage == "Description must not exceed 500 characters");
    }

    [Fact]
    public void Description_WhenNull_ShouldNotHaveValidationError()
    {
        var name = "test";
        var description = null as string;
        
        var validator = new CreateCompanyCommandValidator();
        var result = validator.Validate(new CreateCompanyCommand { Name = name, Description = description });
        
        result.IsValid.Should().BeTrue();
    }
}