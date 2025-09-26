using BloodTrack.Application.Models;
using MediatR;

namespace BloodTrack.Application.Queries.DonationsQueries.GetAllDonations
{
    public class GetAllDonationsQuerie : IRequest<ResultViewModel<List<GetAllDonationsViewModel>>>
    {

    }
}
