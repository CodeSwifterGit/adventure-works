using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.GetSalesOrderHeaders;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Commands.CreateSalesOrderHeader
{
    public partial class CreateSalesOrderHeaderSetCommand : IRequest<List<SalesOrderHeaderLookupModel>>
    {
        public List<BaseSalesOrderHeader> SalesOrderHeaders { get; set; }

        public CreateSalesOrderHeaderSetCommand()
        {
        }

        public CreateSalesOrderHeaderSetCommand(List<BaseSalesOrderHeader> model)
        {
            SalesOrderHeaders = model;
        }

        public partial class Handler : IRequestHandler<CreateSalesOrderHeaderSetCommand, List<SalesOrderHeaderLookupModel>>
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

            public async Task<List<SalesOrderHeaderLookupModel>> Handle(CreateSalesOrderHeaderSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<SalesOrderHeaderLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.SalesOrderHeaders)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateSalesOrderHeaderCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}