using NewsPortal.Model.Domain;
using Microsoft.EntityFrameworkCore;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces;
using System.Linq;
using NewsPortal.Model;

namespace Repositories.Implementations
{
    public class UserRepository : BaseRepository<UserDto, User>, IUserRepository
    {
        public UserRepository(WebApiContext context) : base(context)
        {

        }

        public override IQueryable<User> DefaultIncludeProperties(DbSet<User> dbSet)
        {
            return base.DefaultIncludeProperties(dbSet).Include(er => er.UserGroups);
        }

    }
}