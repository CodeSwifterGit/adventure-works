using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.GetProductVendors;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;


namespace AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Commands.CreateProductVendor
{
    public partial class CreateProductVendorSetCommand : IRequest<List<ProductVendorLookupModel>>
    {
        public List<BaseProductVendor> ProductVendors { get; set; }

        public CreateProductVendorSetCommand()
        {
        }

        public CreateProductVendorSetCommand(List<BaseProductVendor> model)
        {
            ProductVendors = model;
        }

        public partial class Handler : IRequestHandler<CreateProductVendorSetCommand, List<ProductVendorLookupModel>>
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

            public async Task<List<ProductVendorLookupModel>> Handle(CreateProductVendorSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ProductVendorLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ProductVendors)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateProductVendorCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}