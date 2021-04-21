using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.GetDatabaseLogs;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Dbo;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Dbo;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Commands.CreateDatabaseLog
{
    public partial class CreateDatabaseLogCommand : BaseDatabaseLog, IRequest<DatabaseLogLookupModel>, IHaveCustomMapping
    {

        public CreateDatabaseLogCommand()
        {

        }

        public CreateDatabaseLogCommand(BaseDatabaseLog model, IMapper mapper)
        {
            mapper.Map<BaseDatabaseLog, CreateDatabaseLogCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateDatabaseLogCommand, DatabaseLogLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly DatabaseLogsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                DatabaseLogsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<DatabaseLogLookupModel> Handle(CreateDatabaseLogCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateDatabaseLogCommand, Entities.DatabaseLog>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.DatabaseLogs.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.DatabaseLogs.FindAsync(new object[] { entity.DatabaseLogID }, cancellationToken);

                await _mediator.Publish(new DatabaseLogCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.DatabaseLog, DatabaseLogLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseDatabaseLog, CreateDatabaseLogCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateDatabaseLogCommand, Entities.DatabaseLog>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
