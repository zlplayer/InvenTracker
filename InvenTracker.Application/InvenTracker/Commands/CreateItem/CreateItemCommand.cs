using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateItem;

public class CreateItemCommand: CreateItemDto, IRequest
{
    public Guid DrawerId { get; set; }
}