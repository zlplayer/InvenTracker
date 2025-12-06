using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateItem;

public class UpdateItemCommand:UpdateItemDto ,IRequest
{
    public Guid ItemId { get; set; }
}