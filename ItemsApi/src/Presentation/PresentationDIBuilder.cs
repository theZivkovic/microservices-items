using Domain.Interfaces.Clients;
using Infrastructure.Client;
using Serilog;
using FluentValidation;
using System.Reflection;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;
using Domain;
using Application.UseCases.GetItems;
using Domain.Constants;


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

        builder.Services.AddScoped(provider =>
        {
            var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
            var httpContext = httpContextAccessor.HttpContext;
            if (httpContext?.Items["PagedListRequest"] is PagedListRequestDto request)
            {
                return request;
            }
            return new PagedListRequestDto(PaginationConstants.DefaultPageNumber, PaginationConstants.DefaultPageSize);
        });
        builder.Services.AddHttpContextAccessor(); // Required for IHttpContextAccessor

        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddValidatorsFromAssemblyContaining<Program>();
    }
}