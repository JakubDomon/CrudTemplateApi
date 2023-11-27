using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.DbContexts
{
    public abstract class DbContextBase : DbContext
    {
        IConfiguration Configuration { get; }
        
        public DbContextBase(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected string GetConnectionString(string databaseName)
        {
            if(databaseName == null) throw new ArgumentNullException(nameof(databaseName));

            return Configuration.GetConnectionString(databaseName)
                ?? throw new ArgumentException($"{databaseName} connection not found in configuration file");
        }
    }
}
