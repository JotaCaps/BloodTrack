using BloodTrack.Application.Models;
using BloodTrack.Core.Repositories;
using MediatR;

namespace BloodTrack.Application.Commands.DonorComands.DeleteDonor
{
    public class DeleteDonorHandler : IRequestHandler<DeleteDonorCommand, ResultViewModel<int>>
    {
        private readonly IDonorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteDonorHandler(IDonorRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;

        }
        public async Task<ResultViewModel<int>> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _repository.GetById(request.Id);

            if (donor is null)
            {
                return ResultViewModel<int>.Error("Doador não existe");
            }

            await _repository.Delete(donor);

            await _unitOfWork.SaveChangesAsync();

            return ResultViewModel<int>.Success(request.Id);
        }
    }
}
