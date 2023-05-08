using Backend_Ressource_Relationnel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Ressource_Relationnel.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;


        [Authorize(Roles = "Administrateur")]
        [HttpGet]
    
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }


    }
}
