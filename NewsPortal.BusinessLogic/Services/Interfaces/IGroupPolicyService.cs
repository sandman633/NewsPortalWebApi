using NewsPortal.BusinessLogic.Services.Interfaces.CRUD;
using NewsPortal.DAL.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPortal.BusinessLogic.Services.Interfaces
{
    public interface IGroupPolicyService : ICrudService<GroupPolicyDto>
    {
        Task<IEnumerable<KeyValuePair<string, short?>>> GetPolicies(int groupId);
        Task<IEnumerable<KeyValuePair<string, short?>>> GetPoliciesForUser(int userId);
    }
}
