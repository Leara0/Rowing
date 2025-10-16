using System.Text.Json.Serialization;
using Rowing.Application.CommonErrors.CommandServices;
using Rowing.Application.CommonErrors.QueryServices;
using Rowing.Application.InjuryPreventionUseCases;
using Rowing.Application.Interfaces;
using Rowing.Application.StrokePhase;
using Rowing.Infrastructure.Connection;
using Rowing.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//add database connection factory 
builder.Services.AddSingleton<IDbConnectionFactory>(provider =>
    new MySqlConnectionFactory(builder.Configuration.GetConnectionString("rowing")));

//repository registration
builder.Services.AddScoped<IStrokePhaseRepository, StrokePhaseRepository>();
builder.Services.AddScoped<IStrokePhaseService, StrokePhaseService>();
builder.Services.AddScoped<IInjuryPreventionRepository, InjuryPreventionRepository>();
builder.Services.AddScoped<IInjuryPreventionCommandService, InjuryPreventionCommandService>();
builder.Services.AddScoped<IInjuryPreventionQueryService, InjuryPreventionQueryService>();
builder.Services.AddScoped<ICommonErrorRepository, CommonErrorRepository>();
builder.Services.AddScoped<ICommonErrorQueryService, CommonErrorQueryService>();
builder.Services.AddScoped<ICommonErrorCommandService, CommonErrorCommandService>();
builder.Services.AddScoped<ITechniqueDrillRepository, TechniqueDrillRepository>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}