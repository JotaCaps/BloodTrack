using BloodTrack.Application.Models;
using BloodTrack.Core.Repositories;
using MediatR;

namespace BloodTrack.Application.Queries.BloodStocksQueries.GetBloodStockById
{
    public class GetBloodStockByIdHandler : IRequestHandler<GetBloodStockByIdQuerie, ResultViewModel<GetBloodStockViewModel>>
    {
        private readonly IBloodStockRepository _repository;
        public GetBloodStockByIdHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<GetBloodStockViewModel>> Handle(GetBloodStockByIdQuerie request, CancellationToken cancellationToken)
        {
            var bloodStock = await _repository.GetById(request.Id);
            var model = GetBloodStockViewModel.FromEntity(bloodStock);

            return ResultViewModel<GetBloodStockViewModel>.Success(model);
        }
    }
}
