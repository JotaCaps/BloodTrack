using BloodTrack.Application.Models;
using BloodTrack.Application.Services.ExternalServices;
using BloodTrack.Core.Entities;
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
        private readonly ICepService _cepService;
        public DonorsController(BloodTrackDbContext context, ICepService cepService)
        {
            _context = context;
            _cepService = cepService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegisterDonorInputModel model)
        {
            var address = await _cepService.GetAddressByCepAsync(model.ZipCode);

            if (address == null)
                return BadRequest("CEP inválido ou não encontrado.");

            var donor = new Donor(model.CompleteName, 
                model.Email, 
                model.BirthDate, 
                model.Gender, 
                model.Weigth, 
                model.BloodTipe, 
                model.RhFactor, 
                address);



            await _context.Donors.AddAsync(donor);

            Console.WriteLine($"Logradouro: {address.Logradouro}");
            Console.WriteLine($"City: {address.City}");
            Console.WriteLine($"State: {address.State}");
            Console.WriteLine($"ZipCode: {address.ZipCode}");

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
