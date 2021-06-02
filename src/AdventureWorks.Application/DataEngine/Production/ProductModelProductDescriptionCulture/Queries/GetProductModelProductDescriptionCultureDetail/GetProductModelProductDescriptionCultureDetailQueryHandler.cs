using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.GetProductModelProductDescriptionCultures;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.GetProductModelProductDescriptionCultureDetail
{
    public partial class GetProductModelProductDescriptionCultureDetailQueryHandler : IRequestHandler<GetProductModelProductDescriptionCultureDetailQuery, ProductModelProductDescriptionCultureLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetProductModelProductDescriptionCultureDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductModelProductDescriptionCultureLookupModel> Handle(GetProductModelProductDescriptionCultureDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductModelProductDescriptionCultures
                .FindAsync(new object[] { request.ProductModelID, request.ProductDescriptionID, request.CultureID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.ProductModelProductDescriptionCulture, ProductModelProductDescriptionCultureLookupModel>(entity);
        }
    }
}
