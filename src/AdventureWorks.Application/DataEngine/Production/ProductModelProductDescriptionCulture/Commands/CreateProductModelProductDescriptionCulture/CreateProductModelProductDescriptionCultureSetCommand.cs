using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.GetProductModelProductDescriptionCultures;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Commands.CreateProductModelProductDescriptionCulture
{
    public partial class CreateProductModelProductDescriptionCultureSetCommand : IRequest<List<ProductModelProductDescriptionCultureLookupModel>>
    {
        public List<BaseProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }

        public CreateProductModelProductDescriptionCultureSetCommand()
        {
        }

        public CreateProductModelProductDescriptionCultureSetCommand(List<BaseProductModelProductDescriptionCulture> model)
        {
            ProductModelProductDescriptionCultures = model;
        }

        public partial class Handler : IRequestHandler<CreateProductModelProductDescriptionCultureSetCommand, List<ProductModelProductDescriptionCultureLookupModel>>
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

            public async Task<List<ProductModelProductDescriptionCultureLookupModel>> Handle(CreateProductModelProductDescriptionCultureSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ProductModelProductDescriptionCultureLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ProductModelProductDescriptionCultures)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateProductModelProductDescriptionCultureCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}