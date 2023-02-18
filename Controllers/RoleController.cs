using Backend_Ressource_Relationnel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Ressource_Relationnel.Controllers
{
    public class RoleController : ControllerBase
    {

        private readonly DataContext _context;

        public RoleController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<RessourceController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRole()
        {
            return await _context.roles.ToListAsync();
        }

        // GET api/<RessourceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var roles = await _context.roles.FindAsync(id);
            if (roles == null)
            {
                return NotFound();
            }

            return roles;
        }

        // POST api/<RessourceController>
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role roles)
        {
            _context.roles.Add(roles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRole", new { id = roles.Id }, roles);
        }

        // PUT api/<RessourceController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role roles)
        {
            if (id != roles.Id)
            {
                return BadRequest();
            }

            _context.Entry(roles).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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
        public async Task<IActionResult> DeleteRole(int id)
        {
            var roles = await _context.roles.FindAsync(id);
            if (roles == null)
            {
                return NotFound();
            }

            _context.roles.Remove(roles);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool RoleExists(int id)
        {
            return _context.roles.Any(e => e.Id == id);
        }
    }
}
