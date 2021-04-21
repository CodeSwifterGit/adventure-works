using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.ContactType.Commands.DeleteContactType
{
    public partial class DeleteContactTypeCommand : IRequest
    {
        public int ContactTypeID { get; set; }
    }
}