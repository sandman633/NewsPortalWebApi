using AutoMapper;
using NewsPortal.Model.Domain;
using Microsoft.EntityFrameworkCore;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces;
using System.Linq;
using NewsPortal.Model;

namespace Repositories.Implementations
{
    public class GroupPolicyRepository : BaseRepository<GroupPolicyDto, GroupPolicy>, IGroupPolicyRepository
    {
        public GroupPolicyRepository(WebApiContext context) : base(context)
        {

        }
        public override IQueryable<GroupPolicy> DefaultIncludeProperties(DbSet<GroupPolicy> dbSet) => dbSet.Include(scr => scr.Group);
    }
}
