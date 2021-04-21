using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.GetProductDescriptions;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductDescription.Commands.CreateProductDescription
{
    public partial class CreateProductDescriptionSetCommand : IRequest<List<ProductDescriptionLookupModel>>
    {
        public List<BaseProductDescription> ProductDescriptions { get; set; }

        public CreateProductDescriptionSetCommand()
        {
        }

        public CreateProductDescriptionSetCommand(List<BaseProductDescription> model)
        {
            ProductDescriptions = model;
        }

        public partial class Handler : IRequestHandler<CreateProductDescriptionSetCommand, List<ProductDescriptionLookupModel>>
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

            public async Task<List<ProductDescriptionLookupModel>> Handle(CreateProductDescriptionSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ProductDescriptionLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ProductDescriptions)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateProductDescriptionCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}