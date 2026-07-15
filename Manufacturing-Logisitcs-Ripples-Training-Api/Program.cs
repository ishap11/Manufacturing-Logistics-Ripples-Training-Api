using Manufacturing_Logisitcs_Ripples_Training_Api.Facade;
using Manufacturing_Logisitcs_Ripples_Training_Api.Models;
using Manufacturing_Logisitcs_Ripples_Training_Api.Repositories;
using Manufacturing_Logisitcs_Ripples_Training_Api.Repositories.Implementation;
using Manufacturing_Logisitcs_Ripples_Training_Api.Services;
using Manufacturing_Logisitcs_Ripples_Training_Api.Services.Implementation;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ManufacturingLogisticsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IReceivingRepository, ReceivingRepository>();
builder.Services.AddScoped<IReceivingService, ReceivingService>();
builder.Services.AddDbContext<ManufacturingLogisticsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<
    IDispatchRepository,
    DispatchRepository>();

builder.Services.AddScoped<DispatchService>();

builder.Services.AddScoped<DispatchFacade>();

builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<SupplierFacade>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "http://localhost:4201")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
