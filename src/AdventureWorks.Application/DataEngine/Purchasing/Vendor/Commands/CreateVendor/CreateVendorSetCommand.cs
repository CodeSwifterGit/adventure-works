using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.GetVendors;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;


namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Commands.CreateVendor
{
    public partial class CreateVendorSetCommand : IRequest<List<VendorLookupModel>>
    {
        public List<BaseVendor> Vendors { get; set; }

        public CreateVendorSetCommand()
        {
        }

        public CreateVendorSetCommand(List<BaseVendor> model)
        {
            Vendors = model;
        }

        public partial class Handler : IRequestHandler<CreateVendorSetCommand, List<VendorLookupModel>>
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

            public async Task<List<VendorLookupModel>> Handle(CreateVendorSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<VendorLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.Vendors)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateVendorCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}