using FinanceBilling.Core.DTOs.Auth;
using FinanceBilling.Core.Entities;
using FinanceBilling.Core.Interfaces.Repositories;
using FinanceBilling.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(
            IUserRepository userRepository,
            IPasswordService passwordService,
            IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _jwtTokenService = jwtTokenService;
        }

        public async Task RegisterAsync(RegisterRequestDto dto)
        {
            var existingUser =
                await _userRepository.GetByUsernameAsync(dto.Username);

            if (existingUser != null)
                throw new Exception("Username already exists.");

            var existingEmail =
                await _userRepository.GetByEmailAsync(dto.Email);

            if (existingEmail != null)
                throw new Exception("Email already exists.");

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash =
                    _passwordService.HashPassword(dto.Password),

                IsApproved = false,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
        }

        public async Task<LoginResponseDto?> LoginAsync(
            LoginRequestDto dto)
        {
            var user =
                await _userRepository.GetByUsernameAsync(dto.Username);

            if (user == null)
                return null;

            if (!user.IsApproved)
                throw new Exception(
                    "Account pending approval.");

            var valid =
                _passwordService.VerifyPassword(
                    dto.Password,
                    user.PasswordHash);

            if (!valid)
                return null;

            var role =
                user.Role?.RoleName ?? "";

            var token =
                _jwtTokenService.GenerateToken(
                    user.UserId,
                    user.Username,
                    role);

            user.LastLoginAt = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user);

            return new LoginResponseDto
            {
                Token = token,
                Username = user.Username,
                Role = role
            };
        }
    }
}
