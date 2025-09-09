using BloodTrack.Core.Entities;

namespace BloodTrack.Application.Models
{
    public class RegisterDonationInputModel
    {
        public RegisterDonationInputModel(int donorId, int amountMl)
        {
            DonorId = donorId;
            AmountMl = amountMl;
        }
        public int DonorId { get; set; }
        public int AmountMl { get; set; }

        public Donation ToEntity()
            => new(DonorId, AmountMl);

    }
}

