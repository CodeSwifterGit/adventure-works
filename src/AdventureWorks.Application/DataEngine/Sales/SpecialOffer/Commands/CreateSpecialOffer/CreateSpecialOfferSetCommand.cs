using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.GetSpecialOffers;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Commands.CreateSpecialOffer
{
    public partial class CreateSpecialOfferSetCommand : IRequest<List<SpecialOfferLookupModel>>
    {
        public List<BaseSpecialOffer> SpecialOffers { get; set; }

        public CreateSpecialOfferSetCommand()
        {
        }

        public CreateSpecialOfferSetCommand(List<BaseSpecialOffer> model)
        {
            SpecialOffers = model;
        }

        public partial class Handler : IRequestHandler<CreateSpecialOfferSetCommand, List<SpecialOfferLookupModel>>
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

            public async Task<List<SpecialOfferLookupModel>> Handle(CreateSpecialOfferSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<SpecialOfferLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.SpecialOffers)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateSpecialOfferCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}