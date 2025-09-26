using BloodTrack.Application.Models;
using BloodTrack.Application.Queries.BloodStocksQueries.GetAllBloodStocks;
using BloodTrack.Application.Queries.BloodStocksQueries.GetBloodStockById;
using BloodTrack.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodTrack.Api.Controllers
{
    [ApiController]
    [Route("api/v1/bloodstocks")]
    public class BloodStocksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BloodStocksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllBloodStocksQuerie());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBloodStockById(int id)
        {
            var result = await _mediator.Send(new GetBloodStockByIdQuerie(id));

            return Ok(result);
        }
    }
}
