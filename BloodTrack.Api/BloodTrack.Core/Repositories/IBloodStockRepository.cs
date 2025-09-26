using BloodTrack.Core.Entities;

namespace BloodTrack.Core.Repositories
{
    public interface IBloodStockRepository
    {
        Task<int> Add(BloodStock bloodStock);
        Task<List<BloodStock>> GetAll();
        Task<BloodStock> GetById(int id);
        Task Update(BloodStock bloodStock);
        Task<BloodStock> Exists(Donor donor);
    }
}
