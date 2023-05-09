using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Neo_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaborateurController : ControllerBase
    {
        private static List<Collaborateur> collaborateurs = new List<Collaborateur>
            {
                new Collaborateur {
                    Id=1,
                    Nom="Charni",
                    Prenom="Rym" ,
                    Email_personnel="rymmm@gmail.com" ,
                    Email_profesionnel="rym@neoledge.com" ,
                    Naissance="1998 mars",
                    Telephone="26962446" },

                new Collaborateur {
                    Id=2,
                    Nom="Charni",
                    Prenom="khouloud" ,
                    Email_personnel="khou@gmail.com" ,
                    Email_profesionnel="kh@cegid.com" ,
                    Naissance="1994 mai",
                    Telephone="23893723" }
            };



        [HttpGet]
        public async Task<ActionResult<List<Collaborateur>>> Get()
        {

            return (Ok(collaborateurs));
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Collaborateur>> Get( int Id)
        {

            var collaborateur = collaborateurs.Find(x => x.Id == Id);
            if (collaborateur == null)
                return BadRequest("collaborateur inexistant .");
            return (Ok(collaborateur));
        }

        [HttpPost]

        public async Task<ActionResult<List<Collaborateur>>> AddCollab(Collaborateur collaborateur)
        {
            collaborateurs.Add(collaborateur);

            return (Ok(collaborateurs));
        }

        [HttpPut]

        public async Task<ActionResult<List<Collaborateur>>> UpdateCollab(Collaborateur request)
        {
            var collaborateur = collaborateurs.Find(x => x.Id == request.Id);
            if (collaborateur == null)
                return BadRequest("collaborateur inexistant .");
           
            collaborateur.Nom=request.Nom;
            collaborateur.Prenom=request.Prenom;
            collaborateur.Email_personnel=request.Email_personnel;
            collaborateur.Email_profesionnel=request.Email_profesionnel;
            collaborateur.Naissance=request.Naissance;
            collaborateur.Telephone=request.Telephone;

            return (Ok(collaborateurs));
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Collaborateur>>> Delete(int Id)
        {

            var collaborateur = collaborateurs.Find(x => x.Id == Id);
            if (collaborateur == null)
                return BadRequest("collaborateur inexistant .");

            collaborateurs.Remove(collaborateur);
            return (Ok(collaborateurs));
        }

    }
}
