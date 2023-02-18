using Backend_Ressource_Relationnel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Ressource_Relationnel.Controllers
{
    public class FavoriteController : ControllerBase
    {
        private readonly DataContext _context;

        public FavoriteController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<FavoriteController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favorite>>> GetFavorite()
        {
            return await _context.favorites.ToListAsync();
        }

        // GET api/<FavoriteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Favorite>> GetFavorite(int id)
        {
            var favorites = await _context.favorites.FindAsync(id);
            if (favorites == null)
            {
                return NotFound();
            }

            return favorites;
        }

        // POST api/<FavoriteController>
        [HttpPost]
        public async Task<ActionResult<Favorite>> PostFavorite(Favorite favorite)
        {
            _context.favorites.Add(favorite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavorite", new { id = favorite.Id }, favorite);
        }

        // PUT api/<FavoriteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavorite(int id, Favorite favorite)
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
                if (!FavoriteExists(id))
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

        // DELETE api/<FavoriteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            var favorites = await _context.favorites.FindAsync(id);
            if (favorites == null)
            {
                return NotFound();
            }

            _context.favorites.Remove(favorites);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool FavoriteExists(int id)
        {
            return _context.favorites.Any(e => e.Id == id);
        }
    }
}
