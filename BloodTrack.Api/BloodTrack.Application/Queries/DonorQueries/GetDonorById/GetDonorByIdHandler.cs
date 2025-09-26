using BloodTrack.Application.Models;
using BloodTrack.Core.Repositories;
using MediatR;

namespace BloodTrack.Application.Queries.DonorQueries.GetDonorById
{
    public class GetDonorByIdHandler : IRequestHandler<GetDonorByIdQuery, ResultViewModel<GetDonorByIdViewModel>>
    {
        private readonly IDonorRepository _repository;
        public GetDonorByIdHandler(IDonorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<GetDonorByIdViewModel>> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
        {
            var donor = await _repository.GetDetailsById(request.Id);

            if (donor == null)
            {
                return ResultViewModel<GetDonorByIdViewModel>.Error("Doador não existe");
            }

            var model = GetDonorByIdViewModel.FromEntity(donor);

            return ResultViewModel<GetDonorByIdViewModel>.Success(model);
        }
    }
}
