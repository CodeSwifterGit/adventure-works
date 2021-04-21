using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.GetTransactionHistories;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Commands.UpdateTransactionHistory
{
    public partial class UpdateTransactionHistorySetCommand : IRequest<List<TransactionHistoryLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateTransactionHistoryCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseTransactionHistory>, List<UpdateTransactionHistoryCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateTransactionHistoryCommand>, List<Entities.TransactionHistory>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.TransactionHistory>, List<Entities.TransactionHistory>>(MemberList.None);
        }
    }
}