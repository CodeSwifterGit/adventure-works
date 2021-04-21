using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.GetTransactionHistoryArchives;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Commands.UpdateTransactionHistoryArchive
{
    public partial class UpdateTransactionHistoryArchiveCommand : BaseTransactionHistoryArchive, IRequest<TransactionHistoryArchiveLookupModel>, IHaveCustomMapping
    {
        public int TransactionID { get; set; }
        public int ProductID { get; set; }
        public int ReferenceOrderID { get; set; }
        public int ReferenceOrderLineID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public int Quantity { get; set; }
        public decimal ActualCost { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateTransactionHistoryArchiveRequestTarget RequestTarget { get; set; }

        public UpdateTransactionHistoryArchiveCommand()
        {
        }

        public UpdateTransactionHistoryArchiveCommand(int transactionID, BaseTransactionHistoryArchive model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateTransactionHistoryArchiveRequestTarget(transactionID);
        }

        public UpdateTransactionHistoryArchiveCommand(int transactionID)
        {
            TransactionID = transactionID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseTransactionHistoryArchive, UpdateTransactionHistoryArchiveCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateTransactionHistoryArchiveCommand, Entities.TransactionHistoryArchive>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.TransactionHistoryArchive, Entities.TransactionHistoryArchive>(MemberList.None);
        }

        public partial class UpdateTransactionHistoryArchiveRequestTarget
        {
            public int TransactionID { get; set; }

            public UpdateTransactionHistoryArchiveRequestTarget()
            {
            }

            public UpdateTransactionHistoryArchiveRequestTarget(int transactionID)
            {
                TransactionID = transactionID;
            }
        }
    }
}