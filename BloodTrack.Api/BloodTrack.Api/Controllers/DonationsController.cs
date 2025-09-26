using BloodTrack.Application.Commands.DonationsCommands.RegisterDonation;
using BloodTrack.Application.Queries.DonationsQueries.GetAllDonations;
using BloodTrack.Application.Queries.DonationsQueries.GetDonationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodTrack.Api.Controllers
{
    [ApiController]
    [Route("api/v1/donations")]
    public class DonationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DonationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegisterDonationCommand command)
        {
            var result = await _mediator.Send(command);
            
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllDonationsQuerie());

            return Ok(result);
        }

        [HttpGet("donations/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetDonationByIdQuerie(id));

            return Ok(result);
        }

    }
}
