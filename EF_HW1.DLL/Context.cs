using EF_HW1.DLL.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Drawing;

namespace EF_HW1.DLL { 
    public class Context : DbContext 
    {
        public DbSet<Team> Team { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<PlayerGame> PlayerGame { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appconfig.json", optional: false, reloadOnChange:true);

            var configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>()
                .HasOne<Team>(f => f.Team1)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne<Team>(f => f.Team2)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<PlayerGame>()
                .HasKey(pg => new { pg.PlayerID, pg.GameID });


            modelBuilder.Entity<PlayerGame>()
                .HasOne(pg => pg.Player)
                .WithMany(pg => pg.PlayerGames)
                .HasForeignKey(pg => pg.PlayerID);


            modelBuilder.Entity<PlayerGame>()
                    .HasOne(pg => pg.Game)
                    .WithMany(pg => pg.PlayerGames)
                    .HasForeignKey(pg => pg.GameID);
        }
    }
}
