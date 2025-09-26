using BloodTrack.Application.Models;
using MediatR;

namespace BloodTrack.Application.Commands.DonorComands.DeleteDonor
{
    public class DeleteDonorCommand : IRequest<ResultViewModel<int>>
    {
        public DeleteDonorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
