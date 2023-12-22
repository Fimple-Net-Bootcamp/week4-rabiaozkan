using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualPetCareAPI.Data;
using VirtualPetCareAPI.Models;

namespace VirtualPetCareAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpGet("istatistikler/{userId}")]
        public async Task<ActionResult<UserStatistics>> GetUserStatistics(int userId)
        {
            var userPets = await _context.Pets
                                         .Where(p => p.UserId == userId)
                                         .Include(p => p.Activities)
                                         .Include(p => p.Foods)
                                         .Include(p => p.HealthStatuses)
                                         .ToListAsync();

            var userStatistics = new UserStatistics
            {
                Pets = userPets
            };

            return Ok(userStatistics);
        }

    }
}
