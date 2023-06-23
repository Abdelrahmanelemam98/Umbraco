using Microsoft.EntityFrameworkCore;

namespace UmbracoProject1.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options) { }
        
        public required DbSet<Movies> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* ModelBuilder.Entity<Movies>(entity =>
            {
                entity.ToTable("Movies");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Title).HasColumnName("Title");
                entity.Property(e => e.Rate).HasColumnName("Rate");
                entity.Property(e => e.Storyline).HasColumnName("Storyline");
            });*/
        }
    }
}
