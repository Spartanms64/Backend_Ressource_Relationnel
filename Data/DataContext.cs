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

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Server = mysql - ressourcesre.alwaysdata.net; Port=3306;Database=ressourcesre_bdd;User=299632;Password=cda2022;");
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
