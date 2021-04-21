using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.AddressType.Queries.GetAddressTypes;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;


namespace AdventureWorks.Application.DataEngine.Person.AddressType.Commands.CreateAddressType
{
    public partial class CreateAddressTypeSetCommand : IRequest<List<AddressTypeLookupModel>>
    {
        public List<BaseAddressType> AddressTypes { get; set; }

        public CreateAddressTypeSetCommand()
        {
        }

        public CreateAddressTypeSetCommand(List<BaseAddressType> model)
        {
            AddressTypes = model;
        }

        public partial class Handler : IRequestHandler<CreateAddressTypeSetCommand, List<AddressTypeLookupModel>>
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

            public async Task<List<AddressTypeLookupModel>> Handle(CreateAddressTypeSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<AddressTypeLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.AddressTypes)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateAddressTypeCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}