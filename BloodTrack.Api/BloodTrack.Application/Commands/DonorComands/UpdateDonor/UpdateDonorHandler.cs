using BloodTrack.Application.Models;
using BloodTrack.Core.Repositories;
using MediatR;

namespace BloodTrack.Application.Commands.DonorComands.UpdateDonor
{
    public class UpdateDonorHandler : IRequestHandler<UpdateDonorCommand, ResultViewModel>
    {
        private readonly IDonorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateDonorHandler(IDonorRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;

        }
        public async Task<ResultViewModel> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _repository.GetById(request.Id);

            if (donor is null)
            {
                return ResultViewModel.Error("Doador não existe");
            }

            donor.Update(request.CompleteName, request.Email, request.BirthDate, request.Gender, request.Weigth, request.BloodTipe, request.RhFactor);

            await _repository.Update(donor);

            await _unitOfWork.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
