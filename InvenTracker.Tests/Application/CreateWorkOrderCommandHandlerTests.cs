using InvenTracker.Application.Dtos;
using InvenTracker.Application.InvenTracker.Commands.CreateWorkOrder;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Moq;
using Xunit;

namespace InvenTracker.Tests.Application;

public class CreateWorkOrderCommandHandlerTests
{
    [Fact]
    public async Task Handle_WhenWardrobeExists_ShouldCallCreateWorkOrder()
    {
        var workOrderRepositoriesMock = new Mock<IWorkOrderRepositories>();
        var wardrobeRepositoriesMock = new Mock<IWardrobeRepositories>();
        var wardrobe = new Wardrobe
        {
            Id = Guid.NewGuid(),
            Name = "Wardrobe"
        };

        wardrobeRepositoriesMock.Setup(x => x.GetWardrobe(wardrobe.Id)).ReturnsAsync(wardrobe);
        workOrderRepositoriesMock.Setup(x => x.CreateWorkOrder(It.IsAny<WorkOrder>()));
        
        var handler = new CreateWorkOrderCommandHandler(workOrderRepositoriesMock.Object, wardrobeRepositoriesMock.Object);
        var command = new CreateWorkOrderCommand{                                                                                                                                                                                                                                                                                                                
            WardrobeId = wardrobe.Id,
            WorkOrderItems = new List<CreateWorkOrderItemDto>()
        };
        await handler.Handle(command, CancellationToken.None);
        
        workOrderRepositoriesMock.Verify(x => x.CreateWorkOrder(It.IsAny<WorkOrder>()), Times.Once);
        wardrobeRepositoriesMock.Verify(x => x.GetWardrobe(wardrobe.Id), Times.Once);
    }

    [Fact]
    public async Task Handle_WhenWardrobeNotFound_ShouldThrowApplicationException()
    {
        var workOrderRepositoriesMock = new Mock<IWorkOrderRepositories>();
        var wardrobeRepositoriesMock = new Mock<IWardrobeRepositories>();
        var wardrobe = new Wardrobe
        {
            Id = Guid.NewGuid(),
            Name = "Wardrobe"
        };

        wardrobeRepositoriesMock.Setup(x => x.GetWardrobe(wardrobe.Id)).ReturnsAsync((Wardrobe?)null);
        workOrderRepositoriesMock.Setup(x => x.CreateWorkOrder(It.IsAny<WorkOrder>()));
        
        var handler = new CreateWorkOrderCommandHandler(workOrderRepositoriesMock.Object, wardrobeRepositoriesMock.Object);
        var command = new CreateWorkOrderCommand{                                                                                                                                                                                                                                                                                                                
            WardrobeId = wardrobe.Id,
            WorkOrderItems = new List<CreateWorkOrderItemDto>()
        };
        
        await Assert.ThrowsAsync<ApplicationException>(async () => await handler.Handle(command, CancellationToken.None));
        workOrderRepositoriesMock.Verify(x => x.CreateWorkOrder(It.IsAny<WorkOrder>()), Times.Never);
    }
}