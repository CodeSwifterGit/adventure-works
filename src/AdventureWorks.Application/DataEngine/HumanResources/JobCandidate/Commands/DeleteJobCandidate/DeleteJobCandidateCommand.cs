using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Commands.DeleteJobCandidate
{
    public partial class DeleteJobCandidateCommand : IRequest
    {
        public int JobCandidateID { get; set; }
    }
}