using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Neo_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaborateurController : ControllerBase
    {
        
        private readonly DataContext context;

        public CollaborateurController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Collaborateur>>> Get()
        {

            return Ok(await context.Collaborateurs.ToListAsync());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Collaborateur>> Get( int Id)
        {

            var collaborateur = await context.Collaborateurs.FindAsync(Id);
            if (collaborateur == null)
                return BadRequest("collaborateur inexistant .");
            return (Ok(collaborateur));
        }

        [HttpPost]

        public async Task<ActionResult<List<Collaborateur>>> AddCollab(Collaborateur collaborateur)
        {
            context.Collaborateurs.Add(collaborateur);
            await context.SaveChangesAsync();

            return Ok(await context.Collaborateurs.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<Collaborateur>>> UpdateCollab(Collaborateur request)
        {
            var dbcollaborateur = await context.Collaborateurs.FindAsync(request.Id);
            if (dbcollaborateur == null)
                return BadRequest("collaborateur inexistant .");

            dbcollaborateur.Nom=request.Nom;
            dbcollaborateur.Prenom=request.Prenom;
            dbcollaborateur.Email_personnel=request.Email_personnel;
            dbcollaborateur.Email_profesionnel=request.Email_profesionnel;
            dbcollaborateur.Naissance=request.Naissance;
            dbcollaborateur.Telephone=request.Telephone;

            await context.SaveChangesAsync();

            return Ok(await context.Collaborateurs.ToListAsync());
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Collaborateur>>> Delete(int Id)
        {

            var dbcollaborateur = await context.Collaborateurs.FindAsync(Id);
            if (dbcollaborateur == null)
                return BadRequest("collaborateur inexistant .");

            context.Collaborateurs.Remove(dbcollaborateur);
            await context.SaveChangesAsync();

            return Ok(await context.Collaborateurs.ToListAsync());
        }

    }
}
