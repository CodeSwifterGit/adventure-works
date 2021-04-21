using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.GetShipMethods;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;


namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Commands.UpdateShipMethod
{
    public partial class
        UpdateShipMethodSetCommandHandler : IRequestHandler<UpdateShipMethodSetCommand, List<ShipMethodLookupModel>>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateShipMethodSetCommandHandler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<List<ShipMethodLookupModel>> Handle(UpdateShipMethodSetCommand request,
            CancellationToken cancellationToken)
        {
            var result = new List<ShipMethodLookupModel>();
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