using Backend_Ressource_Relationnel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Ressource_Relationnel.Controllers
{
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
            return await _context.relations.ToListAsync();
        }

        // GET api/<RelationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Relation>> GetRelation(int id)
        {
            var relations = await _context.relations.FindAsync(id);
            if (relations == null)
            {
                return NotFound();
            }

            return relations;
        }

        // POST api/<RelationController>
        [HttpPost]
        public async Task<ActionResult<Ressource>> PostRelation(Relation relation)
        {
            _context.relations.Add(relation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRelation", new { id = relation.Id }, relation);
        }

        // PUT api/<RelationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelation(int id, Ressource relations)
        {
            if (id != relations.Id)
            {
                return BadRequest();
            }

            _context.Entry(relations).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

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
            var relations = await _context.relations.FindAsync(id);
            if (relations == null)
            {
                return NotFound();
            }

            _context.relations.Remove(relations);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool RelationExists(int id)
        {
            return _context.relations.Any(e => e.Id == id);
        }
    }
}
