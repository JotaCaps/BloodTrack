using BloodTrack.Core.Entities;
using BloodTrack.Core.Repositories;
using Microsoft.EntityFrameworkCore;


namespace BloodTrack.Infrastructure.Persistence.Repositories
{
    public class BloodStockRepository : IBloodStockRepository
    {
        private readonly BloodTrackDbContext _context;
        public BloodStockRepository(BloodTrackDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(BloodStock bloodStock)
        {
            await _context.BloodStocks.AddAsync(bloodStock);
            await _context.SaveChangesAsync();
            return bloodStock.Id;
        }

        public async Task<BloodStock> Exists(Donor donor)
        {
            return await _context
                .BloodStocks
                .SingleOrDefaultAsync(b => b.BloodType == donor.BloodTipe && 
                b.RhFactor == donor.RhFactor);

        }

        public async Task<List<BloodStock>> GetAll()
        {
            var bloodStocks = await _context.BloodStocks.ToListAsync();

            return bloodStocks;
        }

        public async Task<BloodStock> GetById(int id)
        {
            var bloodStock = await _context.BloodStocks.SingleOrDefaultAsync(x => x.Id == id);

            return bloodStock;
        }

        public async Task Update(BloodStock bloodStock)
        {
            _context.BloodStocks.Update(bloodStock);
            await _context.SaveChangesAsync();  
        }
    }
}
