using NewsPortal.BusinessLogic.Services.Interfaces.CRUD;
using NewsPortal.DAL.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.BusinessLogic.Services.Interfaces
{
    public interface IUserRoleService : ICrudService<UserRoleDto>
    {
        //public Task<UserDto> BanUser(UserRoleDto id);
        //public Task<UserDto> UnBanUser(UserRoleDto id);
    }
}
