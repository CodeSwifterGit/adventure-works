using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.GetProductCategories;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductCategory.Commands.CreateProductCategory
{
    public partial class CreateProductCategorySetCommand : IRequest<List<ProductCategoryLookupModel>>
    {
        public List<BaseProductCategory> ProductCategories { get; set; }

        public CreateProductCategorySetCommand()
        {
        }

        public CreateProductCategorySetCommand(List<BaseProductCategory> model)
        {
            ProductCategories = model;
        }

        public partial class Handler : IRequestHandler<CreateProductCategorySetCommand, List<ProductCategoryLookupModel>>
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

            public async Task<List<ProductCategoryLookupModel>> Handle(CreateProductCategorySetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ProductCategoryLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ProductCategories)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateProductCategoryCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}