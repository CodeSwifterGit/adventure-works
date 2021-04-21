using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.Address.Commands.DeleteAddress
{
    public partial class DeleteAddressCommand : IRequest
    {
        public int AddressID { get; set; }
    }
}