using BloodTrack.Application.Models;
using BloodTrack.Core.Entities;
using MediatR;

namespace BloodTrack.Application.Queries.DonationsQueries.GetDonationById
{
    public class GetDonationByIdQuerie : IRequest<ResultViewModel<GetDonationByIdViewModel>>
    {
        public GetDonationByIdQuerie(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
