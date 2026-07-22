using ManufacturingLogisticsMVC.Models;
using ManufacturingLogisticsMVC.Repository.StoreProfiles;
using ManufacturingLogisticsMVC.Facade.StoreProfiles;
using ManufacturingLogisticsMVC.Bo.StoreProfiles;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<ManufacturingLogisticsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IStoreProfilesRepository,StoreProfilesRepository>();
builder.Services.AddScoped<StoreProfilesBO>();
builder.Services.AddScoped<StoreProfilesFacade>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors("AllowAngular");
app.UseAuthorization();
app.MapControllers();
app.Run();