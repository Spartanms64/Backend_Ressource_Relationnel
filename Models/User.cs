using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend_Ressource_Relationnel.Models
{
    public class User : IdentityUser
    {
        //**** User Table ****//
        [JsonPropertyName("userId")]
        public int Id { get; set; }

        public string name { get; set; }
        public string firstname { get; set; }

        [DataType(DataType.Date)]
        public DateTime birthday { get; set; }

        //[Phone]
        //public string PhoneNumber { get; set; }

        //public string email { get; set; }

        //public string password { get; set; }
        public bool isdeleted { get; set; }

        [EmailAddress]
        public override string UserName { get; set; }

        [EmailAddress]
        public override string Email { get; set; }

        //**** Jointure Role Table ****//
        /*
        public int id_role { get; set; }
        public virtual Role role { get; set; }*/

        public int id_role { get; set; }
        public Role role { get; set; }
    }

    public class CitoyenConnect : User
    {
    }

    public class Moderateur : CitoyenConnect
    {
    }

    public class Administrateur : Moderateur
    {
    }
}