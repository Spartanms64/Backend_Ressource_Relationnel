using Backend_Ressource_Relationnel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend_Ressource_Relationnel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return await _context.favorite.ToListAsync();
        }

        // GET api/<FavoriteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Favorite>> GetFavorite(int id)
        {
            var favorite = await _context.favorite.FindAsync(id);

            if (favorite == null)
            {
                return NotFound();
            }

            return favorite;
        }

        // POST api/<FavoriteController>
        [HttpPost]
        public async Task<ActionResult<Favorite>> AddFavorite(Favorite favorite)
        {
            _context.favorite.Add(favorite);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFavorite), new { id = favorite.id }, favorite);
        }

        // PUT api/<FavoriteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFavorite(int id, Favorite favorite)
        {
            if (id != favorite.id)
            {
                return BadRequest();
            }

            _context.Entry(favorite).State = EntityState.Modified;

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

            return Ok(favorite);
        }

        // DELETE api/<FavoriteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            var favorite = await _context.favorite.FindAsync(id);

            if (favorite == null)
            {
                return NotFound();
            }

            _context.favorite.Remove(favorite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteExists(int id)
        {
            return _context.favorite.Any(e => e.id == id);
        }
    }
}