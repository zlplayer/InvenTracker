using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.RetrieveItemPartition;

public class RetrieveItemPartitionCommandHandler: IRequestHandler<RetrieveItemPartitionCommand, string>
{
    private readonly IItemPartitionRepositories _itemPartitionRepositories;

    public RetrieveItemPartitionCommandHandler(IItemPartitionRepositories itemPartitionRepositories)
    {
        _itemPartitionRepositories = itemPartitionRepositories;
    }
    public async Task<string> Handle(RetrieveItemPartitionCommand request, CancellationToken cancellationToken)
    {
        var itemPartition = await _itemPartitionRepositories
            .GetItemPartitionByWardrobeAndItem(request.WardrobeId, request.ItemId);

        if (itemPartition == null)
            throw new KeyNotFoundException($"Item {request.ItemId} not found in wardrobe {request.WardrobeId}");
        
        var quntity = itemPartition.QuantityItem - request.Quantity;

        if (quntity == 0)
        {
            var itemPartitionDetail = await _itemPartitionRepositories.GetItemPartition(itemPartition.Id);
            if (itemPartitionDetail == null) throw new KeyNotFoundException($"Item {itemPartition.Id} not found");
            await  _itemPartitionRepositories.DeleteItemPartition(itemPartitionDetail);
            return
                $"Wyciągnieto całą ilość przedmiotu {itemPartition.Item.Name} w szufladzie {itemPartition.Partition.Drawer.Name} o współrzędnych X= {itemPartition.Partition.Drawer.X}, Y= {itemPartition.Partition.Drawer.Y}  w przegrodzie {itemPartition.Partition.Z}, przegroda została zwolniona";
        }
        else if (quntity > 0)
        {
            var itemPartitionDetail = await _itemPartitionRepositories.GetItemPartition(itemPartition.Id);
            if (itemPartitionDetail == null) throw new KeyNotFoundException($"Item {itemPartition.Id} not found");
            itemPartitionDetail.QuantityItem = quntity;
            await _itemPartitionRepositories.UpdateItemPartition(itemPartitionDetail);
            
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