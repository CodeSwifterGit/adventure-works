using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Commands.DeleteJobCandidate
{
    public partial class DeleteJobCandidateSetCommand : IRequest
    {
        public List<DeleteJobCandidateCommand> Commands { get; set; }
    }
}