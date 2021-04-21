using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.GetSalesOrderHeaderSalesReasons;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Commands.UpdateSalesOrderHeaderSalesReason
{
    public partial class
        UpdateSalesOrderHeaderSalesReasonSetCommandHandler : IRequestHandler<UpdateSalesOrderHeaderSalesReasonSetCommand, List<SalesOrderHeaderSalesReasonLookupModel>>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateSalesOrderHeaderSalesReasonSetCommandHandler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<List<SalesOrderHeaderSalesReasonLookupModel>> Handle(UpdateSalesOrderHeaderSalesReasonSetCommand request,
            CancellationToken cancellationToken)
        {
            var result = new List<SalesOrderHeaderSalesReasonLookupModel>();
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                foreach (var singleRequest in request.Commands)
                {
                    var singleUpdateResult = await _mediator.Send(singleRequest, cancellationToken);
                    result.Add(singleUpdateResult);
                }

                await transaction.CommitAsync(cancellationToken);
            }
            return result;
        }
    }
}