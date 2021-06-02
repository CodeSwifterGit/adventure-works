using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.GetJobCandidates;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.GetJobCandidateDetail
{
    public partial class GetJobCandidateDetailQueryHandler : IRequestHandler<GetJobCandidateDetailQuery, JobCandidateLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetJobCandidateDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<JobCandidateLookupModel> Handle(GetJobCandidateDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.JobCandidates
                .FindAsync(new object[] { request.JobCandidateID }, cancellationToken);

            return _mapper.Map<Domain.Entities.HumanResources.JobCandidate, JobCandidateLookupModel>(entity);
        }
    }
}
