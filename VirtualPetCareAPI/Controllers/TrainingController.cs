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
    public class TrainingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TrainingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Training>> PostTraining(Training training)
        {
            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTraining), new { id = training.Id }, training);
        }

        [HttpGet("{petId}")]
        public async Task<ActionResult<IEnumerable<Training>>> GetTrainingsForPet(int petId)
        {
            var trainings = await _context.Trainings
                                          .Where(t => t.PetId == petId)
                                          .ToListAsync();

            if (trainings == null || trainings.Count == 0)
            {
                return NotFound();
            }

            return Ok(trainings);
        }

        [HttpGet("specific/{id}")]
        public async Task<ActionResult<Training>> GetTraining(int id)
        {
            var training = await _context.Trainings.FindAsync(id);

            if (training == null)
            {
                return NotFound();
            }

            return training;
        }
    }
}
