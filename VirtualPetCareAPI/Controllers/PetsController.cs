using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualPetCareAPI.Data;
using VirtualPetCareAPI.Models;

namespace VirtualPetCareAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPet", new { id = pet.Id }, pet);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            return Ok(await _context.Pets.ToListAsync());
        }

        [HttpGet("{petId}")]
        public async Task<ActionResult<Pet>> GetPet(int petId)
        {
            var pet = await _context.Pets.FindAsync(petId);
            if (pet == null)
            {
                return NotFound();
            }
            return pet;
        }

        [HttpPut("{petId}")]
        public async Task<IActionResult> PutPet(int petId, Pet pet)
        {
            if (petId != pet.Id)
            {
                return BadRequest();
            }

            _context.Entry(pet).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(petId))
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

        private bool PetExists(int id)
        {
            return _context.Pets.Any(e => e.Id == id);
        }

        [HttpGet("istatistikler/{petId}")]
        public async Task<ActionResult<PetStatistics>> GetPetStatistics(int petId)
        {
            var pet = await _context.Pets
                                    .Include(p => p.Activities)
                                    .Include(p => p.Foods)
                                    .Include(p => p.HealthStatuses)
                                    .FirstOrDefaultAsync(p => p.Id == petId);
            if (pet == null)
            {
                return NotFound();
            }

            var petStatistics = new PetStatistics
            {
                Activities = pet.Activities,
                Foods = pet.Foods,
                HealthStatuses = pet.HealthStatuses
            };

            return Ok(petStatistics);
        }


    }
}
