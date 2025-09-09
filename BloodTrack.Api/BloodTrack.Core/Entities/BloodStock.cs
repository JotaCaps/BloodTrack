namespace BloodTrack.Core.Entities
{
    public class BloodStock
    {
        public BloodStock(string bloodType, string rhFactor, int amountMl)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            AmountMl = amountMl;
        }

        public int Id { get; private set; }
        public string BloodType { get; private set; }
        public string RhFactor { get; private set; }
        public int AmountMl { get; private set; }

        public void UpdateStock(int amount)
        {
            AmountMl += amount;
        }
    }
}
