using BloodTrack.Core.Repositories;

namespace BloodTrack.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BloodTrackDbContext _context;

        public UnitOfWork(BloodTrackDbContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
