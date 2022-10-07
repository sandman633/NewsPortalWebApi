using Bl.Services.Interfaces.CRUD;
using DAL.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services.Interfaces
{
    public interface IGroupPolicyService : ICrudService<GroupPolicyDto>
    {
        Task<Dictionary<string, short?>> GetPolicies(int groupId);
        Task<Dictionary<string, short?>> GetPoliciesForUser(int userId);
    }
}
