using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Location.Commands.DeleteLocation
{
    public partial class DeleteLocationCommand : IRequest
    {
        public short LocationID { get; set; }
    }
}