using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.ReturnItemPartition;

public class ReturnItemPartitionCommandHandler: IRequestHandler<ReturnItemPartitionCommand, string>
{
    private readonly IItemPartitionRepositories _itemPartitionRepositories;
    private readonly IItemHistoryRepositories _itemHistoryRepositories;
    public ReturnItemPartitionCommandHandler(
        IItemPartitionRepositories itemPartitionRepositories,
        IItemHistoryRepositories itemHistoryRepositories
        )
    {
        _itemPartitionRepositories = itemPartitionRepositories;
        _itemHistoryRepositories = itemHistoryRepositories;
    }
    public async Task<string> Handle(ReturnItemPartitionCommand request, CancellationToken cancellationToken)
    {
        var partition = await _itemPartitionRepositories.GetItemPartitionWithDetails(request.ItemPartitionId);

        if (partition == null)
            throw new KeyNotFoundException($"Przegroda {request.ItemPartitionId} nie została znaleziona.");
        
        partition.QuantityItem += request.Quantity;
        await _itemPartitionRepositories.UpdateItemPartition(partition);

        await _itemHistoryRepositories.CreateItemHistory(new ItemHistory
        {
            UserId = request.UserId,
            WardrobeId = request.WardrobeId,
            WardrobeName = partition.Partition.Drawer.Wardrobe?.Name,
            DrawerName = partition.Partition.Drawer.Name,
            PartitionName = partition.Partition.Z.ToString(),
            ItemName = partition.Item.Name,
            Quantity = request.Quantity,
            ActionType = "RETURN"
        });
        
        return $"Zwrócono {request.Quantity} szt. przedmiotu '{partition.Item.Name}' do " +
               $"szuflady {partition.Partition.Drawer.Name} (X={partition.Partition.Drawer.X}, Y={partition.Partition.Drawer.Y}), " +
               $"przegroda {partition.Partition.Z}. " +
               $"Stan po zwrocie: {partition.QuantityItem} szt.";
    }
}