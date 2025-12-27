using Domain.Interfaces.Clients;
using Infrastructure.Client;
using Serilog;

namespace Presentation;

public static class PresentationDIBuilder
{
    public static void Build(WebApplicationBuilder builder)
    {
        builder.Services.Configure<AppSettings>(
            builder.Configuration.GetSection(nameof(AppSettings))
        );

        builder.Services.AddOpenApi();
        builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
        {
            loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
        });
    }
}