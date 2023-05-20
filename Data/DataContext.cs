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
            /* Contrainte Resource */
            /*modelBuilder.Entity<Resource>()
                .HasOne(r => r.category)
                .WithMany()
                .HasForeignKey(r => r.id_category);*/
            //modelBuilder.Entity<Resource>().HasOne().WithMany().HasForeignKey(r => r.id_category);
            //modelBuilder.Entity<Resource>().HasAlternateKey(r => r.id_category);
            modelBuilder.Entity<Resource>().HasKey(r => r.category);
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.typeR)
                .WithMany()
                .HasForeignKey(r => r.id_type);

            modelBuilder.Entity<Resource>()
                .HasOne(r => r.relation)
                .WithMany()
                .HasForeignKey(r => r.id_relation);

            /* Contrainte user */

            modelBuilder.Entity<User>()
                .HasOne(u => u.role)
                .WithMany()
                .HasForeignKey(u => u.id_role);

            /* Contrainte comment */

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.resource)
                .WithMany()
                .HasForeignKey(c => c.id_resource);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.user)
                .WithMany()
                .HasForeignKey(c => c.id_user);

            /* Contrainte favorie */

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.user)
                .WithMany()
                .HasForeignKey(f => f.id_user);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.resource)
                .WithMany()
                .HasForeignKey(f => f.id_resource);
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}