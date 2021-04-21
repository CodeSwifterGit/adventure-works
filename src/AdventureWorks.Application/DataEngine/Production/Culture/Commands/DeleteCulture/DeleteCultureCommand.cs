using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Culture.Commands.DeleteCulture
{
    public partial class DeleteCultureCommand : IRequest
    {
        public string CultureID { get; set; }
    }
}