using Microsoft.EntityFrameworkCore;
using VisiotechSecurityAPI.Infra;
using VisiotechSecurityAPI.Services;
using VisiotechSecurityAPI.Domain.Interfaces;
using VisiotechSecurityAPI.Domain.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura acceso a banco de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura los servicios
builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
builder.Services.AddScoped<IManagerService, ManagerService>();

builder.Services.AddScoped<IGrapeRepository, GrapeRepository>();
builder.Services.AddScoped<IGrapeService, GrapeService>();

builder.Services.AddScoped<IVineyardReposiroty, VineyardRepository>();
builder.Services.AddScoped<IVineyardService, VineyardService>();

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
