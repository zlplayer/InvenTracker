using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetAllUsers;

public class GetAllUsersQueryHandler:IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    private readonly IUserRepositories _userRepositories;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IUserRepositories  userRepositories, IMapper mapper)
    {
        _userRepositories = userRepositories;
        _mapper = mapper;
        
    }
    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepositories.GetUsers();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }
}