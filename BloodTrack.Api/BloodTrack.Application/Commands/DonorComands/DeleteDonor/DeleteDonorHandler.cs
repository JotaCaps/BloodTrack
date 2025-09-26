using BloodTrack.Application.Models;
using BloodTrack.Core.Repositories;
using MediatR;

namespace BloodTrack.Application.Commands.DonorComands.DeleteDonor
{
    public class DeleteDonorHandler : IRequestHandler<DeleteDonorCommand, ResultViewModel<int>>
    {
        private readonly IDonorRepository _repository;
        public DeleteDonorHandler(IDonorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<int>> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _repository.GetById(request.Id);

            await _repository.Delete(request.Id);

            return ResultViewModel<int>.Success(request.Id);
        }
    }
}
