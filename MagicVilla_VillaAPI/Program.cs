using MagicVilla_Repository;
using MagicVilla_Repository.Implementations;
using MagicVilla_Repository.Interfaces;
using MagicVilla_Service.Implementations;
using MagicVilla_Service.Interfaces;
using MagicVilla_VillaAPI.Logging;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


//Log.Logger = new LoggerConfiguration().MinimumLevel.Information()
//    .WriteTo.File("log/villasLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();

//builder.Host.UseSerilog();

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILogging, Logging>();

//Inject Repository
builder.Services.AddScoped<IVillaRepository, VillaRepository>();

//Inject Services
builder.Services.AddScoped<IVillaService, VillaService>();

//Add Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
