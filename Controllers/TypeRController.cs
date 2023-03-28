using Backend_Ressource_Relationnel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend_Ressource_Relationnel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeRController : ControllerBase
    {
        private readonly DataContext _context;

        public TypeRController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<TypeRController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeR>>> GetTypeR()
        {
            return await _context.type.ToListAsync();
        }

        // GET api/<TypeRController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeR>> GetTypeR(int id)
        {
            var type = await _context.type.FindAsync(id);

            if (type == null)
            {
                return NotFound();
            }

            return type;
        }

        // POST api/<TypeRController>
        [HttpPost]
        public async Task<ActionResult<TypeR>> AddTypeR(TypeR type)
        {
            _context.type.Add(type);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTypeR), new { id = type.id }, type);
        }

        // PUT api/<TypeRController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateType(int id, TypeR type)
        {
            if (id != type.id)
            {
                return BadRequest();
            }

            _context.Entry(type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeRExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(type);
        }

        // DELETE api/<TypeRController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            var type = await _context.type.FindAsync(id);

            if (type == null)
            {
                return NotFound();
            }

            _context.type.Remove(type);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeRExists(int id)
        {
            return _context.type.Any(e => e.id == id);
        }
    }
}