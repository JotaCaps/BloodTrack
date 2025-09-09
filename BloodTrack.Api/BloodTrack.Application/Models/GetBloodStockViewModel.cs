using BloodTrack.Core.Entities;

namespace BloodTrack.Application.Models
{
    public class GetBloodStockViewModel
    {
        public GetBloodStockViewModel(int id, string bloodType, string rhFactor, int amountMl)
        {
            Id = id;
            BloodType = bloodType;
            RhFactor = rhFactor;
            AmountMl = amountMl;
        }

        public int Id { get; private set; }
        public string BloodType { get; private set; }
        public string RhFactor { get; private set; }
        public int AmountMl { get; private set; }

        public static GetBloodStockViewModel FromEntity(BloodStock entity)
            => new GetBloodStockViewModel(entity.Id, entity.BloodType, entity.RhFactor, entity.AmountMl);
    }
}
