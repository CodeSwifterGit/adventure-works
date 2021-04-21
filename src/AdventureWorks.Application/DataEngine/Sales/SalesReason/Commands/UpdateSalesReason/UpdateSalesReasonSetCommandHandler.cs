using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.GetSalesReasons;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Commands.UpdateSalesReason
{
    public partial class
        UpdateSalesReasonSetCommandHandler : IRequestHandler<UpdateSalesReasonSetCommand, List<SalesReasonLookupModel>>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateSalesReasonSetCommandHandler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<List<SalesReasonLookupModel>> Handle(UpdateSalesReasonSetCommand request,
            CancellationToken cancellationToken)
        {
            var result = new List<SalesReasonLookupModel>();
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