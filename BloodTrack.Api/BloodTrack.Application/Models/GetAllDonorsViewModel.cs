using BloodTrack.Core.Entities;

namespace BloodTrack.Application.Models
{
    public class GetAllDonorsViewModel
    {
        public GetAllDonorsViewModel(int id, string completeName, string email, DateTime birthDate, string gender, double weigth, string bloodTipe, string rhFactor)
        {
            Id = id;
            CompleteName = completeName;
            Email = email;
            Gender = gender;
            BloodTipe = bloodTipe;
            RhFactor = rhFactor;
        }

        public int Id { get; set; }
        public string CompleteName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string BloodTipe { get; set; }
        public string RhFactor { get; set; }

        public static GetAllDonorsViewModel FromEntity(Donor entity)
         => new GetAllDonorsViewModel(entity.Id, entity.CompleteName, entity.Email, entity.BirthDate, entity.Gender, entity.Weigth, entity.BloodTipe, entity.RhFactor);
    }
}


