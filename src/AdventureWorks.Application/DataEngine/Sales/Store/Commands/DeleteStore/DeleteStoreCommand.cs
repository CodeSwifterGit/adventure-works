using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.Store.Commands.DeleteStore
{
    public partial class DeleteStoreCommand : IRequest
    {
        public int CustomerID { get; set; }
    }
}