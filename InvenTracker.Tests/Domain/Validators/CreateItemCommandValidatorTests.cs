using FluentAssertions;
using InvenTracker.Application.InvenTracker.Commands.CreateItem;
using Xunit;

namespace InvenTracker.Tests.Domain.Validators;

public class CreateItemCommandValidatorTests
{
    [Fact]
    public void Name_WhenEmpty_ShouldHaveValidationError()
    {
        var name = "";
        
        var validator = new CreateItemCommandValidator();
        
        var result = validator.Validate(new CreateItemCommand { Name = name });
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorMessage == "Name is required");     
    }

    [Fact]
    public void Name_WhenNotEmpty_ShouldNotHaveValidationError()
    {
        var name = "Śróbka";
        
        var validator = new CreateItemCommandValidator();
        var result = validator.Validate(new CreateItemCommand { Name = name });
        
        result.IsValid.Should().BeTrue();
    }
    
    [Fact]
    public void Description_WhenExceeds500Chars_ShouldHaveValidationError()
    {
        var name = "test";
        var description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since 1966, when designers at Letraset and James Mosley, the librarian at St Bride Printing Library in London, took a 1914 Cicero translation and scrambled it to make dummy text for Letraset's Body Type sheets. It has survived not only many decades, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised thanks to these sheets and more recently with desktop publishing software like Aldus PageMaker and Microsoft Word including versions of Lorem Ipsum.";
        var validator = new CreateItemCommandValidator();
        var result = validator.Validate(new CreateItemCommand { Name = name, Description = description });
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.ErrorMessage == "Description must not exceed 500 characters");
    }

    [Fact]
    public void Description_WhenExactly500Chars_ShouldNotHaveValidationError()
    {
        var name = "test";
        var description = new string('a', 500);
        
        var validator = new CreateItemCommandValidator();
        var result = validator.Validate(new CreateItemCommand { Name = name, Description = description });
        
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void QuantityPerPackage_WhenZero_ShouldHaveValidationError()
    {
        var quantityPerPackage = 0;
        var validator = new CreateItemCommandValidator();
        var result = validator.Validate(new CreateItemCommand {  QuantityPerPackage = quantityPerPackage });
        
        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void QuantityPerPackage_WhenNull_ShouldNotHaveValidationError()
    {
        var name = "test";
        var validator = new CreateItemCommandValidator();
        var result = validator.Validate(new CreateItemCommand { Name = name, QuantityPerPackage = null });
        
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void QuantityPerPackage_WhenPositive_ShouldNotHaveValidationError()
    {
        var name = "test";
        var quantityPerPackage = 5;
        
        var validator = new CreateItemCommandValidator();
        var result = validator.Validate(new CreateItemCommand { Name = name, QuantityPerPackage = quantityPerPackage });
        
        result.IsValid.Should().BeTrue();
    }
}