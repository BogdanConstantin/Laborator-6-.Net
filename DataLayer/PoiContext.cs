using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class PoiContext : DbContext
    {
        public DbSet<Poi> Pois { get; set; }

        public PoiContext(DbContextOptions<PoiContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poi>().HasKey(p => p.Id);
            modelBuilder.Entity<Poi>().Property(p => p.Id)
                .IsRequired();

            modelBuilder.Entity<Poi>().Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Poi>().Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
