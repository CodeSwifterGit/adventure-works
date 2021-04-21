using System;
using AutoMapper;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using System.Collections.Generic;
using AdventureWorks.Common.Extensions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContacts;
namespace AdventureWorks.Application.DataEngine.Sales.Individual.Queries.GetIndividuals
{
    public partial class IndividualLookupModel : IHaveCustomMapping
    {
        public int CustomerID { get; set; }
        public int ContactID { get; set; }
        public string Demographics { get; set; }
        public DateTime ModifiedDate { get; set; }

        #region Navigation Properties

        // Uncomment the following line if you need child navigation properties (can cause a poor performance)
        /*  */
        // Uncomment the following line if you need parent navigation properties
        /*  */
        #endregion

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Domain.Entities.Sales.Individual, IndividualLookupModel>().IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<IndividualLookupModel, BaseIndividual>().IgnoreMissingDestinationMembers();
        }
    }
}
