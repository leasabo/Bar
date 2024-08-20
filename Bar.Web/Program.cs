using Bar.Infraestructure.Repositories;
using Bar.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bar.Infraestructure.Context;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrar AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 

// Conexión a la BBDD
var connectionString = builder.Configuration.GetConnectionString("Connection");

// Inyección de dependencias para el AppDbContext
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString)
);

// Registrar Repositorios
builder.Services.AddScoped<IWaiterRepository, WaiterRepository>();
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<IReceiptRepository, ReceiptRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
