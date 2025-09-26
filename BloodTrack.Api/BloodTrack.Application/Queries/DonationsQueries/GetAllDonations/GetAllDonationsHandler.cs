using BloodTrack.Application.Models;
using BloodTrack.Core.Repositories;
using MediatR;

namespace BloodTrack.Application.Queries.DonationsQueries.GetAllDonations
{
    public class GetAllDonationsHandler : IRequestHandler<GetAllDonationsQuerie, ResultViewModel<List<GetAllDonationsViewModel>>>
    {
        private readonly IDonationRepository _repository;
        public GetAllDonationsHandler(IDonationRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<GetAllDonationsViewModel>>> Handle(GetAllDonationsQuerie request, CancellationToken cancellationToken)
        {
            var donations = await _repository.GetAll();
            var model = donations.Select(GetAllDonationsViewModel.FromEntity).ToList();

            return ResultViewModel<List<GetAllDonationsViewModel>>.Success(model);
        }
    }
}
