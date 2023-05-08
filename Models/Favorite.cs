namespace Backend_Ressource_Relationnel.Models
{
    public class Favorite
    {
        //**** Favorite Table ****//
        public int id { get; set; }

        //**** Jointure User & Ressource Table ****//
        /* public int id_user { get; set; }
         public int id_resource { get; set; }

         public virtual User user { get; set; }
         public virtual Resource resource { get; set; }*/

        public int id_user { get; set; }
        public User user { get; set; }

        public int id_resource { get; set; }
        public Resource resource { get; set; }
    }
}