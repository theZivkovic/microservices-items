using Infrastructure;
using Presentation;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

PresentationDIBuilder.Build(builder);
InfrastructureDIBuilder.Build(builder);
ApplicationDIBuilder.Build(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseMiddleware<PaginationMiddleware>();
app.UseHttpsRedirection();
app.UseSerilogRequestLogging();

ItemsController.BuildEndpoints(app);

app.Run();