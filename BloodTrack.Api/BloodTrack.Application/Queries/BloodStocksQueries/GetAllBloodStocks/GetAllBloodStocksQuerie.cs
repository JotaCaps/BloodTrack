using BloodTrack.Application.Models;
using MediatR;

namespace BloodTrack.Application.Queries.BloodStocksQueries.GetAllBloodStocks
{
    public class GetAllBloodStocksQuerie : IRequest<ResultViewModel<List<GetBloodStockViewModel>>>
    {
        
    }
}
