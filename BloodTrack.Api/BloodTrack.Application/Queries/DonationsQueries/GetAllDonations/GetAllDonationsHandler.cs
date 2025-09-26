using BloodTrack.Application.Models;
using BloodTrack.Core.Repositories;
using MediatR;

namespace BloodTrack.Application.Queries.DonationsQueries.GetAllDonations
{
    public class GetAllDonationsHandler : IRequestHandler<GetAllDonationsQuery, ResultViewModel<List<GetAllDonationsViewModel>>>
    {
        private readonly IDonationRepository _repository;
        public GetAllDonationsHandler(IDonationRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<GetAllDonationsViewModel>>> Handle(GetAllDonationsQuery request, CancellationToken cancellationToken)
        {
            var donations = await _repository.GetAll();

            if (donations == null)
            {
                return ResultViewModel<List<GetAllDonationsViewModel>>.Error("Não existem doações");
            }

            var model = donations.Select(GetAllDonationsViewModel.FromEntity).ToList();

            return ResultViewModel<List<GetAllDonationsViewModel>>.Success(model);
        }
    }
}
