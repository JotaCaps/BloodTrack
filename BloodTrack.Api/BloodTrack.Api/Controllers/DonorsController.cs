using BloodTrack.Application.Commands.DonorComands.DeleteDonor;
using BloodTrack.Application.Commands.DonorComands.RegisterDonor;
using BloodTrack.Application.Commands.DonorComands.UpdateDonor;
using BloodTrack.Application.Queries.DonorQueries.GetAllDonors;
using BloodTrack.Application.Queries.DonorQueries.GetDonationByDonorId;
using BloodTrack.Application.Queries.DonorQueries.GetDonorById;
using BloodTrack.Application.Services.ExternalServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodTrack.Api.Controllers
{
    [ApiController]
    [Route("api/v1/donors")]
    public class DonorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICepService _cepService;
        public DonorsController(ICepService cepService, IMediator mediator)
        {
            _cepService = cepService;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegisterDonorCommand command)
        {
            var address = await _cepService.GetAddressByCepAsync(command.ZipCode);

            if (address == null)
                return BadRequest("CEP inválido ou não encontrado.");

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetDonorById), new { id = result.Data}, result);
        }

        [HttpGet("/donations")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllDonorsQuery();

            var result = await _mediator.Send(query);
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonorById(int id)
        {
            var query = new GetDonorByIdQuery(id);

            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("{id}/donations")]
        public async Task<IActionResult> GetDonationsByDonorId([FromRoute]int id)
        {
            var query = new GetDonationsByDonorIdQuery(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]UpdateDonorCommand command, [FromRoute]int id)      
        {
            command.Id = id;
            
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                NotFound(result.Message);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteDonorCommand(id));

            if (!result.IsSuccess)
                NotFound(result.Message);

            return NoContent();
        }
    }
}
