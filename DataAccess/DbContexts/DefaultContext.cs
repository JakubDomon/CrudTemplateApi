﻿using DataAccessLayer.DbContexts.Enums;
using DataAccessLayer.Models.UserGroups;
using DataAccessLayer.Models.Users;
using DataAccessLayer.Utils.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.DbContexts
{
    public class DefaultContext: DbContextBase
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

        public DefaultContext(IConfiguration configuration) : base(configuration) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.Groups)
                .WithMany(g => g.Users);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString(DatabaseTypes.MsSQL_Mikrus.GetStringValue()));
        }
    }
}
