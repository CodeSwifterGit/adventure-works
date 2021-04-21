using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.GetCreditCards;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.CreditCard.Commands.CreateCreditCard
{
    public partial class CreateCreditCardCommand : BaseCreditCard, IRequest<CreditCardLookupModel>, IHaveCustomMapping
    {

        public CreateCreditCardCommand()
        {

        }

        public CreateCreditCardCommand(BaseCreditCard model, IMapper mapper)
        {
            mapper.Map<BaseCreditCard, CreateCreditCardCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateCreditCardCommand, CreditCardLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly CreditCardsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                CreditCardsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<CreditCardLookupModel> Handle(CreateCreditCardCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateCreditCardCommand, Entities.CreditCard>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.CreditCards.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.CreditCards.FindAsync(new object[] { entity.CreditCardID }, cancellationToken);

                await _mediator.Publish(new CreditCardCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.CreditCard, CreditCardLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseCreditCard, CreateCreditCardCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateCreditCardCommand, Entities.CreditCard>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
