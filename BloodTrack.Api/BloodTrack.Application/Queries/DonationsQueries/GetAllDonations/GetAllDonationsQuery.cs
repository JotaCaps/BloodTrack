using BloodTrack.Application.Models;
using MediatR;

namespace BloodTrack.Application.Queries.DonationsQueries.GetAllDonations
{
    public class GetAllDonationsQuery : IRequest<ResultViewModel<List<GetAllDonationsViewModel>>>
    {

    }
}
