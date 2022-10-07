using AutoMapper;
using Model.Domain;
using Microsoft.EntityFrameworkCore;
using DAL.Dto;
using Repositories.Interfaces;
using System.Linq;
using Model;

namespace Repositories.Implementations
{
    public class UserGroupRepository : BaseRepository<UserGroupDto, UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(WebApiContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override IQueryable<UserGroup> DefaultIncludeProperties(DbSet<UserGroup> dbSet) => dbSet.Include(scr => scr.GroupPolicies);
    }
}
