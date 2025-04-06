// En la capa UI (Web API)
using DotNetEnv; // Para cargar el archivo .env
using AdventumCaez_API_DAL; // 
using AdventumCaez_API_BL; // 
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cargar las variables de entorno del archivo .env
Env.Load();

// Obtener la cadena de conexión desde las variables de entorno
var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

// Configurar la base de datos con Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)); // Usamos la cadena de conexión

// Inyectar los servicios de la BL
builder.Services.AddScoped<IDataService, DataService>();

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
