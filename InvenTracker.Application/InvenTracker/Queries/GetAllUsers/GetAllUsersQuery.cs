using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetAllUsers;

public class GetAllUsersQuery: IRequest<IEnumerable<UserDto>>
{
    
}