using InvenTracker.Application.InvenTracker.Commands.CreateCompany;
using InvenTracker.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace InvenTracker.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddProfile<InvenTrackerMappingProfile>());
        services.AddMediatR(cfg =>
              cfg.RegisterServicesFromAssemblyContaining<CreateCompanyCommand>()
          );

    }

}