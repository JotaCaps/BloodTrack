namespace BloodTrack.Core.Entities
{
    public class Donation
    {
        public Donation(int donorId, int amountMl)
        {
            DonorId = donorId;
            DonationDate = DateTime.Now;
            AmountMl = amountMl;
        }

        public int Id { get; private set; }
        public int DonorId { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int AmountMl { get; private set; }
        public Donor Donor { get; private set; }

    }
}
