using BloodTrack.Application.Models;
using MediatR;

namespace BloodTrack.Application.Queries.DonorQueries.GetDonorById
{
    public class GetDonorByIdQuerie : IRequest<ResultViewModel<GetDonorByIdViewModel>>
    {
        public GetDonorByIdQuerie(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
