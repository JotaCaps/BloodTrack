using BloodTrack.Application.Models;
using MediatR;

namespace BloodTrack.Application.Queries.DonorQueries.GetAllDonors
{
    public class GetAllDonorsQuery : IRequest<ResultViewModel<List<GetAllDonorsViewModel>>>
    {
        
    }
}

