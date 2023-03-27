namespace Backend_Ressource_Relationnel.Models
{
    public class User
    {
        //**** User Table ****//  
        public int id { get; set; }
        public string name { get; set; }
        public string firstname { get; set; }
        public DateTime birthday { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }

        public string password { get; set; }
        public bool isdeleted { get; set; }

        //**** Jointure Role Table ****//
        /*
        public int id_role { get; set; }
        public virtual Role role { get; set; }*/


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
