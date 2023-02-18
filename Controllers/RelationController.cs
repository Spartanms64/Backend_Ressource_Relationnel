using Backend_Ressource_Relationnel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Ressource_Relationnel.Controllers
{
    public class RelationController : Controller
    {
        private readonly DataContext _context;

        public RelationController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<RelationController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Relation>>> GetFavorite()
        {
            return await _context.relations.ToListAsync();
        }

        // GET api/<RelationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Relation>> GetFavorite(int id)
        {
            var favorite = await _context.relations.FindAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }

            return favorite;
        }

        // POST api/<RelationController>
        [HttpPost]
        public async Task<ActionResult<Relation>> PostFavorite(Relation favorite)
        {
            _context.relations.Add(favorite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavorite", new { id = favorite.Id }, favorite);
        }

        // PUT api/<RelationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavorite(int id, Relation favorite)
        {
            if (id != favorite.Id)
            {
                return BadRequest();
            }

            _context.Entry(favorite).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

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
            var favorite = await _context.relations.FindAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }

            _context.relations.Remove(favorite);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool RelationExists(int id)
        {
            return _context.relations.Any(e => e.Id == id);
        }
    }
}
