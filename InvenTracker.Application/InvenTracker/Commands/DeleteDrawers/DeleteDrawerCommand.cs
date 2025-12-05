using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteDrawers;

public class DeleteDrawerCommand:IRequest
{
    public Guid DrawerId { get; set; }
}