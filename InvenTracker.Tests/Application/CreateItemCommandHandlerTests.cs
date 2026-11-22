using AutoMapper;
using InvenTracker.Application.InvenTracker.Commands.CreateItem;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace InvenTracker.Tests.Application;

public class CreateItemCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCallCreateItem_Once()
    {
        //Arrange
        var mockIMapper = new Mock<IMapper>();
        var mockIItemRepositories = new Mock<IItemRepositories>();
        var mockILogger = new Mock<ILogger<CreateItemCommandHandler>>();

        mockIMapper.Setup(x => x.Map<Item>(It.IsAny<CreateItemCommand>())).Returns(new Item());
        
        var handler = new CreateItemCommandHandler(mockIMapper.Object, mockIItemRepositories.Object , mockILogger.Object);
        var command = new CreateItemCommand();
        
        //Act
        await handler.Handle(command, CancellationToken.None);
        
        //Assert
        
        mockIItemRepositories.Verify(x => x.CreateItem(It.IsAny<Item>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldMapCommandToItem_BeforeCallingRepository()
    {
        var mockIMapper = new Mock<IMapper>();
        var mockIItemRepositories = new Mock<IItemRepositories>();
        var mockILogger = new Mock<ILogger<CreateItemCommandHandler>>();
        
        mockIMapper.Setup(x => x.Map<Item>(It.IsAny<CreateItemCommand>())).Returns(new Item());
        
        var handler = new CreateItemCommandHandler(mockIMapper.Object, mockIItemRepositories.Object, mockILogger.Object);
        var command = new CreateItemCommand();
        
        await handler.Handle(command, CancellationToken.None);
        
        mockIMapper.Verify(x => x.Map<Item>(It.IsAny<CreateItemCommand>()), Times.Once);
    }
}