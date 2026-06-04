using FinanceBilling.Core.Interfaces.Repositories;
using FinanceBilling.Core.Interfaces.Services;
using FinanceBilling.Core.Services;
using FinanceBilling.Infrastructure.Repositories;
using FinanceBilling.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection
            AddInfrastructure(
                this IServiceCollection services)
        {
            services.AddScoped<IUserRepository,
                UserRepository>();

            services.AddScoped<IInvoiceRepository,
                InvoiceRepository>();

            services.AddScoped<IPaymentRepository,
                PaymentRepository>();

            services.AddScoped<IAuditLogRepository,
                AuditLogRepository>();

            services.AddScoped<IPasswordService,
                PasswordService>();

            services.AddScoped<IJwtTokenService,
                JwtTokenService>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IInvoiceService, InvoiceService>();

            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }
    }
}
