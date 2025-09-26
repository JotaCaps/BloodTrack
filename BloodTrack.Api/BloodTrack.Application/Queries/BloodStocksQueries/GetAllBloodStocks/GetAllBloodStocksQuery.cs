using BloodTrack.Application.Models;
using MediatR;

namespace BloodTrack.Application.Queries.BloodStocksQueries.GetAllBloodStocks
{
    public class GetAllBloodStocksQuery : IRequest<ResultViewModel<List<GetBloodStockViewModel>>>
    {
        
    }
}
