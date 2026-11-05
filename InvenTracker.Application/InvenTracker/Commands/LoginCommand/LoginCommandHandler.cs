using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Application.Iterfaces;
using InvenTracker.Domain.Exceptions;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.LoginCommand;

public class LoginCommandHandler: IRequestHandler<LoginCommand, AuthResponseDto>
{
    private readonly IUserRepositories _userRepository;
    private readonly IJwtAuth _jwtService;
    private readonly IMapper _mapper;
    private readonly IRefreshTokenRepositories _refreshTokenRepository;

    public LoginCommandHandler(IUserRepositories userRepository, 
        IJwtAuth jwtService,
        IMapper mapper,
        IRefreshTokenRepositories  refreshTokenRepository
        )
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
        _mapper = mapper;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByUsername(request.Username);
        
        if (user == null)
        {
            throw new UnauthorizedException("Nieprawidłowa nazwa użytkownika lub hasło");
        }

        var isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

        if (!isPasswordValid)
        {
            throw new UnauthorizedException("Nieprawidłowa nazwa użytkownika lub hasło");
        }
        
        var userDto = _mapper.Map<UserDto>(user);
        
        var token = _jwtService.GenerateToken(userDto, 2);
        
        var refreshToken = _jwtService.GenerateToken(userDto, 744);

        var refreshTokenDto = new CreateRefreshTokenDto
        {
            Token = refreshToken,
            UserId =  user.Id,
            IsRevoked=false,
            ExpiresAt = DateTime.UtcNow.AddHours(744)
        };

        var refreshTokenMap = _mapper.Map<Domain.Entities.RefreshToken>(refreshTokenDto);
        
        await _refreshTokenRepository.CreateRefreshToken(refreshTokenMap);
        
        return new AuthResponseDto
        {
            RefreshToken = refreshToken,
            Token = token,
            User = userDto
        };
    }
}