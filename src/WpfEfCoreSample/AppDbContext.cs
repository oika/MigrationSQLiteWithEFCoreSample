using Microsoft.EntityFrameworkCore;
using System.IO;

namespace WpfEfCoreSample
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> People { get; set; } = null!;
        
        private static string DbPath => Path.Combine(
            System.Environment.CurrentDirectory, "sample.db");
            
        public AppDbContext()
        {
        }
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={DbPath}");
            }
        }
    }
}