using BloodTrack.Application.Models;
using MediatR;

namespace BloodTrack.Application.Queries.DonorQueries.GetAllDonors
{
    public class GetAllDonorsQuerie : IRequest<ResultViewModel<List<GetAllDonorsViewModel>>>
    {
        
    }
}

