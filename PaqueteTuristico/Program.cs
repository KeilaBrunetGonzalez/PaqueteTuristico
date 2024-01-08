using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PaqueteTuristico;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using PaqueteTuristico.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

// Conecction to DB
builder.Services.AddDbContext<conocubaContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//Configuration of identity
builder.Services.AddIdentityCore<UserApp>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<conocubaContext>();

//Configuration of JWT
builder.Services.AddHttpContextAccessor().
    AddAuthorization().
    AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// Add services to the container.
builder.Services
    .AddControllers()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
builder.Services.AddCustomServices();
builder.Services.AddDataProtection();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Configuración de contraseña
    options.Password.RequireDigit = true; // Requiere números
    options.Password.RequiredLength = 6; // Longitud mínima de 6 caracteres
    options.Password.RequireNonAlphanumeric = false; // No requiere símbolos especiales
    options.Password.RequireUppercase = false; // No requiere mayúsculas
    options.Password.RequireLowercase = true; // Requiere minúsculas
    options.Password.RequiredUniqueChars = 1; // Al menos 1 caracter único

   
});

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//este codigo se ejecuta al iniciar la api para que se creen los datos en la bd
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var myServices = services.GetRequiredService<InitializationServices>();
        await myServices.CreateRoles();
        await myServices.CreateUsers();
        await myServices.CreateProvinces();
        await myServices.createDataHotels();
        await myServices.createRooms();
        await myServices.crateMeals();
        await myServices.crateActivities();
        await myServices.crateVehicles();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:9000"));

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
