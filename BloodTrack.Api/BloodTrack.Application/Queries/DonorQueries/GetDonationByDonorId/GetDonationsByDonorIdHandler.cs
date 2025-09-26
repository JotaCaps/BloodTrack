using BloodTrack.Application.Models;
using BloodTrack.Core.Repositories;
using MediatR;

namespace BloodTrack.Application.Queries.DonorQueries.GetDonationByDonorId
{
    public class GetDonationsByDonorIdHandler : IRequestHandler<GetDonationsByDonorIdQuerie, ResultViewModel<List<GetAllDonationsViewModel>>>
    {
        private readonly IDonorRepository _repository;
        public GetDonationsByDonorIdHandler(IDonorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<GetAllDonationsViewModel>>> Handle(GetDonationsByDonorIdQuerie request, CancellationToken cancellationToken)
        {
            var donor = await _repository.GetDonationByDonorId(request.Id);

            if (donor == null)
                return ResultViewModel<List<GetAllDonationsViewModel>>.Error("Doador não encontrado.");

            if (donor.Donations == null)
                return ResultViewModel<List<GetAllDonationsViewModel>>.Error("O doador não possui doações.");

            var donations = donor.Donations
                .Select(GetAllDonationsViewModel.FromEntity)
                .ToList();

            return ResultViewModel<List<GetAllDonationsViewModel>>.Success(donations);
        }
    }
}
