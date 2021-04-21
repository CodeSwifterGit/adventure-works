using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.ContactType.Queries.GetContactTypes;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;


namespace AdventureWorks.Application.DataEngine.Person.ContactType.Commands.CreateContactType
{
    public partial class CreateContactTypeSetCommand : IRequest<List<ContactTypeLookupModel>>
    {
        public List<BaseContactType> ContactTypes { get; set; }

        public CreateContactTypeSetCommand()
        {
        }

        public CreateContactTypeSetCommand(List<BaseContactType> model)
        {
            ContactTypes = model;
        }

        public partial class Handler : IRequestHandler<CreateContactTypeSetCommand, List<ContactTypeLookupModel>>
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

            public async Task<List<ContactTypeLookupModel>> Handle(CreateContactTypeSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ContactTypeLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ContactTypes)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateContactTypeCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}