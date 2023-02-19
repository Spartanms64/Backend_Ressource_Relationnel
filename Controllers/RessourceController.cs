using Backend_Ressource_Relationnel.Models;
using Backend_Ressource_Relationnel.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Ressource_Relationnel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RessourceController : ControllerBase
    {
        private readonly DataContext _context;

        public RessourceController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<RessourceController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ressource>>> GetRessource()
        {
            return await _context.ressources.ToListAsync();
        }

        // GET api/<RessourceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ressource>> GetRessource(int id)
        {
            var ressources = await _context.ressources.FindAsync(id);
            if (ressources == null)
            {
                return NotFound();
            }

            return ressources;
        }

        // POST api/<RessourceController>
        [HttpPost]
        public async Task<ActionResult<Ressource>> PostRessource(Ressource ressources)
        {
            _context.ressources.Add(ressources);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRessource", new { id = ressources.Id }, ressources);
        }

        // PUT api/<RessourceController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRessource(int id, Ressource ressource)
        {
            if (id != ressource.Id)
            {
                return BadRequest();
            }

            _context.Entry(ressource).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RessourceExists(id))
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

        // DELETE api/<RessourceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRessource(int id)
        {
            var ressource = await _context.ressources.FindAsync(id);
            if (ressource == null)
            {
                return NotFound();
            }

            _context.ressources.Remove(ressource);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool RessourceExists(int id)
        {
            return _context.ressources.Any(e => e.Id == id);
        }
    }
}
