using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.GetJobCandidates;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;


namespace AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Commands.UpdateJobCandidate
{
    public partial class UpdateJobCandidateSetCommand : IRequest<List<JobCandidateLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateJobCandidateCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseJobCandidate>, List<UpdateJobCandidateCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateJobCandidateCommand>, List<Entities.JobCandidate>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.JobCandidate>, List<Entities.JobCandidate>>(MemberList.None);
        }
    }
}