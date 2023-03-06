using Backend_Ressource_Relationnel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend_Ressource_Relationnel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationController : ControllerBase
    {
        private readonly DataContext _context;

        public RelationController(DataContext context)
        {
            _context = context;
        }
        // GET: api/<RelationController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Relation>>> GetRelation()
        {
            return await _context.relation.ToListAsync();
        }

        // GET api/<RelationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Relation>> GetRelation(int id)
        {
            var relation = await _context.relation.FindAsync(id);

            if (relation == null)
            {
                return NotFound();
            }

            return relation;
        }

        // POST api/<RelationController>
        [HttpPost]
        public async Task<ActionResult<Relation>> AddRelation(Relation relation)
        {
            _context.relation.Add(relation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRelation), new { id = relation.id }, relation);
        }

        // PUT api/<RelationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRelation(int id, Relation relation)
        {
            if (id != relation.id)
            {
                return BadRequest();
            }

            _context.Entry(relation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelationExists(id))
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

        // DELETE api/<RelationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelation(int id)
        {
            var relation = await _context.relation.FindAsync(id);

            if (relation == null)
            {
                return NotFound();
            }

            _context.relation.Remove(relation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RelationExists(int id)
        {
            return _context.relation.Any(e => e.id == id);
        }
    }
}
