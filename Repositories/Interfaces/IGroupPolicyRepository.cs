using NewsPortal.Model.Domain;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces.CRUD;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface IGroupPolicyRepository : ICrudRepository<GroupPolicyDto, GroupPolicy>
    {
    }
}
