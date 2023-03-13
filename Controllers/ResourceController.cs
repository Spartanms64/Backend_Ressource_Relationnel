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

            return Ok(resource);
        }

        private bool ResourceExists(int id)
        {
            return _context.resource.Any(e => e.id == id);
        }
    }
}
