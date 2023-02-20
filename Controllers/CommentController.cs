using Backend_Ressource_Relationnel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


namespace Backend_Ressource_Relationnel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly DataContext _context;

        public CommentController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<CommentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComment()
        {
            return await _context.comments.ToListAsync();
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comments = await _context.comments.FindAsync(id);
            if (comments == null)
            {
                return NotFound();
            }

            return comments;
        }

        // POST api/<CommentController>
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comments)
        {
            _context.comments.Add(comments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = comments.Id }, comments);
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comments)
        {
            if (id != comments.Id)
            {
                return BadRequest();
            }

            _context.Entry(comments).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

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

            return NoContent();
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var comments = await _context.comments.FindAsync(id);
            if (comments == null)
            {
                return NotFound();
            }

            _context.comments.Remove(comments);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CommentExists(int id)
        {
            return _context.comments.Any(e => e.Id == id);
        }
    }
}
