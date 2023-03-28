using Backend_Ressource_Relationnel.Models;

using Microsoft.EntityFrameworkCore;

namespace Backend_Ressource_Relationnel
{
    public class DataContext : DbContext
    {
        public DbSet<Category> category { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<Comment> comment { get; set; }
        public DbSet<Relation> relation { get; set; }
        public DbSet<Resource> resource { get; set; }
        public DbSet<TypeR> type { get; set; }
        public DbSet<Favorite> favorite { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Resource>()
                .HasOne(r => r.id_category)
                .WithMany()
                .HasForeignKey(r => r.id_category);
            modelBuilder.Entity<Resource>()
                .HasOne(r=>r.typeR)
                .WithMany()
                .HasForeignKey(r=>r.id_type);

            */
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}