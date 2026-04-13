using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using MediatR;
using System.Text;

namespace InvenTracker.Application.InvenTracker.Commands.RetrieveItemPartitionFifo;

public class RetrieveItemPartitionFifoCommandHandler : IRequestHandler<RetrieveItemPartitionFifoCommand, string>
{
    private readonly IItemPartitionRepositories _itemPartitionRepositories;
    private readonly IItemHistoryRepositories _itemHistoryRepositories;

    public RetrieveItemPartitionFifoCommandHandler(IItemPartitionRepositories itemPartitionRepositories, IItemHistoryRepositories itemHistoryRepositories)
    {
        _itemPartitionRepositories = itemPartitionRepositories;
        _itemHistoryRepositories = itemHistoryRepositories;
    }

    public async Task<string> Handle(RetrieveItemPartitionFifoCommand request, CancellationToken cancellationToken)
    {
        var partitions = await _itemPartitionRepositories
            .GetAllItemPartitionsByWardrobeAndItemFifo(request.WardrobeId, request.ItemId);

        if (partitions.Count == 0)
            throw new KeyNotFoundException($"Przedmiot {request.ItemId} nie znaleziony w szafie {request.WardrobeId}");

        var totalAvailable = partitions.Sum(p => p.QuantityItem);
        if (totalAvailable < request.Quantity)
            throw new InvalidOperationException(
                $"Nie można pobrać {request.Quantity} szt. — dostępne łącznie: {totalAvailable} szt. w {partitions.Count} przegrodzie/przegrodach");

        var remaining = request.Quantity;
        var summary = new StringBuilder();
        var itemName = partitions[0].Item.Name;

        foreach (var partition in partitions)
        {
            if (remaining == 0) break;

            var takenFromThis = Math.Min(partition.QuantityItem, remaining);
            remaining -= takenFromThis;

            await _itemHistoryRepositories.CreateItemHistory(new ItemHistory
            {
                UserId = request.UserId,
                WardrobeId = request.WardrobeId,
                WardrobeName = partition.Partition.Drawer.Wardrobe?.Name,
                DrawerName = partition.Partition.Drawer.Name,
                PartitionName = partition.Partition.Z.ToString(),
                ItemName = itemName,
                Quantity = takenFromThis,
                ActionType = "GET"
            });

            if (takenFromThis == partition.QuantityItem)
            {
                var detail = await _itemPartitionRepositories.GetItemPartition(partition.Id);
                if (detail != null)
                    await _itemPartitionRepositories.DeleteItemPartition(detail);

                summary.AppendLine(
                    $"Szuflada {partition.Partition.Drawer.Name} (X={partition.Partition.Drawer.X}, Y={partition.Partition.Drawer.Y}), " +
                    $"przegroda {partition.Partition.Z}: pobrano {takenFromThis} szt. — przegroda zwolniona");
            }
            else
            {
                var leftAfter = partition.QuantityItem - takenFromThis;
                var detail = await _itemPartitionRepositories.GetItemPartition(partition.Id);
                if (detail != null)
                {
                    detail.QuantityItem = leftAfter;
                    await _itemPartitionRepositories.UpdateItemPartition(detail);
                }

                summary.AppendLine(
                    $"Szuflada {partition.Partition.Drawer.Name} (X={partition.Partition.Drawer.X}, Y={partition.Partition.Drawer.Y}), " +
                    $"przegroda {partition.Partition.Z}: pobrano {takenFromThis} szt. — pozostało {leftAfter} szt.");
            }
        }

        return $"Pobrano łącznie {request.Quantity} szt. przedmiotu '{itemName}':\n{summary}";
    }
}
