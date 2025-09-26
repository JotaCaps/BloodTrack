using BloodTrack.Application.Models;
using MediatR;

namespace BloodTrack.Application.Queries.BloodStocksQueries.GetBloodStockById
{
    public class GetBloodStockByIdQuery : IRequest<ResultViewModel<GetBloodStockViewModel>>
    {
        public GetBloodStockByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
      
    }
}

