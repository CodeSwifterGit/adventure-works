using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.GetEmployeePayHistories;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Commands.CreateEmployeePayHistory
{
    public partial class CreateEmployeePayHistoryCommand : BaseEmployeePayHistory, IRequest<EmployeePayHistoryLookupModel>, IHaveCustomMapping
    {

        public CreateEmployeePayHistoryCommand()
        {

        }

        public CreateEmployeePayHistoryCommand(BaseEmployeePayHistory model, IMapper mapper)
        {
            mapper.Map<BaseEmployeePayHistory, CreateEmployeePayHistoryCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateEmployeePayHistoryCommand, EmployeePayHistoryLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly EmployeePayHistoriesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                EmployeePayHistoriesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<EmployeePayHistoryLookupModel> Handle(CreateEmployeePayHistoryCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateEmployeePayHistoryCommand, Entities.EmployeePayHistory>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.EmployeePayHistories.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.EmployeePayHistories.FindAsync(new object[] { entity.EmployeeID, entity.RateChangeDate }, cancellationToken);

                await _mediator.Publish(new EmployeePayHistoryCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.EmployeePayHistory, EmployeePayHistoryLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseEmployeePayHistory, CreateEmployeePayHistoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateEmployeePayHistoryCommand, Entities.EmployeePayHistory>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
