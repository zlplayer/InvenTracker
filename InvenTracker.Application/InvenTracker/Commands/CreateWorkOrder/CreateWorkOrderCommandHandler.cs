using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateWorkOrder;

public class CreateWorkOrderCommandHandler: IRequestHandler<CreateWorkOrderCommand>
{
    private readonly IWorkOrderRepositories _workOrderRepositories;
    private readonly IWardrobeRepositories _wardrobeRepositories;

    public CreateWorkOrderCommandHandler(IWorkOrderRepositories workOrderRepositories, IWardrobeRepositories wardrobeRepositories)
    {
        _workOrderRepositories = workOrderRepositories;
        _wardrobeRepositories = wardrobeRepositories;
    }

    public async Task Handle(CreateWorkOrderCommand request, CancellationToken cancellationToken)
    {
        var wardrobe= await _wardrobeRepositories.GetWardrobe(request.WardrobeId);
        if (wardrobe == null) throw new ApplicationException("Wardrobe not found");
        
            var workOrder = new WorkOrder                                                                                                                                                                                                                                                                                    
            {                                                                                                                                                                                                                                                                                                                
                WardrobeId = request.WardrobeId,
                Code = Guid.NewGuid().ToString()[..8].ToUpper(),
                Status = "New",
                Items = request.WorkOrderItems.Select(x => new WorkOrderItem
                {
                    ItemId = x.ItemId,
                    Quantity = x.Quantity
                }).ToList()
            };
            await _workOrderRepositories.CreateWorkOrder(workOrder);
        
    }
}