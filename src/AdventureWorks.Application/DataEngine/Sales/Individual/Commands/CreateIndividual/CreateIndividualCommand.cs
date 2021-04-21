using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.Individual.Queries.GetIndividuals;
using AdventureWorks.Application.DataEngine.Sales.Individual.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.Individual.Commands.CreateIndividual
{
    public partial class CreateIndividualCommand : BaseIndividual, IRequest<IndividualLookupModel>, IHaveCustomMapping
    {

        public CreateIndividualCommand()
        {

        }

        public CreateIndividualCommand(BaseIndividual model, IMapper mapper)
        {
            mapper.Map<BaseIndividual, CreateIndividualCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateIndividualCommand, IndividualLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly IndividualsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                IndividualsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<IndividualLookupModel> Handle(CreateIndividualCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateIndividualCommand, Entities.Individual>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.Individuals.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.Individuals.FindAsync(new object[] { entity.CustomerID }, cancellationToken);

                await _mediator.Publish(new IndividualCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.Individual, IndividualLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseIndividual, CreateIndividualCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateIndividualCommand, Entities.Individual>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
