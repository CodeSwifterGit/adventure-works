using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.GetProductModelIllustrations;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.GetProductModelIllustrationDetail
{
    public partial class GetProductModelIllustrationDetailQueryHandler : IRequestHandler<GetProductModelIllustrationDetailQuery, ProductModelIllustrationLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetProductModelIllustrationDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductModelIllustrationLookupModel> Handle(GetProductModelIllustrationDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductModelIllustrations
                .FindAsync(new object[] { request.ProductModelID, request.IllustrationID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.ProductModelIllustration, ProductModelIllustrationLookupModel>(entity);
        }
    }
}
