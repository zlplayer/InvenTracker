using AutoMapper;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateItem;

public class UpdateItemCommandHandler:IRequestHandler<UpdateItemCommand>
{
    private readonly IMapper _mapper;
    private readonly IItemRepositories _itemRepositories;

    public UpdateItemCommandHandler(IMapper mapper, IItemRepositories itemRepositories)
    {
        _mapper = mapper;
        _itemRepositories= itemRepositories;
    }
    public async Task Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _itemRepositories.GetItem(request.ItemId);
        if(item == null) throw new NullReferenceException("Item not found");
        _mapper.Map(request, item);
        await _itemRepositories.UpdateItem(item);
    }
}