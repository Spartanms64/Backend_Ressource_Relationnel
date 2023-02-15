namespace Backend_Ressource_Relationnel.Models
{
    public class User
    {
        //**** User Table ****//  
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }

        //**** Jointure Role Table ****//

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }


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
