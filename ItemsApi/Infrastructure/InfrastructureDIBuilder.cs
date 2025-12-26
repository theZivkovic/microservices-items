using Domain.Interfaces;
using Domain.Interfaces.Clients;
using Domain.Interfaces.Repositories;
using Infrastructure.Client;
using Infrastructure.Postgres;
using Infrastructure.Postgres.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public static class InfrastructureDIBuilder
{
    public static void Build(WebApplicationBuilder builder)
    {

        builder.Services.AddDbContext<ItemsDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetSection("AppSettings:Database").ToNpSqlConnectionString()));
        builder.Services.AddScoped<IIdGenerator<string>, UuidIdGenerator>();

        builder.Services.AddScoped<IItemsRepository, ItemsRepository>();
        builder.Services.AddScoped<IAuditLogClient, AuditLogClient>();
    }
}