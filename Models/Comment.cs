namespace Backend_Ressource_Relationnel.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string content { get; set; }
        public bool IsDelected { get; set; }

        //***** Jointure User & Ressource *****//
        
        public int UserId { get; set; }
        public int RessourceId { get; set; }
        public virtual User User { get; set; }
        public virtual Ressource Ressource { get; set; }

    }
}
