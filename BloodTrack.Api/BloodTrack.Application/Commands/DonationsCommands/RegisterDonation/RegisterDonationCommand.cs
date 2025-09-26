using BloodTrack.Application.Models;
using BloodTrack.Core.Entities;
using MediatR;

namespace BloodTrack.Application.Commands.DonationsCommands.RegisterDonation
{
    public class RegisterDonationCommand : IRequest<ResultViewModel<int>>
    {
        public RegisterDonationCommand(int donorId, int amountMl)
        {
            DonorId = donorId;
            AmountMl = amountMl;
        }
        public int DonorId { get; set; }
        public int AmountMl { get; set; }

        public Donation ToEntity()
            => new(DonorId, AmountMl);
    }
}
