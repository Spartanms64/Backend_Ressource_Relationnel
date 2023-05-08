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
            return await _context.resource
                .Include(r => r.category)
                .Include(r => r.typeR)
                .Include(r => r.relation)
                .ToListAsync();
        }

        // GET api/<ResourceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resource>> GetResource(int id)
        {
            var resource = await _context.resource
                .Include(r => r.category)
                .Include(r => r.typeR)
                .Include(r => r.relation)
                .FirstOrDefaultAsync(r => r.id == id);

            if (resource == null)
            {
                return NotFound();
            }
            //string contentbdd = Convert.ToBase64String(resource.content);
            //resource.content = contentbdd;

            return resource;
        }

        //toute les ressource de la meme categorie
        [HttpGet("Category/{id}")]
        public async Task<ActionResult<IEnumerable<Resource>>> GetResourceByCategory(int id)
        {
            var resources = await _context.resource.Where(r => r.id_category == id).ToListAsync();
            if (resources == null)
            {
                return NotFound();
            }

            return resources;
        }

        // Toute les ressources du meme type
        [HttpGet("Type/{id}")]
        public async Task<ActionResult<IEnumerable<Resource>>> GetResourceByType(int id)
        {
            var resources = await _context.resource.Where(r => r.id_type == id).ToListAsync();
            if (resources == null)
            {
                return NotFound();
            }

            return resources;
        }

        // toute les ressources qui on la meme relation
        [HttpGet("Relation/{id}")]
        public async Task<ActionResult<IEnumerable<Resource>>> GetResourceByRelation(int id)
        {
            var resources = await _context.resource.Where(r => r.id_relation == id).ToListAsync();
            if (resources == null)
            {
                return NotFound();
            }

            return resources;
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

            return Ok(resource);
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

            return Ok(resource);
        }

        private bool ResourceExists(int id)
        {
            return _context.resource.Any(e => e.id == id);
        }
    }
}