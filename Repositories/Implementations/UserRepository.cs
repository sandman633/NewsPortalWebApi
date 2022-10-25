using AutoMapper;
using Model.Domain;
using Microsoft.EntityFrameworkCore;
using DAL.Dto;
using Repositories.Interfaces;
using System.Linq;
using System.Text;
using Model;

namespace Repositories.Implementations
{
    public class UserRepository : BaseRepository<UserDto, User>, IUserRepository
    {
        public UserRepository(WebApiContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override IQueryable<User> DefaultIncludeProperties(DbSet<User> dbSet)
        {
            return base.DefaultIncludeProperties(dbSet).Include(er => er.UserGroups);
        }

    }
}