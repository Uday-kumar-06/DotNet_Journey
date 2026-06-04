using FinanceBilling.Core.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterRequestDto dto);

        Task<LoginResponseDto?> LoginAsync(LoginRequestDto dto);
    }
}
