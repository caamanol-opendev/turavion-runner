using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("PasarelaPagos")),
            ServiceLifetime.Transient);

        services.AddTransient<ICommandSqlDB<SolicitudPagoEntity>, CommandSqlDB<SolicitudPagoEntity>>();
        services.AddTransient<IQuerySqlDB<SolicitudPagoEntity>, QuerySqlDB<SolicitudPagoEntity>>();
        services.AddTransient<ISendMail, SendMail>();
        services.AddTransient<ISolicitudPagoRepository, SolicitudPagoRepository>();

        return services;
    }

}