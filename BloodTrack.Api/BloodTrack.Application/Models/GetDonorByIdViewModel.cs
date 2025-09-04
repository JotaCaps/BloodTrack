using BloodTrack.Core.Entities;

namespace BloodTrack.Application.Models
{
    public class GetDonorByIdViewModel
    {
        public GetDonorByIdViewModel(int id, string completeName, string email, DateTime birthDate, string gender, double weigth, string bloodTipe, string rhFactor)
        {
            Id = id;
            CompleteName = completeName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weigth = weigth;
            BloodTipe = bloodTipe;
            RhFactor = rhFactor;
        }

        public int Id { get; private set; }
        public string CompleteName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public double Weigth { get; private set; }
        public string BloodTipe { get; private set; }
        public string RhFactor { get; private set; }

        public static GetDonorByIdViewModel FromEntity(Donor entity)
            => new GetDonorByIdViewModel(entity.Id, entity.CompleteName, entity.Email, entity.BirthDate, entity.Gender, entity.Weigth, entity.BloodTipe, entity.RhFactor);

    }
}

