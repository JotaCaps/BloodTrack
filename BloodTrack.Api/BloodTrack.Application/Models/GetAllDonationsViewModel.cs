using BloodTrack.Core.Entities;

namespace BloodTrack.Application.Models
{
    public class GetAllDonationsViewModel
    {
        public GetAllDonationsViewModel(int id, int donorId, DateTime donationDate, int amountMl)
        {
            DonorId = donorId;
            DonationDate = donationDate;
            AmountMl = amountMl;
            Id = id;
        }

        public int Id { get; set; }
        public int DonorId { get; set; }
        public DateTime DonationDate { get; set; }
        public int AmountMl { get; set; }

        public static GetAllDonationsViewModel FromEntity(Donation entity)
            => new GetAllDonationsViewModel(entity.Id, entity.DonorId, entity.DonationDate, entity.AmountMl);
        
    }
}
