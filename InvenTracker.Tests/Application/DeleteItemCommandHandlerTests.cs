using InvenTracker.Application.InvenTracker.Commands.DeleteItems;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Exceptions;
using InvenTracker.Domain.Interfaces;
using Moq;
using Xunit;

namespace InvenTracker.Tests.Application;

public class DeleteItemCommandHandlerTests
{
    [Fact]  
    public async Task Handle_WhenItemExists_ShouldCallDeleteItem()
    {
        var itemRopositoriesMock = new Mock<IItemRepositories>();

        var item = new Item
        {
            Id = Guid.NewGuid(),
            Name = "Item",
            Description = "Description",
            Status = "Status",
            IsPackaged = true,
            QuantityPerPackage = 5,
        };

        itemRopositoriesMock.Setup(x => x.GetItem(It.IsAny<Guid>())).ReturnsAsync(item);
        
        var handler = new DeleteItemCommandHandler(itemRopositoriesMock.Object);
        var command = new DeleteItemCommand();
        
        await handler.Handle(command, CancellationToken.None);
        
        itemRopositoriesMock.Verify(x=>x.DeleteItem(item), Times.Once);
    }

    [Fact]
    public async Task Handle_WhenItemNotFound_ShouldThrowNotFoundException()
    {
        var itemRopositoriesMock = new Mock<IItemRepositories>();
        
        itemRopositoriesMock.Setup(x => x.GetItem(It.IsAny<Guid>())).ReturnsAsync((Item?)null);
        
        var handler = new DeleteItemCommandHandler(itemRopositoriesMock.Object);
        var command = new DeleteItemCommand();
        
        
        await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(command, CancellationToken.None));
    }
}