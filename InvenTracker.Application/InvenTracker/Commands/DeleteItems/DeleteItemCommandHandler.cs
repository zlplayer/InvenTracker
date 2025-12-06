using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteItems;

public class DeleteItemCommandHandler: IRequestHandler<DeleteItemCommand>
{
    private readonly IItemRepositories _itemRepositories;

    public DeleteItemCommandHandler(IItemRepositories itemRepositories)
    {
        _itemRepositories = itemRepositories;
    }

    public async Task Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        var item= await _itemRepositories.GetItem(request.ItemId);
        if (item == null) throw new KeyNotFoundException($"Drawer with id {request.ItemId} not found");
        await _itemRepositories.DeleteItem(item);
    }
}