using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetPartition;

public class GetPartitionQueryHandler: IRequestHandler<GetPartitionQuery, GetDetailsPartitionsDto>
{
    private readonly IPartitionRepositories _partitionRepository;
    private readonly IMapper _mapper;

    public GetPartitionQueryHandler(IMapper mapper,IPartitionRepositories partitionRepository)
    {
        _mapper = mapper;
        _partitionRepository  = partitionRepository;
    }
    public async Task<GetDetailsPartitionsDto> Handle(GetPartitionQuery request, CancellationToken cancellationToken)
    {
        var partition = await _partitionRepository.GetPartitionById(request.Id);
        if(partition == null) throw new ArgumentNullException(nameof(partition)); 
        return _mapper.Map<GetDetailsPartitionsDto>(partition);
    }
}