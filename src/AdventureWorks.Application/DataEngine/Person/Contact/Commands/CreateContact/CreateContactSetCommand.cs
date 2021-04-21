using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContacts;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;


namespace AdventureWorks.Application.DataEngine.Person.Contact.Commands.CreateContact
{
    public partial class CreateContactSetCommand : IRequest<List<ContactLookupModel>>
    {
        public List<BaseContact> Contacts { get; set; }

        public CreateContactSetCommand()
        {
        }

        public CreateContactSetCommand(List<BaseContact> model)
        {
            Contacts = model;
        }

        public partial class Handler : IRequestHandler<CreateContactSetCommand, List<ContactLookupModel>>
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

            public async Task<List<ContactLookupModel>> Handle(CreateContactSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ContactLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.Contacts)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateContactCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}