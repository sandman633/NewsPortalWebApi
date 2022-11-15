using AutoMapper;
using NewsPortal.Model.Domain;
using Microsoft.EntityFrameworkCore;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsPortal.Model;

namespace Repositories.Implementations
{
    public class GroupPolicyRepository : BaseRepository<GroupPolicyDto, GroupPolicy>, IGroupPolicyRepository
    {
        public GroupPolicyRepository(WebApiContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override IQueryable<GroupPolicy> DefaultIncludeProperties(DbSet<GroupPolicy> dbSet) => dbSet.Include(scr => scr.Group);
    }
}
