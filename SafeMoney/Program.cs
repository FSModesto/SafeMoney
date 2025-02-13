using SafeMoneyAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

//Configura��o do appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");

// Configura��es customizadas
builder.Services.AddAuthorization();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenSetup();

var app = builder.Build();

// Configura��o de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();