using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.GetJobCandidates;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Commands.CreateJobCandidate
{
    public partial class CreateJobCandidateCommand : BaseJobCandidate, IRequest<JobCandidateLookupModel>, IHaveCustomMapping
    {

        public CreateJobCandidateCommand()
        {

        }

        public CreateJobCandidateCommand(BaseJobCandidate model, IMapper mapper)
        {
            mapper.Map<BaseJobCandidate, CreateJobCandidateCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateJobCandidateCommand, JobCandidateLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly JobCandidatesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                JobCandidatesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<JobCandidateLookupModel> Handle(CreateJobCandidateCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateJobCandidateCommand, Entities.JobCandidate>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.JobCandidates.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.JobCandidates.FindAsync(new object[] { entity.JobCandidateID }, cancellationToken);

                await _mediator.Publish(new JobCandidateCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.JobCandidate, JobCandidateLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseJobCandidate, CreateJobCandidateCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateJobCandidateCommand, Entities.JobCandidate>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
