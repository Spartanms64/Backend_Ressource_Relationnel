using Backend_Ressource_Relationnel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend_Ressource_Relationnel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly DataContext _context;

        public ResourceController(DataContext context)
        {
            _context = context;
        }
        // GET: api/<ResourceController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resource>>> GetResource()
        {
            return await _context.resource.ToListAsync();
        }

        // GET api/<ResourceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resource>> GetResource(int id)
        {
            var resource = await _context.resource.FindAsync(id);

            if (resource == null)
            {
                return NotFound();
            }

            return resource;
        }

        // GET /SHARE 

        [HttpGet("{id}/share")]
        public IActionResult Share(int id)
        {
            // Rechercher la ressource dans la base de données par son ID
            var ressource = _context.resource.FirstOrDefault(a => a.id == id);

            if (ressource == null)
            {
                return NotFound(); // Retourne une réponse 404 si la ressource n'est pas trouvé
            }

            // Générer une URL unique pour la ressource
            var baseUrl = Request.Scheme + "://" + Request.Host.ToUriComponent();
            var url = baseUrl + "/ressource/" + ressource.id;

            // Retourner l'URL dans le corps de la réponse
            return Ok(url);
        }


        // POST api/<ResourceController>
        [HttpPost]
        public async Task<ActionResult<Resource>> AddResource(Resource resource)
        {
            _context.resource.Add(resource);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetResource), new { id = resource.id }, resource);
        }

        // PUT api/<ResourceController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResource(int id, Resource resource)
        {
            if (id != resource.id)
            {
                return BadRequest();
            }

            _context.Entry(resource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResourceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<ResourceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(int id)
        {
            var resource = await _context.resource.FindAsync(id);

            if (resource == null)
            {
                return NotFound();
            }

            _context.resource.Remove(resource);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResourceExists(int id)
        {
            return _context.resource.Any(e => e.id == id);
        }
    }
}
