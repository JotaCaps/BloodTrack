namespace BloodTrack.Core.Entities
{
    public class Donor
    {
        public Donor(string completeName, string email, DateTime birthDate, string gender, double weigth, string bloodTipe, string rhFactor)
        {
            CompleteName = completeName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weigth = weigth;
            BloodTipe = bloodTipe;
            RhFactor = rhFactor;
            Donations = [];
        }

        public int Id { get; private set; }
        public string CompleteName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public double Weigth { get; private set; }
        public string BloodTipe { get; private set; }
        public string RhFactor { get; private set; }
        public List<Donation> Donations { get; private set; }

        public void Update(string completeName, string email, DateTime birthDate, string gender, double weigth, string bloodTipe, string rhFactor)
        {
            CompleteName = completeName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weigth = weigth;
            BloodTipe = bloodTipe;
            RhFactor = rhFactor;
        }

    }
}
