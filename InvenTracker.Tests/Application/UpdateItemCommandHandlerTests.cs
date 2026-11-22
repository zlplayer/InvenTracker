using AutoMapper;
using InvenTracker.Application.InvenTracker.Commands.UpdateItem;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Moq;
using Xunit;

namespace InvenTracker.Tests.Application;

public class UpdateItemCommandHandlerTests
{
    [Fact]
    public async Task Handle_WhenItemExists_ShouldCallUpdateItem()
    {
        var mapperMock = new Mock<IMapper>();
        var itemRepositoriesMock = new Mock<IItemRepositories>();

        itemRepositoriesMock.Setup(x => x.GetItem(It.IsAny<Guid>())).ReturnsAsync(new Item());                                                                                                                                                                                                                           
        mapperMock.Setup(x => x.Map(It.IsAny<UpdateItemCommand>(), It.IsAny<Item>()));
        itemRepositoriesMock.Setup(x=>x.UpdateItem(It.IsAny<Item>()));
        
        var handler= new UpdateItemCommandHandler(mapperMock.Object, itemRepositoriesMock.Object);
        var command = new UpdateItemCommand();
        
        await handler.Handle(command, CancellationToken.None);
        
        itemRepositoriesMock.Verify(x => x.UpdateItem(It.IsAny<Item>()), Times.Once);
    }

    [Fact]
    public async Task Handle_WhenItemNotFound_ShouldThrowNullReferenceException()
    {
        var mapperMock = new Mock<IMapper>();
        var itemRepositoriesMock = new Mock<IItemRepositories>();
        itemRepositoriesMock.Setup(x => x.GetItem(It.IsAny<Guid>())).ReturnsAsync((Item?)null);         
        var handler = new UpdateItemCommandHandler(mapperMock.Object, itemRepositoriesMock.Object);
        var command = new UpdateItemCommand();
        await Assert.ThrowsAsync<NullReferenceException>(() => handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WhenItemExists_ShouldCallMapper()
    {
        var mapperMock = new Mock<IMapper>();
        var itemRepositoriesMock = new Mock<IItemRepositories>();
        
        itemRepositoriesMock.Setup(x => x.GetItem(It.IsAny<Guid>())).ReturnsAsync(new Item());                                                                                                                                                                                                                           
        mapperMock.Setup(x=>x.Map(It.IsAny<UpdateItemCommand>(), It.IsAny<Item>()));
        
        var handler = new UpdateItemCommandHandler(mapperMock.Object, itemRepositoriesMock.Object);
        var command = new UpdateItemCommand();
        await handler.Handle(command, CancellationToken.None);
        mapperMock.Verify(x => x.Map(It.IsAny<UpdateItemCommand>(), It.IsAny<Item>()), Times.Once);
    }

    [Fact]
    public async Task Handle_WhenItemExists_ShouldCallGetItemWithCorrectId()
    {
        var specificId = Guid.NewGuid();
        var mapperMock = new Mock<IMapper>();
        var itemRepositoriesMock = new Mock<IItemRepositories>();

        itemRepositoriesMock.Setup(x => x.GetItem(It.IsAny<Guid>())).ReturnsAsync(new Item());
        mapperMock.Setup(x => x.Map(It.IsAny<UpdateItemCommand>(), It.IsAny<Item>()));
        var handler = new UpdateItemCommandHandler(mapperMock.Object, itemRepositoriesMock.Object);
        var command = new UpdateItemCommand{ItemId = specificId};
        await handler.Handle(command, CancellationToken.None);
        
        itemRepositoriesMock.Verify(x=>x.GetItem(specificId), Times.Once);
    }
}