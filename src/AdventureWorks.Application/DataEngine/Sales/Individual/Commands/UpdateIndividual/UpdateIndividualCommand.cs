using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.Individual.Queries.GetIndividuals;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.Individual.Commands.UpdateIndividual
{
    public partial class UpdateIndividualCommand : IRequest<IndividualLookupModel>, IHaveCustomMapping
    {
        public int CustomerID { get; set; }
        public int ContactID { get; set; }
        public string Demographics { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateIndividualRequestTarget RequestTarget { get; set; }

        public UpdateIndividualCommand()
        {
        }

        public UpdateIndividualCommand(int customerID, BaseIndividual model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateIndividualRequestTarget(customerID);
        }

        public UpdateIndividualCommand(int customerID)
        {
            CustomerID = customerID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseIndividual, UpdateIndividualCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateIndividualCommand, Entities.Individual>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.Individual, Entities.Individual>(MemberList.None);
        }

        public partial class UpdateIndividualRequestTarget
        {
            public int CustomerID { get; set; }

            public UpdateIndividualRequestTarget()
            {
            }

            public UpdateIndividualRequestTarget(int customerID)
            {
                CustomerID = customerID;
            }
        }
    }
}