using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata;

namespace Backend_Ressource_Relationnel.Models
{
    public class Ressource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public Blob Content { get; set; }
        public JsonContent JsonContent { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }

        public int TypeID { get; set; }
        public virtual TypeR Type { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int RelationId { get; set; } 
        public virtual Ressource Relation { get; set; }

    }
}