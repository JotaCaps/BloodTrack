using BloodTrack.Application.Models;
using BloodTrack.Core.Entities;
using BloodTrack.Core.Repositories;
using MediatR;

namespace BloodTrack.Application.Commands.DonationsCommands.RegisterDonation
{
    public class RegisterDonationHandler : IRequestHandler<RegisterDonationCommand, ResultViewModel<int>>
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IDonorRepository _donorRepository;
        private readonly IBloodStockRepository _bloodStockRepository;
        public RegisterDonationHandler(IDonationRepository donationRepository, IDonorRepository donorRepository, IBloodStockRepository bloodStockRepository)
        {
            _donationRepository = donationRepository;
            _donorRepository = donorRepository;
            _bloodStockRepository = bloodStockRepository;
        }
        public async Task<ResultViewModel<int>> Handle(RegisterDonationCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetById(request.DonorId);
             if (donor == null)
                return ResultViewModel<int>.Error("Doador não existe");

            var bloodStock = await _bloodStockRepository.Exists(donor);

            if (bloodStock == null)
            {
                var newBloodStock = new BloodStock(donor.BloodTipe, donor.RhFactor, request.AmountMl);
                await _bloodStockRepository.Add(newBloodStock);

            }
            else
            {
                bloodStock.UpdateStock(request.AmountMl);
            }

            var model = request.ToEntity();

            // donor.Donations.Add(model);

            var donation = await _donationRepository.Add(model);

            return ResultViewModel<int>.Success(model.Id);
        }
    }
}
