using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.RegisterCommand;

public class RegisterCommandHandler: IRequestHandler<RegisterCommand, Unit>
{
    private readonly IUserRepositories _userRepository;
    private readonly IMapper _mapper;

    public RegisterCommandHandler(IUserRepositories userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }


    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = _mapper.Map<User>(request);
        await _userRepository.CreateUser(user);

        return Unit.Value;
    }
}