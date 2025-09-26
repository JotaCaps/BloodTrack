using BloodTrack.Application.Models;
using BloodTrack.Application.Services.ExternalServices;
using BloodTrack.Core.Entities;
using BloodTrack.Core.Repositories;
using MediatR;

namespace BloodTrack.Application.Commands.DonorComands.RegisterDonor
{
    public class RegisterDonorHandler : IRequestHandler<RegisterDonorCommand, ResultViewModel<int>>
    {
        
        private readonly IDonorRepository _repository;
        private readonly ICepService _cepService;
        public RegisterDonorHandler(IDonorRepository repository, ICepService cepService)
        {
            _repository = repository;
            _cepService = cepService;
        }
        public async Task<ResultViewModel<int>> Handle(RegisterDonorCommand request, CancellationToken cancellationToken)
        {
            var address = await _cepService.GetAddressByCepAsync(request.ZipCode);

            if (address == null)
                return ResultViewModel<int>.Error("CEP inválido ou não encontrado.");
            
            var donor = new Donor(request.CompleteName,
                request.Email,
                request.BirthDate,
                request.Gender,
                request.Weigth,
                request.BloodTipe,
                request.RhFactor,
                address);

            await _repository.Add(donor, address);

            return ResultViewModel<int>.Success(donor.Id);
        }
    }
}
