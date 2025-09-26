using BloodTrack.Application.Models;
using MediatR;

namespace BloodTrack.Application.Queries.DonorQueries.GetDonorById
{
    public class GetDonorByIdQuery : IRequest<ResultViewModel<GetDonorByIdViewModel>>
    {
        public GetDonorByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
