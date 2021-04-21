using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Document.Queries.GetDocuments;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.Document.Commands.CreateDocument
{
    public partial class CreateDocumentSetCommand : IRequest<List<DocumentLookupModel>>
    {
        public List<BaseDocument> Documents { get; set; }

        public CreateDocumentSetCommand()
        {
        }

        public CreateDocumentSetCommand(List<BaseDocument> model)
        {
            Documents = model;
        }

        public partial class Handler : IRequestHandler<CreateDocumentSetCommand, List<DocumentLookupModel>>
        {
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public Handler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
            {
                _context = context;
                _mediator = mediator;
                _mapper = mapper;
            }

            public async Task<List<DocumentLookupModel>> Handle(CreateDocumentSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<DocumentLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.Documents)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateDocumentCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}