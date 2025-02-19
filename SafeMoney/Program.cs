using Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using SafeMoneyAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

//Configuração do appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");

var connectionString = builder.Configuration.GetConnectionString("UsuarioConnection");
builder.Services.AddDbContext<SafeMoneyContext>(opt => opt.UseSqlServer(connectionString));

// Configurações customizadas
builder.Services.AddAuthorization();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenSetup();

var app = builder.Build();

// Configuração de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseSwaggerUI(c => { c.SwaggerEndpoint("./v1/swagger.json", "SafeMoneyAPI"); });
app.UseSwaggerUI(static options => { options.SwaggerEndpoint("/openapi/v1.json", "SafeMoneyAPI"); });

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();