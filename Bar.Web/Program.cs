using Bar.Infraestructure.Repositories;
using Bar.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bar.Infraestructure.Context;
using AutoMapper;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllersWithViews();

// Agregar Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bar API", Version = "v1" });
});

// Registrar AutoMapper
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(Program));

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

// Configurar el pipeline de solicitudes HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Agregar Swagger al pipeline de solicitudes
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bar API V1");
    c.RoutePrefix = string.Empty; // Esto hace que Swagger UI esté en la raíz
});

app.Run();
