using InvenTracker.Application.InvenTracker.Commands.ExecuteWorkOrder;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Exceptions;
using InvenTracker.Domain.Interfaces;
using MediatR;
using Moq;
using Xunit;

namespace InvenTracker.Tests.Application;

public class ExecuteWorkOrderCommandHandlerTests
{
    [Fact]
    public async Task Handle_WhenWorkOrderNotFound_ShouldThrowNotFoundException()
    {
        var workOrderRepositoriesMock = new Mock<IWorkOrderRepositories>();
        var mediatorMock = new Mock<IMediator>();
        
        workOrderRepositoriesMock.Setup(x=>x.GetWorkOrderByCode(It.IsAny<string>())).ReturnsAsync((WorkOrder?)null);
        
        var hanler = new ExecuteWorkOrderCommandHandler(workOrderRepositoriesMock.Object, mediatorMock.Object);
        var command = new ExecuteWorkOrderCommand();
        
        await Assert.ThrowsAsync<NotFoundException>(async  () => await hanler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WhenWorkOrderAlreadyDone_ShouldThrowInvalidOperationException()
    {
        var workOrderRepositoriesMock = new Mock<IWorkOrderRepositories>();
        var mediatorMock = new Mock<IMediator>();

        var workOrder = new WorkOrder
        {
            Id = Guid.NewGuid(),
            Status = "Done",
        };
        
        workOrderRepositoriesMock.Setup(x=>x.GetWorkOrderByCode(It.IsAny<string>())).ReturnsAsync(workOrder);
        
        var hanler = new ExecuteWorkOrderCommandHandler(workOrderRepositoriesMock.Object, mediatorMock.Object);
        var command = new ExecuteWorkOrderCommand();
        
        await Assert.ThrowsAsync<InvalidOperationException>(async  () => await hanler.Handle(command, CancellationToken.None));

    }

    [Fact]
    public async Task Handle_WhenWorkOrderExists_ShouldCallUpdateWorkOrder()
    {
        var workOrderRepositoriesMock = new Mock<IWorkOrderRepositories>();
        var mediatorMock = new Mock<IMediator>();
        WorkOrder? captured = null;
        
        var workOrder = new WorkOrder
        {
            Id = Guid.NewGuid(),
            Status = "New",
            Items = new List<WorkOrderItem>()
        };
        workOrderRepositoriesMock
            .Setup(x => x.UpdateWorkOrder(It.IsAny<WorkOrder>()))                                                                                                                                                                                                                                                        
            .Callback<WorkOrder>(w => captured = w);
        workOrderRepositoriesMock.Setup(x=>x.GetWorkOrderByCode(It.IsAny<string>())).ReturnsAsync(workOrder);
        
        var hanler = new ExecuteWorkOrderCommandHandler(workOrderRepositoriesMock.Object, mediatorMock.Object);
        var command = new ExecuteWorkOrderCommand();
        await hanler.Handle(command, CancellationToken.None);
        
        workOrderRepositoriesMock.Verify(x => x.UpdateWorkOrder(workOrder), Times.Once);
        Assert.Equal("Done", captured!.Status);
    }

    [Fact]
    public async Task Handle_WhenWorkOrderHasItems_ShouldSendMediatorCommandForEachItem()
    {
        var workOrderRepositoriesMock = new Mock<IWorkOrderRepositories>();
        var mediatorMock = new Mock<IMediator>();
        
        var workOrder = new WorkOrder
        {
            Id = Guid.NewGuid(),
            Status = "New",
            Items = new List<WorkOrderItem>
            {
                new WorkOrderItem
                {
                    Id = Guid.NewGuid(),
                    Quantity = 10,
                    ItemId =  Guid.NewGuid()
                },
                new WorkOrderItem
                {
                    Id = Guid.NewGuid(),
                    Quantity = 20,
                    ItemId =  Guid.NewGuid()
                }
            }
        };
        
        workOrderRepositoriesMock.Setup(x=>x.GetWorkOrderByCode(It.IsAny<string>())).ReturnsAsync(workOrder);
        
        mediatorMock.Setup(x => x.Send(It.IsAny<IRequest<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("ok");

        var hanler = new ExecuteWorkOrderCommandHandler(workOrderRepositoriesMock.Object, mediatorMock.Object);
        var command = new ExecuteWorkOrderCommand();
        await hanler.Handle(command, CancellationToken.None);
        
        mediatorMock.Verify(x => x.Send(It.IsAny<IRequest<string>>(), It.IsAny<CancellationToken>()), Times.Exactly(workOrder.Items.Count));
    }
}