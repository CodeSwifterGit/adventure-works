using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.CountryRegion.Commands.DeleteCountryRegion
{
    public partial class DeleteCountryRegionCommand : IRequest
    {
        public string CountryRegionCode { get; set; }
    }
}