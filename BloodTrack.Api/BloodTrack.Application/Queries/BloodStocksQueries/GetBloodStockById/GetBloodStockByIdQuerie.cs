using BloodTrack.Application.Models;
using MediatR;

namespace BloodTrack.Application.Queries.BloodStocksQueries.GetBloodStockById
{
    public class GetBloodStockByIdQuerie : IRequest<ResultViewModel<GetBloodStockViewModel>>
    {
        public GetBloodStockByIdQuerie(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
      
    }
}

