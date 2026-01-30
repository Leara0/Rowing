using System.Text.Json.Serialization;
using Rowing.Application.CommonErrors.CommandServices;
using Rowing.Application.CommonErrors.QueryServices;
using Rowing.Application.DrillTechniqueUseCase.CommandServices;
using Rowing.Application.DrillTechniqueUseCase.QueryServices;
using Rowing.Application.InjuryPreventionUseCases;
using Rowing.Application.Interfaces;
using Rowing.Application.StrokePhase;
using Rowing.Application.UseCases.TrainingWorkoutsUseCase.CommandServices;
using Rowing.Application.UseCases.TrainingWorkoutsUseCase.QueryServices;
using Rowing.Infrastructure.Connection;
using Rowing.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCors();

var connectionString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")
                       ?? builder.Configuration.GetConnectionString("rowing");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string not found. Looked for 'AZURE_SQL_CONNECTIONSTRING' and 'rowing'");
}

//add database connection factory 
builder.Services.AddSingleton<IDbConnectionFactory>(provider =>
    new SqlConnectionFactory(connectionString));

//dependency injection
builder.Services.AddScoped<IStrokePhaseRepository, StrokePhaseRepository>();
builder.Services.AddScoped<IStrokePhaseService, StrokePhaseService>();
builder.Services.AddScoped<IInjuryPreventionRepository, InjuryPreventionRepository>();
builder.Services.AddScoped<IInjuryPreventionCommandService, InjuryPreventionCommandService>();
builder.Services.AddScoped<IInjuryPreventionQueryService, InjuryPreventionQueryService>();
builder.Services.AddScoped<ICommonErrorRepository, CommonErrorRepository>();
builder.Services.AddScoped<ICommonErrorQueryService, CommonErrorQueryService>();
builder.Services.AddScoped<ICommonErrorCommandService, CommonErrorCommandService>();
builder.Services.AddScoped<ITechniqueDrillRepository, TechniqueDrillRepository>();
builder.Services.AddScoped<ITechniqueDrillQueryService, TechniqueDrillQueryService>();
builder.Services.AddScoped<ITechniqueDrillCommandService, TechniqueDrillCommandService>();
builder.Services.AddScoped<ITrainingWorkoutQueryService, TrainingWorkoutQueryService>();
builder.Services.AddScoped<ITrainingWorkoutCommandService, TrainingWorkoutCommandService>();


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
app.UseCors(policy =>
{
    policy.AllowAnyOrigin() // any website can call this API
        .AllowAnyMethod()   // allows GET, POST, PUT, DELETE etc
        .AllowAnyHeader();  // allow any header in requests
});


app.MapControllers();
app.Run();
