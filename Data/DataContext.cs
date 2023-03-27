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

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }

        //public DataContext(DbContextOptionsBuilder<DataContext> optionsBuilder) { optionsBuilder.UseMemoryCache(); }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMemoryCache(memoryCache);*/
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
