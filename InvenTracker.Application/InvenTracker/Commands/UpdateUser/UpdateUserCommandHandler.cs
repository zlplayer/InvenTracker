using AutoMapper;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateUser;

public class UpdateUserCommandHandler: IRequestHandler<UpdateUserCommand>
{
    private readonly IMapper _mapper;
    private readonly IUserRepositories _userRepositories;

    public UpdateUserCommandHandler(IMapper mapper, IUserRepositories userRepositories)
    {
        _mapper=mapper;
        _userRepositories = userRepositories;
    }
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user= await _userRepositories.GetUser(request.UserId);
        if (user == null) throw new NullReferenceException("User not found");
        _mapper.Map(request, user);
        await _userRepositories.UpdateUser(user);
    }
}