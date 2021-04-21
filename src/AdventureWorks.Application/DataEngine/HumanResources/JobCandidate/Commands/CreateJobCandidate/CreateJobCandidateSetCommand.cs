using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.GetJobCandidates;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;


namespace AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Commands.CreateJobCandidate
{
    public partial class CreateJobCandidateSetCommand : IRequest<List<JobCandidateLookupModel>>
    {
        public List<BaseJobCandidate> JobCandidates { get; set; }

        public CreateJobCandidateSetCommand()
        {
        }

        public CreateJobCandidateSetCommand(List<BaseJobCandidate> model)
        {
            JobCandidates = model;
        }

        public partial class Handler : IRequestHandler<CreateJobCandidateSetCommand, List<JobCandidateLookupModel>>
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

            public async Task<List<JobCandidateLookupModel>> Handle(CreateJobCandidateSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<JobCandidateLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.JobCandidates)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateJobCandidateCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}