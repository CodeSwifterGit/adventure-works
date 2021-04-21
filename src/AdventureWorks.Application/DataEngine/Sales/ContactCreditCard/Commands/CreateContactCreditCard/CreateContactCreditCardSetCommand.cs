using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.GetContactCreditCards;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Commands.CreateContactCreditCard
{
    public partial class CreateContactCreditCardSetCommand : IRequest<List<ContactCreditCardLookupModel>>
    {
        public List<BaseContactCreditCard> ContactCreditCards { get; set; }

        public CreateContactCreditCardSetCommand()
        {
        }

        public CreateContactCreditCardSetCommand(List<BaseContactCreditCard> model)
        {
            ContactCreditCards = model;
        }

        public partial class Handler : IRequestHandler<CreateContactCreditCardSetCommand, List<ContactCreditCardLookupModel>>
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

            public async Task<List<ContactCreditCardLookupModel>> Handle(CreateContactCreditCardSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ContactCreditCardLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ContactCreditCards)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateContactCreditCardCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}