using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.GetErrorLogs;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Dbo;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Dbo;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Commands.CreateErrorLog
{
    public partial class CreateErrorLogCommand : BaseErrorLog, IRequest<ErrorLogLookupModel>, IHaveCustomMapping
    {

        public CreateErrorLogCommand()
        {

        }

        public CreateErrorLogCommand(BaseErrorLog model, IMapper mapper)
        {
            mapper.Map<BaseErrorLog, CreateErrorLogCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateErrorLogCommand, ErrorLogLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ErrorLogsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ErrorLogsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ErrorLogLookupModel> Handle(CreateErrorLogCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateErrorLogCommand, Entities.ErrorLog>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ErrorLogs.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ErrorLogs.FindAsync(new object[] { entity.ErrorLogID }, cancellationToken);

                await _mediator.Publish(new ErrorLogCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ErrorLog, ErrorLogLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseErrorLog, CreateErrorLogCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateErrorLogCommand, Entities.ErrorLog>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
