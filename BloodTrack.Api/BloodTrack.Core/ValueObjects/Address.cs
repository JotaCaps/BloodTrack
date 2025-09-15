namespace BloodTrack.Core.ValueObjects
{
    public class Address
    {
        public Address(string logradouro, string city, string state, string zipCode)
        {
            Logradouro = logradouro;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string Logradouro { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public override bool Equals(object? obj)
        {
            return obj is Address address &&
                   Logradouro == address.Logradouro &&
                   City == address.City &&
                   State == address.State &&
                   ZipCode == address.ZipCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Logradouro, City, State, ZipCode);
        }
    }
}
