using DotNetEnv; // Para cargar el archivo .env
using AdventumCaez_API_BL; // Para usar AddBusinessLayer()

var builder = WebApplication.CreateBuilder(args);

// Cargar las variables de entorno del archivo .env
Env.Load();

// Obtener la cadena de conexión desde el entorno
var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

// Usar la capa BL para inyectar todo
builder.Services.AddBusinessLayer(connectionString);

// Servicios generales de ASP.NET Core
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
