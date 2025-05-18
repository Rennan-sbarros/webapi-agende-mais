using Microsoft.EntityFrameworkCore;
using webapi_agende_mais.src.Data;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ContentRootPath = Directory.GetCurrentDirectory(),
    Args = args
});

builder.Configuration
    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "src"))
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
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

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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
