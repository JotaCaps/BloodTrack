using BloodTrack.Application.Models;
using MediatR;

namespace BloodTrack.Application.Commands.DonorComands.UpdateDonor
{
    public class UpdateDonorCommand : IRequest<ResultViewModel>
    {
        public UpdateDonorCommand(string completeName, string email, DateTime birthDate, string gender, double weigth, string bloodTipe, string rhFactor)
        {
            CompleteName = completeName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weigth = weigth;
            BloodTipe = bloodTipe;
            RhFactor = rhFactor;
        }

        public int Id { get; set; }
        public string CompleteName { get; set; }
        public string Email { get;  set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public double Weigth { get; set; }
        public string BloodTipe { get; set; }
        public string RhFactor { get; set; }
    }
}

