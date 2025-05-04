using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProyectoHotel.Models;
using ProyectoHotel.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ProyectoHotel.Models.DbContextBeachHotel>();

//Configurar el Servicio ORM Entity Framework Core
builder.Services.AddDbContext<DbContextBeachHotel>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("StringConexion")));

//Configuración del Servicio JWT
builder.Services.AddScoped<IAutorizacionServices, AutorizacionServices>();

//Se toma la llave para el token
var key = builder.Configuration.GetValue<string>("JwtSettings:Key");
var keyBytes = Encoding.ASCII.GetBytes(key);

builder.Services.AddAuthentication(
 config =>
 {
     config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
     config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
 }).AddJwtBearer(
    config => {
        config.RequireHttpsMetadata = false;
        config.SaveToken = true;
        config.TokenValidationParameters =
        new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();//Directiva autenticacion

app.UseAuthorization();


app.MapControllers();

app.Run();
