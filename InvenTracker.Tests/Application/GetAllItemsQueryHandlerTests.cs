using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Application.InvenTracker.Queries.GetAllItems;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Moq;
using Xunit;

namespace InvenTracker.Tests.Application;

public class GetAllItemsQueryHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnMappedDtos()
    {
        var mapperMock = new Mock<IMapper>();
        var itemRepositories = new Mock<IItemRepositories>();

        itemRepositories.Setup(x => x.GetItems()).ReturnsAsync(new List<Item>());
        mapperMock.Setup(x => x.Map<IEnumerable<GetAllItemDto>>(It.IsAny<IEnumerable<Item>>())).Returns(new List<GetAllItemDto>());
        
        var handler = new GetAllItemsQueryHandler(mapperMock.Object, itemRepositories.Object);
        var command = new GetAllItemsQuery();
        var result = await handler.Handle(command, CancellationToken.None);
        
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Handle_WhenNoItems_ShouldReturnEmptyList()
    {
        var mapperMock = new Mock<IMapper>();
        var itemRepositories = new Mock<IItemRepositories>();
        
        itemRepositories.Setup(x => x.GetItems()).ReturnsAsync(new List<Item>());
        mapperMock.Setup(x => x.Map<IEnumerable<GetAllItemDto>>(It.IsAny<IEnumerable<Item>>())).Returns(new List<GetAllItemDto>());
        
        var handler = new GetAllItemsQueryHandler(mapperMock.Object, itemRepositories.Object);
        var command = new GetAllItemsQuery();
        var result = await handler.Handle(command, CancellationToken.None);
        
        Assert.Empty(result);
    }

    [Fact]
    public async Task Handle_ShouldCallGetItemsOnce()
    {
        var mapperMock = new Mock<IMapper>();
        var itemRepositories = new Mock<IItemRepositories>();
        itemRepositories.Setup(x => x.GetItems()).ReturnsAsync(new List<Item>());
        
        var handler = new GetAllItemsQueryHandler(mapperMock.Object, itemRepositories.Object);
        var command = new GetAllItemsQuery(); 
        await handler.Handle(command, CancellationToken.None);
        
        itemRepositories.Verify(x => x.GetItems(), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldCallMapperWithItemsList()
    {
        var mapperMock = new Mock<IMapper>();
        var itemRepositories = new Mock<IItemRepositories>();
        
        itemRepositories.Setup(x => x.GetItems()).ReturnsAsync(new List<Item>());
        mapperMock.Setup(x => x.Map<IEnumerable<GetAllItemDto>>(It.IsAny<IEnumerable<Item>>())).Returns(new List<GetAllItemDto>());
        
        var handler = new GetAllItemsQueryHandler(mapperMock.Object, itemRepositories.Object);
        var command = new GetAllItemsQuery();
        await handler.Handle(command, CancellationToken.None);
        
        mapperMock.Verify(x => x.Map<IEnumerable<GetAllItemDto>>(It.IsAny<IEnumerable<Item>>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldReturnCorrectCount()
    {
        var mapperMock = new Mock<IMapper>();
        var itemRepositories = new Mock<IItemRepositories>();
        
        itemRepositories.Setup(x => x.GetItems()).ReturnsAsync(new List<Item>{new Item(), new Item(), new Item()});
        mapperMock.Setup(x => x.Map<IEnumerable<GetAllItemDto>>(It.IsAny<IEnumerable<Item>>())).Returns(new List<GetAllItemDto> { new GetAllItemDto(), new GetAllItemDto(), new GetAllItemDto() }); 
        
        var handler = new GetAllItemsQueryHandler(mapperMock.Object, itemRepositories.Object);
        var command = new GetAllItemsQuery();
        var result = await handler.Handle(command, CancellationToken.None);
        
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());
    }
}