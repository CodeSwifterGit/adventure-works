using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.GetProductDocuments;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.GetProductDocumentDetail
{
    public partial class GetProductDocumentDetailQueryHandler : IRequestHandler<GetProductDocumentDetailQuery, ProductDocumentLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetProductDocumentDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDocumentLookupModel> Handle(GetProductDocumentDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductDocuments
                .FindAsync(new object[] { request.ProductID, request.DocumentID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.ProductDocument, ProductDocumentLookupModel>(entity);
        }
    }
}
