using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PerthLeadership.Application.Interfaces;
using PerthLeadership.Application.Services;
using PerthLeadership.Application.Validators;
using PerthLeadership.Domain.Interfaces;
using PerthLeadership.Infrastructure.Data;
using PerthLeadership.Infrastructure.Repositories;

namespace PerthLeadership.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register service interfaces to implementations
        services.AddScoped<ISubjectService, SubjectService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<ICouponService, CouponService>();
        services.AddScoped<IProgramService, ProgramService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IAssessmentService, AssessmentService>();
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IDocumentService, DocumentService>();

        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register DbContext
        services.AddDbContext<PerthLeadershipDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(PerthLeadershipDbContext).Assembly.FullName);
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null);
                }));

        // Register generic repository and unit of work
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    public static IServiceCollection AddValidationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateSubjectRequestValidator>();
        return services;
    }
}
