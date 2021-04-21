using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.GetDatabaseLogs;
using AdventureWorks.BaseDomain.Entities.Dbo;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Dbo;


namespace AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Commands.CreateDatabaseLog
{
    public partial class CreateDatabaseLogSetCommand : IRequest<List<DatabaseLogLookupModel>>
    {
        public List<BaseDatabaseLog> DatabaseLogs { get; set; }

        public CreateDatabaseLogSetCommand()
        {
        }

        public CreateDatabaseLogSetCommand(List<BaseDatabaseLog> model)
        {
            DatabaseLogs = model;
        }

        public partial class Handler : IRequestHandler<CreateDatabaseLogSetCommand, List<DatabaseLogLookupModel>>
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

            public async Task<List<DatabaseLogLookupModel>> Handle(CreateDatabaseLogSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<DatabaseLogLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.DatabaseLogs)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateDatabaseLogCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}