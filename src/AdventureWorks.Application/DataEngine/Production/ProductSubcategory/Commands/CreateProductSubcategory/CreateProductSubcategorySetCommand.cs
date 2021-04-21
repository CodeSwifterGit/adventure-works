using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.GetProductSubcategories;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Commands.CreateProductSubcategory
{
    public partial class CreateProductSubcategorySetCommand : IRequest<List<ProductSubcategoryLookupModel>>
    {
        public List<BaseProductSubcategory> ProductSubcategories { get; set; }

        public CreateProductSubcategorySetCommand()
        {
        }

        public CreateProductSubcategorySetCommand(List<BaseProductSubcategory> model)
        {
            ProductSubcategories = model;
        }

        public partial class Handler : IRequestHandler<CreateProductSubcategorySetCommand, List<ProductSubcategoryLookupModel>>
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

            public async Task<List<ProductSubcategoryLookupModel>> Handle(CreateProductSubcategorySetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ProductSubcategoryLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ProductSubcategories)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateProductSubcategoryCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}