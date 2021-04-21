using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.Individual.Commands.DeleteIndividual
{
    public partial class DeleteIndividualSetCommand : IRequest
    {
        public List<DeleteIndividualCommand> Commands { get; set; }
    }
}