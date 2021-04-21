using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.GetSalesReasons;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Commands.CreateSalesReason
{
    public partial class CreateSalesReasonSetCommand : IRequest<List<SalesReasonLookupModel>>
    {
        public List<BaseSalesReason> SalesReasons { get; set; }

        public CreateSalesReasonSetCommand()
        {
        }

        public CreateSalesReasonSetCommand(List<BaseSalesReason> model)
        {
            SalesReasons = model;
        }

        public partial class Handler : IRequestHandler<CreateSalesReasonSetCommand, List<SalesReasonLookupModel>>
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

            public async Task<List<SalesReasonLookupModel>> Handle(CreateSalesReasonSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<SalesReasonLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.SalesReasons)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateSalesReasonCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}