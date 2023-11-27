using DataAccessLayer.DbContexts;
using DataAccessLayer.Models.UserGroups;
using DataAccessLayer.Models.Users;
using DataAccessLayer.Repositiories;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.DependencyInjection
{
    public static class DalServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            // Database context
            services.AddDbContext<DefaultContext>();

            // Repositories
            services.AddTransient<IRepository<User>, Repository<User, DefaultContext>>();
            services.AddTransient<IRepository<UserGroup>, Repository<UserGroup, DefaultContext>>();

            return services;
        }
    }
}
