using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateItem;

public class CreateItemCommandHandler: IRequestHandler<CreateItemCommand>
{
    private readonly IMapper _mapper;
    private readonly IItemRepositories _itemRepositories;

    public CreateItemCommandHandler(IMapper mapper, IItemRepositories itemRepositories)
    {
        _mapper = mapper;
        _itemRepositories= itemRepositories;
    }
    public async Task Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Item>(request);
        await _itemRepositories.CreateItem(item);
    }
}