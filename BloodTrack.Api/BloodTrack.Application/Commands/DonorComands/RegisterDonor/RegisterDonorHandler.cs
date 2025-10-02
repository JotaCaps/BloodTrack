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
        private readonly IUnitOfWork _unitOfWork;
        public RegisterDonorHandler(IDonorRepository repository, ICepService cepService, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _cepService = cepService;
            _unitOfWork = unitOfWork;
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

            await _repository.Add(donor);

            await _unitOfWork.SaveChangesAsync();

            return ResultViewModel<int>.Success(donor.Id);
        }
    }
}
