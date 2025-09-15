using BloodTrack.Application.Models;
using BloodTrack.Core.Entities;

namespace BloodTrack.Application.Services.BloodStockServices
{
    public interface IBloodStockService
    {
        void RegisterBloodStock(RegisterDonationInputModel model, Donor donor, int id);
        
    }
}
