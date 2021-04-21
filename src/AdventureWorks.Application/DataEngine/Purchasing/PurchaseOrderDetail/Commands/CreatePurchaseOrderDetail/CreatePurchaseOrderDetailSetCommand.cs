using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.GetPurchaseOrderDetails;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;


namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Commands.CreatePurchaseOrderDetail
{
    public partial class CreatePurchaseOrderDetailSetCommand : IRequest<List<PurchaseOrderDetailLookupModel>>
    {
        public List<BasePurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        public CreatePurchaseOrderDetailSetCommand()
        {
        }

        public CreatePurchaseOrderDetailSetCommand(List<BasePurchaseOrderDetail> model)
        {
            PurchaseOrderDetails = model;
        }

        public partial class Handler : IRequestHandler<CreatePurchaseOrderDetailSetCommand, List<PurchaseOrderDetailLookupModel>>
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

            public async Task<List<PurchaseOrderDetailLookupModel>> Handle(CreatePurchaseOrderDetailSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<PurchaseOrderDetailLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.PurchaseOrderDetails)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreatePurchaseOrderDetailCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}