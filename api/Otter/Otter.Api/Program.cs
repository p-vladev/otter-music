using Microsoft.EntityFrameworkCore;
using Otter.Core.Data;
using DotNetEnv;
using Otter.Core.Interfaces;
using Otter.Core.Services;

Env.TraversePath().Load();

var connectionString = $"Host={Env.GetString("DB_HOST")};" +
                       $"Port={Env.GetString("POSTGRES_PORT")};" +
                       $"Database={Env.GetString("POSTGRES_DB")};" +
                       $"Username={Env.GetString("POSTGRES_USER")};" +
                       $"Password={Env.GetString("POSTGRES_PASSWORD")}";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OtterDbContext>(options =>
    options.UseNpgsql(connectionString));

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
