using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Exceptions;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.RestockItemPartition;

// Uzupełnienie stanu przez dostawcę — może tylko dodać ilość, nie zmienia przedmiotu, przegrody ani minimum
public class RestockItemPartitionCommandHandler : IRequestHandler<RestockItemPartitionCommand, string>
{
    private readonly IItemPartitionRepositories _itemPartitionRepositories;
    private readonly IItemHistoryRepositories _itemHistoryRepositories;

    public RestockItemPartitionCommandHandler(
        IItemPartitionRepositories itemPartitionRepositories,
        IItemHistoryRepositories itemHistoryRepositories)
    {
        _itemPartitionRepositories = itemPartitionRepositories;
        _itemHistoryRepositories = itemHistoryRepositories;
    }

    public async Task<string> Handle(RestockItemPartitionCommand request, CancellationToken cancellationToken)
    {
        var itemPartition = await _itemPartitionRepositories.GetItemPartitionWithDetails(request.ItemPartitionId);
        if (itemPartition == null)
            throw new NotFoundException($"ItemPartition with id {request.ItemPartitionId} not found");

        itemPartition.QuantityItem += request.Quantity;
        await _itemPartitionRepositories.UpdateItemPartition(itemPartition);

        var drawer = itemPartition.Partition.Drawer;
        await _itemHistoryRepositories.CreateItemHistory(new ItemHistory
        {
            UserId = request.UserId,
            WardrobeId = drawer.WardrobeId ?? Guid.Empty,
            WardrobeName = drawer.Wardrobe?.Name,
            DrawerName = drawer.Name,
            PartitionName = itemPartition.Partition.Z.ToString(),
            ItemName = itemPartition.Item.Name,
            Quantity = request.Quantity,
            ActionType = "RESTOCK",
            ItemPartitionId = itemPartition.Id
        });

        return $"Uzupełniono {request.Quantity} szt. przedmiotu '{itemPartition.Item.Name}' " +
               $"(szuflada {drawer.Name}, przegroda {itemPartition.Partition.Z}). " +
               $"Stan po uzupełnieniu: {itemPartition.QuantityItem} szt.";
    }
}
