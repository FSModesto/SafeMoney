using Application.AutoMapper;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using SafeMoneyAPI.Configurations;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Configuração do appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");

var connectionString = builder.Configuration.GetConnectionString("UsuarioConnection");
builder.Services.AddDbContext<SafeMoneyContext>(opt => opt.UseSqlServer(connectionString));

// Configurações customizadas
builder.Services.AddAutoMapperSetup();
builder.Services.AddRepositories();
builder.Services.AddHandlers();
builder.Services.AddServices();
builder.Services.AddValidators();
builder.Services.AddAuthenticationSetup(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenSetup();

var key = Encoding.ASCII.GetBytes(builder.Configuration["SecretKey:PrivateKey"]);

//Configuração AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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
app.Run();