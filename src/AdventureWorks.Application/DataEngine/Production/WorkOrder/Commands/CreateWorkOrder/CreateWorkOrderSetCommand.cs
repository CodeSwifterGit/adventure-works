using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.GetWorkOrders;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Commands.CreateWorkOrder
{
    public partial class CreateWorkOrderSetCommand : IRequest<List<WorkOrderLookupModel>>
    {
        public List<BaseWorkOrder> WorkOrders { get; set; }

        public CreateWorkOrderSetCommand()
        {
        }

        public CreateWorkOrderSetCommand(List<BaseWorkOrder> model)
        {
            WorkOrders = model;
        }

        public partial class Handler : IRequestHandler<CreateWorkOrderSetCommand, List<WorkOrderLookupModel>>
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

            public async Task<List<WorkOrderLookupModel>> Handle(CreateWorkOrderSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<WorkOrderLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.WorkOrders)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateWorkOrderCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}