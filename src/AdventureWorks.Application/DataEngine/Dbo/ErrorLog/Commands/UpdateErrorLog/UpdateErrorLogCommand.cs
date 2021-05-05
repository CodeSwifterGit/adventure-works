using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Dbo;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Dbo;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.GetErrorLogs;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Commands.UpdateErrorLog
{
    public partial class UpdateErrorLogCommand : IRequest<ErrorLogLookupModel>, IHaveCustomMapping
    {
        public int ErrorLogID { get; set; }
        public DateTime ErrorTime { get; set; }
        public string UserName { get; set; }
        public int ErrorNumber { get; set; }
        public int? ErrorSeverity { get; set; }
        public int? ErrorState { get; set; }
        public string ErrorProcedure { get; set; }
        public int? ErrorLine { get; set; }
        public string ErrorMessage { get; set; }

        public UpdateErrorLogRequestTarget RequestTarget { get; set; }

        public UpdateErrorLogCommand()
        {
        }

        public UpdateErrorLogCommand(int errorLogID, BaseErrorLog model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateErrorLogRequestTarget(errorLogID);
        }

        public UpdateErrorLogCommand(int errorLogID)
        {
            ErrorLogID = errorLogID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseErrorLog, UpdateErrorLogCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateErrorLogCommand, Entities.ErrorLog>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ErrorLog, Entities.ErrorLog>(MemberList.None);
        }

        public partial class UpdateErrorLogRequestTarget
        {
            public int ErrorLogID { get; set; }

            public UpdateErrorLogRequestTarget()
            {
            }

            public UpdateErrorLogRequestTarget(int errorLogID)
            {
                ErrorLogID = errorLogID;
            }
        }
    }
}