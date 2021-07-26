﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace DAL.Domain
{
    public partial class WebApiContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }
        public DbSet<Сomment> Comments { get; set; }

        public WebApiContext(DbContextOptions options) : base(options)
        {

        }
    }
}
