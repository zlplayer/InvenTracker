using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using MediatR;
using System.Text;
using InvenTracker.Application.Iterfaces;

namespace InvenTracker.Application.InvenTracker.Commands.RetrieveItemPartitionFifo;

public class RetrieveItemPartitionFifoCommandHandler : IRequestHandler<RetrieveItemPartitionFifoCommand, string>
{
    private readonly IItemPartitionRepositories _itemPartitionRepositories;
    private readonly IItemHistoryRepositories _itemHistoryRepositories;
    private readonly IEmailService _emailService;
    private readonly IWardrobeResponsibleRepositories _wardrobeResponsibleRepositories ;


    public RetrieveItemPartitionFifoCommandHandler(
        IItemPartitionRepositories itemPartitionRepositories, 
        IItemHistoryRepositories itemHistoryRepositories, 
        IEmailService  emailService, 
        IWardrobeResponsibleRepositories wardrobeResponsibleRepositories)
    {
        _itemPartitionRepositories = itemPartitionRepositories;
        _itemHistoryRepositories = itemHistoryRepositories;
        _emailService = emailService;
        _wardrobeResponsibleRepositories = wardrobeResponsibleRepositories;
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
        var belowMinPartitions = new List<ItemPartition>();
        
        foreach (var partition in partitions)
        {
            if (remaining == 0) break;

            var takenFromThis = Math.Min(partition.QuantityItem, remaining);
            remaining -= takenFromThis;

            await _itemHistoryRepositories.CreateItemHistory(new ItemHistory
            {
                UserId = request.UserId,
                WardrobeId = request.WardrobeId,
                ItemPartitionId =  partition.Id,
                WardrobeName = partition.Partition.Drawer.Wardrobe?.Name,
                DrawerName = partition.Partition.Drawer.Name,
                PartitionName = partition.Partition.Z.ToString(),
                ItemName = itemName,
                Quantity = takenFromThis,
                ActionType = "GET"
            });

            var leftAfter = partition.QuantityItem - takenFromThis;
            var detail = await _itemPartitionRepositories.GetItemPartition(partition.Id);
            if (detail != null)
            {
                detail.QuantityItem = leftAfter;
                await _itemPartitionRepositories.UpdateItemPartition(detail);
                if (leftAfter <= detail.MinimumQuantityItem)
                    belowMinPartitions.Add(detail);
            }

            var status = leftAfter == 0 ? "przegroda pusta" : $"pozostało {leftAfter} szt.";
            summary.AppendLine(
                $"Szuflada {partition.Partition.Drawer.Name} (X={partition.Partition.Drawer.X}, Y={partition.Partition.Drawer.Y}), " +
                $"przegroda {partition.Partition.Z}: pobrano {takenFromThis} szt. — {status}");
        }


        var responsibles = await _wardrobeResponsibleRepositories
            .GetWardrobeResponsiblesByWardrobeId(request.WardrobeId);

        if(belowMinPartitions.Any())
        {
            foreach (var belowMinPartition in belowMinPartitions)
            {
                foreach (var responsible in responsibles)
                {
                    await _emailService.SendLowStockAlertAsync(
                        responsible.User.Email, belowMinPartition.Item.Name, belowMinPartition.QuantityItem, belowMinPartition.MinimumQuantityItem );
                }
            }
        }
        
        return $"Pobrano łącznie {request.Quantity} szt. przedmiotu '{itemName}':\n{summary}";
    }
}
