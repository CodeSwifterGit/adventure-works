using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Queries.GetJobCandidates;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Commands.UpdateJobCandidate
{
    public partial class UpdateJobCandidateCommand : BaseJobCandidate, IRequest<JobCandidateLookupModel>, IHaveCustomMapping
    {
        public int JobCandidateID { get; set; }
        public int? EmployeeID { get; set; }
        public string Resume { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateJobCandidateRequestTarget RequestTarget { get; set; }

        public UpdateJobCandidateCommand()
        {
        }

        public UpdateJobCandidateCommand(int jobCandidateID, BaseJobCandidate model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateJobCandidateRequestTarget(jobCandidateID);
        }

        public UpdateJobCandidateCommand(int jobCandidateID)
        {
            JobCandidateID = jobCandidateID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseJobCandidate, UpdateJobCandidateCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateJobCandidateCommand, Entities.JobCandidate>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.JobCandidate, Entities.JobCandidate>(MemberList.None);
        }

        public partial class UpdateJobCandidateRequestTarget
        {
            public int JobCandidateID { get; set; }

            public UpdateJobCandidateRequestTarget()
            {
            }

            public UpdateJobCandidateRequestTarget(int jobCandidateID)
            {
                JobCandidateID = jobCandidateID;
            }
        }
    }
}