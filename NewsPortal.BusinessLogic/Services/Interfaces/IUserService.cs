using NewsPortal.BusinessLogic.Services.Interfaces.CRUD;
using NewsPortal.DAL.Dto;
using System;
using System.Threading.Tasks;

namespace NewsPortal.BusinessLogic.Services.Interfaces
{
    public interface IUserService : ICrudService<UserDto>
    {
        /// <summary>
        /// Returns User by given email.
        /// </summary>
        /// <param name="email">Email</param>
        Task<UserDto> GetByEmailAsync(string email);
    }
}
