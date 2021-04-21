using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.Individual.Queries.GetIndividuals;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.Individual.Commands.UpdateIndividual
{
    public partial class UpdateIndividualSetCommand : IRequest<List<IndividualLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateIndividualCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseIndividual>, List<UpdateIndividualCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateIndividualCommand>, List<Entities.Individual>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.Individual>, List<Entities.Individual>>(MemberList.None);
        }
    }
}