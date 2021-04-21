using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.GetContactCreditCards;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Commands.CreateContactCreditCard
{
    public partial class CreateContactCreditCardCommand : BaseContactCreditCard, IRequest<ContactCreditCardLookupModel>, IHaveCustomMapping
    {

        public CreateContactCreditCardCommand()
        {

        }

        public CreateContactCreditCardCommand(BaseContactCreditCard model, IMapper mapper)
        {
            mapper.Map<BaseContactCreditCard, CreateContactCreditCardCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateContactCreditCardCommand, ContactCreditCardLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ContactCreditCardsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ContactCreditCardsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ContactCreditCardLookupModel> Handle(CreateContactCreditCardCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateContactCreditCardCommand, Entities.ContactCreditCard>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ContactCreditCards.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ContactCreditCards.FindAsync(new object[] { entity.ContactID, entity.CreditCardID }, cancellationToken);

                await _mediator.Publish(new ContactCreditCardCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ContactCreditCard, ContactCreditCardLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseContactCreditCard, CreateContactCreditCardCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateContactCreditCardCommand, Entities.ContactCreditCard>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
