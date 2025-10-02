using BloodTrack.Application.Commands.DonorComands.RegisterDonor;
using BloodTrack.Core.Entities;
using BloodTrack.Core.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodTrack.Application.Validators
{
    public class RegisterDonorValidator : AbstractValidator<RegisterDonorCommand>
    {
        private readonly IDonorRepository _donorRepository;
        public RegisterDonorValidator(IDonorRepository donorDepository)
        {
            _donorRepository = donorDepository;

            RuleFor(d => d.CompleteName)
                .NotEmpty()
                    .WithMessage("O nome não pode ser vazio")
                .MinimumLength(2)
                    .WithMessage("O nome deve ter no mínimo 2 caracteres")
                .MaximumLength(100)
                    .WithMessage("O nome deve ter no máximo 100 caracteres");

            RuleFor(d => d.BirthDate)
                .LessThan(DateTime.Now.Date)
                    .WithMessage("A data de nascimento deve ser menor que a data atual");

            RuleFor(d => d.Weigth)
                .GreaterThanOrEqualTo(50)
                    .WithMessage("O peso mínimo para doação é 50kg");


            /*RuleFor(d => d.Email)
                .NotEmpty()
                    .WithMessage("O email não pode ser vazio")
                .EmailAddress()
                    .WithMessage("O email deve ser um email válido")
                .MustAsync(BeUniqueEmail)
                    .WithMessage("Já existe um doador cadastrado com esse email");
            }

            private async Task<bool> BeUniqueEmail(string email, CancellationToken token)
        {
            var donor = await _donorRepository.GetByEmail(email);

            return donor == null;
        }
            */
        }
    }
}

