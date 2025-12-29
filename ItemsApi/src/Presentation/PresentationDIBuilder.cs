using Domain.Interfaces.Clients;
using Infrastructure.Client;
using Serilog;
using FluentValidation;
using System.Reflection;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;


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

        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddValidatorsFromAssemblyContaining<Program>();
    }
}