using BloodTrack.Core.Entities;

namespace BloodTrack.Application.Models
{
    public class RegisterDonationInputModel
    {
        public RegisterDonationInputModel(int donorId, int amountMl)
        {
            DonorId = donorId;
            DonationDate = DateTime.Now;
            AmountMl = amountMl;
        }

        public int Id { get; set; }
        public int DonorId { get; set; }
        public DateTime DonationDate { get; set; }
        public int AmountMl { get; set; }

        public Donation ToEntity()
         => new(DonorId, AmountMl);

    }
}

