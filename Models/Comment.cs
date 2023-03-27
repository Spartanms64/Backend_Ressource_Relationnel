using Backend_Ressource_Relationnel.Models;

namespace Backend_Ressource_Relationnel.Models
{
    public class Comment
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string content { get; set; }
        public bool isdeleted { get; set; }

        //***** Jointure User & Ressource *****//

       /* public int id_user { get; set; }
        public int is_ressource { get; set; }
        public virtual User user { get; set; }
        public virtual Resource resource { get; set; }*/
    }
}
