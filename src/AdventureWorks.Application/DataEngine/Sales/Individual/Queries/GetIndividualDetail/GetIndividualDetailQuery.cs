using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.Individual.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.Individual.Queries.GetIndividuals;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.Individual.Queries.GetIndividualDetail
{
    public partial class GetIndividualDetailQuery : IRequest<IndividualLookupModel>
    {
        public int CustomerID { get; set; }
    }
}
