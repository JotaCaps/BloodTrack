using BloodTrack.Core.ValueObjects;

namespace BloodTrack.Application.Services.ExternalServices
{
    public interface ICepService
    {
        Task<Address> GetAddressByCepAsync(string cep);
    }
}
