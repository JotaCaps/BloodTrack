namespace BloodTrack.Application.Models
{
    public class RegisterAddressInputModel
    {
        public RegisterAddressInputModel(string zipCode)
        {

            ZipCode = zipCode;
        }

        public string ZipCode { get; private set; }

    }
}
