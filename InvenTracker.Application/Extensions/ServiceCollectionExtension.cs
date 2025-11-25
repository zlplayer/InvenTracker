using InvenTracker.Application.Interfaces;
using InvenTracker.Application.Mappings;
using InvenTracker.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InvenTracker.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddProfile<InvenTrackerMappingProfile>());
        services.AddScoped<ICompanyService, CompanyService>();
    }

}