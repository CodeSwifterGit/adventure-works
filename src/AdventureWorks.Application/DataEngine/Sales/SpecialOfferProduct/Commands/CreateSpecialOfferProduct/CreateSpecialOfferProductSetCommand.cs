using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.GetSpecialOfferProducts;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Commands.CreateSpecialOfferProduct
{
    public partial class CreateSpecialOfferProductSetCommand : IRequest<List<SpecialOfferProductLookupModel>>
    {
        public List<BaseSpecialOfferProduct> SpecialOfferProducts { get; set; }

        public CreateSpecialOfferProductSetCommand()
        {
        }

        public CreateSpecialOfferProductSetCommand(List<BaseSpecialOfferProduct> model)
        {
            SpecialOfferProducts = model;
        }

        public partial class Handler : IRequestHandler<CreateSpecialOfferProductSetCommand, List<SpecialOfferProductLookupModel>>
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

            public async Task<List<SpecialOfferProductLookupModel>> Handle(CreateSpecialOfferProductSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<SpecialOfferProductLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.SpecialOfferProducts)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateSpecialOfferProductCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}