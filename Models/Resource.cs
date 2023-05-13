using System.Reflection.Metadata;

namespace Backend_Ressource_Relationnel.Models
{
    public class Resource
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string illustration { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
        public int nfavorie { get; set; }

        public bool isdeleted { get; set; }

        /* public int id_type { get; set; }
         public virtual TypeR type { get; set; }
         public int id_category { get; set; }
         public virtual Category category { get; set; }
         public int id_relation { get; set; }
         public virtual Relation relation { get; set; }*/

        public int id_category { get; set; }
        public Category category { get; set; }

        public int id_type { get; set; }
        public TypeR typeR { get; set; }

        public int id_relation { get; set; }
        public Relation relation { get; set; }
    }
}