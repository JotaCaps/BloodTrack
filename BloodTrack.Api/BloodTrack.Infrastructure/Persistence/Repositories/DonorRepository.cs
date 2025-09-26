using BloodTrack.Core.Entities;
using BloodTrack.Core.Repositories;
using BloodTrack.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;


namespace BloodTrack.Infrastructure.Persistence.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodTrackDbContext _context;
        public DonorRepository(BloodTrackDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Donor donor, Address address)
        {
            await _context.Donors.AddAsync(donor);
            await _context.SaveChangesAsync();

            return donor.Id;
        }

        public async Task Delete(int id)
        {
            var donor = await _context.Donors.SingleOrDefaultAsync(x => x.Id == id);
            
            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Donor>> GetAll()
        {
            var donors = await _context.Donors.ToListAsync();

            return donors;
        }

        public async Task<Donor> GetDonationByDonorId(int id)
        {
            var donor = await _context.Donors
                .Include(x => x.Donations)
                .SingleOrDefaultAsync(x => x.Id == id);

            return donor;
        }

        public async Task<Donor> GetDetailsById(int id)
        {
            var donor = await _context.Donors.SingleOrDefaultAsync(x => x.Id == id); 
            
            return donor;
        }

        public async Task Update(Donor donor)
        {
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync();
        }

        public async Task<Donor?> GetById(int id)
        {
            return await _context.Donors.SingleOrDefaultAsync(x => x.Id == id);

        }
    }
}
