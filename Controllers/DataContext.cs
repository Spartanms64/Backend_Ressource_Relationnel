#region Import

using Backend_Ressource_Relationnel.Models;
using Microsoft.EntityFrameworkCore;
#endregion
namespace Backend_Ressource_Relationnel.Controllers
{
    // Classe representant la BDD
    public class DataContext : DbContext
    {

        DbSet<Category> categories { get; set; }
        DbSet<User> users { get; set; }
        DbSet<Role> roles { get; set; }
        DbSet<Comment> comments { get; set; }
        DbSet<Favorite> favorite { get; set; }
        DbSet<Relation> relations { get; set; }
        DbSet<Ressource> ressources { get; set; }
        DbSet<Models.Type> types { get; set; }



        //**** Option de connexion BDD ****//
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=mysql-ressourcesre.alwaysdata.net;database=ressourcesre_bdd;user=299632;password=cda2022;Encrypt=true;");
        }

        //protected override void 



    }
}
////////// Documentation
///https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli
/////////