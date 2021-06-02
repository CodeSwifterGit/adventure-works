using System;
using AutoMapper;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using System.Collections.Generic;
using AdventureWorks.Common.Extensions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;


namespace AdventureWorks.Application.DataEngine.Sales.Store.Queries.GetStores
{
    public partial class StoreLookupModel : IHaveCustomMapping
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public int? SalesPersonID { get; set; }
        public string Demographics { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        #region Navigation Properties

        // Uncomment the following line if you need child navigation properties (can cause a poor performance)
        /*  */
        // Uncomment the following line if you need parent navigation properties
        /*  */
        #endregion

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Domain.Entities.Sales.Store, StoreLookupModel>().IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<StoreLookupModel, BaseStore>().IgnoreMissingDestinationMembers();
        }
    }
}
