using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.GetSalesPeople;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesPerson.Commands.CreateSalesPerson
{
    public partial class CreateSalesPersonSetCommand : IRequest<List<SalesPersonLookupModel>>
    {
        public List<BaseSalesPerson> SalesPeople { get; set; }

        public CreateSalesPersonSetCommand()
        {
        }

        public CreateSalesPersonSetCommand(List<BaseSalesPerson> model)
        {
            SalesPeople = model;
        }

        public partial class Handler : IRequestHandler<CreateSalesPersonSetCommand, List<SalesPersonLookupModel>>
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

            public async Task<List<SalesPersonLookupModel>> Handle(CreateSalesPersonSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<SalesPersonLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.SalesPeople)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateSalesPersonCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}