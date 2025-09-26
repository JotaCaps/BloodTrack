using BloodTrack.Application.Models;
using BloodTrack.Core.Entities;
using MediatR;

namespace BloodTrack.Application.Queries.DonationsQueries.GetDonationById
{
    public class GetDonationByIdQuery : IRequest<ResultViewModel<GetDonationByIdViewModel>>
    {
        public GetDonationByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
