using AutoMapper;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateWardrobe;

public class CreateWardrobeCommandHandler:IRequestHandler<CreateWardrobeCommand>
{

    public CreateWardrobeCommandHandler(IMapper mapper, IWardrobeRepositories wardrobeRepositories, ICompanyRepositories companyRepositories)
    {
        
    }
    
    public Task Handle(CreateWardrobeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}