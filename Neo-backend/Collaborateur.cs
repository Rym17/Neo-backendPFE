using System.Security.Principal;

namespace Neo_backend
{
    public class Collaborateur
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; }= string.Empty;
        public string Email_personnel { get; set; } = string.Empty;
        public string Email_profesionnel { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Naissance { get; set; } = string.Empty;


    }
}
