using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend_Ressource_Relationnel.Models
{
    public class Role: IdentityRole
    {
        [JsonPropertyName("roleId")]
        [Key]
        public int id { get; set; }
        public string role_name { get; set; }
    }
}