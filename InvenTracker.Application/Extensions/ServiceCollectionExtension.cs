using System.Text;
using FluentValidation;
using InvenTracker.Application.Auth;
using InvenTracker.Application.Behaviors;
using InvenTracker.Application.InvenTracker.Commands.CreateCompany;
using InvenTracker.Application.InvenTracker.Commands.RegisterCommand;
using InvenTracker.Application.Iterfaces;
using InvenTracker.Application.Mappings;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace InvenTracker.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(cfg => cfg.AddProfile<InvenTrackerMappingProfile>());

        services.AddMediatR(cfg =>
              cfg.RegisterServicesFromAssemblyContaining<CreateCompanyCommand>()
          );

        services.AddValidatorsFromAssemblyContaining<RegisterCommandValidator>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddScoped<IJwtAuth, JwtAuth>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
    }
}