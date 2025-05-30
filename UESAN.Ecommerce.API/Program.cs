using Microsoft.EntityFrameworkCore;
using UESAN.Ecommerce.CORE.Core.Interfaces;
using UESAN.Ecommerce.CORE.Infrastructure.Data;
using UESAN.Ecommerce.CORE.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Referenciamos con la cadena de conexion del Core y la API.
var _configuration = builder.Configuration;

var connectionString = _configuration
                        .GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(connectionString));

// TODO: Add interfaces -----
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();



builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
