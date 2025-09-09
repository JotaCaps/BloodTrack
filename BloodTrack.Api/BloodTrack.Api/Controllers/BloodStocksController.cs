using BloodTrack.Application.Models;
using BloodTrack.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodTrack.Api.Controllers
{
    [ApiController]
    [Route("api/v1/bloodstocks")]
    public class BloodStocksController : ControllerBase
    {
        private readonly BloodTrackDbContext _context;

        public BloodStocksController(BloodTrackDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bloodStocks = _context.BloodStocks.ToList();
            var model = bloodStocks.Select(GetBloodStockViewModel.FromEntity).ToList();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBloodStockById(int id)
        {
            var bloodStock = await _context.BloodStocks.SingleOrDefaultAsync(x => x.Id == id);
            var model = GetBloodStockViewModel.FromEntity(bloodStock);
            
            return Ok(model);
        }
    }
}
