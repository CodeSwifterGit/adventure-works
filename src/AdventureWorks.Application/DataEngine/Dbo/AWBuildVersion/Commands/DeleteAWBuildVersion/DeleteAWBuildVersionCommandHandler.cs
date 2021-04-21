using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Dbo;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Commands.DeleteAWBuildVersion
{
    public partial class DeleteAWBuildVersionCommandHandler : IRequestHandler<DeleteAWBuildVersionCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private AWBuildVersionsQueryManager _queryManager;

        public DeleteAWBuildVersionCommandHandler(IAdventureWorksContext context, IMediator mediator, AWBuildVersionsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteAWBuildVersionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.AWBuildVersions
                .FirstOrDefaultAsync(c => c.SystemInformationID == request.SystemInformationID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.AWBuildVersion), JsonConvert.SerializeObject(new { request.SystemInformationID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new AWBuildVersionDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
