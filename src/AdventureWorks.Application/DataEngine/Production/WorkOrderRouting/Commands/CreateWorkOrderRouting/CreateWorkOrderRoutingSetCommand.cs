using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.GetWorkOrderRoutings;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Commands.CreateWorkOrderRouting
{
    public partial class CreateWorkOrderRoutingSetCommand : IRequest<List<WorkOrderRoutingLookupModel>>
    {
        public List<BaseWorkOrderRouting> WorkOrderRoutings { get; set; }

        public CreateWorkOrderRoutingSetCommand()
        {
        }

        public CreateWorkOrderRoutingSetCommand(List<BaseWorkOrderRouting> model)
        {
            WorkOrderRoutings = model;
        }

        public partial class Handler : IRequestHandler<CreateWorkOrderRoutingSetCommand, List<WorkOrderRoutingLookupModel>>
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

            public async Task<List<WorkOrderRoutingLookupModel>> Handle(CreateWorkOrderRoutingSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<WorkOrderRoutingLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.WorkOrderRoutings)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateWorkOrderRoutingCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}