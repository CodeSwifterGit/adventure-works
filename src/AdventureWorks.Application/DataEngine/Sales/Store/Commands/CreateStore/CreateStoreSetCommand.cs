using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.Store.Queries.GetStores;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.Store.Commands.CreateStore
{
    public partial class CreateStoreSetCommand : IRequest<List<StoreLookupModel>>
    {
        public List<BaseStore> Stores { get; set; }

        public CreateStoreSetCommand()
        {
        }

        public CreateStoreSetCommand(List<BaseStore> model)
        {
            Stores = model;
        }

        public partial class Handler : IRequestHandler<CreateStoreSetCommand, List<StoreLookupModel>>
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

            public async Task<List<StoreLookupModel>> Handle(CreateStoreSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<StoreLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.Stores)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateStoreCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}