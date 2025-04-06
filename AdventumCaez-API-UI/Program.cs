using DotNetEnv;
using AdventumCaez_API_BL;

var builder = WebApplication.CreateBuilder(args);

Env.Load(); // Cargar variables del archivo .env

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("La cadena de conexión no está definida en las variables de entorno.");

builder.Services.AddBusinessLayer(connectionString);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
