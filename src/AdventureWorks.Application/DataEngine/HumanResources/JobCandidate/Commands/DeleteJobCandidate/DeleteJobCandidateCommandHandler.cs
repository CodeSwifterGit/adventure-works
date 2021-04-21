using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Commands.DeleteJobCandidate
{
    public partial class DeleteJobCandidateCommandHandler : IRequestHandler<DeleteJobCandidateCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private JobCandidatesQueryManager _queryManager;

        public DeleteJobCandidateCommandHandler(IAdventureWorksContext context, IMediator mediator, JobCandidatesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteJobCandidateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.JobCandidates
                .FirstOrDefaultAsync(c => c.JobCandidateID == request.JobCandidateID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.JobCandidate), JsonConvert.SerializeObject(new { request.JobCandidateID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new JobCandidateDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
