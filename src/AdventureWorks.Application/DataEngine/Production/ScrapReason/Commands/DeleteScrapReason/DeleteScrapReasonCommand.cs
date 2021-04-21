using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Commands.DeleteScrapReason
{
    public partial class DeleteScrapReasonCommand : IRequest
    {
        public short ScrapReasonID { get; set; }
    }
}