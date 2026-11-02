using AutoMapper;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteCompany;

public class DeleteCompanyCommandHandler:IRequestHandler<DeleteCompanyCommand>
{
    private readonly ICompanyRepositories _companyRepositories;
    private readonly IWardrobeRepositories _wardrobeRepositories;

    public DeleteCompanyCommandHandler(IMapper mapper, ICompanyRepositories companyRepositories, IWardrobeRepositories wardrobeRepositories)
    {
        _companyRepositories=companyRepositories;
        _wardrobeRepositories=wardrobeRepositories;
    }

    public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyRepositories.GetCompany(request.CompanyId);
        if (company == null) throw new ArgumentNullException(nameof(company));

        // Szafy przypisane bezpośrednio do firmy (bez oddziału) nie są objęte kaskadą
        // Department -> Company / Wardrobe -> Department, bo SQL Server nie pozwala
        // na dwie ścieżki kaskady do tej samej tabeli (Wardrobe -> Company i Wardrobe -> Department -> Company).
        var wardrobes = await _wardrobeRepositories.GetAllWardrobes();
        var directWardrobes = wardrobes.Where(w => w.CompanyId == request.CompanyId && w.DepartmentId == null);
        foreach (var wardrobe in directWardrobes)
        {
            await _wardrobeRepositories.DeleteWardrobe(wardrobe);
        }

        await _companyRepositories.DeleteCompany(company);
    }
}