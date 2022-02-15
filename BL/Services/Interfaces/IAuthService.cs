﻿using DAL.Dto;
using System.Threading.Tasks;

namespace BL.Services.Interfaces
{
    /// <summary>
    /// Interface for an authentification service.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Authenticate employee by email and password.
        /// </summary>
        /// <param name="email">Email of registered employee</param>
        /// <param name="password">Password</param>
        Task<AuthenticatedUserDto> AuthenticateAsync(string email, string password);

        /// <summary>
        /// Register new employee.
        /// </summary>
        /// <param name="employee">Employee model</param>
        Task<AuthenticatedUserDto> RegisterAsync(UserDto employee);
    }
}
