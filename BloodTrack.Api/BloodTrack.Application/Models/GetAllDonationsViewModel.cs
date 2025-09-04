using BloodTrack.Core.Entities;

namespace BloodTrack.Application.Models
{
    public class GetAllDonationsViewModel
    {
        public GetAllDonationsViewModel(int donorId, int amountMl)
        {
            DonorId = donorId;
            AmountMl = amountMl;
        }

        public int Id { get; set; }
        public int DonorId { get; set; }
        public int AmountMl { get; set; }

        public static GetAllDonationsViewModel FromEntity(Donation entity)
            => new GetAllDonationsViewModel(entity.DonorId, entity.AmountMl)
            {
                Id = entity.Id
            };
    }
}
