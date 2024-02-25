using EF_HW1.DLL.Modules;
using Microsoft.EntityFrameworkCore;

namespace EF_HW1.DLL { 
    public class Context : DbContext 
    {
    string conectString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SpanishFootData;Integrated Security=True;Connect Timeout=30;";


        public DbSet<SpanishFootball> Footballs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conectString);
        }


    }
}
