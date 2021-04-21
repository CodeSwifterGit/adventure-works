using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.GetSalesPersonQuotaHistories;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Commands.CreateSalesPersonQuotaHistory
{
    public partial class CreateSalesPersonQuotaHistorySetCommand : IRequest<List<SalesPersonQuotaHistoryLookupModel>>
    {
        public List<BaseSalesPersonQuotaHistory> SalesPersonQuotaHistories { get; set; }

        public CreateSalesPersonQuotaHistorySetCommand()
        {
        }

        public CreateSalesPersonQuotaHistorySetCommand(List<BaseSalesPersonQuotaHistory> model)
        {
            SalesPersonQuotaHistories = model;
        }

        public partial class Handler : IRequestHandler<CreateSalesPersonQuotaHistorySetCommand, List<SalesPersonQuotaHistoryLookupModel>>
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

            public async Task<List<SalesPersonQuotaHistoryLookupModel>> Handle(CreateSalesPersonQuotaHistorySetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<SalesPersonQuotaHistoryLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.SalesPersonQuotaHistories)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateSalesPersonQuotaHistoryCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}