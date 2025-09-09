using BloodTrack.Application.Models;
using BloodTrack.Core.Entities;
using BloodTrack.Infrastructure.Persistence;

namespace BloodTrack.Core.Services
{
    public class BloodStockService
    {
        private readonly BloodTrackDbContext _context;
        public void RegisterBloodStock(RegisterDonationInputModel model, Donor donor, int id)
        {
            donor = _context.Donors.SingleOrDefault(x => x.Id == id);
            if (donor == null)
                return;


            var bloodStock = _context.BloodStocks.SingleOrDefault(b => b.BloodType == donor.BloodTipe && b.RhFactor == donor.RhFactor);

            if (bloodStock == null)
            {
                var newBloodStock = new BloodStock(donor.BloodTipe, donor.RhFactor, model.AmountMl);
                _context.BloodStocks.AddAsync(newBloodStock);

            }
            else
            {
                bloodStock.UpdateStock(model.AmountMl);
            }

            _context.SaveChangesAsync();
        }
    }
}
