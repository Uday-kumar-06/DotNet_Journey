using Microsoft.EntityFrameworkCore;
using SecureBankingAPI.Data;
using SecureBankingAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    options.UseSqlServer(
        builder.Configuration
        .GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<PasswordService>();

builder.Services.AddScoped<EncryptionService>();

builder.Services.AddScoped<HmacService>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();