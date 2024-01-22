using Microsoft.EntityFrameworkCore;
using Note.Core.Entities;
using Note.Infrastructure.EntityConfigurations;

namespace Note.Infrastructure
{
    public class DataContext : DbContext
    {
        public DbSet<Notepad> Notepad => Set<Notepad>();

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NotepadConfiguration());
        }
    }
}