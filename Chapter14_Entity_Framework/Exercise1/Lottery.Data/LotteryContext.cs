using System.Configuration;
using Lottery.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lottery.Data
{
    public class LotteryContext : DbContext
    {
        public DbSet<Draw> Draws { get; set; }
        public DbSet<LotteryGame> LotteryGames { get; set; }

        public LotteryContext() { } //Constructor used by UI project

        public LotteryContext(DbContextOptions<LotteryContext> options) : base(options) { } //Constructor used by Test project

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) //only configure the connection if the parameterless contructor was used (no options where provided).
            {
                //TODO: tell EF (Entity Framework) that is going to operate against a SQL Server database using the connection string in the app.config of the UI project
                string connectionString =
                    ConfigurationManager.ConnectionStrings["LotteryConnectionString"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DrawNumber>()
                .HasKey(dn => new { dn.DrawId, dn.Number });

            modelBuilder.Entity<LotteryGame>()
                .Property(s => s.Name).IsRequired();

            modelBuilder.Entity<LotteryGame>()
                .HasData(
                    new LotteryGame
                    {
                        Id = 1,
                        Name = "National Lottery",
                        NumberOfNumbersInADraw = 6,
                        MaximumNumber = 45
                    },
                    new LotteryGame
                    {
                        Id = 2,
                        Name = "Keeno",
                        NumberOfNumbersInADraw = 20,
                        MaximumNumber = 70
                    }
                );
            base.OnModelCreating(modelBuilder);
        }

        public void CreateOrUpdateDatabase()
        {
            Database.Migrate();
        }
    }
}
