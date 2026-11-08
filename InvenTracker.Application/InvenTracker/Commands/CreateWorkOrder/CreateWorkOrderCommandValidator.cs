using FluentValidation;

namespace InvenTracker.Application.InvenTracker.Commands.CreateWorkOrder;

public class CreateWorkOrderCommandValidator:AbstractValidator<CreateWorkOrderCommand>
{
    public CreateWorkOrderCommandValidator()
    {
        RuleFor(c=>c.WardrobeId).NotEmpty().WithMessage("Wardrobe id is required");
        RuleFor(c=>c.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(c=>c.WorkOrderItems).NotEmpty().WithMessage("Work order items are required");
    }
}