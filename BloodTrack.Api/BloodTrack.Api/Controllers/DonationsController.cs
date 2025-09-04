using BloodTrack.Application.Models;
using BloodTrack.Core.Entities;
using BloodTrack.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodTrack.Api.Controllers
{
    [ApiController]
    [Route("api/v1/donations")]
    public class DonationsController : ControllerBase
    {
        private readonly BloodTrackDbContext _context;

        public DonationsController(BloodTrackDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegisterDonationInputModel model, int id)
        {
            var donor = await _context.Donors.SingleOrDefaultAsync(x => x.Id == id);
            if (donor == null)
                return NotFound("Doador não existe");

            var donation = model.ToEntity();
            donor.Donations.Add(donation);

            await _context.Donations.AddAsync(donation);
            await _context.SaveChangesAsync();
            
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var donations = await _context.Donations.ToListAsync();
            var model = donations.Select(GetAllDonationsViewModel.FromEntity).ToList();

            return Ok(donations);
        }

        [HttpGet("donations/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var donation = await _context.Donations.SingleOrDefaultAsync(x => x.Id == id);
            var model = GetDonationByIdViewModel.FromEntity(donation);

            return Ok(model);
        }

    }
}
