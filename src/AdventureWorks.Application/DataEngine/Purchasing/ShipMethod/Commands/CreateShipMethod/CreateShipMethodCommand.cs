using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.GetShipMethods;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Commands.CreateShipMethod
{
    public partial class CreateShipMethodCommand : BaseShipMethod, IRequest<ShipMethodLookupModel>, IHaveCustomMapping
    {

        public CreateShipMethodCommand()
        {

        }

        public CreateShipMethodCommand(BaseShipMethod model, IMapper mapper)
        {
            mapper.Map<BaseShipMethod, CreateShipMethodCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateShipMethodCommand, ShipMethodLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ShipMethodsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ShipMethodsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ShipMethodLookupModel> Handle(CreateShipMethodCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateShipMethodCommand, Entities.ShipMethod>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ShipMethods.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ShipMethods.FindAsync(new object[] { entity.ShipMethodID }, cancellationToken);

                await _mediator.Publish(new ShipMethodCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ShipMethod, ShipMethodLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseShipMethod, CreateShipMethodCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateShipMethodCommand, Entities.ShipMethod>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
