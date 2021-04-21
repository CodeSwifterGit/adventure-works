using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.GetSpecialOffers;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Commands.CreateSpecialOffer
{
    public partial class CreateSpecialOfferCommand : BaseSpecialOffer, IRequest<SpecialOfferLookupModel>, IHaveCustomMapping
    {

        public CreateSpecialOfferCommand()
        {

        }

        public CreateSpecialOfferCommand(BaseSpecialOffer model, IMapper mapper)
        {
            mapper.Map<BaseSpecialOffer, CreateSpecialOfferCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateSpecialOfferCommand, SpecialOfferLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly SpecialOffersQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                SpecialOffersQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<SpecialOfferLookupModel> Handle(CreateSpecialOfferCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateSpecialOfferCommand, Entities.SpecialOffer>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.SpecialOffers.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.SpecialOffers.FindAsync(new object[] { entity.SpecialOfferID }, cancellationToken);

                await _mediator.Publish(new SpecialOfferCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.SpecialOffer, SpecialOfferLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSpecialOffer, CreateSpecialOfferCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateSpecialOfferCommand, Entities.SpecialOffer>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
