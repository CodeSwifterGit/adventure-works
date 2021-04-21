using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetails;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Commands.CreateSalesOrderDetail
{
    public partial class CreateSalesOrderDetailSetCommand : IRequest<List<SalesOrderDetailLookupModel>>
    {
        public List<BaseSalesOrderDetail> SalesOrderDetails { get; set; }

        public CreateSalesOrderDetailSetCommand()
        {
        }

        public CreateSalesOrderDetailSetCommand(List<BaseSalesOrderDetail> model)
        {
            SalesOrderDetails = model;
        }

        public partial class Handler : IRequestHandler<CreateSalesOrderDetailSetCommand, List<SalesOrderDetailLookupModel>>
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

            public async Task<List<SalesOrderDetailLookupModel>> Handle(CreateSalesOrderDetailSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<SalesOrderDetailLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.SalesOrderDetails)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateSalesOrderDetailCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}