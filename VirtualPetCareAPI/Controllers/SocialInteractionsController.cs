using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualPetCareAPI.Data;
using VirtualPetCareAPI.Models;

namespace VirtualPetCareAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SocialInteractionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SocialInteractionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<SocialInteraction>> PostSocialInteraction(SocialInteraction socialInteraction)
        {
            _context.SocialInteractions.Add(socialInteraction);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSocialInteraction), new { id = socialInteraction.Id }, socialInteraction);
        }


        [HttpGet("{petId}")]
        public async Task<ActionResult<IEnumerable<SocialInteraction>>> GetSocialInteractionsForPet(int petId)
        {
            var socialInteractions = await _context.SocialInteractions
                                                   .Where(si => si.PetId1 == petId || si.PetId2 == petId)
                                                   .ToListAsync();

            if (socialInteractions == null || socialInteractions.Count == 0)
            {
                return NotFound();
            }

            return Ok(socialInteractions);
        }


        [HttpGet("specific/{id}")]
        public async Task<ActionResult<SocialInteraction>> GetSocialInteraction(int id)
        {
            var socialInteraction = await _context.SocialInteractions.FindAsync(id);

            if (socialInteraction == null)
            {
                return NotFound();
            }

            return socialInteraction;
        }
    }
}
