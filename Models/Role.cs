namespace Backend_Ressource_Relationnel.Models
{
    public enum User_Role
    {
        Citoyen, Moderateur, Administrateur, SuperAdministrateur
    }


    public class Role
    {
        public int id { get; set; }
        public string role_name { get; set; }
    }
}