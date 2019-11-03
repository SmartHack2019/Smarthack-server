using Microsoft.EntityFrameworkCore;
using smarthack.Models;

namespace smarthack.Data
{
    public class SmartHackDbContext : DbContext
    {
        public SmartHackDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<News> Newses { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            optionsBuilder.UseMySQL(
            //                "server=eu-cdbrwest-02.cleardb.net;Database=heroku_1c3f591c0e17d07;userid=b5977c722a69d6;password=a7c61ba3; port=3306");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}