using FinanceBilling.Core.DTOs;
using FinanceBilling.Core.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetPendingUsersAsync();

        Task ApproveUserAsync(
            int adminUserId,
            ApproveUserDto dto);

        Task<IEnumerable<ClientLookupDto>> GetClientsAsync();
    }
}
