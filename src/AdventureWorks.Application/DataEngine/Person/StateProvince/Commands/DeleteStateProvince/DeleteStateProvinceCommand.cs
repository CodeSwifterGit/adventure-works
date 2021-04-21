using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Commands.DeleteStateProvince
{
    public partial class DeleteStateProvinceCommand : IRequest
    {
        public int StateProvinceID { get; set; }
    }
}