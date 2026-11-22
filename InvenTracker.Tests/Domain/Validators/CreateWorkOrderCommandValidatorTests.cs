using FluentAssertions;
using InvenTracker.Application.Dtos;
using InvenTracker.Application.InvenTracker.Commands.CreateWorkOrder;
using Xunit;

namespace InvenTracker.Tests.Domain.Validators;

public class CreateWorkOrderCommandValidatorTests
{
    [Fact]
    public void WardrobeId_WhenEmpty_ShouldHaveValidationError()
    {
        var id = new Guid();
        var name = "test";
        var workOrderItems = new List<CreateWorkOrderItemDto>([
            new CreateWorkOrderItemDto
            {
                ItemId = Guid.NewGuid(),
                Quantity = 1
            },
            new CreateWorkOrderItemDto
            {
                ItemId = Guid.NewGuid(),
                Quantity = 2
            }]);
        var validator = new CreateWorkOrderCommandValidator();
        var result = validator.Validate(new CreateWorkOrderCommand { WardrobeId = id,  Name = name, WorkOrderItems = workOrderItems });

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle(e=>e.ErrorMessage == "Wardrobe id is required");
    }
    
    [Fact]
    public void Name_WhenEmpty_ShouldHaveValidationError()
    {
        var id = Guid.NewGuid();
        var name = null as  string;
        var workOrderItems = new List<CreateWorkOrderItemDto>([
            new CreateWorkOrderItemDto
            {
                ItemId = Guid.NewGuid(),
                Quantity = 1
            },
            new CreateWorkOrderItemDto
            {
                ItemId = Guid.NewGuid(),
                Quantity = 2
            }]);
        var validator = new CreateWorkOrderCommandValidator();
        var result = validator.Validate(new CreateWorkOrderCommand { WardrobeId = id,  Name = name, WorkOrderItems = workOrderItems });
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle(e=>e.ErrorMessage == "Name is required");

    }

    [Fact]
    public void WorkOrderItems_WhenEmpty_ShouldHaveValidationError()
    {
        var id = Guid.NewGuid();
        var name = "test";
        var workOrderItems = new List<CreateWorkOrderItemDto>([]);
        
        var validator = new CreateWorkOrderCommandValidator();
        var result = validator.Validate(new CreateWorkOrderCommand { WardrobeId = id,  Name = name, WorkOrderItems = workOrderItems });

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle(e=>e.ErrorMessage == "Work order items are required");
    }
    
    [Fact]
    public void AllFieldsValid_ShouldNotHaveAnyValidationErrors()
    {
        var id = Guid.NewGuid();
        var name = "test";
        var workOrderItems = new List<CreateWorkOrderItemDto>([
        new CreateWorkOrderItemDto
        {
            ItemId = Guid.NewGuid(),
            Quantity = 1
        },
        new CreateWorkOrderItemDto
        {
            ItemId = Guid.NewGuid(),
            Quantity = 2
        }]);
        
        var validator = new CreateWorkOrderCommandValidator();
        var result = validator.Validate(new CreateWorkOrderCommand { WardrobeId = id,  Name = name, WorkOrderItems = workOrderItems });

        result.IsValid.Should().BeTrue();
    }
}