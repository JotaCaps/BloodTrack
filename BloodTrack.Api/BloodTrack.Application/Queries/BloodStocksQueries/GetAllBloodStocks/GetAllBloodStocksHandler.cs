using BloodTrack.Application.Models;
using BloodTrack.Core.Repositories;
using MediatR;

namespace BloodTrack.Application.Queries.BloodStocksQueries.GetAllBloodStocks
{
    public class GetAllBloodStocksHandler : IRequestHandler<GetAllBloodStocksQuerie, ResultViewModel<List<GetBloodStockViewModel>>>
    {
        private readonly IBloodStockRepository _repository;
        public GetAllBloodStocksHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<GetBloodStockViewModel>>> Handle(GetAllBloodStocksQuerie request, CancellationToken cancellationToken)
        {
            var bloodStocks = await _repository.GetAll();
            var model =  bloodStocks.Select(GetBloodStockViewModel.FromEntity).ToList();

            return ResultViewModel<List<GetBloodStockViewModel>>.Success(model);

        }
    }
}
