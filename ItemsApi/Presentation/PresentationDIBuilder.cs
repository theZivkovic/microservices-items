using Domain.Interfaces.Clients;
using Infrastructure.Client;

namespace Presentation;

public static class PresentationDIBuilder
{
    public static void Build(WebApplicationBuilder builder)
    {
        builder.Services.Configure<AppSettings>(
            builder.Configuration.GetSection(nameof(AppSettings))
        );

        builder.Services.AddHttpClient<IAuditLogClient, AuditLogClient>(client =>
        {
            client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("AppSettings:AuditLogService:BaseUrl")!);
        });

        builder.Services.AddOpenApi();
    }
}