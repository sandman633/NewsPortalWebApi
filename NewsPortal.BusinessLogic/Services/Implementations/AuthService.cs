using AutoMapper;
using NewsPortal.BusinessLogic.Services.Interfaces;
using NewsPortal.DAL.Dto;
using System;
using System.Threading.Tasks;

namespace NewsPortal.BusinessLogic.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthService(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<AuthenticatedUserDto> AuthenticateAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(email));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));

            var user = await _userService.GetByEmailAsync(email);
            if (user == null)
                throw new ArgumentException($"Employee with email: {email} is not exists!");

            if (user.Password != password)
                return null;

            return _mapper.Map<AuthenticatedUserDto>(user);
        }

        public async Task<AuthenticatedUserDto> RegisterAsync(UserDto employee)
        {
            if (employee == null)
                throw new ArgumentException("Value cannot be null.", nameof(employee));

            if (string.IsNullOrEmpty(employee.Email))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(employee.Email));

            if (string.IsNullOrEmpty(employee.Password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(employee.Password));

            var existingEmployee = await _userService.GetByEmailAsync(employee.Email);
            if (existingEmployee != null)
                throw new ArgumentException($"Employee with email: {employee.Email} is already exists!");

            var createdEmployee = await _userService.CreateAsync(employee);
            return _mapper.Map<AuthenticatedUserDto>(createdEmployee);
        }
    }
}

