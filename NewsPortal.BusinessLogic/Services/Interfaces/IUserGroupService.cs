using NewsPortal.BusinessLogic.Services.Interfaces.CRUD;
using NewsPortal.DAL.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPortal.BusinessLogic.Services.Interfaces
{
    public interface IUserGroupService : ICrudService<UserGroupDto>
    {
        Task<Dictionary<int, string>> GetGroups(int groupId);
    }
}
