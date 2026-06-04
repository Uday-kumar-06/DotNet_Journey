using FinanceBilling.Core.DTOs;
using FinanceBilling.Core.DTOs.User;
using FinanceBilling.Core.Entities;
using FinanceBilling.Core.Interfaces.Repositories;
using FinanceBilling.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuditLogRepository _auditRepository;

        public UserService(
            IUserRepository userRepository,
            IAuditLogRepository auditRepository)
        {
            _userRepository = userRepository;
            _auditRepository = auditRepository;
        }

        public async Task<IEnumerable<UserDto>>
            GetPendingUsersAsync()
        {
            var users =
                await _userRepository.GetPendingUsersAsync();

            return users.Select(x => new UserDto
            {
                UserId = x.UserId,
                Username = x.Username,
                Email = x.Email,
                IsApproved = x.IsApproved
            });
        }

        public async Task ApproveUserAsync(
            int adminUserId,
            ApproveUserDto dto)
        {
            var user =
                await _userRepository.GetByIdAsync(dto.UserId);

            if (user == null)
                throw new Exception("User not found.");

            user.RoleId = dto.RoleId;
            user.IsApproved = true;

            await _userRepository.UpdateAsync(user);

            await _auditRepository.AddAsync(
                new AuditLog
                {
                    UserId = adminUserId,
                    Action = "User Approved",
                    EntityName = "User",
                    EntityId = user.UserId,
                    ChangedAt = DateTime.UtcNow,
                    Details =
                        $"Assigned RoleId {dto.RoleId}"
                });
        }

        public async Task<IEnumerable<ClientLookupDto>>
    GetClientsAsync()
        {
            var clients =
                await _userRepository
                    .GetApprovedClientsAsync();

            return clients.Select(x =>
                new ClientLookupDto
                {
                    UserId = x.UserId,
                    Username = x.Username,
                    Email = x.Email
                });
        }
    }
}
