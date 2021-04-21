using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.GetJobCandidates;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Commands.UpdateJobCandidate
{
    public partial class UpdateJobCandidateCommandHandler : IRequestHandler<UpdateJobCandidateCommand, JobCandidateLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly JobCandidatesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateJobCandidateCommandHandler(IAdventureWorksContext context,
            JobCandidatesQueryManager queryManager,
            IAuthenticatedUserService authenticatedUserService,
            IMediator mediator,
            IMapper mapper,
            IDateTime machineDateTime)
        {
            _context = context;
            _queryManager = queryManager;
            _authenticatedUserService = authenticatedUserService;
            _mediator = mediator;
            _mapper = mapper;
            _machineDateTime = machineDateTime;
        }

        public async Task<JobCandidateLookupModel> Handle(UpdateJobCandidateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.JobCandidates
                .SingleAsync(c => c.JobCandidateID == request.RequestTarget.JobCandidateID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.JobCandidate, UpdateJobCandidateCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(JobCandidate), JsonConvert.SerializeObject(new { request.RequestTarget.JobCandidateID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.JobCandidates.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.JobCandidates.SingleAsync(c => c.JobCandidateID == request.RequestTarget.JobCandidateID, cancellationToken);

            await _mediator.Publish(new JobCandidateUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.JobCandidate, JobCandidateLookupModel>(entity);
        }
    }
}
