using BloodTrack.Core.Entities;
using BloodTrack.Core.ValueObjects;

namespace BloodTrack.Core.Repositories
{
    public interface IDonorRepository
    {
        Task<int> Add(Donor donor, Address address);
        Task Update(Donor donor);
        Task Delete(int id);
        Task<List<Donor>> GetAll();
        Task<Donor> GetDetailsById(int id);
        Task<Donor> GetDonationByDonorId(int id);
        Task<Donor?> GetById(int id);



    }
}
