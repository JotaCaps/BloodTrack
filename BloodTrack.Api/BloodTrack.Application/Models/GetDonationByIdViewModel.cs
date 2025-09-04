using BloodTrack.Core.Entities;

namespace BloodTrack.Application.Models
{
    public class GetDonationByIdViewModel
    {
        public GetDonationByIdViewModel(int id, int donorId, int amountMl)
        {
            Id = id;
            DonorId = donorId;
            AmountMl = amountMl;
        }

        public int Id { get; set; }
        public DateTime DonationDate { get; set; }
        public int DonorId { get; set; }
        public int AmountMl { get; set; }

        public static GetDonationByIdViewModel FromEntity(Donation entity)
            => new GetDonationByIdViewModel(entity.Id, entity.DonorId, entity.AmountMl)
            { 
                DonationDate = entity.DonationDate
            };
    }
}

