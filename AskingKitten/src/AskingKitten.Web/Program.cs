using AskingKitten.Infrastructure.Postgresql;
using AskingKitten.Infrastructure.Postgresql.Seeders;
using AskingKitten.Web;
using AskingKitten.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProgramDependencies(builder.Configuration);

var app = builder.Build();

app.UseExceptionMiddleware();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "AskingKitten API"));
}

app.MapControllers();

using var scope = app.Services.CreateScope();

var seeders = scope.ServiceProvider.GetServices<ISeeder>();

foreach (var seeder in seeders)
{
    await seeder.SeedAsync();
}

app.Run();