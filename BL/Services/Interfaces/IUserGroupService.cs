using Bl.Services.Interfaces.CRUD;
using DAL.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services.Interfaces
{
    public interface IUserGroupService : ICrudService<UserGroupDto>
    {
        Task<Dictionary<int, string>> GetGroups(int groupId);
    }
}
