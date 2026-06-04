using FinanceBilling.API.Middleware;
using FinanceBilling.Core.Interfaces.Services;
using FinanceBilling.Infrastructure;
using FinanceBilling.Infrastructure.Data;
using FinanceBilling.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.AspNetCore;
using NSwag.Generation.Processors.Security;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FinanceBillingDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<
    IDashboardService,
    DashboardService>();

builder.Services.AddScoped<
    IAuditLogService,
    AuditLogService>();

builder.Services.AddInfrastructure();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "FinanceBilling API";
    options.Version = "v1";

    // JWT Security Definition
    options.AddSecurity("Bearer", new OpenApiSecurityScheme
    {
        Type = OpenApiSecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "Enter your JWT token"
    });

    // Apply security to all endpoints
    options.OperationProcessors.Add(
    new OperationSecurityScopeProcessor("Bearer"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Serve the OpenAPI/Swagger JSON
    app.UseOpenApi();

    // Serve the Swagger UI
    app.UseSwaggerUi(options =>
    {
        options.DocumentTitle = "FinanceBilling API";
        options.Path = "/swagger";
    });

    // Optional: ReDoc UI (read-only, clean docs)
    app.UseReDoc(options =>
    {
        options.Path = "/redoc";
    });
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();