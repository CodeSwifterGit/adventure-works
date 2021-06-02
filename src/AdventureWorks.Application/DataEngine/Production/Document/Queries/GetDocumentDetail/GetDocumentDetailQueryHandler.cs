using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Document.Queries.GetDocuments;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.Document.Queries.GetDocumentDetail
{
    public partial class GetDocumentDetailQueryHandler : IRequestHandler<GetDocumentDetailQuery, DocumentLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetDocumentDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DocumentLookupModel> Handle(GetDocumentDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Documents
                .FindAsync(new object[] { request.DocumentID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.Document, DocumentLookupModel>(entity);
        }
    }
}
