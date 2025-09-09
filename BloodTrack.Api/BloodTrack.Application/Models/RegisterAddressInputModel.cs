using BloodTrack.Core.Entities;

namespace BloodTrack.Application.Models
{
    public class RegisterAddressInputModel
    {
        public RegisterAddressInputModel(string logradouro, string city, string state, string zipCode)
        {
            Logradouro = logradouro;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public int Id { get; private set; }
        public string Logradouro { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public Address ToEntity()
            => new(Logradouro, City, State, ZipCode);
    }
}
