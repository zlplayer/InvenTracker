using InvenTracker.Application.InvenTracker.Commands.DeleteCompany;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Moq;
using Xunit;

namespace InvenTracker.Tests.Application;

public class DeleteCompanyCommandHandlerTests
{
    [Fact]
    public async Task Handle_WhenCompanyExists_ShouldCallDeleteCompany()
    {
        var companyRepositoriesMap = new Mock<ICompanyRepositories>();
        var wardrobeRepositoriesMap= new Mock<IWardrobeRepositories>();

        var company = new Company
        {
            Id = Guid.NewGuid(),
            Name = "Company",
            AddressId = Guid.NewGuid(),
        };

        companyRepositoriesMap.Setup(x => x.GetCompany(company.Id)).ReturnsAsync(company);
        wardrobeRepositoriesMap.Setup(x=>x.GetAllWardrobes()).ReturnsAsync(new List<Wardrobe>());
        
        companyRepositoriesMap.Setup(x=>x.DeleteCompany(company));
        
        var handler = new DeleteCompanyCommandHandler(companyRepositoriesMap.Object,wardrobeRepositoriesMap.Object);
        var command = new DeleteCompanyCommand { CompanyId= company.Id };
        await handler.Handle(command, CancellationToken.None);
        
        companyRepositoriesMap.Verify(x=>x.GetCompany(company.Id), Times.Once);
        wardrobeRepositoriesMap.Verify(x=>x.GetAllWardrobes(), Times.Once);
        companyRepositoriesMap.Verify(x=>x.DeleteCompany(company), Times.Once);
    }

    [Fact]
    public async Task Handle_WhenCompanyNotFound_ShouldThrowArgumentNullException()
    {
        var companyRepositoriesMap = new Mock<ICompanyRepositories>();
        var wardrobeRepositoriesMap= new Mock<IWardrobeRepositories>();
        
        companyRepositoriesMap.Setup(x => x.GetCompany(It.IsAny<Guid>())).ReturnsAsync((Company?)null);        
        var handler = new DeleteCompanyCommandHandler(companyRepositoriesMap.Object,wardrobeRepositoriesMap.Object);
        var command = new DeleteCompanyCommand();
        await Assert.ThrowsAsync<ArgumentNullException>(() => handler.Handle(command, CancellationToken.None));
        
    }

    [Fact]
    public async Task Handle_WhenCompanyHasDirectWardrobes_ShouldDeleteEachWardrobe()
    {
        var companyRepositoriesMap = new Mock<ICompanyRepositories>();
        var wardrobeRepositoriesMap= new Mock<IWardrobeRepositories>();
        var company = new Company
        {
            Id = Guid.NewGuid(),
        };
        var wardrobes = new List<Wardrobe>
        {
            new Wardrobe
            {
                Id = Guid.NewGuid(),
                Name = "Wardrobe",
                CompanyId =  company.Id,
                DepartmentId = null
            },
            new Wardrobe
            {
                Id = Guid.NewGuid(),
                Name = "Wardrobe2",
                CompanyId =  company.Id,
                DepartmentId = null
            },
            new Wardrobe
            {
                Id = Guid.NewGuid(),
                Name = "Wardrobe3",
                CompanyId =  company.Id,
                DepartmentId = Guid.NewGuid()
            }
        };
        companyRepositoriesMap.Setup(x => x.GetCompany(company.Id)).ReturnsAsync(company);
        wardrobeRepositoriesMap.Setup(x => x.GetAllWardrobes()).ReturnsAsync(wardrobes);
        var handler = new DeleteCompanyCommandHandler(companyRepositoriesMap.Object, wardrobeRepositoriesMap.Object);
        var command = new DeleteCompanyCommand{ CompanyId = company.Id };
        await handler.Handle(command, CancellationToken.None);
        
        wardrobeRepositoriesMap.Verify(x=>x.DeleteWardrobe(It.IsAny<Wardrobe>()), Times.Exactly(2));
    }

    [Fact]
    public async Task Handle_WhenCompanyHasNoDirectWardrobes_ShouldNotCallDeleteWardrobe()
    {
        var companyRepositoriesMap = new Mock<ICompanyRepositories>();
        var wardrobeRepositoriesMap= new Mock<IWardrobeRepositories>();
        var company = new Company
        {
            Id = Guid.NewGuid(),
        };
        companyRepositoriesMap.Setup(x => x.GetCompany(company.Id)).ReturnsAsync(company);
        wardrobeRepositoriesMap.Setup(x => x.GetAllWardrobes()).ReturnsAsync(new List<Wardrobe>());
        var handler = new DeleteCompanyCommandHandler(companyRepositoriesMap.Object, wardrobeRepositoriesMap.Object);
        var command = new DeleteCompanyCommand{ CompanyId = company.Id };
        await handler.Handle(command, CancellationToken.None);
        
        wardrobeRepositoriesMap.Verify(x=>x.DeleteWardrobe(It.IsAny<Wardrobe>()), Times.Never);
    }

    [Fact]
    public async Task Handle_WhenWardrobesHaveDepartment_ShouldNotDeleteThem()
    {
        var companyRepositoriesMap = new Mock<ICompanyRepositories>();
        var wardrobeRepositoriesMap= new Mock<IWardrobeRepositories>();
        var company = new Company
        {
            Id = Guid.NewGuid(),
        };
        var wardrobes = new List<Wardrobe>
        {
            new Wardrobe
            {
                Id = Guid.NewGuid(),
                Name = "Wardrobe",
                CompanyId =  company.Id,
                DepartmentId = Guid.NewGuid()
            },
            new Wardrobe
            {
                Id = Guid.NewGuid(),
                Name = "Wardrobe2",
                CompanyId =  company.Id,
                DepartmentId = Guid.NewGuid()
            },
            new Wardrobe
            {
                Id = Guid.NewGuid(),
                Name = "Wardrobe3",
                CompanyId =  company.Id,
                DepartmentId = Guid.NewGuid()
            }
        };
        companyRepositoriesMap.Setup(x => x.GetCompany(company.Id)).ReturnsAsync(company);
        wardrobeRepositoriesMap.Setup(x => x.GetAllWardrobes()).ReturnsAsync(wardrobes);
        var handler = new DeleteCompanyCommandHandler(companyRepositoriesMap.Object, wardrobeRepositoriesMap.Object);
        var command = new DeleteCompanyCommand{ CompanyId = company.Id };
        await handler.Handle(command, CancellationToken.None);
        
        wardrobeRepositoriesMap.Verify(x=>x.DeleteWardrobe(It.IsAny<Wardrobe>()), Times.Never);
    }
}