using FluentValidation;

namespace InvenTracker.Application.InvenTracker.Commands.RestockItemPartition;

public class RestockItemPartitionCommandValidator : AbstractValidator<RestockItemPartitionCommand>
{
    public RestockItemPartitionCommandValidator()
    {
        RuleFor(c => c.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
    }
}
