using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetUser;

public class GetUserQuery : IRequest<UserDto>
{
    public Guid UserId { get; set; }
}