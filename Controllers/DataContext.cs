#region Import

using Backend_Ressource_Relationnel.Models;
using Microsoft.EntityFrameworkCore;
#endregion
namespace Backend_Ressource_Relationnel.Controllers
{
    // Classe representant la BDD
    public class DataContext : DbContext
    {

        public DbSet<Category> categories { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Favorite> favorite { get; set; }
        public DbSet<Relation> relations { get; set; }
        public DbSet<Ressource> ressources { get; set; }
        public DbSet<Models.Type> types { get; set; }

        
        //**** Option de connexion BDD ****//
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=mysql-ressourcesre.alwaysdata.net;database=ressourcesre_bdd;user=299632;password=cda2022;Encrypt=true;");
        }


        //****** Mise à jour classe + BDD *****//

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("category");
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<Role>().ToTable("role");
            modelBuilder.Entity<Comment>().ToTable("comment");
            modelBuilder.Entity<Favorite>().ToTable("favorite");
            modelBuilder.Entity<Relation>().ToTable("relation");
            modelBuilder.Entity<Ressource>().ToTable("ressource");
            modelBuilder.Entity<Models.Type>().ToTable("model");
        }

    }
}
////////// Documentation
///https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli
///https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core.html
///https://learn.microsoft.com/en-us/ef/core/
///https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-7.0&tabs=visual-studio
/////////