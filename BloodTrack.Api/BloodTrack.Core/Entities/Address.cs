namespace BloodTrack.Core.Entities
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

        public int Id { get; private set; }
        public string Logradouro { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public Donor Donor { get; private set; }
    }
}
