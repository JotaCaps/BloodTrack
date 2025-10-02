using BloodTrack.Application.Commands.DonationsCommands.RegisterDonation;
using BloodTrack.Core.Repositories;
using FluentValidation;

namespace BloodTrack.Application.Validators
{
    public class RegisterDonationValidator : AbstractValidator<RegisterDonationCommand>
    {
        private readonly IDonorRepository _donorRepository;
        private readonly IDonationRepository _donationRepository;
        public RegisterDonationValidator(IDonorRepository donorRepository, IDonationRepository donationRepository)
        {
            _donorRepository = donorRepository;
            _donationRepository = donationRepository;

            RuleFor(d => d.AmountMl)
                .NotEmpty()
                    .WithMessage("A quantidade não pode ser vazia")
                .GreaterThanOrEqualTo(420)
                    .WithMessage("A quantidade mínima de sangue que pode ser doada é 420ml")
                .LessThanOrEqualTo(470)
                    .WithMessage("A quantidade máxima de sangue que pode ser doada é 470ml");

            /*
            
            RuleFor(d => d.DonorId)
                .MustAsync(RespectMinAgeAndInterval)
                .WithMessage("O doador não atende os requisitos de idade ou intervalo de doação.");
                    
        }

        private async Task<bool> RespectMinAgeAndInterval(int id, CancellationToken token)
        {
            var donor = await _donorRepository.GetById(id);

            if(donor is null)
                return false;

            var minAge = DateTime.Now.AddYears(-18);
            if (donor.BirthDate.Date < minAge.Date)
                return false;

            var lastDonation = await _donationRepository.GetLastDonationDate(id);

            if (lastDonation != null)
            {
                int requiredDays = donor.Gender == "Feminino" ? 90 : 60;
                var minDate = lastDonation.Value.AddDays(requiredDays);

                if (DateTime.Now.Date > minDate)
                    return false;
            }

            return true;

            */
        }
    }
}
 

