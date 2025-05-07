using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using webapi_agende_mais.src.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = $"Server={Environment.GetEnvironmentVariable("MYSQL_HOST")};" +
                       $"Port={Environment.GetEnvironmentVariable("MYSQL_PORT")};" +
                       $"Database={Environment.GetEnvironmentVariable("MYSQL_DATABASE")};" +
                       $"User={Environment.GetEnvironmentVariable("MYSQL_USER")};" +
                       $"Password={Environment.GetEnvironmentVariable("MYSQL_PASSWORD")};" +
                       "SslMode=Required;TrustServerCertificate=True;";

// Teste de conexão
try
{
    using var connection = new MySqlConnection(connectionString);
    connection.Open();
    Console.WriteLine("Conexão com o banco de dados bem-sucedida!");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
    return; 
}

// Configuração do DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 32)))
           .LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "AgendeMais API",
        Version = "v1",
        Description = "API de agendamentos da plataforma AgendeMais.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Rennan Barros",
            Email = "rennan_sbarros@hotmail.com",
            Url = new Uri("https://www.linkedin.com/in/rennan-candido1") 
        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "Use sob licença XYZ",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AgendeMais API v1");
    c.RoutePrefix = string.Empty; 
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
