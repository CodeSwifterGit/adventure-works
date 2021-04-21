using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddresses;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;


namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Commands.CreateVendorAddress
{
    public partial class CreateVendorAddressSetCommand : IRequest<List<VendorAddressLookupModel>>
    {
        public List<BaseVendorAddress> VendorAddresses { get; set; }

        public CreateVendorAddressSetCommand()
        {
        }

        public CreateVendorAddressSetCommand(List<BaseVendorAddress> model)
        {
            VendorAddresses = model;
        }

        public partial class Handler : IRequestHandler<CreateVendorAddressSetCommand, List<VendorAddressLookupModel>>
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

            public async Task<List<VendorAddressLookupModel>> Handle(CreateVendorAddressSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<VendorAddressLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.VendorAddresses)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateVendorAddressCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}