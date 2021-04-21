using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.GetStoreContacts;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.StoreContact.Commands.CreateStoreContact
{
    public partial class CreateStoreContactSetCommand : IRequest<List<StoreContactLookupModel>>
    {
        public List<BaseStoreContact> StoreContacts { get; set; }

        public CreateStoreContactSetCommand()
        {
        }

        public CreateStoreContactSetCommand(List<BaseStoreContact> model)
        {
            StoreContacts = model;
        }

        public partial class Handler : IRequestHandler<CreateStoreContactSetCommand, List<StoreContactLookupModel>>
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

            public async Task<List<StoreContactLookupModel>> Handle(CreateStoreContactSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<StoreContactLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.StoreContacts)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateStoreContactCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}