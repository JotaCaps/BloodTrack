using BloodTrack.Core.Entities;

namespace BloodTrack.Core.Repositories
{
    public interface IDonorRepository
    {
        Task Add(Donor donor);
        Task Update(Donor donor);
        Task Delete(Donor donor);
        Task<List<Donor>> GetAll();
        Task<Donor> GetDetailsById(int id);
        Task<Donor> GetDonationByDonorId(int id);
        Task<Donor?> GetById(int id);
        Task<Donor> GetByEmail(string email);



    }
}
