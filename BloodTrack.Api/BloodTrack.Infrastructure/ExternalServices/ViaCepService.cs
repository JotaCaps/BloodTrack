using BloodTrack.Application.Services.ExternalServices;
using BloodTrack.Core.ValueObjects;
using BloodTrack.Infrastructure.ExternalServices;
using System.Net.Http.Json;

namespace BloodTrack.Infrastructure.Services
{
    public class ViaCepService : ICepService
    {
        private readonly HttpClient _httpClient;
        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Address?> GetAddressByCepAsync(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8 || !cep.All(char.IsDigit))
                return null;

            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Cep inválido ou não encontrado");

            var viaCepResponse = await response.Content.ReadFromJsonAsync<ViaCepResponse>();

            if (viaCepResponse is null || viaCepResponse.Error)
                throw new Exception("Cep inválido");

            return new Address(viaCepResponse.Logradouro, viaCepResponse.Localidade, viaCepResponse.Uf, viaCepResponse.Cep);
        }

    }
}
