using InvenTracker.Application.Iterfaces;
using InvenTracker.Application.Settings;
using InvenTracker.Domain.Interfaces;
using InvenTracker.Infrastructure.Repositories;
using InvenTracker.Infrastructure.Seeders;
using InvenTracker.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuestPDF.Infrastructure;

namespace InvenTracker.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        QuestPDF.Settings.License = LicenseType.Community;

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
        services.AddScoped<IItemHistoryRepositories, ItemHistoryRepositories>();
        services.AddScoped<IWardrobeResponsibleRepositories, WardrobeResponsibleRepositories>();

        services.AddScoped<InvenTrackerSeeder>();
        services.AddScoped<IPdfService, PdfService>();
        
        services.Configure<EmailSettings>(configuration.GetSection("Email"));
        //  - services.Configure<EmailSettings>(...) - mówi .NET "weź sekcję "Email" z appsettings.json i mapuj ją na klasę EmailSettings". To właśnie sprawia że IOptions<EmailSettings> działa w konstruktorze.
        services.AddScoped<IEmailService, EmailService>(); 
    }
}