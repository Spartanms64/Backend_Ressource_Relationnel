namespace Backend_Ressource_Relationnel.Models
{
    public enum User_Role
    {
        Citoyen, Moderateur, Administrateur, SuperAdministrateur
    }


    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}