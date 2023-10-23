using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.DbContexts
{
    public abstract class DbContextBase : DbContext
    {
        IConfigurationRoot ConfigurationRoot { get; }
        
        public DbContextBase()
        {
            ConfigurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        protected string GetConnectionString(string databaseName)
        {
            if(databaseName == null) throw new ArgumentNullException(nameof(databaseName));

            return ConfigurationRoot.GetConnectionString(databaseName)
                ?? throw new ArgumentException($"{databaseName} connection not found in configuration file");
        }
    }
}
