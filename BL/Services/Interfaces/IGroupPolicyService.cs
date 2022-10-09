using Bl.Services.Interfaces.CRUD;
using DAL.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services.Interfaces
{
    public interface IGroupPolicyService : ICrudService<GroupPolicyDto>
    {
        Task<IEnumerable<KeyValuePair<string, short?>>> GetPolicies(int groupId);
        Task<IEnumerable<KeyValuePair<string, short?>>> GetPoliciesForUser(int userId);
    }
}
