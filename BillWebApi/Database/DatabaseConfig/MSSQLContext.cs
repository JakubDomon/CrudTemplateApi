using BCrypt.Net;
using BillWebApi.Database.Models.DatabaseModels.Bills;
using BillWebApi.Database.Models.DatabaseModels.Groups;
using BillWebApi.Database.Models.DatabaseModels.Users;
using Microsoft.EntityFrameworkCore;

namespace BillWebApi.Database.DatabaseConfig
{
    public class MSSQLContext: DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> _options) : base(_options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Bill>().HasKey(x => x.Id);
            builder.Entity<BillUsersCash>().HasKey(x => x.Id);
            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<Group>().HasKey(x => x.Id);

            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Jakub",
                    Surname = "Domoń",
                    Password = BCrypt.Net.BCrypt.HashPassword("admPass12@12")
                });
        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillUsersCash> BillsUsersCash { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
