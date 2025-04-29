var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AgendeMais API v1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
