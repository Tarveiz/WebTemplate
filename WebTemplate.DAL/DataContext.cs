using Microsoft.EntityFrameworkCore;
using WebTemplate.DAL.Entities;

namespace WebTemplate.DAL
{
    /// <summary>
    ///     Контекст базы данных
    /// </summary>
    public class DataContext : DbContext
    {
        public DbSet<EntityTest> EntityTest { get; set; } = null!;

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityTest>().HasData(
                new EntityTest { Name = "First Test Data", Description = "First Test Description" },
                new EntityTest { Name = "Second Test Data", Description = "Second Test Description" }
            );
        }
    }
}
