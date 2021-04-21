using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.GetTransactionHistories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Commands.UpdateTransactionHistory
{
    public partial class UpdateTransactionHistoryCommand : BaseTransactionHistory, IRequest<TransactionHistoryLookupModel>, IHaveCustomMapping
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

        public UpdateTransactionHistoryRequestTarget RequestTarget { get; set; }

        public UpdateTransactionHistoryCommand()
        {
        }

        public UpdateTransactionHistoryCommand(int transactionID, BaseTransactionHistory model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateTransactionHistoryRequestTarget(transactionID);
        }

        public UpdateTransactionHistoryCommand(int transactionID)
        {
            TransactionID = transactionID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseTransactionHistory, UpdateTransactionHistoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateTransactionHistoryCommand, Entities.TransactionHistory>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.TransactionHistory, Entities.TransactionHistory>(MemberList.None);
        }

        public partial class UpdateTransactionHistoryRequestTarget
        {
            public int TransactionID { get; set; }

            public UpdateTransactionHistoryRequestTarget()
            {
            }

            public UpdateTransactionHistoryRequestTarget(int transactionID)
            {
                TransactionID = transactionID;
            }
        }
    }
}