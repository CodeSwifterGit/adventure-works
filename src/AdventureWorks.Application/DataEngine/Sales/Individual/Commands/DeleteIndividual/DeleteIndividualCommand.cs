using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.Individual.Commands.DeleteIndividual
{
    public partial class DeleteIndividualCommand : IRequest
    {
        public int CustomerID { get; set; }
    }
}