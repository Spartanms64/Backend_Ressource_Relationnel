using Backend_Ressource_Relationnel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Ressource_Relationnel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly DataContext _context;

        public CommentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _context.comment
                .Include(c=>c.user)
                .Include(c=>c.resource)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _context.comment
                .Include(c => c.id_user)
                .Include(c => c.id_resource)
                .FirstOrDefaultAsync(c => c.id == id);
            if (comment == null)
            {
                return NotFound();
            }
            return comment;
        }

        //Ajout
        [HttpPost]
        public async Task<ActionResult<Comment>> AddComment(Comment comment)
        {
            _context.comment.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComment), new { id = comment.id }, comment);
        }

        //mise a jour
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, Comment comment)
        {
            if (id != comment.id)
            {
                return BadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(comment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.comment.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            _context.comment.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentExists(int id)
        {
            return _context.comment.Any(e => e.id == id);
        }
    }
}