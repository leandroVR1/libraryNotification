using System;
using System.Text;
using JwtAuthLibrary;
using LuegoPago.Data;
using LuegoPago.Helpers;
using LuegoPago.Services;
using LuegoPago.Services.CuponesRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ExceptionNotification;

var builder = WebApplication.CreateBuilder(args);

// Obtener la clave JWT desde la configuración
var jwtKey = builder.Configuration["Jwt:Key"];

// Registrar JwtAuthManager con la clave JWT
builder.Services.AddSingleton<JwtAuthManager>(sp => new JwtAuthManager(jwtKey));
builder.Services.AddScoped<ICuponRepository, CuponRepository>();
builder.Services.AddSingleton<Utilidades>();

// Registrar SlackExceptionNotifier con la URL del webhook de Slack
builder.Services.AddSingleton<SlackExceptionNotifier>(sp =>
    new SlackExceptionNotifier("https://hooks.slack.com/services/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")
);

// Otros servicios
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Cupones API", Version = "v1" });
});
builder.Services.AddControllers();

// Configuración de la base de datos MySQL con Entity Framework Core
builder.Services.AddDbContext<BaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
    ));

// Configuración de autenticación JWT
builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Middleware para Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cupones API v1");
        c.RoutePrefix = ""; // Abre Swagger UI en la raíz del sitio
    });
}

// Middleware para manejar excepciones y enviar notificaciones a Slack
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionHandlerPathFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();
        var exception = exceptionHandlerPathFeature.Error;

        // Aquí manejas la excepción y notificasa Slack usando SlackExceptionNotifier
        var notifier = context.RequestServices.GetRequiredService<SlackExceptionNotifier>();
        await notifier.NotifyAsync(exception);

        // Retornar una respuesta adecuada para la excepción manejada
        context.Response.StatusCode = 500; // O el código de estado que prefieras
        await context.Response.WriteAsync($"Ocurrió un error: {exception.Message}");
    });
});

app.UseCors("NewPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
