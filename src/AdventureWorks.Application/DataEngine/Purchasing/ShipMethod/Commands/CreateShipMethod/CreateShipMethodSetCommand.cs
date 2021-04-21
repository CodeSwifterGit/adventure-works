using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.GetShipMethods;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;


namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Commands.CreateShipMethod
{
    public partial class CreateShipMethodSetCommand : IRequest<List<ShipMethodLookupModel>>
    {
        public List<BaseShipMethod> ShipMethods { get; set; }

        public CreateShipMethodSetCommand()
        {
        }

        public CreateShipMethodSetCommand(List<BaseShipMethod> model)
        {
            ShipMethods = model;
        }

        public partial class Handler : IRequestHandler<CreateShipMethodSetCommand, List<ShipMethodLookupModel>>
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

            public async Task<List<ShipMethodLookupModel>> Handle(CreateShipMethodSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ShipMethodLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ShipMethods)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateShipMethodCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}