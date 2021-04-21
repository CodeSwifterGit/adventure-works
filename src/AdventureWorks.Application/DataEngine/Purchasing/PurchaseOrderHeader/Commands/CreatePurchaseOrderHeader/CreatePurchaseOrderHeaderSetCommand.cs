using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.GetPurchaseOrderHeaders;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;


namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Commands.CreatePurchaseOrderHeader
{
    public partial class CreatePurchaseOrderHeaderSetCommand : IRequest<List<PurchaseOrderHeaderLookupModel>>
    {
        public List<BasePurchaseOrderHeader> PurchaseOrderHeaders { get; set; }

        public CreatePurchaseOrderHeaderSetCommand()
        {
        }

        public CreatePurchaseOrderHeaderSetCommand(List<BasePurchaseOrderHeader> model)
        {
            PurchaseOrderHeaders = model;
        }

        public partial class Handler : IRequestHandler<CreatePurchaseOrderHeaderSetCommand, List<PurchaseOrderHeaderLookupModel>>
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

            public async Task<List<PurchaseOrderHeaderLookupModel>> Handle(CreatePurchaseOrderHeaderSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<PurchaseOrderHeaderLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.PurchaseOrderHeaders)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreatePurchaseOrderHeaderCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}