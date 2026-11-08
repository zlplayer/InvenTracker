using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InvenTracker.Application.InvenTracker.Commands.CreateItem;

public class CreateItemCommandHandler: IRequestHandler<CreateItemCommand>
{
    private readonly IMapper _mapper;
    private readonly IItemRepositories _itemRepositories;
    private readonly ILogger<CreateItemCommandHandler> _logger;

    public CreateItemCommandHandler(IMapper mapper, IItemRepositories itemRepositories, ILogger<CreateItemCommandHandler> logger)
    {
        _mapper = mapper;
        _itemRepositories= itemRepositories;
        _logger = logger;
    }
    public async Task Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Item>(request);
        await _itemRepositories.CreateItem(item);
        _logger.LogInformation("Item {Id} created",  item.Id);
    }
}