using BloodTrack.Application.Models;
using BloodTrack.Core.Repositories;
using MediatR;

namespace BloodTrack.Application.Queries.DonorQueries.GetAllDonors
{
    public class GetAllDonorsHandler : IRequestHandler<GetAllDonorsQuerie, ResultViewModel<List<GetAllDonorsViewModel>>>
    {
        private readonly IDonorRepository _repository;
        public GetAllDonorsHandler(IDonorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<GetAllDonorsViewModel>>> Handle(GetAllDonorsQuerie request, CancellationToken cancellationToken)
        {
            var donations = await _repository.GetAll();
            var model = donations.Select(GetAllDonorsViewModel.FromEntity).ToList();

            return ResultViewModel<List<GetAllDonorsViewModel>>.Success(model);
        }
    }
}
