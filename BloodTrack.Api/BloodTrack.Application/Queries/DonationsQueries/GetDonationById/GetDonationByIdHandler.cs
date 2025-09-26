using BloodTrack.Application.Models;
using BloodTrack.Core.Repositories;
using MediatR;

namespace BloodTrack.Application.Queries.DonationsQueries.GetDonationById
{
    public class GetDonationByIdHandler : IRequestHandler<GetDonationByIdQuery, ResultViewModel<GetDonationByIdViewModel>>
    {
        private readonly IDonationRepository _repository;
        public GetDonationByIdHandler(IDonationRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<GetDonationByIdViewModel>> Handle(GetDonationByIdQuery request, CancellationToken cancellationToken)
        {
            var donation = await _repository.GetById(request.Id);

            if (donation == null)
            {
                return ResultViewModel<GetDonationByIdViewModel>.Error("Doação não existe");
            }

            var model = GetDonationByIdViewModel.FromEntity(donation);

            return ResultViewModel<GetDonationByIdViewModel>.Success(model);     
        }

    }
}
