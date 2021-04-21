using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.GetProductModels;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Commands.CreateProductModel
{
    public partial class CreateProductModelSetCommand : IRequest<List<ProductModelLookupModel>>
    {
        public List<BaseProductModel> ProductModels { get; set; }

        public CreateProductModelSetCommand()
        {
        }

        public CreateProductModelSetCommand(List<BaseProductModel> model)
        {
            ProductModels = model;
        }

        public partial class Handler : IRequestHandler<CreateProductModelSetCommand, List<ProductModelLookupModel>>
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

            public async Task<List<ProductModelLookupModel>> Handle(CreateProductModelSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ProductModelLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ProductModels)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateProductModelCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}