using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Application.InvenTracker.Commands.UpdateCompany;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Moq;
using Xunit;

namespace InvenTracker.Tests.Application;

public class UpdateCompanyCommandHandlerTests
{
    [Fact]
    public async Task Handle_WhenCompanyExists_ShouldCallUpdateCompany()
    {
        var mapperMock = new Mock<IMapper>();
        var companyRepositoriesMock = new Mock<ICompanyRepositories>();

        companyRepositoriesMock.Setup(x => x.GetCompany(It.IsAny<Guid>())).ReturnsAsync(new Company());
        mapperMock.Setup(x=>x.Map(It.IsAny<CreateCompanyDto>(), It.IsAny<Company>()));
        companyRepositoriesMock.Setup(x=>x.UpdateCompany(It.IsAny<Company>()));
        
        var handler = new UpdateCompanyCommandHandler( mapperMock.Object, companyRepositoriesMock.Object);
        var command = new UpdateCompanyCommand();
        await handler.Handle(command, CancellationToken.None);
        
        mapperMock.Verify(x=>x.Map(It.IsAny<CreateCompanyDto>(), It.IsAny<Company>()), Times.Once);
        companyRepositoriesMock.Verify(x=>x.GetCompany(command.CompanyId), Times.Once);
        companyRepositoriesMock.Verify(x=>x.UpdateCompany(It.IsAny<Company>()), Times.Once);
        
    }

    [Fact]
    public async Task Handle_WhenCompanyNotFound_ShouldThrowArgumentNullException()
    {
        var mapperMock = new Mock<IMapper>();
        var companyRepositoriesMock = new Mock<ICompanyRepositories>();
        
        companyRepositoriesMock.Setup(x => x.GetCompany(It.IsAny<Guid>())).ReturnsAsync((Company?)null);
        
        var handler = new UpdateCompanyCommandHandler( mapperMock.Object, companyRepositoriesMock.Object);
        var command = new UpdateCompanyCommand();
        
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await handler.Handle(command, CancellationToken.None));
    }
}