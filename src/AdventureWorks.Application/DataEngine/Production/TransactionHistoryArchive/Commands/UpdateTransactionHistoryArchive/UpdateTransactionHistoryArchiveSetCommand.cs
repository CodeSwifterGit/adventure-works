using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.GetTransactionHistoryArchives;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Commands.UpdateTransactionHistoryArchive
{
    public partial class UpdateTransactionHistoryArchiveSetCommand : IRequest<List<TransactionHistoryArchiveLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateTransactionHistoryArchiveCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseTransactionHistoryArchive>, List<UpdateTransactionHistoryArchiveCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateTransactionHistoryArchiveCommand>, List<Entities.TransactionHistoryArchive>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.TransactionHistoryArchive>, List<Entities.TransactionHistoryArchive>>(MemberList.None);
        }
    }
}