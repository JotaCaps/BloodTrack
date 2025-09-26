using BloodTrack.Core.Entities;

namespace BloodTrack.Core.Repositories
{
    public interface IDonationRepository
    {
        Task<int> Add(Donation donation);
        Task<List<Donation>> GetAll();
        Task<Donation> GetById(int id);
        Task<Donation> GetDetails(int id);
        Task<Donor> GetDonorById(int id);
    }
}
