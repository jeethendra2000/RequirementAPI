using Microsoft.EntityFrameworkCore;
using RequirementAPI.Data;
using RequirementAPI.Middleware;
using RequirementAPI.Repositories;
using RequirementAPI.Repositories.Interfaces;
using RequirementAPI.Services;
using RequirementAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register controllers.
builder.Services.AddControllers();

// Register EF Core In-Memory database.
//builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("RequirementsDatabase"));

builder.Services.AddSingleton<IRequirementRepository, InMemoryRequirementRepository>();

// Register application services.
builder.Services.AddScoped<IRequirementService, RequirementService>();

// Register API documentation services.
builder.Services.AddEndpointsApiExplorer(); // Required for Swagger to find your endpoints
builder.Services.AddSwaggerGen();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var app = builder.Build();


// Exception handler must be early in the pipeline.
app.UseMiddleware<GlobalExceptionMiddleware>();

// Log incoming HTTP requests.
app.UseMiddleware<LoggingMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();   // Serves the documentation as a JSON endpoint
    app.UseSwaggerUI(); // Serves the visual web UI page
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
