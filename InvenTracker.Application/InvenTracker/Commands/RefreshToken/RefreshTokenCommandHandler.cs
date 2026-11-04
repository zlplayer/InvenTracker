using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Application.Iterfaces;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.RefreshToken;

public class RefreshTokenCommandHandler:IRequestHandler<RefreshTokenCommand, string>
{
    private readonly IRefreshTokenRepositories _refreshTokenRepositories;
    private readonly IMapper _mapper;
    private readonly IJwtAuth _jwtService;
    private readonly IUserRepositories _userRepository;

    public RefreshTokenCommandHandler(IRefreshTokenRepositories refreshTokenRepositories, IMapper mapper, IJwtAuth jwtService, IUserRepositories userRepository)
    {
        _refreshTokenRepositories= refreshTokenRepositories;
        _mapper=mapper;
        _jwtService = jwtService;
        _userRepository = userRepository;
    }
    public async Task<string> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await _refreshTokenRepositories.FindByRefreshToken(request.RefreshToken,request.UserId);
        
        if (refreshToken == null) 
            throw new  InvalidOperationException("RefreshToken not exist");
        
        if(refreshToken.IsRevoked || refreshToken.ExpiresAt <= DateTime.UtcNow)
            throw new  InvalidOperationException("RefreshToken is expired");
        
        var user = await _userRepository.GetUser(request.UserId);
        
        if (user == null) 
            throw new  InvalidOperationException("User not exist");

        var userDto = _mapper.Map<UserDto>(user);
        
        return _jwtService.GenerateToken(userDto, 2);
    }
}