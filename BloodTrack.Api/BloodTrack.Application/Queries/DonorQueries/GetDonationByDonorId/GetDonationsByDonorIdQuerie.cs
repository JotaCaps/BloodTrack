using BloodTrack.Application.Models;
using MediatR;

namespace BloodTrack.Application.Queries.DonorQueries.GetDonationByDonorId
{
    public class GetDonationsByDonorIdQuerie : IRequest<ResultViewModel<List<GetAllDonationsViewModel>>>
    {
        public GetDonationsByDonorIdQuerie(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
