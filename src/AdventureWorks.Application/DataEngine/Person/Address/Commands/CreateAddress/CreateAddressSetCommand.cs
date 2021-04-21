using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.Address.Queries.GetAddresses;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;


namespace AdventureWorks.Application.DataEngine.Person.Address.Commands.CreateAddress
{
    public partial class CreateAddressSetCommand : IRequest<List<AddressLookupModel>>
    {
        public List<BaseAddress> Addresses { get; set; }

        public CreateAddressSetCommand()
        {
        }

        public CreateAddressSetCommand(List<BaseAddress> model)
        {
            Addresses = model;
        }

        public partial class Handler : IRequestHandler<CreateAddressSetCommand, List<AddressLookupModel>>
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

            public async Task<List<AddressLookupModel>> Handle(CreateAddressSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<AddressLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.Addresses)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateAddressCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}