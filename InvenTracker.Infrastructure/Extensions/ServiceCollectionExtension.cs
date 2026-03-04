using InvenTracker.Domain.Interfaces;
using InvenTracker.Infrastructure.Repositories;
using InvenTracker.Infrastructure.Seeders;
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
        services.AddScoped<IWardrobeRepositories, WardrobeRepositories>();
        services.AddScoped<IDrawerRepositories, DrawerRepositories>();
        services.AddScoped<IItemRepositories, ItemRepositories>();
        services.AddScoped<IUserRepositories, UserRepositories>();
        services.AddScoped<IPartitionRepositories, PartitionRepositories>();
        services.AddScoped<IItemPartitionRepositories, ItemPartitionRepositories>();

        services.AddScoped<InvenTrackerSeeder>();
    }
}