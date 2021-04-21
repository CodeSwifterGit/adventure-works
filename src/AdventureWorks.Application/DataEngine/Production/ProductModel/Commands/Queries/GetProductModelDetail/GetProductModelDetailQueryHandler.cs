using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.GetProductModels;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.GetProductModelDetail
{
    public partial class GetProductModelDetailQueryHandler : IRequestHandler<GetProductModelDetailQuery, ProductModelLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetProductModelDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductModelLookupModel> Handle(GetProductModelDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductModels
                .FindAsync(new object[] { request.ProductModelID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.ProductModel, ProductModelLookupModel>(entity);
        }
    }
}
