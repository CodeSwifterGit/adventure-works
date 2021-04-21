using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Person.CountryRegion.Commands.DeleteCountryRegion
{
    public partial class DeleteCountryRegionSetCommand : IRequest
    {
        public List<DeleteCountryRegionCommand> Commands { get; set; }
    }
}