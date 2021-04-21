using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.GetVendorContacts;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Commands.CreateVendorContact
{
    public partial class CreateVendorContactCommand : BaseVendorContact, IRequest<VendorContactLookupModel>, IHaveCustomMapping
    {

        public CreateVendorContactCommand()
        {

        }

        public CreateVendorContactCommand(BaseVendorContact model, IMapper mapper)
        {
            mapper.Map<BaseVendorContact, CreateVendorContactCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateVendorContactCommand, VendorContactLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly VendorContactsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                VendorContactsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<VendorContactLookupModel> Handle(CreateVendorContactCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateVendorContactCommand, Entities.VendorContact>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.VendorContacts.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.VendorContacts.FindAsync(new object[] { entity.VendorID, entity.ContactID }, cancellationToken);

                await _mediator.Publish(new VendorContactCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.VendorContact, VendorContactLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseVendorContact, CreateVendorContactCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateVendorContactCommand, Entities.VendorContact>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
