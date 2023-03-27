using Backend_Ressource_Relationnel.Models;

namespace Backend_Ressource_Relationnel.Models
{
    public class Category
    {
        public int id { get; set; }
        public string category_name { get; set; }

        // public virtual Resource resource { get; set; }
        ///Doc jointure
        ///https://learn.microsoft.com/en-us/ef/ef6/fundamentals/relationships
    }
}
