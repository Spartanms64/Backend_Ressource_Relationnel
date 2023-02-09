#region Import

using Backend_Ressource_Relationnel.Models;
using Microsoft.EntityFrameworkCore;
#endregion
namespace Backend_Ressource_Relationnel.Controllers
{
    // Classe representant la BDD
    public class DataContext : DbContext
    {
        //**** 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=mysql-ressourcesre.alwaysdata.net;database=ressourcesre_bdd;user=299632;password=cda2022");
        }


    }
}
