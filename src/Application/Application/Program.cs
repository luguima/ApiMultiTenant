using Application.Data.Context;
using Application.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseContentRoot(Directory.GetCurrentDirectory());
builder.Configuration.AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ApplicationContext>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

    var httpContext = provider.GetService<IHttpContextAccessor>()?.HttpContext;
    var tenantId = httpContext?.GetTenantId();

    var connectionString = builder.Configuration.GetConnectionString("custom").Replace("_DATABASE_", tenantId);

    optionsBuilder
        .UseSqlServer(connectionString)
        .LogTo(Console.WriteLine)
        .EnableSensitiveDataLogging();

    return new ApplicationContext(optionsBuilder.Options);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
