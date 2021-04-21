using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.GetVendorContacts;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;


namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Commands.CreateVendorContact
{
    public partial class CreateVendorContactSetCommand : IRequest<List<VendorContactLookupModel>>
    {
        public List<BaseVendorContact> VendorContacts { get; set; }

        public CreateVendorContactSetCommand()
        {
        }

        public CreateVendorContactSetCommand(List<BaseVendorContact> model)
        {
            VendorContacts = model;
        }

        public partial class Handler : IRequestHandler<CreateVendorContactSetCommand, List<VendorContactLookupModel>>
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

            public async Task<List<VendorContactLookupModel>> Handle(CreateVendorContactSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<VendorContactLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.VendorContacts)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateVendorContactCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}