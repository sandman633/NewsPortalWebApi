﻿using NewsPortal.Model.Domain;
using Microsoft.EntityFrameworkCore;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces;
using System.Linq;
using NewsPortal.Model;

namespace Repositories.Implementations
{
    public class UserGroupRepository : BaseRepository<UserGroupDto, UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(WebApiContext context) : base(context)
        {

        }

        public override IQueryable<UserGroup> DefaultIncludeProperties(DbSet<UserGroup> dbSet) => dbSet.Include(scr => scr.Group).ThenInclude(src=>src.GroupPolicies);
    }
}
