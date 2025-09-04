using BloodTrack.Application.Models;
using BloodTrack.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodTrack.Api.Controllers
{
    [ApiController]
    [Route("api/v1/donors")]
    public class DonorsController : ControllerBase
    {
        private readonly BloodTrackDbContext _context;

        public DonorsController(BloodTrackDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegisterDonorInputModel model)
        {
            var donor = model.ToEntity();

            await _context.Donors.AddAsync(donor);
            await _context.SaveChangesAsync();
            
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var donations = _context.Donors.ToList();
            var model = donations.Select(GetAllDonorsViewModel.FromEntity).ToList();
            
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonorById(int id)
        {
            var donor = await _context.Donors.SingleOrDefaultAsync(x => x.Id == id);
            var model = GetDonorByIdViewModel.FromEntity(donor);

            return Ok(model);
        }

        [HttpGet("{id}/donations")]
        public async Task<IActionResult> GetDonationsByDonorId(int id)
        {
            var donor = await _context.Donors
                .Include(x => x.Donations)
                .SingleOrDefaultAsync(x => x.Id == id);
            
            var donations = donor.Donations
                .Where(d => d.DonorId == id)
                .Select(GetAllDonationsViewModel.FromEntity) 
                .ToList();
            
            return Ok(donations);
        }

        [HttpPut("donors/{id}")]
        public async Task<IActionResult> Put(UpdateDonorInputModel model, int id)      
        {
            var donor = await _context.Donors.SingleOrDefaultAsync(x => x.Id == id);
            donor.Update(model.CompleteName, model.Email, model.BirthDate, model.Gender, model.Weigth, model.BloodTipe, model.RhFactor);

            _context.Donors.Update(donor);
            await _context.SaveChangesAsync();
            
            return Ok(donor.Id);
        }

        [HttpDelete("donors/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var donor = await _context.Donors.SingleOrDefaultAsync(x => x.Id == id);

            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();
            
            return Ok();
        }
    }
}
