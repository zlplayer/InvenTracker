using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.RetrieveItemPartitionFifo;

public class RetrieveItemPartitionFifoCommandHandler:IRequestHandler<RetrieveItemPartitionFifoCommand, string>
{
    private readonly IItemPartitionRepositories _itemPartitionRepositories;
    private readonly IItemHistoryRepositories _itemHistoryRepositories;

    public RetrieveItemPartitionFifoCommandHandler(IItemPartitionRepositories itemPartitionRepositories, IItemHistoryRepositories itemHistoryRepositories)
    {
        _itemPartitionRepositories=itemPartitionRepositories;
        _itemHistoryRepositories = itemHistoryRepositories;
    }
    
    public async Task<string> Handle(RetrieveItemPartitionFifoCommand request, CancellationToken cancellationToken)
    {
        var itemPartition = await _itemPartitionRepositories
            .GetItemPartitionByWardrobeAndItemFifo(request.WardrobeId, request.ItemId);

        if (itemPartition == null)
            throw new KeyNotFoundException($"Item {request.ItemId} not found in wardrobe {request.WardrobeId}");
        
        var quntity = itemPartition.QuantityItem - request.Quantity;

        if (quntity == 0)
        {
            var itemPartitionDetail = await _itemPartitionRepositories.GetItemPartition(itemPartition.Id);
            if (itemPartitionDetail == null) throw new KeyNotFoundException($"Item {itemPartition.Id} not found");
            await _itemPartitionRepositories.DeleteItemPartition(itemPartitionDetail);

            await _itemHistoryRepositories.CreateItemHistory(new ItemHistory
            {
                UserId = request.UserId,
                WardrobeId = request.WardrobeId,
                WardrobeName = itemPartition.Partition.Drawer.Wardrobe?.Name,
                DrawerName = itemPartition.Partition.Drawer.Name,
                PartitionName = itemPartition.Partition.Z.ToString(),
                ItemName = itemPartition.Item.Name,
                Quantity = request.Quantity,
                ActionType = "GET"
            });

            return
                $"Wyciągnieto całą ilość przedmiotu {itemPartition.Item.Name} w szufladzie {itemPartition.Partition.Drawer.Name} o współrzędnych X= {itemPartition.Partition.Drawer.X}, Y= {itemPartition.Partition.Drawer.Y}  w przegrodzie {itemPartition.Partition.Z}, przegroda została zwolniona";

        }
        else if (quntity > 0)
        {
            var itemPartitionDetail = await _itemPartitionRepositories.GetItemPartition(itemPartition.Id);
            if (itemPartitionDetail == null) throw new KeyNotFoundException($"Item {itemPartition.Id} not found");
            itemPartitionDetail.QuantityItem = quntity;
            await _itemPartitionRepositories.UpdateItemPartition(itemPartitionDetail);

            await _itemHistoryRepositories.CreateItemHistory(new ItemHistory
            {
                UserId = request.UserId,
                WardrobeId = request.WardrobeId,
                WardrobeName = itemPartition.Partition.Drawer.Wardrobe?.Name,
                DrawerName = itemPartition.Partition.Drawer.Name,
                PartitionName = itemPartition.Partition.Z.ToString(),
                ItemName = itemPartition.Item.Name,
                Quantity = request.Quantity,
                ActionType = "GET"
            });

            return
                $"Znaleziono przedmiot {itemPartition.Item.Name} w szufladzie {itemPartition.Partition.Drawer.Name} o współrzędnych X= {itemPartition.Partition.Drawer.X}, Y= {itemPartition.Partition.Drawer.Y}  w przegrodzie {itemPartition.Partition.Z}, wyciągnieto: {request.Quantity} aktualna ilość to {quntity}";
        }
        else
        {
            return 
                $"Nie można wyciągnąć więcej {itemPartition.Item.Name} niż jest w szufladzie obecnie ilość to {itemPartition.QuantityItem}";
        }
    }
}