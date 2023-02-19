using Backend_Ressource_Relationnel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Ressource_Relationnel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {

        private readonly DataContext _context;

        public TypeController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<RessourceController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Backend_Ressource_Relationnel.Models.Type>>> GetType()
        {
            return await _context.types.ToListAsync();
        }

        // GET api/<RessourceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Backend_Ressource_Relationnel.Models.Type>> GetType(int id)
        {
            var types = await _context.types.FindAsync(id);
            if (types == null)
            {
                return NotFound();
            }

            return types;
        }

        // POST api/<RessourceController>
        [HttpPost]
        public async Task<ActionResult<Backend_Ressource_Relationnel.Models.Type>> PostType(Backend_Ressource_Relationnel.Models.Type types)
        {
            _context.types.Add(types);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetType", new { id = types.Id }, types);
        }

        // PUT api/<RessourceController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutType(int id, Backend_Ressource_Relationnel.Models.Type types)
        {
            if (id != types.Id)
            {
                return BadRequest();
            }

            _context.Entry(types).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(id))
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
        public async Task<IActionResult> DeleteType(int id)
        {
            var types = await _context.types.FindAsync(id);
            if (types == null)
            {
                return NotFound();
            }

            _context.types.Remove(types);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool TypeExists(int id)
        {
            return _context.types.Any(e => e.Id == id);
        }
    }
}
