using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.GetProductDescriptions;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.GetProductDescriptionDetail
{
    public partial class GetProductDescriptionDetailQueryHandler : IRequestHandler<GetProductDescriptionDetailQuery, ProductDescriptionLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetProductDescriptionDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDescriptionLookupModel> Handle(GetProductDescriptionDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductDescriptions
                .FindAsync(new object[] { request.ProductDescriptionID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.ProductDescription, ProductDescriptionLookupModel>(entity);
        }
    }
}
