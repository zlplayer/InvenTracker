using AutoMapper;
using FluentAssertions;
using InvenTracker.Application.Dtos;
using InvenTracker.Application.InvenTracker.Queries.GetItem;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Exceptions;
using InvenTracker.Domain.Interfaces;
using Moq;
using Xunit;

namespace InvenTracker.Tests.Application;

public class GetItemQueryHandlerTests
{
    [Fact]
    public async Task Handle_WhenItemExists_ShouldReturnMappedDto()
    {
        var mapperMock = new Mock<IMapper>();
        var itemRepositories = new Mock<IItemRepositories>();
        var item = new Item { Id = Guid.NewGuid(), Name = "Test" };
        
        itemRepositories.Setup(x => x.GetItem(It.IsAny<Guid>())).ReturnsAsync(item);
        mapperMock.Setup(m => m.Map<GetDetailsItemDto>(It.IsAny<Item>())).Returns(new GetDetailsItemDto());
        
        var handler = new GetItemQueryHandler( mapperMock.Object, itemRepositories.Object);
        var command = new GetItemQuery();
        
        var result = await handler.Handle(command, CancellationToken.None);
        
        mapperMock.Verify(m => m.Map<GetDetailsItemDto>(It.IsAny<Item>()), Times.Once);
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task Handle_WhenItemNotFound_ShouldReturnNull()
    {
        var mapperMock = new Mock<IMapper>();
        var itemRepositories = new Mock<IItemRepositories>();
        
        itemRepositories.Setup(x=>x.GetItem(It.IsAny<Guid>())).ReturnsAsync((Item?) null);
        
        var handler = new GetItemQueryHandler( mapperMock.Object, itemRepositories.Object);
        var command = new GetItemQuery();

        await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(command, CancellationToken.None));
    }
}