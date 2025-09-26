using BloodTrack.Core.Entities;
using BloodTrack.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodTrack.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly BloodTrackDbContext _context;

        public DonationRepository(BloodTrackDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Donation donation)
        {
            await _context.Donations.AddAsync(donation);
            await _context.SaveChangesAsync();

            return donation.Id;
        }

        public async Task<List<Donation>> GetAll()
        {
            var donations = await _context.Donations.ToListAsync();

            return donations;
        }

        public async Task<Donation> GetById(int id)
        {
            var donation = await _context.Donations.SingleOrDefaultAsync(x => x.Id == id);

            return donation;
        }

        public async Task<Donation> GetDetails(int id)
        {
            var donation = await _context.Donations.SingleOrDefaultAsync(x => x.Id == id);
            
            return donation;
        }

        public async Task<Donor> GetDonorById(int id)
        {
            var donor = await _context.Donors
                .Include(x => x.Donations)
                .SingleOrDefaultAsync(x => x.Id == id);
            return donor;
        }
    }
}
