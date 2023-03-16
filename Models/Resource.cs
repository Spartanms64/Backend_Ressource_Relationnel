using System.Reflection.Metadata;

namespace Backend_Ressource_Relationnel.Models
{
    public class Resource
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        public byte[] content { get; set; }
        public string element { get; set; }
        public DateTime date { get; set; }

        public bool isdeleted { get; set; }

        /* public int id_type { get; set; }
         public virtual TypeR type { get; set; }
         public int id_category { get; set; }
         public virtual Category category { get; set; }
         public int id_relation { get; set; }
         public virtual Relation relation { get; set; }*/
    }
}