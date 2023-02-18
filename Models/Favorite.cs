namespace Backend_Ressource_Relationnel.Models
{
    public class Favorite
    {
        //**** Favorite Table ****//
        public int Id { get; set; }


        //**** Jointure User & Ressource Table ****//
        public int UserId { get; set; }
        public int RessourceId { get; set; }

        public virtual User User { get; set; }
        public virtual Ressource Ressource { get; set; }



    }
}
