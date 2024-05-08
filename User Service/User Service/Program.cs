using Microsoft.EntityFrameworkCore;
using User_Service.Data;
using User_Service.Repository.Interfaces;
using User_Service.Repository;
using User_Service.Service.Interfaces;
using User_Service.Service;
using User_Service.Models;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISpeechTherapistService, SpeechTherapistService>();
builder.Services.AddScoped<ISpeechTherapistRepository, SpeechTherapistRepository>();

builder.Services.AddScoped<IParentRepository, ParentRepository>();
builder.Services.AddScoped<IParentService, ParentService>();

builder.Services.AddScoped<IChildRepository, ChildRepository>();
builder.Services.AddScoped<IChildService, ChildService>();

builder.Services.AddScoped<PasswordHasherService>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext
builder.Services.AddDbContext<UserContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
