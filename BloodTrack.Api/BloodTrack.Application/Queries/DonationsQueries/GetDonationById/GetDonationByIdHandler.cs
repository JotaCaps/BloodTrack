using BloodTrack.Application.Models;
using BloodTrack.Core.Repositories;
using MediatR;

namespace BloodTrack.Application.Queries.DonationsQueries.GetDonationById
{
    public class GetDonationByIdHandler : IRequestHandler<GetDonationByIdQuerie, ResultViewModel<GetDonationByIdViewModel>>
    {
        private readonly IDonationRepository _repository;
        public GetDonationByIdHandler(IDonationRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<GetDonationByIdViewModel>> Handle(GetDonationByIdQuerie request, CancellationToken cancellationToken)
        {
            var donation = await _repository.GetById(request.Id);
            var model = GetDonationByIdViewModel.FromEntity(donation);

            return ResultViewModel<GetDonationByIdViewModel>.Success(model);     
        }

    }
}
