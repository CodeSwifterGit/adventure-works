using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.GetCreditCards;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.CreditCard.Commands.CreateCreditCard
{
    public partial class CreateCreditCardSetCommand : IRequest<List<CreditCardLookupModel>>
    {
        public List<BaseCreditCard> CreditCards { get; set; }

        public CreateCreditCardSetCommand()
        {
        }

        public CreateCreditCardSetCommand(List<BaseCreditCard> model)
        {
            CreditCards = model;
        }

        public partial class Handler : IRequestHandler<CreateCreditCardSetCommand, List<CreditCardLookupModel>>
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

            public async Task<List<CreditCardLookupModel>> Handle(CreateCreditCardSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<CreditCardLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.CreditCards)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateCreditCardCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}