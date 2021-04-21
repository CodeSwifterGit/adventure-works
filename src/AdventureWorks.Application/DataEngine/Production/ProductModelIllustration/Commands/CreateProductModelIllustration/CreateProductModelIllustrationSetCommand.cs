using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.GetProductModelIllustrations;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Commands.CreateProductModelIllustration
{
    public partial class CreateProductModelIllustrationSetCommand : IRequest<List<ProductModelIllustrationLookupModel>>
    {
        public List<BaseProductModelIllustration> ProductModelIllustrations { get; set; }

        public CreateProductModelIllustrationSetCommand()
        {
        }

        public CreateProductModelIllustrationSetCommand(List<BaseProductModelIllustration> model)
        {
            ProductModelIllustrations = model;
        }

        public partial class Handler : IRequestHandler<CreateProductModelIllustrationSetCommand, List<ProductModelIllustrationLookupModel>>
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

            public async Task<List<ProductModelIllustrationLookupModel>> Handle(CreateProductModelIllustrationSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ProductModelIllustrationLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ProductModelIllustrations)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateProductModelIllustrationCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}