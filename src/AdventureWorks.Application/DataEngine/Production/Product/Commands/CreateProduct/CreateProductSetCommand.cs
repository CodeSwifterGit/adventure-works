using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Product.Queries.GetProducts;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.Product.Commands.CreateProduct
{
    public partial class CreateProductSetCommand : IRequest<List<ProductLookupModel>>
    {
        public List<BaseProduct> Products { get; set; }

        public CreateProductSetCommand()
        {
        }

        public CreateProductSetCommand(List<BaseProduct> model)
        {
            Products = model;
        }

        public partial class Handler : IRequestHandler<CreateProductSetCommand, List<ProductLookupModel>>
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

            public async Task<List<ProductLookupModel>> Handle(CreateProductSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ProductLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.Products)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateProductCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}