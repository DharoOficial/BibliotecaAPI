using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MVCAPIBiblioteca.Autorization;
using MVCAPIBiblioteca.Context;
using MVCAPIBiblioteca.Controllers;
using MVCAPIBiblioteca.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<LivroRepositories>();
builder.Services.AddTransient<AutorRepositorie>();
builder.Services.AddTransient<BibliotecaContexto>();
builder.Services.AddScoped<UsuarioRepositories>();
builder.Services.AddSingleton<IAuthorizationHandler, AdmimAuthorization>();
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("Adimim", y => y.AddRequirements(new CheckAdmim(1))
    ); 
});
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("imtringbutitshardjustalittlemrrigthnowiguess")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
        
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
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
