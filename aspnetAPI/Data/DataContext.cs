global using Microsoft.EntityFrameworkCore;

namespace aspnetAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-BSAM999; Database=testapidb;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<Test> Tests { get; set; }
    }
}
