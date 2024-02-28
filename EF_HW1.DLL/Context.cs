using EF_HW1.DLL.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF_HW1.DLL { 
    public class Context : DbContext 
    {
        public DbSet<SpanishFootball> Footballs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appconfig.json", optional: false, reloadOnChange:true);

            var configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
