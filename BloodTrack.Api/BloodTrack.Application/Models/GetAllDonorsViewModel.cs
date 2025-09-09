using BloodTrack.Core.Entities;

namespace BloodTrack.Application.Models
{
    public class GetAllDonorsViewModel
    {
        public GetAllDonorsViewModel(int id, string completeName, string email, DateTime birthDate, string gender, double weigth)
        {
            Id = id;
            CompleteName = completeName;
            Email = email;
            Gender = gender;
            Weigth = weigth;
        }

        public int Id { get; set; }
        public string CompleteName { get; set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public double Weigth { get; set; }

        public static GetAllDonorsViewModel FromEntity(Donor entity)
            => new GetAllDonorsViewModel(entity.Id, entity.CompleteName, entity.Email, entity.BirthDate, entity.Gender, entity.Weigth);
    }
}

