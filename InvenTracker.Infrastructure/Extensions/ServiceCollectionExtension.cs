using InvenTracker.Domain.Interfaces;
using InvenTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvenTracker.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InvenTrackerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("InvenTrackerDbContext")));

        services.AddScoped<ICompanyRepositories, CompanyRepositories>();
        services.AddScoped<IDepartmentRepositories, DepartmentRepositories>();
    }
}