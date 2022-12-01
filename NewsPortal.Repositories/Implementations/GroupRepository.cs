using NewsPortal.Model.Domain;
using Microsoft.EntityFrameworkCore;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces;
using System.Linq;
using NewsPortal.Model;

namespace Repositories.Implementations
{
    public class GroupRepository : BaseRepository<GroupDto, Group>, IGroupRepository
    {
        public GroupRepository(WebApiContext context) : base(context)
        {

        }

        public override IQueryable<Group> DefaultIncludeProperties(DbSet<Group> dbSet) => dbSet.Include(scr => scr.UserGroups).ThenInclude(scr=>scr.Group).ThenInclude(x=>x.GroupPolicies);
    }
}
