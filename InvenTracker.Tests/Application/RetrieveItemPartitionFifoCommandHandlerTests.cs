using InvenTracker.Application.InvenTracker.Commands.RetrieveItemPartitionFifo;
using InvenTracker.Application.Iterfaces;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Exceptions;
using InvenTracker.Domain.Interfaces;
using Moq;
using Xunit;

namespace InvenTracker.Tests.Application;

public class RetrieveItemPartitionFifoCommandHandlerTests
{
    [Fact]
    public async Task Handle_WhenPartitionsEmpty_ShouldThrowNotFoundException()
    {
        var itemPartitionRepositoriesMock = new Mock<IItemPartitionRepositories>();
        var itemHistoryRepositoriesMock = new Mock<IItemHistoryRepositories>();
        var emailServiceMock = new Mock<IEmailService>();
        var wardrobeResponsibleRepositoriesMock = new Mock<IWardrobeResponsibleRepositories>();
        
        itemPartitionRepositoriesMock.Setup(x=>x.GetAllItemPartitionsByWardrobeAndItemFifo(It.IsAny<Guid>(),It.IsAny<Guid>())).ReturnsAsync(new List<ItemPartition>());
        
        var handler= new RetrieveItemPartitionFifoCommandHandler(itemPartitionRepositoriesMock.Object, itemHistoryRepositoriesMock.Object, emailServiceMock.Object, wardrobeResponsibleRepositoriesMock.Object);
        var command = new RetrieveItemPartitionFifoCommand();
        
        await Assert.ThrowsAsync<NotFoundException>(async  () => await handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WhenTotalQuantityInsufficient_ShouldThrowInvalidOperationException()
    {
        var itemPartitionRepositoriesMock = new Mock<IItemPartitionRepositories>();
        var itemHistoryRepositoriesMock = new Mock<IItemHistoryRepositories>();
        var emailServiceMock = new Mock<IEmailService>();
        var wardrobeResponsibleRepositoriesMock = new Mock<IWardrobeResponsibleRepositories>();

        var itemPartition = new List<ItemPartition>
        {
            new ItemPartition
            {
                QuantityItem = 1
            }
        };
        
        itemPartitionRepositoriesMock.Setup(x=>x.GetAllItemPartitionsByWardrobeAndItemFifo(It.IsAny<Guid>(),It.IsAny<Guid>())).ReturnsAsync(itemPartition);
        
        var handler= new RetrieveItemPartitionFifoCommandHandler(itemPartitionRepositoriesMock.Object, itemHistoryRepositoriesMock.Object, emailServiceMock.Object, wardrobeResponsibleRepositoriesMock.Object);
        var command = new RetrieveItemPartitionFifoCommand{ Quantity = 10};
        
        await Assert.ThrowsAsync<InvalidOperationException>(async  () => await handler.Handle(command, CancellationToken.None));
    }
}