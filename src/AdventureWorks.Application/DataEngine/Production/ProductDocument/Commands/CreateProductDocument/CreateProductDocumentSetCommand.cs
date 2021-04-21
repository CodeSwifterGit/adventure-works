using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.GetProductDocuments;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Commands.CreateProductDocument
{
    public partial class CreateProductDocumentSetCommand : IRequest<List<ProductDocumentLookupModel>>
    {
        public List<BaseProductDocument> ProductDocuments { get; set; }

        public CreateProductDocumentSetCommand()
        {
        }

        public CreateProductDocumentSetCommand(List<BaseProductDocument> model)
        {
            ProductDocuments = model;
        }

        public partial class Handler : IRequestHandler<CreateProductDocumentSetCommand, List<ProductDocumentLookupModel>>
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

            public async Task<List<ProductDocumentLookupModel>> Handle(CreateProductDocumentSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ProductDocumentLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ProductDocuments)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateProductDocumentCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}