using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.GetSalesOrderHeaderSalesReasons;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Commands.CreateSalesOrderHeaderSalesReason
{
    public partial class CreateSalesOrderHeaderSalesReasonSetCommand : IRequest<List<SalesOrderHeaderSalesReasonLookupModel>>
    {
        public List<BaseSalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; }

        public CreateSalesOrderHeaderSalesReasonSetCommand()
        {
        }

        public CreateSalesOrderHeaderSalesReasonSetCommand(List<BaseSalesOrderHeaderSalesReason> model)
        {
            SalesOrderHeaderSalesReasons = model;
        }

        public partial class Handler : IRequestHandler<CreateSalesOrderHeaderSalesReasonSetCommand, List<SalesOrderHeaderSalesReasonLookupModel>>
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

            public async Task<List<SalesOrderHeaderSalesReasonLookupModel>> Handle(CreateSalesOrderHeaderSalesReasonSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<SalesOrderHeaderSalesReasonLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.SalesOrderHeaderSalesReasons)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateSalesOrderHeaderSalesReasonCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}