using BloodTrack.Core.Entities;

namespace BloodTrack.Application.Models
{
    public class GetDonorByIdViewModel
    {
        public GetDonorByIdViewModel(int id, string completeName, string email, DateTime birthDate, string gender, double weigth, string bloodType, string rhFactor)
        {
            Id = id;
            CompleteName = completeName;
            Email = email;
            Gender = gender;
            Weigth = weigth;
            BloodTipe = bloodType;
            RhFactor = rhFactor;
        }

        public int Id { get; set; }
        public string CompleteName { get; set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public double Weigth { get; set; }
        public string BloodTipe { get; set; }
        public string RhFactor { get; set; }

        public static GetDonorByIdViewModel FromEntity(Donor entity)
            => new GetDonorByIdViewModel(entity.Id, entity.CompleteName, entity.Email, entity.BirthDate, entity.Gender, entity.Weigth, entity.BloodTipe, entity.RhFactor);
    }
}


