using ClinicApi.Domain.Entities;
using ClinicApi.Domain.Interfaces;
using ClinicApi.Infrastructure.Data;
using ClinicApi.Infrastructure.Repositories;
using ClinicApi.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(o =>
            o.UseSqlServer(configuration.GetConnectionString("Default")));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IRepository<Appointment>, AppointmentRepository>();

        services.AddScoped<TokenService>();

        return services;
    }
}