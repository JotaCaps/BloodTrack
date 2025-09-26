using BloodTrack.Application.Models;
using MediatR;

namespace BloodTrack.Application.Queries.DonorQueries.GetDonationByDonorId
{
    public class GetDonationsByDonorIdQuery : IRequest<ResultViewModel<List<GetAllDonationsViewModel>>>
    {
        public GetDonationsByDonorIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
